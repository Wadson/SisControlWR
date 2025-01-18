using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using SisControl;
using System.IO;


namespace SisControl.View
{
    public partial class FrmVendas : SisControl.FrmBaseGeral
    {
        private string QueryVendas = "SELECT MAX(VendaID) FROM Venda";
        private string QueryItensVenda = "SELECT MAX(ItemVendaID) FROM ItemVenda";
        private string QueryParcela = "SELECT MAX(ParcelaID) FROM Parcela";
        private string QueryContaReceber = "SELECT MAX(ContaReceberID) FROM ContaReceber";

        private Guid VendaID;        
        private Guid ItemVendaID;
        private Guid ContaReceberID;
        private Guid ParcelaID;
        private Guid ProdutoID;
        private string connectionString; //implementado 10/01/2025 
                
        private decimal valorTotal;
        private int numeroParcelas = 1;

        
        public FrmVendas()
        {
            InitializeComponent();
           
            InicializarDataGridViewItensVenda();
            PersonalizarDataGridViewParcela(dgvParcelas);
        }
        private void InicializarDataGridViewItensVenda()
        {
            DataTable dt = new DataTable();

            // Definir colunas no DataTable apenas uma vez            
            dt.Columns.Add("ProdutoID", typeof(int));
            dt.Columns.Add("Quantidade", typeof(int));
            dt.Columns.Add("ValorProduto", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));

            dgvItensVenda.DataSource = dt;

            // Alinhar e renomear colunas no DataGridView            
            dgvItensVenda.Columns["ProdutoID"].HeaderText = "ID do Produto";
            dgvItensVenda.Columns["Quantidade"].HeaderText = "Quantidade";
            dgvItensVenda.Columns["ValorProduto"].HeaderText = "Valor do Produto";            
            dgvItensVenda.Columns["SubTotal"].HeaderText = "Subtotal";
            
            dgvItensVenda.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvItensVenda.Columns["ValorProduto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvItensVenda.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvItensVenda.Columns["ProdutoID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InicializarDataGridViewItensVenda();
        }

        public void PersonalizarDataGridViewParcela(DataGridView dgv)
        {
            // Configuração dos cabeçalhos das colunas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false; // Necessário para aplicar as cores personalizadas no cabeçalho

            // Estilo alternado das linhas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Alinhamento e fonte das células
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = new Font("Arial", 10);

            // Ajustar colunas automaticamente
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tornar o grid somente leitura
            dgv.ReadOnly = true;

            // Estilo das bordas das células
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Estilo da seleção das células
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Esconder a coluna de cabeçalho de linha
            dgv.RowHeadersVisible = false;

            // Cor do grid
            dgv.GridColor = Color.Black;

            // Definir as colunas manualmente
            if (dgv.Columns.Count == 0)
            {                
                dgv.Columns.Add("ValorParcela", "Preço Unit.");
                dgv.Columns.Add("NumeroParcela", "Nº Parc");
                dgv.Columns.Add("DataVencimento", "Vencimento");
                                
                dgv.Columns["ValorParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["NumeroParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["DataVencimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                
            }           
        }

        private void IncluirItens()
        {
            try
            {
                int _ProdutoID = int.Parse(txtProdutoID.Text);
                int Quantidade = int.Parse(txtQuantidade.Text);
                decimal ValorProduto = decimal.Parse(txtValorProduto.Text);
                decimal SubTotal = decimal.Parse(txtSubTotal.Text);

                // Obter a fonte de dados do DataGridView
                DataTable dt = dgvItensVenda.DataSource as DataTable;

                // Remover a linha dt.Rows.Clear();

                // Adicionar linhas ao DataTable
                for (var i = 0; i < numeroParcelas; i++)
                {
                    dt.Rows.Add(_ProdutoID, Quantidade, ValorProduto, SubTotal);
                    SomarSubtotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir os dados no datagridview: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        private void IncluirItensNaGrid()
        {
            try
            {
                // Inicializa as colunas do DataGridView se ainda não estiverem definidas
                //PersonalizarDataGridView(dgvItensVenda);

                // Verificações iniciais
                if (string.IsNullOrWhiteSpace(txtVendaID.Text))
                {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
                {
                    MessageBox.Show("Por favor, informe o nome do cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtValorProduto.Text))
                {
                    MessageBox.Show("Por favor, informe o valor do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = dgvItensVenda.DataSource as DataTable ?? new DataTable();

                // Verifica se as colunas já foram adicionadas ao DataTable
                if (dt.Columns.Count == 0)
                {
                    dt.Columns.Add("ProdutoID");
                    dt.Columns.Add("Quantidade");
                    dt.Columns.Add("ValorProduto");
                    dt.Columns.Add("SubTotal");
                }

                // Criação e adição da linha
                DataRow row = dt.NewRow();
                row["ProdutoID"] = txtProdutoID.Text;
                row["Quantidade"] = txtQuantidade.Text;
                row["ValorProduto"] = txtValorProduto.Text;
                row["SubTotal"] = txtSubTotal.Text;

                dt.Rows.Add(row);

                // Atualiza o DataGridView
                dgvItensVenda.DataSource = dt;

                // Atualização dos valores
                if (decimal.TryParse(txtValorProduto.Text, out decimal valorProduto))
                {
                    valorTotal = valorProduto;
                }
                // Limpeza dos campos
                txtNomeProduto.Clear();
                txtProdutoID.Clear();
                txtQuantidade.Clear();
                txtValorProduto.Clear();
                txtValorTotal.Clear();
                btnLocalizarProduto.Focus();
                txtSubTotal.Clear();
                txtSubTotal.Text = "0,00";

                // Soma dos valores na Grid
                SomarSubtotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SomarSubtotal()
        {
            decimal somaSubtotal = 0;

            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                // Verifica se a célula não é nula e converte o valor para decimal
                if (row.Cells["Subtotal"].Value != null && decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal valor))
                {
                    somaSubtotal += valor;
                }
            }
            // Exibe o resultado em um TextBox ou Label
            txtValorTotal.Text = somaSubtotal.ToString("N2"); // ou lblSomaSubtotal.Text
        }

        private void NovoCodigo()
        {
            // Gera novos GUIDs para as chaves primárias
            VendaID = Guid.NewGuid();
            ItemVendaID = Guid.NewGuid();
            ContaReceberID = Guid.NewGuid();
            ParcelaID = Guid.NewGuid();
            
            txtVendaID.Text = VendaID.ToString();
            txtQuantidade.Leave += txtQuantidade_Leave;
            txtValorProduto.Leave += txtValorProduto_Leave;
        }           

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            NovoCodigo();            
        }
        public void ToMoney(TextBox text, string format = "N")
        {
            if (decimal.TryParse(text.Text, out decimal value))
            {
                text.Text = value.ToString(format);
            }
            else
            {
                text.Text = "0,00";
            }
        }
        private void TirarZeroEsquerda(System.Windows.Forms.TextBox tx)
        {
            string valor = tx.Text;
            string NovoValorSemZero = valor.TrimStart('0');
            tx.Text = NovoValorSemZero;
        }

        private void LocalizarProduto()
        {
            // Cria uma instância do FrmLocalizarProduto e define o Owner como o FrmVendas
            FrmLocalizarProduto frmLocalizarProduto = new FrmLocalizarProduto
            {
                Owner = this
            };
            frmLocalizarProduto.ShowDialog();
            frmLocalizarProduto.Text = "Localizar Produtos";

            ToMoney(txtValorProduto);
            ToMoney(txtValorTotal);
            txtQuantidade.Focus();
            //CalculaPrecoTotal();
        }
        private void btnLocalizarProduto_Click(object sender, EventArgs e)
        {
            LocalizarProduto();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            GravarVenda();
        }
        public void ReceberDadosParcelas(DataTable dt)
        {
            dgvParcelas.Rows.Clear(); // Limpa as linhas existentes no DataGridView

            foreach (DataRow row in dt.Rows)
            {
                // Converte o valor de "DataVencimento" para apenas a data
                DateTime dataVencimento = Convert.ToDateTime(row["DataVencimento"]).Date;

                dgvParcelas.Rows.Add(
                    row["ValorParcela"],
                    row["NumeroParcela"],
                    dataVencimento
                );
            }

            // Configura o formato da célula para mostrar apenas a data
            foreach (DataGridViewRow dgvRow in dgvParcelas.Rows)
            {
                dgvRow.Cells["DataVencimento"].Value = Convert.ToDateTime(dgvRow.Cells["DataVencimento"].Value).ToString("dd/MM/yyyy");
            }
        }
        
        public void GravarVenda()
        {
            Log("Iniciando gravação da venda...");
            try
            {
                using (var connection = Conexao.Conex())
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                           // Inserir dados na tabela Venda
VendaModel venda = new VendaModel
{
    // Gera um novo identificador único para VendaID
    VendaID = Guid.NewGuid(),

    // Converte o texto do campo txtClienteID para um inteiro e atribui a ClienteID
    ClienteID = int.Parse(txtClienteID.Text),

    // Define a data e hora atuais como DataVenda
    DataVenda = DateTime.Now,

    // Converte o texto do campo txtValorTotal para decimal e atribui a ValorTotal
    ValorTotal = decimal.Parse(txtValorTotal.Text)
};

// String de consulta para inserir dados na tabela Venda
string vendaQuery = @"INSERT INTO Venda (VendaID, DataVenda, ClienteID, ValorTotal) VALUES (@VendaID, @DataVenda, @ClienteID, @ValorTotal)";

// Cria um novo comando SqlCommand para executar a consulta de inserção
using (SqlCommand vendaCommand = new SqlCommand(vendaQuery, connection, transaction))
{
    // Adiciona os parâmetros ao comando com os valores da instância de VendaModel
    vendaCommand.Parameters.AddWithValue("@VendaID", venda.VendaID);
    vendaCommand.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
    vendaCommand.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
    vendaCommand.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);

    // Executa o comando de inserção
    vendaCommand.ExecuteNonQuery();
}


                            // Cria uma lista para armazenar os itens de venda
List<ItemVendaModel> itens = new List<ItemVendaModel>();

// Itera sobre todas as linhas do DataGridView 'dgvItensVenda'
foreach (DataGridViewRow row in dgvItensVenda.Rows)
{
    // Verifica se as células 'ProdutoID', 'Quantidade' e 'ValorProduto' não são nulas
    if (row.Cells["ProdutoID"].Value != null &&
        row.Cells["Quantidade"].Value != null &&
        row.Cells["ValorProduto"].Value != null)
    {
        // Cria uma nova instância de ItemVendaModel e preenche suas propriedades
        var itemVenda = new ItemVendaModel
        {
            // Gera um novo identificador único para ItemVendaID
            ItemVendaID = Guid.NewGuid(),

            // Atribui o ID da venda atual
            VendaID = venda.VendaID,

            // Converte o valor da célula 'ProdutoID' para inteiro e atribui a ProdutoID
            ProdutoID = int.Parse(row.Cells["ProdutoID"].Value.ToString()),

            // Converte o valor da célula 'Quantidade' para inteiro e atribui a Quantidade
            Quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString()),

            // Converte o valor da célula 'ValorProduto' para decimal e atribui a PrecoUnitario
            PrecoUnitario = decimal.Parse(row.Cells["ValorProduto"].Value.ToString())
        };

        // Adiciona o itemVenda à lista de itens
        itens.Add(itemVenda);
    }
}

// String de consulta para inserir dados na tabela ItemVenda
string itemVendaQuery = @"INSERT INTO ItemVenda (ItemVendaID, VendaID, ProdutoID, Quantidade, PrecoUnitario) VALUES (@ItemVendaID, @VendaID, @ProdutoID, @Quantidade, @PrecoUnitario)";

// Itera sobre cada item na lista de itens
foreach (var item in itens)
{
    // Cria um novo comando SqlCommand para executar a consulta de inserção
    using (SqlCommand itemVendaCommand = new SqlCommand(itemVendaQuery, connection, transaction))
    {
        // Adiciona os parâmetros ao comando com os valores do itemVenda
        itemVendaCommand.Parameters.AddWithValue("@ItemVendaID", item.ItemVendaID);
        itemVendaCommand.Parameters.AddWithValue("@VendaID", item.VendaID);
        itemVendaCommand.Parameters.AddWithValue("@ProdutoID", item.ProdutoID);
        itemVendaCommand.Parameters.AddWithValue("@Quantidade", item.Quantidade);
        itemVendaCommand.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);

        // Executa o comando de inserção
        itemVendaCommand.ExecuteNonQuery();
    }
}

                            // Inserir dados na tabela Parcela
                            List<ParcelaModel> parcelas = new List<ParcelaModel>();
                            foreach (DataGridViewRow row in dgvParcelas.Rows)
                            {
                                if (row.Cells["DataVencimento"].Value != null &&
                                    row.Cells["ValorParcela"].Value != null &&
                                    row.Cells["NumeroParcela"].Value != null)
                                {
                                    var parcela = new ParcelaModel
                                    {
                                        ParcelaID = Guid.NewGuid(),
                                        VendaID = venda.VendaID,
                                        NumeroParcela = int.Parse(row.Cells["NumeroParcela"].Value.ToString()),
                                        DataVencimento = DateTime.Parse(row.Cells["DataVencimento"].Value.ToString()),
                                        ValorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString()),
                                        ValorRecebido = 0,
                                        SaldoRestante = decimal.Parse(row.Cells["ValorParcela"].Value.ToString()),
                                        Pago = false
                                    };
                                    parcelas.Add(parcela);
                                }
                            }

                            string parcelaQuery = @"INSERT INTO Parcela (ParcelaID, VendaID, NumeroParcela, DataVencimento, ValorParcela, ValorRecebido, SaldoRestante, Pago) 
                                   VALUES (@ParcelaID, @VendaID, @NumeroParcela, @DataVencimento, @ValorParcela, @ValorRecebido, @SaldoRestante, @Pago)";
                            foreach (var parcela in parcelas)
                            {
                                using (SqlCommand parcelaCommand = new SqlCommand(parcelaQuery, connection, transaction))
                                {
                                    parcelaCommand.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);
                                    parcelaCommand.Parameters.AddWithValue("@VendaID", parcela.VendaID);
                                    parcelaCommand.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                                    parcelaCommand.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                                    parcelaCommand.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
                                    parcelaCommand.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);
                                    parcelaCommand.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
                                    parcelaCommand.Parameters.AddWithValue("@Pago", parcela.Pago);
                                    parcelaCommand.ExecuteNonQuery();
                                }
                            }

                            // Commit da transação
                            transaction.Commit();
                            Log("Venda finalizada com sucesso.");//Gerar arquivo de log para registrar as operações realizadas
                            MessageBox.Show("Venda finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Utilitario.LimpaCampo(this);
                            NovoCodigo();
                        }
                        catch (Exception ex)
                        {
                            // Rollback da transação em caso de erro
                            Log($"Erro ao finalizar a venda: {ex.Message}");
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao finalizar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Erro ao conectar ao banco de dados: {ex.Message}");                
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private List<ContaReceberModel> ObterContasReceber(List<ParcelaModel> parcelas)
        {
            List<ContaReceberModel> contasReceber = new List<ContaReceberModel>();

            // Adiciona contas a receber com base nos dados do DataGridView
            foreach (DataGridViewRow row in dgvParcelas.Rows)
            {
                if (VendaID != null && ParcelaID != null)
                {
                    var valorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
                    var valorRecebido = 0; // Inicialmente, valor recebido é zero.

                    DateTime? dataRecebimento = null; // DataRecebimento permanece nula

                    var contaReceber = new ContaReceberModel
                    {
                        ContaReceberID = Guid.NewGuid(), // Gerar um novo GUID para ContaReceberID
                        VendaID = VendaID, // Converter VendaID para GUID
                        ParcelaID = ParcelaID, // Converter ParcelaID para GUID
                        DataRecebimento = dataRecebimento,
                        ValorRecebido = valorRecebido,
                        SaldoRestante = valorParcela - valorRecebido, // Cálculo do Saldo Restante
                        Pago = false
                    };
                    contasReceber.Add(contaReceber);
                }
            }

            return contasReceber;
        }


        private void btnParcelar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGerarParcelas gerarparc = new FrmGerarParcelas();
                                
                if (dgvItensVenda.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum item de venda encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                gerarparc.txtIdVenda.Text = txtVendaID.Text;
                gerarparc.txtTotal.Text = txtValorTotal.Text; // dgvItensVenda.CurrentRow.Cells[4].Value.ToString();
                gerarparc.txtNomeCliente.Text = txtNomeCliente.Text;
                gerarparc.txtQtdParcelas.Text = txtNumeroParcelas.Text;

                // Passa o parcelaID como Guid para o formulário de gerar parcelas
                gerarparc.parcelaID = ParcelaID;

                gerarparc.ShowDialog();
                gerarparc.Text = "Gerar Parcelas para o Cliente:" + txtNomeCliente.Text;
                btnParcelar.Enabled = false;
                rbUmaParcela.Checked = true;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Erro no formato dos dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AbrirFrmLocalizarCliente()
        {
            FrmLocalizarCliente frmLocalizarCliente = new FrmLocalizarCliente();
            frmLocalizarCliente.FormChamador = this; // Define o formulário chamador
            frmLocalizarCliente.ShowDialog();
        }

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarCliente();
            ToMoney(txtValorProduto);
            ToMoney(txtValorTotal);
            txtQuantidade.Focus();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se todos os valores necessários estão preenchidos
                if (VendaID == Guid.Empty)
                {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               if (VendaID == Guid.Empty)
               {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ItemVendaID == Guid.Empty)
                {
                    MessageBox.Show("Por favor, informe o ID dos itens da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
                {
                    MessageBox.Show("Por favor, informe a quantidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica se a quantidade é um número válido
                if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
                {
                    MessageBox.Show("Por favor, informe uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chama o método para incluir os itens na grid
                
                IncluirItens();
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CalcularSubtotal()
        {
            if (decimal.TryParse(txtQuantidade.Text, out decimal quantidade) &&
                decimal.TryParse(txtValorProduto.Text, out decimal precoUnitario) &&
                decimal.TryParse(txtValorRecebido.Text, out decimal valorpago))
            {
                decimal subtotal = quantidade * precoUnitario - valorpago;
                txtSubTotal.Text = subtotal.ToString("N2");
            }
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtValorProduto_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void rbUmaParcela_CheckedChanged(object sender, EventArgs e)
        {
            txtNumeroParcelas.Text = "1";
            btnParcelar.Enabled = false;
        }

        private void rbParcelar_CheckedChanged(object sender, EventArgs e)
        {
            txtNumeroParcelas.Text = "2";
            btnParcelar.Enabled = true;
        }

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void Log(string message)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n");
        }
        // Exemplo de uso do método Log
        private void ProcessarVenda()
        {
            try
            {
                // Código de processamento...
            }
            catch (Exception ex)
            {
                Log(ex.Message);
                MessageBox.Show("Ocorreu um erro ao processar a venda.");
            }
        }
        // Exemplo de uso do método LerLog
        private void LerLog()
        {
            if (File.Exists("log.txt"))
            {
                string[] linhasDoLog = File.ReadAllLines("log.txt");
                foreach (string linha in linhasDoLog)
                {
                    Console.WriteLine(linha);
                }
            }
        }
        

    }
}
