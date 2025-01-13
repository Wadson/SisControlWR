using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaVendas
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

            // Configurar colunas do DataGridView
            dataGridViewItensVenda.Columns.Add("Produto", "Produto");
            dataGridViewItensVenda.Columns.Add("Quantidade", "Quantidade");
            dataGridViewItensVenda.Columns.Add("PrecoUnitario", "Preço Unitário");
            dataGridViewItensVenda.Columns.Add("Total", "Total");
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
                        var parcelas = Parcela.GerarParcelas(decimal.Parse(textBoxTotal.Text.Substring(3)), 12);
                        foreach (var parcela in parcelas)
                        {
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


