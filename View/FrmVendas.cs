﻿using SisControl.MODEL;
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
        private string QueryFormaPgto = "SELECT NomeFormaPgto, FormaPgtoID FROM FormaPgto";
        
        private int nextItemVendaID;

        public int ClienteID { get; set; }
        public int VendaID { get; set; }
        public int ItemVendaID { get; set; }
        public int ContaReceberID { get; set; }
        public int ParcelaID { get; set; }
        public int ProdutoID { get; set; }
        public string connectionString { get; set; }   //implementado 10/01/2025 

        public decimal valorTotal { get; set; }
        public int numeroParcelas = 1;

        
        public FrmVendas()
        {
            InitializeComponent();

            nextItemVendaID = Utilitario.GerarNovoCodigoID("ItemVendaID", "ItemVenda");

            Utilitario.ConfigurarEventosDeFoco(this);// Texbox fundo amarelo quando em foco

            // Definir os valores iniciais dos TextBox
            txtValorProduto.Text = "0,00";
            txtValorRecebido.Text = "0,00";
            txtSubTotal.Text = "0,00";
            txtQuantidade.Text = "1";

            InicializarDataGridViewItensVenda();
            PersonalizarDataGridViewParcela(dgvParcelas);

            txtQuantidade.Leave += new EventHandler(txtQuantidade_Leave);
            txtValorProduto.Leave += new EventHandler(txtValorProduto_Leave); 
            txtValorRecebido.Leave += new EventHandler(txtValorRecebido_Leave);
        }
        private void InicializarDataGridViewItensVenda()
        {
            DataTable dt = new DataTable();

            // Definir colunas no DataTable apenas uma vez
            dt.Columns.Add("ItemVendaID", typeof(int));
            dt.Columns.Add("ProdutoID", typeof(int));
            dt.Columns.Add("Quantidade", typeof(int));
            dt.Columns.Add("ValorProduto", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));

            dgvItensVenda.DataSource = dt;

            // Alinhar e renomear colunas no DataGridView
            dgvItensVenda.Columns["ItemVendaID"].HeaderText = "Cód.ItemVenda";
            dgvItensVenda.Columns["ProdutoID"].HeaderText = "Cód. Prod";
            dgvItensVenda.Columns["Quantidade"].HeaderText = "Quantidade";
            dgvItensVenda.Columns["ValorProduto"].HeaderText = "Valor do Produto";            
            dgvItensVenda.Columns["SubTotal"].HeaderText = "Subtotal";

            dgvItensVenda.Columns["ItemVendaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvItensVenda.Columns["Quantidade"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvItensVenda.Columns["ValorProduto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvItensVenda.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvItensVenda.Columns["ProdutoID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
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
                dgv.Columns.Add("ParcelaID", "Cód. Parc");
                dgv.Columns.Add("ValorParcela", "Preço Unit.");
                dgv.Columns.Add("NumeroParcela", "Nº Parc");
                dgv.Columns.Add("DataVencimento", "Vencimento");

                dgv.Columns["ParcelaID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["ValorParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["NumeroParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["DataVencimento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;                
            }           
        }

        private void IncluirItens()
        {
            try
            {
                int _ProdutoID = ProdutoID;
                int Quantidade = int.Parse(txtQuantidade.Text);
                decimal ValorProduto = decimal.Parse(txtValorProduto.Text);
                decimal SubTotal = decimal.Parse(txtSubTotal.Text);

                // Obter a fonte de dados do DataGridView
                DataTable dt = dgvItensVenda.DataSource as DataTable;

                // Remover a linha dt.Rows.Clear();

                // Adicionar linhas ao DataTable
                for (var i = 0; i < numeroParcelas; i++)
                {
                    dt.Rows.Add(nextItemVendaID++, _ProdutoID, Quantidade, ValorProduto, SubTotal);
                    SomarSubtotal();
                }
                txtValorProduto.Text = "0,00";
                txtValorRecebido.Text = "0,00";
                txtSubTotal.Text = "0,00";
                txtQuantidade.Text = "1";
                txtNomeProduto.Text = "";
                txtNomeProduto.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir os dados no datagridview: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        //public void IncluirItensNaGrid()
        //{
        //    try
        //    {
        //        // Inicializa as colunas do DataGridView se ainda não estiverem definidas
        //        //PersonalizarDataGridView(dgvItensVenda);

        //        // Verificações iniciais
        //        if (string.IsNullOrWhiteSpace(txtVendaID.Text))
        //        {
        //            MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
        //        {
        //            MessageBox.Show("Por favor, informe o nome do cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        if (string.IsNullOrWhiteSpace(txtValorProduto.Text))
        //        {
        //            MessageBox.Show("Por favor, informe o valor do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        DataTable dt = dgvItensVenda.DataSource as DataTable ?? new DataTable();

        //        // Verifica se as colunas já foram adicionadas ao DataTable
        //        if (dt.Columns.Count == 0)
        //        {
        //            dt.Columns.Add("ItemVendaID");
        //            dt.Columns.Add("ProdutoID");
        //            dt.Columns.Add("Quantidade");
        //            dt.Columns.Add("ValorProduto");
        //            dt.Columns.Add("SubTotal");
        //        }
        //        int itemVendaID = Utilitario.GerarNovoCodigoID("ItemVendaID", "ItemVenda");
        //        // Criação e adição da linha
        //        DataRow row = dt.NewRow();
        //        row["ItemVendaID"] = itemVendaID;
        //        row["ProdutoID"] = ProdutoID;
        //        row["Quantidade"] = txtQuantidade.Text;
        //        row["ValorProduto"] = txtValorProduto.Text;
        //        row["SubTotal"] = txtSubTotal.Text;

        //        dt.Rows.Add(row);

        //        // Atualiza o DataGridView
        //        dgvItensVenda.DataSource = dt;

        //        // Atualização dos valores
        //        if (decimal.TryParse(txtValorProduto.Text, out decimal valorProduto))
        //        {
        //            valorTotal = valorProduto;
        //        }
        //        // Limpeza dos campos
        //        txtNomeProduto.Clear();                
        //        txtQuantidade.Clear();
        //        txtValorProduto.Clear();
        //        txtValorTotal.Clear();
        //        btnLocalizarProduto.Focus();
        //        txtSubTotal.Clear();
        //        txtSubTotal.Text = "0,00";

        //        // Soma dos valores na Grid
        //        SomarSubtotal();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
            Utilitario.PreencherComboBox(cmbFormaPgto, QueryFormaPgto, "NomeFormaPgto", "FormaPgtoID");
            // Definir o item padrão do ComboBox como "Crediário"
          

            // Gera novos GUIDs para as chaves primárias
            VendaID = Utilitario.GerarNovoCodigoID("VendaID", "Venda");
            ItemVendaID = Utilitario.GerarNovoCodigoID("ItemVendaID", "ItemVenda");
            ContaReceberID = Utilitario.GerarNovoCodigoID("ContaReceberID", "ContaReceber");
            ParcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela");

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
            CalcularSubtotal();
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
                    row["ParcelaID"],
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
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Inserir dados na tabela Venda
                            InserirVenda(connection, transaction);

                            // Inserir itens da venda
                            InserirItensVenda(connection, transaction);

                            // Inserir parcelas e contas a receber
                            InserirParcelasEContasReceber(connection, transaction);

                            // Commit da transação
                            transaction.Commit();

                            Log("Venda finalizada com sucesso.");
                            MessageBox.Show("Venda finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Utilitario.LimpaCampo(this);
                            NovoCodigo();
                        }
                        catch (Exception ex)
                        {
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

        private void InserirVenda(SqlConnection connection, SqlTransaction transaction)
        {
            VendaModel venda = new VendaModel
            {
                VendaID = VendaID,
                ClienteID = ClienteID,
                DataVenda = DateTime.Now,
                ValorTotal = decimal.Parse(txtValorTotal.Text),
                FormaPgtoID = int.Parse(txtFormaPgtoID.Text),
            };

            string vendaQuery = @"INSERT INTO Venda (VendaID, DataVenda, ClienteID, ValorTotal, FormaPgtoID) 
                          VALUES (@VendaID, @DataVenda, @ClienteID, @ValorTotal, @FormaPgtoID)";

            using (SqlCommand vendaCommand = new SqlCommand(vendaQuery, connection, transaction))
            {
                vendaCommand.Parameters.Add("@VendaID", SqlDbType.Int).Value = venda.VendaID;
                vendaCommand.Parameters.Add("@DataVenda", SqlDbType.DateTime).Value = venda.DataVenda;
                vendaCommand.Parameters.Add("@ClienteID", SqlDbType.Int).Value = venda.ClienteID;
                vendaCommand.Parameters.Add("@ValorTotal", SqlDbType.Decimal).Value = venda.ValorTotal;
                vendaCommand.Parameters.Add("@FormaPgtoID", SqlDbType.Int).Value = venda.FormaPgtoID;

                vendaCommand.ExecuteNonQuery();
            }
        }

        private void InserirItensVenda(SqlConnection connection, SqlTransaction transaction)
        {
            List<ItemVendaModel> itens = new List<ItemVendaModel>();

            foreach (DataGridViewRow row in dgvItensVenda.Rows)
            {
                if (row.Cells["ItemVendaID"].Value != null &&
                    row.Cells["ProdutoID"].Value != null &&
                    row.Cells["Quantidade"].Value != null &&
                    row.Cells["ValorProduto"].Value != null)
                {
                    var itemVenda = new ItemVendaModel
                    {
                       
                        VendaID = VendaID,
                        ItemVendaID = int.Parse(row.Cells["ItemVendaID"].Value.ToString()),
                        ProdutoID = int.Parse(row.Cells["ProdutoID"].Value.ToString()),
                        Quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString()),
                        PrecoUnitario = decimal.Parse(row.Cells["ValorProduto"].Value.ToString()),
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
                    itemVendaCommand.Parameters.Add("@ItemVendaID", SqlDbType.Int).Value = item.ItemVendaID;
                    itemVendaCommand.Parameters.Add("@VendaID", SqlDbType.Int).Value = item.VendaID;
                    itemVendaCommand.Parameters.Add("@ProdutoID", SqlDbType.Int).Value = item.ProdutoID;
                    itemVendaCommand.Parameters.Add("@Quantidade", SqlDbType.Int).Value = item.Quantidade;
                    itemVendaCommand.Parameters.Add("@PrecoUnitario", SqlDbType.Decimal).Value = item.PrecoUnitario;

                    itemVendaCommand.ExecuteNonQuery();
                }
            }
        }

        private void InserirParcelasEContasReceber(SqlConnection connection, SqlTransaction transaction)
        {
            List<ParcelaModel> parcelas = new List<ParcelaModel>();

            foreach (DataGridViewRow row in dgvParcelas.Rows)
            {
                if (row.Cells["DataVencimento"].Value != null &&
                    row.Cells["ValorParcela"].Value != null &&
                    row.Cells["NumeroParcela"].Value != null)
                {
                    var parcela = new ParcelaModel
                    {
                        ParcelaID = int.Parse(row.Cells["ParcelaID"].Value.ToString()),
                        VendaID = VendaID,
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
                    parcelaCommand.Parameters.Add("@ParcelaID", SqlDbType.Int).Value = parcela.ParcelaID;
                    parcelaCommand.Parameters.Add("@VendaID", SqlDbType.Int).Value = parcela.VendaID;
                    parcelaCommand.Parameters.Add("@NumeroParcela", SqlDbType.Int).Value = parcela.NumeroParcela;
                    parcelaCommand.Parameters.Add("@DataVencimento", SqlDbType.DateTime).Value = parcela.DataVencimento;
                    parcelaCommand.Parameters.Add("@ValorParcela", SqlDbType.Decimal).Value = parcela.ValorParcela;
                    parcelaCommand.Parameters.Add("@ValorRecebido", SqlDbType.Decimal).Value = parcela.ValorRecebido;
                    parcelaCommand.Parameters.Add("@SaldoRestante", SqlDbType.Decimal).Value = parcela.SaldoRestante;
                    parcelaCommand.Parameters.Add("@Pago", SqlDbType.Bit).Value = parcela.Pago;

                    parcelaCommand.ExecuteNonQuery();
                }
            }

            string contaReceberQuery = @"INSERT INTO ContaReceber (ContaReceberID, VendaID, ParcelaID, DataRecebimento, ValorRecebido, SaldoRestante, Pago) 
                                 VALUES (@ContaReceberID, @VendaID, @ParcelaID, @DataRecebimento, @ValorRecebido, @SaldoRestante, @Pago)";

            foreach (var parcela in parcelas)
            {
                ContaReceberID++;
                using (SqlCommand contaReceberCommand = new SqlCommand(contaReceberQuery, connection, transaction))
                {
                    contaReceberCommand.Parameters.Add("@ContaReceberID", SqlDbType.Int).Value = ContaReceberID;
                    contaReceberCommand.Parameters.Add("@VendaID", SqlDbType.Int).Value = parcela.VendaID;
                    contaReceberCommand.Parameters.Add("@ParcelaID", SqlDbType.Int).Value = parcela.ParcelaID;
                    contaReceberCommand.Parameters.Add("@DataRecebimento", SqlDbType.DateTime).Value = DBNull.Value;
                    contaReceberCommand.Parameters.Add("@ValorRecebido", SqlDbType.Decimal).Value = parcela.ValorRecebido;
                    contaReceberCommand.Parameters.Add("@SaldoRestante", SqlDbType.Decimal).Value = parcela.SaldoRestante;
                    contaReceberCommand.Parameters.Add("@Pago", SqlDbType.Bit).Value = parcela.Pago;

                    contaReceberCommand.ExecuteNonQuery();
                }
            }
        }

        //public void GravarVenda()
        //{
        //    Log("Iniciando gravação da venda...");
        //    try
        //    {
        //        using (var connection = Conexao.Conex())
        //        {
        //            connection.Open();
        //            using (SqlTransaction transaction = connection.BeginTransaction())
        //            {
        //                try
        //                {
        //                    // Inserir dados na tabela Venda
        //                    VendaModel venda = new VendaModel
        //                    {
        //                        // Gera um novo identificador único para VendaID
        //                        VendaID = VendaID,

        //                        // Converte o texto do campo txtClienteID para um inteiro e atribui a ClienteID
        //                        ClienteID = ClienteID,

        //                        // Define a data e hora atuais como DataVenda
        //                        DataVenda = DateTime.Now,

        //                        // Converte o texto do campo txtValorTotal para decimal e atribui a ValorTotal
        //                        ValorTotal = decimal.Parse(txtValorTotal.Text),
        //                        FormaPgtoID = int.Parse(txtFormaPgtoID.Text),
        //                    };

        //                    // String de consulta para inserir dados na tabela Venda
        //                    string vendaQuery = @"INSERT INTO Venda (VendaID, DataVenda, ClienteID, ValorTotal, FormaPgtoID) VALUES (@VendaID, @DataVenda, @ClienteID, @ValorTotal, @FormaPgtoID)";

        //                    // Cria um novo comando SqlCommand para executar a consulta de inserção
        //                    using (SqlCommand vendaCommand = new SqlCommand(vendaQuery, connection, transaction))
        //                    {
        //                        // Adiciona os parâmetros ao comando com os valores da instância de VendaModel
        //                        vendaCommand.Parameters.AddWithValue("@VendaID", venda.VendaID);
        //                        vendaCommand.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
        //                        vendaCommand.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
        //                        vendaCommand.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
        //                        vendaCommand.Parameters.AddWithValue("@FormaPgtoID", venda.FormaPgtoID);

        //                        // Executa o comando de inserção
        //                        vendaCommand.ExecuteNonQuery();
        //                    }

        //                    // Cria uma lista para armazenar os itens de venda
        //                    List<ItemVendaModel> itens = new List<ItemVendaModel>();

        //                    // Itera sobre todas as linhas do DataGridView 'dgvItensVenda'
        //                    foreach (DataGridViewRow row in dgvItensVenda.Rows)
        //                    {
        //                        // Verifica se as células 'ProdutoID', 'Quantidade' e 'ValorProduto' não são nulas
        //                        if (row.Cells["ProdutoID"].Value != null &&
        //                            row.Cells["Quantidade"].Value != null &&
        //                            row.Cells["ValorProduto"].Value != null)                                      
        //                        {
        //                            // Cria uma nova instância de ItemVendaModel e preenche suas propriedades
        //                            var itemVenda = new ItemVendaModel
        //                            {
        //                                // Gera um novo identificador único para ItemVendaID
        //                                ItemVendaID = ItemVendaID,

        //                                // Atribui o ID da venda atual
        //                                VendaID = VendaID,

        //                                // Converte o valor da célula 'ProdutoID' para inteiro e atribui a ProdutoID
        //                                ProdutoID = int.Parse(row.Cells["ProdutoID"].Value.ToString()),

        //                                // Converte o valor da célula 'Quantidade' para inteiro e atribui a Quantidade
        //                                Quantidade = int.Parse(row.Cells["Quantidade"].Value.ToString()),

        //                                // Converte o valor da célula 'ValorProduto' para decimal e atribui a PrecoUnitario
        //                                PrecoUnitario = decimal.Parse(row.Cells["ValorProduto"].Value.ToString()),                                        
        //                            };

        //                            // Adiciona o itemVenda à lista de itens
        //                            itens.Add(itemVenda);
        //                        }
        //                    }

        //                    // String de consulta para inserir dados na tabela ItemVenda
        //                    string itemVendaQuery = @"INSERT INTO ItemVenda (ItemVendaID, VendaID, ProdutoID, Quantidade, PrecoUnitario) VALUES (@ItemVendaID, @VendaID, @ProdutoID, @Quantidade, @PrecoUnitario)";

        //                    // Itera sobre cada item na lista de itens
        //                    foreach (var item in itens)
        //                    {
        //                        // Cria um novo comando SqlCommand para executar a consulta de inserção
        //                        using (SqlCommand itemVendaCommand = new SqlCommand(itemVendaQuery, connection, transaction))
        //                        {
        //                            // Adiciona os parâmetros ao comando com os valores do itemVenda
        //                            itemVendaCommand.Parameters.AddWithValue("@ItemVendaID", item.ItemVendaID);
        //                            itemVendaCommand.Parameters.AddWithValue("@VendaID", item.VendaID);
        //                            itemVendaCommand.Parameters.AddWithValue("@ProdutoID", item.ProdutoID);
        //                            itemVendaCommand.Parameters.AddWithValue("@Quantidade", item.Quantidade);
        //                            itemVendaCommand.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);

        //                            // Executa o comando de inserção
        //                            itemVendaCommand.ExecuteNonQuery();
        //                        }
        //                    }

        //                    // Inserir dados na tabela Parcela
        //                    List<ParcelaModel> parcelas = new List<ParcelaModel>();
        //                    foreach (DataGridViewRow row in dgvParcelas.Rows)
        //                    {
        //                        if (row.Cells["DataVencimento"].Value != null &&
        //                            row.Cells["ValorParcela"].Value != null &&
        //                            row.Cells["NumeroParcela"].Value != null)
        //                        {
        //                            var parcela = new ParcelaModel
        //                            {
        //                                ParcelaID = int.Parse(row.Cells["ParcelaID"].Value.ToString()),
        //                                VendaID = VendaID,
        //                                NumeroParcela = int.Parse(row.Cells["NumeroParcela"].Value.ToString()),
        //                                DataVencimento = DateTime.Parse(row.Cells["DataVencimento"].Value.ToString()),
        //                                ValorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString()),
        //                                ValorRecebido = 0,
        //                                SaldoRestante = decimal.Parse(row.Cells["ValorParcela"].Value.ToString()),
        //                                Pago = false
        //                            };
        //                            parcelas.Add(parcela);
        //                        }
        //                    }

        //                    string parcelaQuery = @"INSERT INTO Parcela (ParcelaID, VendaID, NumeroParcela, DataVencimento, ValorParcela, ValorRecebido, SaldoRestante, Pago) 
        //                           VALUES (@ParcelaID, @VendaID, @NumeroParcela, @DataVencimento, @ValorParcela, @ValorRecebido, @SaldoRestante, @Pago)";
        //                    foreach (var parcela in parcelas)
        //                    {
        //                        using (SqlCommand parcelaCommand = new SqlCommand(parcelaQuery, connection, transaction))
        //                        {
        //                            parcelaCommand.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);
        //                            parcelaCommand.Parameters.AddWithValue("@VendaID", parcela.VendaID);
        //                            parcelaCommand.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
        //                            parcelaCommand.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
        //                            parcelaCommand.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
        //                            parcelaCommand.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);
        //                            parcelaCommand.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
        //                            parcelaCommand.Parameters.AddWithValue("@Pago", parcela.Pago);
        //                            parcelaCommand.ExecuteNonQuery();
        //                        }
        //                    }
        //                    // Inserir dados na tabela ContaReceber
        //                    string contaReceberQuery = @"INSERT INTO ContaReceber (ContaReceberID, VendaID, ParcelaID, DataRecebimento, ValorRecebido, SaldoRestante, Pago) 
        //                                         VALUES (@ContaReceberID, @VendaID, @ParcelaID, @DataRecebimento, @ValorRecebido, @SaldoRestante, @Pago)";

        //                    foreach (var parcela in parcelas)
        //                    {
        //                        ContaReceberID++;
        //                        using (SqlCommand contaReceberCommand = new SqlCommand(contaReceberQuery, connection, transaction))
        //                        {
        //                            contaReceberCommand.Parameters.AddWithValue("@ContaReceberID", ContaReceberID);
        //                            contaReceberCommand.Parameters.AddWithValue("@VendaID", parcela.VendaID);
        //                            contaReceberCommand.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);
        //                            contaReceberCommand.Parameters.AddWithValue("@DataRecebimento", DBNull.Value);
        //                            contaReceberCommand.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);
        //                            contaReceberCommand.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
        //                            contaReceberCommand.Parameters.AddWithValue("@Pago", parcela.Pago);
        //                            contaReceberCommand.ExecuteNonQuery();
        //                        }
        //                    }
        //                    // Commit da transação
        //                    transaction.Commit();
        //                    Log("Venda finalizada com sucesso.");//Gerar arquivo de log para registrar as operações realizadas
        //                    MessageBox.Show("Venda finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    Utilitario.LimpaCampo(this);
        //                    NovoCodigo();
        //                }
        //                catch (Exception ex)
        //                {
        //                    // Rollback da transação em caso de erro
        //                    Log($"Erro ao finalizar a venda: {ex.Message}");
        //                    transaction.Rollback();
        //                    MessageBox.Show($"Erro ao finalizar a venda: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log($"Erro ao conectar ao banco de dados: {ex.Message}");                
        //        MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private List<ContaReceberModel> ObterContasReceber(List<ParcelaModel> parcelas)
        {
            List<ContaReceberModel> contasReceber = new List<ContaReceberModel>();

            // Adiciona contas a receber com base nos dados do DataGridView
            foreach (DataGridViewRow row in dgvParcelas.Rows)
            {
                // Remove a verificação de null para VendaID e ParcelaID, pois são do tipo int
                var valorParcela = decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
                var valorRecebido = 0; // Inicialmente, valor recebido é zero.

                DateTime? dataRecebimento = null; // DataRecebimento permanece nula

                var contaReceber = new ContaReceberModel
                {
                    ContaReceberID = ContaReceberID, // Gerar um novo GUID para ContaReceberID
                    VendaID = VendaID, // Converter VendaID para GUID
                    ParcelaID = ParcelaID, // Converter ParcelaID para GUID
                    DataRecebimento = dataRecebimento,
                    ValorRecebido = valorRecebido,
                    SaldoRestante = valorParcela - valorRecebido, // Cálculo do Saldo Restante
                    Pago = false
                };
                contasReceber.Add(contaReceber);
            }

            return contasReceber;
        }


        private void btnParcelar_Click(object sender, EventArgs e)
        {
            // Gerar o ParcelaID
            ParcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela");

            // Instanciar o formulário FrmGerarParcelas
            FrmGerarParcelas gerarparc = new FrmGerarParcelas();

            // Definir o ParcelaID no formulário FrmGerarParcelas
            gerarparc.SetParcelaID(ParcelaID);
           
            try
            {
               
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
                if (VendaID == 0)
                {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               if (VendaID == 0)
               {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (VendaID == 0)
                {
                    MessageBox.Show("Por favor, informe o ID da venda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ItemVendaID == 0)
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
        //public void CalcularSubtotal()
        //{
        //    if (decimal.TryParse(txtQuantidade.Text, out decimal quantidade) &&
        //        decimal.TryParse(txtValorProduto.Text, out decimal precoUnitario) &&
        //        decimal.TryParse(txtValorRecebido.Text, out decimal valorpago))
        //    {
        //        decimal subtotal = quantidade * precoUnitario - valorpago;
        //        txtSubTotal.Text = subtotal.ToString("N2");
        //    }
        //}
        public void CalcularSubtotal()
        {
            try
            {
                if (decimal.TryParse(txtQuantidade.Text, out decimal quantidade) &&
                    decimal.TryParse(txtValorProduto.Text, out decimal precoUnitario) &&
                    decimal.TryParse(txtValorRecebido.Text, out decimal valorRecebido))
                {
                    decimal subtotal = (quantidade * precoUnitario) - valorRecebido;
                    txtSubTotal.Text = subtotal.ToString("N2");
                }
                else
                {
                    txtSubTotal.Text = "0.00";
                    MessageBox.Show("Por favor, preencha todos os campos corretamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }




        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                txtQuantidade.Text = "0";
            }
            CalcularSubtotal();
        }

        private void txtValorProduto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValorProduto.Text))
            {
                txtValorProduto.Text = "0,00";
            }
            CalcularSubtotal();
        }
        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValorRecebido.Text))
            {
                txtValorRecebido.Text = "0,00";
            }
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

        private void cmbFormaPgto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica se há um item selecionado e captura o ID
            if (cmbFormaPgto.SelectedValue is int idFormaPgto)
            {
                txtFormaPgtoID.Text = idFormaPgto.ToString(); // Atualiza o TextBox com o ID
            }
            else
            {
                txtFormaPgtoID.Text = string.Empty; // Limpa o TextBox caso não haja seleção válida
            }
        }

        private void txtNomeCliente_KeyUp(object sender, KeyEventArgs e)
        {
            string textoDigitado = txtNomeCliente.Text;

            // Abre o formulário de pesquisa se ao menos uma letra for digitada
            if (!string.IsNullOrWhiteSpace(textoDigitado))
            {
                FrmLocalizarCliente frmLocalizar = new FrmLocalizarCliente
                {
                    txtPesquisa = { Text = textoDigitado } // Passa as letras digitadas
                };

                frmLocalizar.ShowDialog(); // Exibe o formulário como modal

                // Atualiza o campo com o cliente selecionado
                if (!string.IsNullOrWhiteSpace(frmLocalizar.nomeCliente))
                {
                    txtNomeCliente.Text = frmLocalizar.nomeCliente;
                    ClienteID = Convert.ToInt16(frmLocalizar.numeroComZeros);
                }
            }
            //// Captura o texto digitado no campo de pesquisa
            //string textoDigitado = txtNomeCliente.Text;

            //// Abre o formulário de pesquisa se ao menos uma letra for digitada
            //if (!string.IsNullOrWhiteSpace(textoDigitado))
            //{
            //    // Verifica se o formulário já está aberto
            //    Form formularioAberto = Application.OpenForms["FrmLocalizarCliente"];
            //    if (formularioAberto == null)
            //    {
            //        // Cria uma nova instância do formulário de pesquisa
            //        FrmLocalizarCliente frmLocalizar = new FrmLocalizarCliente();
            //        frmLocalizar.txtPesquisa.Text = textoDigitado; // Passa as letras digitadas
            //        frmLocalizar.Show();

            //        // Foco no campo de pesquisa do formulário de localizar cliente
            //        frmLocalizar.txtPesquisa.Focus();
            //        frmLocalizar.txtPesquisa.SelectionStart = frmLocalizar.txtPesquisa.Text.Length;
            //    }
            //    else
            //    {
            //        // Se o formulário já estiver aberto, apenas atualiza o campo de texto
            //        FrmLocalizarCliente frmLocalizar = (FrmLocalizarCliente)formularioAberto;
            //        frmLocalizar.txtPesquisa.Text = textoDigitado;
            //        frmLocalizar.txtPesquisa.Focus();
            //        frmLocalizar.txtPesquisa.SelectionStart = frmLocalizar.txtPesquisa.Text.Length;
            //    }
            //}
        }

        private void txtNomeProduto_KeyUp(object sender, KeyEventArgs e)
        {
            string textoDigitado = txtNomeProduto.Text;

            // Abre o formulário de pesquisa se ao menos uma letra for digitada
            if (!string.IsNullOrWhiteSpace(textoDigitado))
            {
                FrmLocalizarProduto frmLocalizar = new FrmLocalizarProduto
                {
                    txtPesquisa = { Text = textoDigitado } // Passa as letras digitadas
                };

                frmLocalizar.ShowDialog(); // Exibe o formulário como modal

                // Atualiza o campo com o cliente selecionado
                if (!string.IsNullOrWhiteSpace(frmLocalizar.NomeProduto))
                {
                    txtNomeCliente.Text = frmLocalizar.NomeProduto;
                    ProdutoID = Convert.ToInt16(frmLocalizar.ProdutoID);
                }
            }
        }
    }
}
