/*
Passo 1: Criação do Projeto
Abra o Visual Studio e crie um novo projeto de Windows Forms Application.
Nomeie seu projeto e clique em "OK".

Passo 2: Design da Interface
Na interface designer do Form1, adicione os seguintes controles a partir da Caixa de Ferramentas:
Labels: Para indicar os campos (Ex: Cliente, Produto, Quantidade, Preço, DataVenda, Parcelas, Total).
TextBoxes: Para entrada de dados (Cliente, Quantidade, Preço, DataVenda, Total).

DateTimePicker: Para selecionar a data da venda.
ComboBox: Para selecionar o produto.
Button: Para adicionar o item à venda e calcular o total.
DataGridView: Para mostrar os itens adicionados à venda.
Button: Para concluir a venda.
Organize esses controles no form conforme necessário.
Passo 3: Código C#
*/



using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace VendaApp
{
    public partial class Form1 : Form
    {
        List<ItemVenda> itensVenda = new List<ItemVenda>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar produtos no ComboBox
            comboBoxProdutos.Items.Add("Produto A");
            comboBoxProdutos.Items.Add("Produto B");
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            string produto = comboBoxProdutos.SelectedItem.ToString();
            int quantidade = int.Parse(textBoxQuantidade.Text);
            decimal preco = decimal.Parse(textBoxPreco.Text);

            var item = new ItemVenda { Produto = produto, Quantidade = quantidade, PrecoUnitario = preco };
            itensVenda.Add(item);

            AtualizarGrid();
            CalcularTotal();
        }

        private void AtualizarGrid()
        {
            dataGridViewItensVenda.Rows.Clear();

            foreach (var item in itensVenda)
            {
                dataGridViewItensVenda.Rows.Add(item.Produto, item.Quantidade, item.PrecoUnitario, item.Quantidade * item.PrecoUnitario);
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in itensVenda)
            {
                total += item.Quantidade * item.PrecoUnitario;
            }
            textBoxTotal.Text = total.ToString("C2");
        }

        private void buttonConcluirVenda_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection("sua-string-de-conexao"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Adiciona Venda
                        string vendaQuery = "INSERT INTO Vendas (Id, DataVenda, ClienteId, ValorTotal) VALUES (@Id, @DataVenda, @ClienteId, @ValorTotal)";
                        using (var cmd = new SqlCommand(vendaQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", 1); // Pode gerar o Id dinamicamente conforme necessário
                            cmd.Parameters.AddWithValue("@DataVenda", dateTimePickerDataVenda.Value);
                            cmd.Parameters.AddWithValue("@ClienteId", int.Parse(textBoxCliente.Text));
                            cmd.Parameters.AddWithValue("@ValorTotal", decimal.Parse(textBoxTotal.Text.Substring(3)));
                            cmd.ExecuteNonQuery();
                        }

                        // Adiciona ItensVenda
                        string itemVendaQuery = "INSERT INTO ItemVenda (Id, VendaId, ProdutoId, Quantidade, ValorUnitario) VALUES (@Id, @VendaId, @ProdutoId, @Quantidade, @ValorUnitario)";
                        foreach (var item in itensVenda)
                        {
                            using (var cmd = new SqlCommand(itemVendaQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Id", item.Id); // Pode gerar o Id dinamicamente conforme necessário
                                cmd.Parameters.AddWithValue("@VendaId", 1); // Id da Venda correspondente
                                cmd.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
                                cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                                cmd.Parameters.AddWithValue("@ValorUnitario", item.PrecoUnitario);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Adiciona Parcelas
                        string parcelaQuery = "INSERT INTO Parcelas (Id, VendaId, Valor, DataVencimento) VALUES (@Id, @VendaId, @Valor, @DataVencimento)";
                        for (int i = 0; i < parcelas.Count; i++)
                        {
                            var parcela = parcelas[i];
                            using (var cmd = new SqlCommand(parcelaQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Id", parcela.Id);
                                cmd.Parameters.AddWithValue("@VendaId", 1); // Id da Venda correspondente
                                cmd.Parameters.AddWithValue("@Valor", parcela.Valor);
                                cmd.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Adiciona ContaReceber
                        string contaReceberQuery = "INSERT INTO ContaReceber (Id, VendaId, ValorRecebido, DataRecebimento) VALUES (@Id, @VendaId, @ValorRecebido, @DataRecebimento)";
                        using (var cmd = new SqlCommand(contaReceberQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", 1); // Pode gerar o Id dinamicamente conforme necessário
                            cmd.Parameters.AddWithValue("@VendaId", 1); // Id da Venda correspondente
                            cmd.Parameters.AddWithValue("@ValorRecebido", 0);
                            cmd.Parameters.AddWithValue("@DataRecebimento", DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }

                        // Commit da transação
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Em caso de erro, rollback na transação
                        transaction.Rollback();
                        MessageBox.Show($"Erro: {ex.Message}");
                    }
                }
                MessageBox.Show("Venda concluída com sucesso!");
            }
        }
    }

    public class ItemVenda
    {
        public int Id { get; set; } // Pode gerar o Id dinamicamente conforme necessário
        public string Produto { get; set; }
        public int ProdutoId { get; set; } // Id do produto para usar na tabela ItemVenda
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }

    public class Parcela
    {
        public int Id { get; set; } // Pode gerar o Id dinamicamente conforme necessário
        public int VendaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }

        // Lista de parcelas fictícias para o exemplo
        public static List<Parcela> GerarParcelas(decimal valorTotal, int quantidadeParcelas)
        {
            var parcelas = new List<Parcela>();
            decimal valorParcela = valorTotal / quantidadeParcelas;
            for (int i = 1; i <= quantidadeParcelas; i++)
            {
                parcelas.Add(new Parcela
                {
                    Id = i,
                    VendaId = 1, // Id da Venda correspondente
                    Valor = valorParcela,
                    DataVencimento = DateTime.Now.AddMonths(i)
                });
            }
            return parcelas;
        }
    }
}

/*
Explicação do Código
Form1_Load: Carrega os produtos no ComboBox.
buttonAddItem_Click: Adiciona um item à lista de itens vendidos e atualiza o DataGridView.

AtualizarGrid: Atualiza os itens no DataGridView.
CalcularTotal: Calcula o valor total da venda.

buttonConcluirVenda_Click: Insere os dados nas tabelas Venda, ItemVenda, Parcela e ContaReceber no banco de dados e faz a commit.

Adaptações
Atualize a string de conexão com a correta para o seu banco de dados.
Crie ou ajuste os métodos para gerar dinamicamente os IDs das entidades.
Com este esqueleto, você tem uma base funcional para uma tela de vendas. Agora, você pode expandir e adaptar para incluir funcionalidades como validações, gerar IDs dinâmicos, e muito mais.

Se precisar de mais ajuda ou quiser algum ajuste específico, estou por aqui! 🚀




Mensagem para o Copilot
*/