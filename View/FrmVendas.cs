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


namespace SisControl.View
{
    public partial class FrmVendas : SisControl.FrmBaseGeral
    {
        private string QueryVendas = "SELECT MAX(VendaID) FROM Venda";
        private string QueryItensVenda = "SELECT MAX(ItemVendaID) FROM ItemVenda";
        private string QueryParcela = "SELECT MAX(ParcelaID) FROM Parcela";
        private string QueryContaReceber = "SELECT MAX(ContaReceberID) FROM ContaReceber";

        private Guid VendaID;        
        private Guid ItensVendaID;
        private Guid ContaReceberID;
        private Guid ParcelaID;
        private Guid ProdutoID;
        private string connectionString; //implementado 10/01/2025 
                
        private decimal valorTotal;
        private int numeroParcelas = 1;

        
        public FrmVendas()
        {
            InitializeComponent();
            //Implementado dia 10/01/2025
            //connectionString = ConfigurationManager.ConnectionStrings["Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;"].ConnectionString;
            //connectionString = ConfigurationManager.ConnectionStrings["SisControl.Properties.Settings.bdsiscontrolConnectionString"].ConnectionString;
            PersonalizarDataGridView(dgvItensVenda);
            PersonalizarDataGridViewParc(dgvParcelas);
        }
        public void PersonalizarDataGridView(DataGridView dgv)
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
                dgv.Columns.Add("ItensVendaID", "ItensVendaID");
                dgv.Columns.Add("VendaID", "VendaID");
                dgv.Columns.Add("ProdutoID", "ProdutoID");
                dgv.Columns.Add("Quantidade", "Quantidade");
                dgv.Columns.Add("PrecoUnitario", "Valor do Produto");
                dgv.Columns.Add("SubTotal", "SubTotal");

                dgv.Columns["ItensVendaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["VendaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["ProdutoID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["PrecoUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ocultar coluna específica se necessário
            if (dgv.Columns.Contains("ItensVendaID"))
            {
                dgv.Columns["ItensVendaID"].Visible = false; // Oculta a coluna "ID"
            }
        }



        public void PersonalizarDataGridViewParc(DataGridView dgv)
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
                dgv.Columns.Add("ParcelaID", "Parcela ID");
                dgv.Columns.Add("ValorParcela", "Valor da Parcela");
                dgv.Columns.Add("NumeroParcela", "Número da Parcela");
                dgv.Columns.Add("DataVencimento", "Data de Vencimento");
                dgv.Columns.Add("VendaID", "Venda ID");

                dgv.Columns["ParcelaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["ValorParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["NumeroParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["DataVencimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["VendaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Ocultar coluna específica se necessário
            if (dgv.Columns.Contains("ParcelaID"))
            {
                dgv.Columns["ParcelaID"].Visible = false; // Oculta a coluna "ParcelaID"
            }
            if (dgv.Columns.Contains("VendaID"))
            {
                dgv.Columns["VendaID"].Visible = false; // Oculta a coluna "VendaID"
            }
        }


        private void IncluirItensNaGrid()
        {
            try
            {
                // Inicializa as colunas do DataGridView se ainda não estiverem definidas
                PersonalizarDataGridView(dgvItensVenda);

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

                // Obter e converter valores
                if (!Guid.TryParse(txtProdutoID.Text, out ProdutoID))
                {
                    MessageBox.Show("ID do produto inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Guid.TryParse(txtVendaID.Text, out VendaID))
                {
                    MessageBox.Show("ID da venda inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = dgvItensVenda.DataSource as DataTable ?? new DataTable();
                
                Guid zeroColumn = ItensVendaID;
                Guid primeiraColumn = Utilitario.AcrescentarZerosEsquerda(VendaID, 6);
                Guid segundaColumn = Utilitario.AcrescentarZerosEsquerda(ProdutoID, 6);
                string terceiraColumn = txtQuantidade.Text;
                string quartaColumn = txtValorProduto.Text;
                string quintaColumn = txtSubTotal.Text;
                //string decimaPriColumn = Utilitario.AcrescentarZerosEsquerda(ContaReceberID, 6);

                // Criação e adição da linha
                string[] row = {
            zeroColumn.ToString(),
            primeiraColumn,
            segundaColumn,
            terceiraColumn,
            quartaColumn,
            quintaColumn
        };
                dgvItensVenda.Rows.Add(row);

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
                txtNomeCliente.Focus();
                txtSubTotal.Clear();

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
        {//Traz o último código cadastrado + 1, para novo cadastro
            VendaID = Guid.NewGuid();
            ItensVendaID = Guid.NewGuid();
            ContaReceberID = Guid.NewGuid();
            ParcelaID = Guid.NewGuid();

            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(VendaID, 6);
            txtVendaID.Text = numeroComZeros;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            NovoCodigo();
            txtQuantidade.Leave += txtQuantidade_Leave;
            txtValorProduto.Leave += txtValorProduto_Leave;
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

        private void btnLocalizarProduto_Click(object sender, EventArgs e)
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            SalvarVenda2();
        }
        public void ReceberDadosParcelas(DataTable dt)
        {
            dgvParcelas.Rows.Clear(); // Limpa as linhas existentes no DataGridView

            foreach (DataRow row in dt.Rows)
            {
                dgvParcelas.Rows.Add(
                    row["ParcelaID"],
                    row["ValorParcela"],
                    row["NumeroParcela"],
                    row["DataVencimento"],                    
                    row["VendaID"]
                );
            }
        }

        public void SalvarVenda2()
        {
            try
            {
                using (var connection = Conexao.Conex())//using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Inserir dados na tabela Venda
                            VendaModel venda = new VendaModel
                            {
                                VendaID = Guid.NewGuid(),
                                ClienteID = int.Parse(txtClienteID.Text),
                                DataVenda = DateTime.Now,
                                ValorTotal = decimal.Parse(txtValorTotal.Text)
                            };

                            string vendaQuery = @"INSERT INTO Venda (DataVenda, ClienteID, ValorTotal) 
                                          VALUES (@DataVenda, @ClienteID, @ValorTotal)";
                            using (SqlCommand vendaCommand = new SqlCommand(vendaQuery, connection, transaction))
                            {                                
                                vendaCommand.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                                vendaCommand.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                                vendaCommand.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                                vendaCommand.ExecuteNonQuery();
                            }

                            // Inserir dados na tabela ItemVenda
                            List<ItemVendaModel> itens = new List<ItemVendaModel>();
                            foreach (DataGridViewRow row in dgvItensVenda.Rows)
                            {
                                if (row.Cells["ProdutoID"].Value != null &&
                                    row.Cells["VendaID"].Value != null &&
                                    row.Cells["Quantidade"].Value != null &&
                                    row.Cells["PrecoUnitario"].Value != null &&
                                    row.Cells["ItensVendaID"].Value != null)
                                {
                                    var itemVenda = new ItemVendaModel
                                    {
                                        ItemVendaID = Guid.NewGuid(), // Gerar um novo GUID                                        
                                        VendaID = int.Parse(row.Cells["VendaID"].Value.ToString()),
                                        ProdutoID = int.Parse(row.Cells["ProdutoID"].Value.ToString()),
                                        Quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString()),
                                        PrecoUnitario = decimal.Parse(row.Cells["PrecoUnitario"].Value.ToString())
                                    };
                                    itens.Add(itemVenda);
                                }
                            }

                            string itemVendaQuery = @"INSERT INTO ItemVenda (VendaID, ProdutoID, Quantidade, PrecoUnitario) 
                                              VALUES (@ItemVendaID, @VendaID, @ProdutoID, @Quantidade, @PrecoUnitario)";
                            foreach (var item in itens)
                            {
                                using (SqlCommand itemVendaCommand = new SqlCommand(itemVendaQuery, connection, transaction))
                                {                                    
                                    itemVendaCommand.Parameters.AddWithValue("@VendaID", item.VendaID);
                                    itemVendaCommand.Parameters.AddWithValue("@ProdutoID", item.ProdutoID);
                                    itemVendaCommand.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                                    itemVendaCommand.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);
                                    itemVendaCommand.ExecuteNonQuery();
                                }
                            }

                            // Inserir dados na tabela Parcela a partir do dgvParcelas
                            List<ParcelaModel> parcelas = new List<ParcelaModel>();
                            foreach (DataGridViewRow row in dgvParcelas.Rows)
                            {
                                if (row.Cells["ParcelaID"].Value != null &&
                                    row.Cells["VendaID"].Value != null &&
                                    row.Cells["DataVencimento"].Value != null &&
                                    row.Cells["ValorParcela"].Value != null &&
                                    row.Cells["NumeroParcela"].Value != null)
                                    
                                {
                                    var parcela = new ParcelaModel
                                    {
                                        ParcelaID = Guid.NewGuid(),
                                        VendaID = int.Parse(row.Cells["VendaID"].Value.ToString()),
                                        NumeroParcela = int.Parse(row.Cells["NumeroParcela"].Value.ToString()),
                                        DataVencimento = DateTime.Parse(row.Cells["DataVencimento"].Value.ToString()),
                                        ValorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString()),
                                        ValorRecebido = decimal.Parse(txtValorRecebido.Text),
                                        SaldoRestante = decimal.Parse(txtValorRecebido.Text) - decimal.Parse(row.Cells["ValorParcela"].Value.ToString()),
                                        Pago = false                                        
                                    };
                                    parcelas.Add(parcela);
                                }
                            }

                            string parcelaQuery = @"INSERT INTO Parcela (VendaID, NumeroParcela, DataVencimento, ValorParcela, ValorRecebido, SaldoRestante, Pago) 
                                            VALUES (@VendaID, @NumeroParcela, @DataVencimento, @ValorParcela, @ValorRecebido, @SaldoRestante, @Pago)";
                            foreach (var parcela in parcelas)
                            {
                                using (SqlCommand parcelaCommand = new SqlCommand(parcelaQuery, connection, transaction))
                                {   
                                    parcelaCommand.Parameters.AddWithValue("@VendaID", parcela.VendaID);
                                    parcelaCommand.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                                    parcelaCommand.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                                    parcelaCommand.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
                                    parcelaCommand.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);
                                    parcelaCommand.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
                                    parcelaCommand.Parameters.AddWithValue("@Pago", parcela.Pago);
                                    //parcelaCommand.Parameters.AddWithValue("@FormaPagamento", parcela.FormaPagamento);
                                    parcelaCommand.ExecuteNonQuery();
                                }
                            }

                            // Inserir dados na tabela ContaReceber
                            List<ContaReceberModel> contasReceber = new List<ContaReceberModel>();
                            contasReceber = ObterContasReceber(parcelas);

                            string contaReceberQuery = @"INSERT INTO ContaReceber (VendaID, ParcelaID, DataRecebimento, ValorRecebido, SaldoRestante, Pago) 
                            VALUES (@VendaID, @ParcelaID, @DataRecebimento, @ValorRecebido, @SaldoRestante, @Pago)";
                            foreach (var conta in contasReceber)
                            {
                                using (SqlCommand contaReceberCommand = new SqlCommand(contaReceberQuery, connection, transaction))
                                {
                                    // Gerar um novo GUID para ContaReceberID
                                    Guid contaReceberID = Guid.NewGuid();
                                    contaReceberCommand.Parameters.AddWithValue("@ContaReceberID", contaReceberID);
                                    contaReceberCommand.Parameters.AddWithValue("@VendaID", conta.VendaID);
                                    contaReceberCommand.Parameters.AddWithValue("@ParcelaID", conta.ParcelaID);

                                    // Verifica se DataRecebimento é nulo e define o valor apropriado
                                    if (conta.DataRecebimento.HasValue)
                                    {
                                        contaReceberCommand.Parameters.AddWithValue("@DataRecebimento", conta.DataRecebimento.Value);
                                    }
                                    else
                                    {
                                        contaReceberCommand.Parameters.AddWithValue("@DataRecebimento", DBNull.Value);
                                    }

                                    contaReceberCommand.Parameters.AddWithValue("@ValorRecebido", conta.ValorRecebido);
                                    contaReceberCommand.Parameters.AddWithValue("@SaldoRestante", conta.SaldoRestante);
                                    contaReceberCommand.Parameters.AddWithValue("@Pago", conta.Pago);

                                    contaReceberCommand.ExecuteNonQuery();
                                }
                            }

                            // Commit da transação
                            transaction.Commit();
                            MessageBox.Show("Venda finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Utilitario.LimpaCampo(this);
                            NovoCodigo();
                        }
                        catch (Exception ex)
                        {
                            // Rollback da transação em caso de erro
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao finalizar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<ContaReceberModel> ObterContasReceber(List<ParcelaModel> parcelas)
        {
            List<ContaReceberModel> contasReceber = new List<ContaReceberModel>();

            // Adiciona contas a receber com base nos dados do DataGridView
            foreach (DataGridViewRow row in dgvParcelas.Rows)
            {
                if (row.Cells["VendaID"].Value != null && row.Cells["ParcelaID"].Value != null)
                {
                    var valorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
                    var valorRecebido = 0; // Inicialmente, valor recebido é zero.

                    DateTime? dataRecebimento = null; // DataRecebimento permanece nula

                    var contaReceber = new ContaReceberModel
                    {
                        ContaReceberID = Guid.NewGuid(), // Gerar um novo GUID para ContaReceberID
                        VendaID = int.Parse(row.Cells["VendaID"].Value.ToString()), // Converter VendaID para GUID
                        ParcelaID = Guid.Parse(row.Cells["ParcelaID"].Value.ToString()), // Converter ParcelaID para GUID
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



        //private List<ContaReceberModel> ObterContasReceber(List<ParcelaModel> parcelas)
        //{
        //    List<ContaReceberModel> contasReceber = new List<ContaReceberModel>();

        //    // Adiciona contas a receber com base nos dados do DataGridView
        //    foreach (DataGridViewRow row in dgvParcelas.Rows)
        //    {
        //        if (row.Cells["VendaID"].Value != null && row.Cells["ParcelaID"].Value != null)
        //        {
        //            var valorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
        //            var valorRecebido = 0; // Inicialmente, valor recebido é zero.

        //            var contaReceber = new ContaReceberModel
        //            {
        //                ContaReceberID = ItensVendaID++,
        //                VendaID = int.Parse(row.Cells["VendaID"].Value.ToString()),
        //                ParcelaID = int.Parse(row.Cells["ParcelaID"].Value.ToString()),
        //                //DataRecebimento = DataRecebimento,
        //                ValorRecebido = valorRecebido,
        //                SaldoRestante = valorParcela - valorRecebido, // Cálculo do Saldo Restante
        //                Pago = false
        //            };
        //            contasReceber.Add(contaReceber);
        //        }
        //    }


        //    // Adiciona contas a receber com base nos dados dos TextBox
        //    foreach (var parcela in parcelas)
        //    {
        //        var contaReceber = new ContaReceberModel
        //        {
        //            ContaReceberID = ContaReceberID,
        //            VendaID = parcela.VendaID,
        //            ParcelaID = parcela.ParcelaID,
        //            DataRecebimento = DateTime.Now, // Supondo que o DataRecebimento seja a data atual ou um valor específico vindo de outro TextBox
        //            ValorRecebido = 0, // Valor vindo do TextBox
        //            SaldoRestante = parcela.ValorParcela - decimal.Parse(txtValorRecebido.Text), // Inicialmente igual ao valor da parcela menos o valor recebido
        //            Pago = parcela.Pago
        //        };
        //        contasReceber.Add(contaReceber);
        //    }

        //    return contasReceber;
        //}

        public void SalvarVenda()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Inserir dados na tabela Venda
                            VendaModel venda = new VendaModel
                            {
                                VendaID = Guid.Parse(txtVendaID.Text),
                                ClienteID = int.Parse(txtClienteID.Text),
                                DataVenda = DateTime.Now,
                                ValorTotal = decimal.Parse(txtValorTotal.Text)
                            };


                            string vendaQuery = @"INSERT INTO Venda (VendaID, DataVenda, ClienteID, ValorTotal) 
                                  VALUES (@VendaID, @DataVenda, @ClienteID, @ValorTotal)";
                            using (SqlCommand vendaCommand = new SqlCommand(vendaQuery, connection, transaction))
                            {
                                vendaCommand.Parameters.AddWithValue("@VendaID", venda.VendaID);
                                vendaCommand.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                                vendaCommand.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                                vendaCommand.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                                vendaCommand.ExecuteNonQuery();
                            }

                            // Inserir dados na tabela ItemVenda
                            List<ItemVendaModel> itens = new List<ItemVendaModel>();
                            foreach (DataGridViewRow row in dgvItensVenda.Rows)
                            {
                                if (row.Cells["ProdutoID"].Value != null &&
                                    row.Cells["VendaID"].Value != null &&
                                    row.Cells["Quantidade"].Value != null &&
                                    row.Cells["PrecoUnitario"].Value != null &&
                                    row.Cells["ItemVendaID"].Value != null)
                                {
                                    var itemVenda = new ItemVendaModel
                                    {
                                        ItemVendaID = Guid.Parse(row.Cells["ItemVendaID"].Value.ToString()), // Converter ItemVendaID para GUID
                                        VendaID = int.Parse(row.Cells["VendaID"].Value.ToString()), // Converter VendaID para GUID
                                        ProdutoID = int.Parse(row.Cells["ProdutoID"].Value.ToString()),
                                        Quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString()),
                                        PrecoUnitario = decimal.Parse(row.Cells["PrecoUnitario"].Value.ToString())
                                    };
                                    itens.Add(itemVenda);
                                }
                            }


                            string itemVendaQuery = @"INSERT INTO ItemVenda (ItemVendaID, VendaID, ProdutoID, Quantidade, PrecoUnitario) 
                                      VALUES (@ItemVendaID, @VendaID, @ProdutoID, @Quantidade, @PrecoUnitario)";
                            foreach (var item in itens)
                            {
                                using (SqlCommand itemVendaCommand = new SqlCommand(itemVendaQuery, connection, transaction))
                                {
                                    itemVendaCommand.Parameters.AddWithValue("@ItemVendaID", item.ItemVendaID);
                                    itemVendaCommand.Parameters.AddWithValue("@VendaID", item.VendaID);
                                    itemVendaCommand.Parameters.AddWithValue("@ProdutoID", item.ProdutoID);
                                    itemVendaCommand.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                                    itemVendaCommand.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);
                                    itemVendaCommand.ExecuteNonQuery();
                                }
                            }
                            // Inserir dados na tabela Parcela a partir do dgvParcelas
                            List<ParcelaModel> parcelas = new List<ParcelaModel>();

                            foreach (DataGridViewRow row in dgvParcelas.Rows)
                            {
                                if (row.Cells["ParcelaID"].Value != null &&
                                    row.Cells["VendaID"].Value != null &&
                                    row.Cells["DataVencimento"].Value != null &&
                                    row.Cells["ValorParcela"].Value != null &&
                                    row.Cells["NumeroParcela"].Value != null)
                                {
                                    var parcela = new ParcelaModel
                                    {
                                        ParcelaID = Guid.Parse(row.Cells["ParcelaID"].Value.ToString()), // Converter ParcelaID para GUID
                                        VendaID = int.Parse(row.Cells["VendaID"].Value.ToString()), // Converter VendaID para GUID
                                        NumeroParcela = int.Parse(row.Cells["NumeroParcela"].Value.ToString()),
                                        DataVencimento = DateTime.Parse(row.Cells["DataVencimento"].Value.ToString()),
                                        ValorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString()),
                                        ValorRecebido = 0,
                                        SaldoRestante = decimal.Parse(txtValorRecebido.Text),
                                        Pago = false,
                                    };
                                    parcelas.Add(parcela);
                                }
                            }

                            string parcelaQuery = @"INSERT INTO Parcela (ParcelaID, VendaID, DataVencimento, ValorParcela, ValorRecebido, SaldoRestante, Pago) 
VALUES (@ParcelaID, @VendaID, @DataVencimento, @ValorParcela, @ValorRecebido, @SaldoRestante, @Pago)";
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










                            // Inserir dados na tabela ContaReceber
                            List<ContaReceberModel> contasReceber = new List<ContaReceberModel>();
                            contasReceber = ObterContasReceber(parcelas);

                            string contaReceberQuery = @"INSERT INTO ContaReceber (ContaReceberID, ParcelaID, DataRecebimento, ValorRecebido) 
                                         VALUES (@ContaReceberID, @ParcelaID, @DataRecebimento, @ValorRecebido)";
                            foreach (var conta in contasReceber)
                            {
                                using (SqlCommand contaReceberCommand = new SqlCommand(contaReceberQuery, connection, transaction))
                                {
                                    contaReceberCommand.Parameters.AddWithValue("@ContaReceberID", conta.ContaReceberID);
                                    contaReceberCommand.Parameters.AddWithValue("@ParcelaID", conta.ParcelaID);
                                    contaReceberCommand.Parameters.AddWithValue("@DataRecebimento", conta.DataRecebimento);
                                    contaReceberCommand.Parameters.AddWithValue("@ValorRecebido", conta.ValorRecebido);

                                    contaReceberCommand.ExecuteNonQuery();
                                }
                            }

                            // Commit da transação
                            transaction.Commit();
                            MessageBox.Show("Venda finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            // Rollback da transação em caso de erro
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao finalizar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
             
        private void btnParcelar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGerarParcelas gerarparc = new FrmGerarParcelas();

                string stringg = txtClienteID.Text;
                string resultado = stringg.TrimStart('0');

                if (!Guid.TryParse(resultado, out Guid clienteID))
                {
                    MessageBox.Show("Cliente ID inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                gerarparc.clienteID = clienteID;

                if (dgvItensVenda.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum item de venda encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                gerarparc.txtIdVenda.Text = txtVendaID.Text;
                gerarparc.txtTotal.Text = txtValorTotal.Text;//dgvItensVenda.CurrentRow.Cells[4].Value.ToString();
                gerarparc.txtNomeCliente.Text = txtNomeCliente.Text;
                gerarparc.txtQtdParcelas.Text = txtNumeroParcelas.Text;

                gerarparc.parcelaID = ParcelaID;

                gerarparc.ShowDialog();
                gerarparc.Text = "Gerar Parcelas para o Cliente:" + txtNomeCliente.Text;
                btnParcelar.Enabled = false;
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

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            using (var localizaCliente = new FrmLocalizarCliente())
            {
                localizaCliente.Text = "Localizar Clientes";
                localizaCliente.ShowDialog();
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se todos os valores necessários estão preenchidos
                if (VendaID == 0)
                {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ItensVendaID == 0)
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
                IncluirItensNaGrid();
            }
            catch (Exception ex)
            {
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
    }
}
