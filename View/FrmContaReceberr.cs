using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static SisControl.View.FrmContaReceberr;

namespace SisControl.View
{
    public partial class FrmContaReceberr : SisControl.FrmModeloForm
    {        
        private Parcela _parcela;
        private FrmBaixarConta frmBaixarConta;
        public int vendaID { get; set; }

        public FrmContaReceberr(FrmContaReceberr formChamador, Parcela parcela)
        {
            InitializeComponent();   
            
            _parcela = parcela;
            ListarContaReceber();
            ConfigurarDgvContasReceber();

            //ConfigurarDgvPagamentosParciais(dgPagamentosParciais);
            
            // No construtor do formulário ou no método de inicialização
            dgvContasReceber.SelectionChanged += dgvContasReceber_SelectionChanged;           

        }

        public FrmContaReceberr(FrmPrincipal frmPrincipal, object value)
        {
            FrmPrincipal = frmPrincipal;
            Value = value;
        }

        public FrmContaReceberr()
        {
        }
        private void ConfigurarDgvContasReceber()
        {
            // Inicializar o DataGridView se ainda não estiver feito
            if (dgvContasReceber == null)
            {
                dgvContasReceber = new KryptonDataGridView();
            }

            // Adicionar colunas se ainda não estiverem adicionadas
            if (dgvContasReceber.Columns.Count == 0)
            {
                dgvContasReceber.Columns.Add("ParcelaID", "Cód.Parc.");
                dgvContasReceber.Columns.Add("ValorParcela", "Vlr.Parc.");
                dgvContasReceber.Columns.Add("NumeroParcela", "Nº Parc.");
                dgvContasReceber.Columns.Add("SaldoRestante", "Sld.Rest.");
                dgvContasReceber.Columns.Add("DataVencimento", "Dta.Venc.");
                dgvContasReceber.Columns.Add("VendaID", "Cód.Vda.");
                dgvContasReceber.Columns.Add("Pago", "Status");
                dgvContasReceber.Columns.Add("ValorRercebido", "Vlr. Rec.");
                dgvContasReceber.Columns.Add("DataRecebimento", "Dt.Recb");

            }

            // Ocultar colunas
            dgvContasReceber.Columns["ParcelaID"].Visible = false;
            dgvContasReceber.Columns["VendaID"].Visible = false;

            // Centralizar coluna
            dgvContasReceber.Columns["NumeroParcela"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
       

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtProdutoID;        
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNomeProduto;

        public FrmPrincipal FrmPrincipal { get; }
        public object Value { get; }

        
        private void RealizarPagamento(int id)
        {
            // Simulação de atualização no banco de dados ou na lógica de negócios
            Log($"Pagamento realizado para a conta ID: {id}");

            // Atualiza a interface
            foreach (DataGridViewRow row in dgvContasReceber.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id"].Value) == id)
                {
                    row.Cells["Pago"].Value = true;
                }
            }

            MessageBox.Show($"Pagamento realizado para a conta ID: {id}");
        }      

        // Método de log (como previamente discutido)
        private void Log(string message)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n");
        }
        private void AbrirFrmLocalizarCliente()
        {
            if (!Application.OpenForms.OfType<FrmLocalizarCliente>().Any())
            {
                FrmLocalizarCliente frmLocalizarCliente = new FrmLocalizarCliente();
                frmLocalizarCliente.FormChamador = this; // Define o formulário chamador
                frmLocalizarCliente.ShowDialog();
            }
        }


        private void LocalizarContaPorNome()
        {
            string query = @"
                    SELECT 
                        Parcela.ParcelaID,                -- ID da parcela
                        Parcela.ValorParcela,             -- Valor da parcela
                        Parcela.NumeroParcela,            -- Número da parcela
                        ContaReceber.SaldoRestante,       -- Saldo restante da parcela
                        Parcela.DataVencimento,           -- Data de vencimento da parcela
                        Parcela.VendaID,                  -- ID da venda associada
                        ContaReceber.Pago,                -- Status de pagamento
                        Parcela.ValorRecebido,            -- Valor recebido da parcela
                        ContaReceber.DataRecebimento,     -- Data de recebimento da conta
                        Cliente.NomeCliente               -- Nome do cliente
                    FROM 
                        ContaReceber                      -- Tabela principal para pagamentos
                    INNER JOIN 
                        Parcela                           -- Relação entre parcelas e pagamentos
                        ON ContaReceber.ParcelaID = Parcela.ParcelaID
                    INNER JOIN 
                        Venda                             -- Relação entre vendas e parcelas
                        ON Parcela.VendaID = Venda.VendaID
                    INNER JOIN
                        Cliente                           -- Relação entre Cliente e ContaReceber
                        ON Venda.ClienteID = Cliente.ClienteID
                    WHERE 
                        ContaReceber.Pago = 0 AND
                        Cliente.NomeCliente = @NomeCliente"; // -- Ordenar por data de vencimento em ordem decrescente";


            string nomeParametro = "@NomeCliente";
            string nomePesquisar = txtNomeCliente.Text;
            Utilitario.PesquisarPorNome(query, nomeParametro, nomePesquisar, dgvContasReceber);

        }
        private void LocalizarContaPorStatus()
        {
            string StatusConta = "";

            if (radioBtnAberto.Checked == true)
            {
                StatusConta = "0";
            }
            if (radioBtnPago.Checked == true)
            {
                StatusConta = "1";
            }

            string query = @"
                    SELECT 
                        Parcela.ParcelaID,                -- ID da parcela
                        Parcela.ValorParcela,             -- Valor da parcela
                        Parcela.NumeroParcela,            -- Número da parcela
                        ContaReceber.SaldoRestante,       -- Saldo restante da parcela
                        Parcela.DataVencimento,           -- Data de vencimento da parcela
                        Parcela.VendaID,                  -- ID da venda associada
                        ContaReceber.Pago,                -- Status de pagamento
                        Parcela.ValorRecebido,            -- Valor recebido da parcela
                        ContaReceber.DataRecebimento,     -- Data de recebimento da conta
                        Cliente.NomeCliente               -- Nome do cliente
                    FROM 
                        ContaReceber                      -- Tabela principal para pagamentos
                    INNER JOIN 
                        Parcela                           -- Relação entre parcelas e pagamentos
                        ON ContaReceber.ParcelaID = Parcela.ParcelaID
                    INNER JOIN 
                        Venda                             -- Relação entre vendas e parcelas
                        ON Parcela.VendaID = Venda.VendaID
                    INNER JOIN
                        Cliente                           -- Relação entre Cliente e ContaReceber
                        ON Venda.ClienteID = Cliente.ClienteID
                    WHERE 
                        ContaReceber.Pago = @Pago";                      

            string nomeParametro = "@Pago";

            Utilitario.PesquisarPorNome(query, nomeParametro, StatusConta, dgvContasReceber);
        }


        private void LocalizarContaPorPeriodoVencimento()
        {
            string query = @"
                    SELECT 
                        Parcela.ParcelaID,                -- ID da parcela
                        Parcela.ValorParcela,             -- Valor da parcela
                        Parcela.NumeroParcela,            -- Número da parcela
                        ContaReceber.SaldoRestante,       -- Saldo restante da parcela
                        Parcela.DataVencimento,           -- Data de vencimento da parcela
                        Parcela.VendaID,                  -- ID da venda associada
                        ContaReceber.Pago,                -- Status de pagamento
                        Parcela.ValorRecebido,            -- Valor recebido da parcela
                        ContaReceber.DataRecebimento,     -- Data de recebimento da conta
                        Cliente.NomeCliente               -- Nome do cliente
                    FROM 
                        ContaReceber                      -- Tabela principal para pagamentos
                    INNER JOIN 
                        Parcela                           -- Relação entre parcelas e pagamentos
                        ON ContaReceber.ParcelaID = Parcela.ParcelaID
                    INNER JOIN 
                        Venda                             -- Relação entre vendas e parcelas
                        ON Parcela.VendaID = Venda.VendaID
                    INNER JOIN
                        Cliente                           -- Relação entre Cliente e ContaReceber
                        ON Venda.ClienteID = Cliente.ClienteID
WHERE 
    Parcela.DataVencimento BETWEEN @DataVencimentoInicio AND @DataVencimentoFim      -- Filtrar por período de vencimento
ORDER BY 
    Parcela.DataVencimento DESC;      -- Ordenar por data de vencimento em ordem decrescente";


            string nomeParametroInicio = "@DataVencimentoInicio";
            string nomeParametroFim = "@DataVencimentoFim";
            DateTime dataVencimentoInicio = DateTime.Parse(dtpDataVencimentoInicio.Text);
            DateTime dataVencimentoFim = DateTime.Parse(dtpDataVencimentoFim.Text);

            Utilitario.PesquisarPorPeriodo(query, nomeParametroInicio, dataVencimentoInicio, nomeParametroFim, dataVencimentoFim, dgvContasReceber);
        }

        private void LocalizarConta()
        {
            string selectedText = cmbFiltro.Text;

            if (selectedText == "Status")
            {
                LocalizarContaPorStatus();
            }           
            else if (selectedText == "Período")
            {
                LocalizarContaPorPeriodoVencimento();
            }
            else if (selectedText == "Nome" && txtClienteID.Text != string.Empty)
            {
                LocalizarContaPorNome();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um critério de filtro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ListarContaReceber();
            }
            AtualizarContagemRegistros();
        }
        public void ListarContaReceber()
        {
            string query = @"SELECT
    Parcela.ParcelaID,                --ID da parcela
    Parcela.ValorParcela,             --Valor da parcela
    Parcela.NumeroParcela,            --Número da parcela
    ContaReceber.SaldoRestante,       --Saldo restante da parcela
    Parcela.DataVencimento,           --Data de vencimento da parcela
    Parcela.VendaID,                  --ID da venda associada
    ContaReceber.Pago,                --Status de pagamento
    Parcela.ValorRecebido,            --Valor recebido da parcela
    ContaReceber.DataRecebimento,     --Data de recebimento da conta
    Cliente.NomeCliente-- Nome do cliente
FROM
    ContaReceber-- Tabela principal para pagamentos
INNER JOIN
    Parcela-- Relação entre parcelas e pagamentos
    ON ContaReceber.ParcelaID = Parcela.ParcelaID
INNER JOIN
    Venda-- Relação entre vendas e parcelas
    ON Parcela.VendaID = Venda.VendaID
INNER JOIN
    Cliente-- Relação entre Cliente e ContaReceber
    ON Venda.ClienteID = Cliente.ClienteID WHERE ContaReceber.Pago = 0";


            string nomeParametro = "@ClienteID";
            string nomePesquisar = txtClienteID.Text;
            Utilitario.PesquisarPorNome(query, nomeParametro, nomePesquisar, dgvContasReceber);
            CalcularTotalDataGrid();

        }
        private void AtualizarContagemRegistros()
        {
            int totalRegistros = Utilitario.ContaRegistros(dgvContasReceber);
            lblTotalRegistros.Text = $"Total de registros: {totalRegistros}";
        }
        private void CarregarContasAReceber(string cliente = "", DateTime? dataVencimentoInicio = null, DateTime? dataVencimentoFim = null)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                // Construir a consulta SQL com filtros opcionais
                string query = @"SELECT Parcela.*, ContaReceber.* FROM ContaReceber INNER JOIN
                         Parcela ON ContaReceber.ParcelaID = Parcela.ParcelaID;
";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cliente", cliente);
                command.Parameters.AddWithValue("@DataVencimentoInicio", dataVencimentoInicio.HasValue ? (object)dataVencimentoInicio.Value : DBNull.Value);
                command.Parameters.AddWithValue("@DataVencimentoFim", dataVencimentoFim.HasValue ? (object)dataVencimentoFim.Value : DBNull.Value);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvContasReceber.DataSource = dataTable;                
            }
        }
        public void BaixarParcelaEContaReceber(int parcelaID, decimal valorRecebido, DateTime dataRecebimento, int formaPgtoID)
        {
            string connectionString = "sua_connection_string";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Iniciar uma transação para garantir a integridade das atualizações
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Atualizar a tabela Parcelas
                        string queryParcelas = @"UPDATE Parcela
                                         SET ValorRecebido = @ValorRecebido,
                                             Pago = CASE WHEN ValorRecebido >= ValorParcela THEN 1 ELSE 0 END
                                         WHERE ParcelaID = @ParcelaID";

                        using (SqlCommand cmdParcelas = new SqlCommand(queryParcelas, conn, transaction))
                        {
                            cmdParcelas.Parameters.AddWithValue("@ParcelaID", parcelaID);
                            cmdParcelas.Parameters.AddWithValue("@ValorRecebido", valorRecebido);

                            cmdParcelas.ExecuteNonQuery();
                        }

                        // Atualizar a tabela ContaReceber
                        string queryContaReceber = @"UPDATE ContaReceber
                                             SET DataRecebimento = @DataRecebimento,
                                                 ValorRecebido = @ValorRecebido,
                                                 Pago = CASE WHEN SaldoRestante - @ValorRecebido <= 0 THEN 1 ELSE 0 END,
                                                 FormaPgtoID = @FormaPgtoID
                                             WHERE ParcelaID = @ParcelaID";

                        using (SqlCommand cmdContaReceber = new SqlCommand(queryContaReceber, conn, transaction))
                        {
                            cmdContaReceber.Parameters.AddWithValue("@ParcelaID", parcelaID);
                            cmdContaReceber.Parameters.AddWithValue("@DataRecebimento", dataRecebimento);
                            cmdContaReceber.Parameters.AddWithValue("@ValorRecebido", valorRecebido);
                            cmdContaReceber.Parameters.AddWithValue("@FormaPgtoID", formaPgtoID);

                            cmdContaReceber.ExecuteNonQuery();
                        }

                        // Commit a transação
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback a transação em caso de erro
                        transaction.Rollback();
                        throw new Exception("Erro ao baixar a parcela e conta a receber: " + ex.Message);
                    }
                }
            }
        }


        private void txtNomeCliente_TextChanged(object sender, EventArgs e)
    {
        FiltrarContasAReceber();
    }

    private void dtpDataVencimentoInicio_ValueChanged(object sender, EventArgs e)
    {
        FiltrarContasAReceber();
    }

    private void dtpDataVencimentoFim_ValueChanged(object sender, EventArgs e)
    {
        FiltrarContasAReceber();
    }

    private void FiltrarContasAReceber()
    {
        string cliente = txtNomeCliente.Text;
        DateTime? dataVencimentoInicio = dtpDataVencimentoInicio.Checked ? (DateTime?)dtpDataVencimentoInicio.Value : null;
        DateTime? dataVencimentoFim = dtpDataVencimentoFim.Checked ? (DateTime?)dtpDataVencimentoFim.Value : null;

        CarregarContasAReceber(cliente, dataVencimentoInicio, dataVencimentoFim);
    }

        private void FrmContaReceber_Load(object sender, EventArgs e)
        {
            ListarContaReceber();                      
        }

        private void txtClienteID_TextChanged(object sender, EventArgs e)
        {
            LocalizarContaPorNome();
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {
        }
        private void cmbFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedText = cmbFiltro.Text;

            if (selectedText == "Status")
            {
                btnFiltro.Visible = true;
                gbStatus.Visible = true;
                gbNome.Visible = false;
                gbPeriodo.Visible = false;
                btnFiltro.Location = new Point(430, 96);
            }
            else if (selectedText == "Período")
            {
                btnFiltro.Visible = true;
                gbPeriodo.Visible = true;
                gbStatus.Visible = false;
                gbNome.Visible = false;
                btnFiltro.Location = new Point(609, 96);
            }
            else if (selectedText == "Nome")
            {
                btnFiltro.Visible = true;
                gbNome.Visible = true;
                gbPeriodo.Visible = false;
                gbStatus.Visible = false;
                btnFiltro.Location = new Point(758, 96);
            }
            else
            {
                btnFiltro.Visible = false;
                gbStatus.Visible = false;
                gbPeriodo.Visible = false;
                gbNome.Visible = false;
                ListarContaReceber();
            }
        }

       

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            LocalizarConta();
            CalcularTotalDataGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            FrmLocalizarCliente frmLocalizarCliente = new FrmLocalizarCliente();
            frmLocalizarCliente.FormChamador = this; // Define o formulário chamador
            frmLocalizarCliente.ShowDialog();
        }

        private void dgvContasReceber_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvContasReceber.SelectedRows.Count > 0)
                {
                    // Obter o ParcelaID da linha selecionada
                    int parcelaID = Convert.ToInt32(dgvContasReceber.SelectedRows[0].Cells["ParcelaID"].Value);
                    // Atualizar o DataGridView de pagamentos parciais
                    ListarPagamentosParciais(parcelaID);

                    vendaID = int.Parse(dgvContasReceber.SelectedRows[0].Cells["VendaID"].Value.ToString());

                    //Chamar método para buscar as informações do cliente

                   BuscarInformacoesCliente();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar a conta: " + ex.Message);

            }
            CalcularTotalDataGrid();
        }
        private void CalcularTotalDataGrid()
        {
            try
            {
                // Calcular o total dos valores Não pagos na coluna "SaldoRestante"
                decimal totalEmAberto = Utilitario.SomarValoresDataGrid(dgvContasReceber, "SaldoRestante");

                // Atualizar a label com o total calculado
                lblTotalEmAberto.Text = $"R$ {totalEmAberto:F2}";


                // Calcular o total dos valores na coluna "ValorParcela"
                decimal totalPago = Utilitario.SomarValoresDataGrid(dgvContasReceber, "ValorRecebido");

                // Atualizar a label com o total calculado
                lblTotalPago.Text = $"R$ {totalPago:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular o total: " + ex.Message);
            }
        }
        private void BuscarInformacoesCliente()
        {
            try
            {
                // Verifique se há uma linha selecionada no DataGridView
                if (dgvContasReceber.SelectedRows.Count > 0)
                {
                    // Pega o ClienteID e o NomeCliente da linha selecionada
                   // int clienteID = Convert.ToInt32(dgvContasReceber.SelectedRows[0].Cells["ClienteID"].Value);
                    string nomeCliente = dgvContasReceber.SelectedRows[0].Cells["NomeCliente"].Value.ToString();

                    using (var connection = Conexao.Conex())
                    {
                        connection.Open();

                        // Consulta para pegar o ClienteID e somar o saldo restante das parcelas (total de débito)
                        string query = @"
                    SELECT c.ClienteID, c.NomeCliente, SUM(p.SaldoRestante) AS TotalDebito
                    FROM Venda v
                    JOIN Cliente c ON v.ClienteID = c.ClienteID
                    JOIN Parcela p ON v.VendaID = p.VendaID
                    WHERE c.NomeCliente = @NomeCliente
                    GROUP BY c.ClienteID, c.NomeCliente";

                        using (var command = new SqlCommand(query, connection))
                        {
                            // Passa o ClienteID para o parâmetro da consulta
                            command.Parameters.AddWithValue("@NomeCliente", nomeCliente);

                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Obtenha o NomeCliente e TotalDebito da consulta
                                    nomeCliente = reader["NomeCliente"].ToString();
                                    decimal totalDebito = reader.IsDBNull(reader.GetOrdinal("TotalDebito")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalDebito"));

                                    // Atualizar as labels com as informações obtidas
                                    lblNomeCliente.Text = nomeCliente;
                                    lblTotalDebito.Text = $"R$ {totalDebito:F2}";
                                }
                                else
                                {
                                    // Caso não encontre o cliente ou o débito
                                    lblNomeCliente.Text = "Cliente não encontrado";
                                    lblTotalDebito.Text = "R$ 0,00";
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecione um cliente na tabela.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar informações do cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Pesquisar o nome do cliente
        //private void BuscarInformacoesCliente()
        //{
        //    try
        //    {
        //        // Exemplo de consulta (adapte conforme sua base de dados)
        //        using (var connection = Conexao.Conex())
        //        {
        //            connection.Open();

        //            // Consulta para pegar o ClienteID da Venda
        //            string query = @"
        //        SELECT c.ClienteID, c.NomeCliente, SUM(p.SaldoRestante) AS TotalDebito
        //        FROM Venda v
        //        JOIN Cliente c ON v.ClienteID = c.ClienteID
        //        JOIN Parcela p ON v.VendaID = p.VendaID
        //        WHERE c.ClienteID = @ClienteID
        //        GROUP BY c.ClienteID, c.NomeCliente";

        //            using (var command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@NomeCliente", NomeCliente);

        //                using (var reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        string nomeCliente = reader["NomeCliente"].ToString();                                
        //                        decimal totalDebito = reader.IsDBNull(reader.GetOrdinal("TotalDebito")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TotalDebito"));

        //                        // Atualizar as labels com as informações obtidas
        //                        lblNomeCliente.Text = nomeCliente;
        //                        lblTotalDebito.Text = $"R$ {totalDebito:F2}";
        //                    }
        //                    else
        //                    {
        //                        // Caso não encontre o cliente ou o débito
        //                        lblNomeCliente.Text = "Cliente não encontrado";
        //                        lblTotalDebito.Text = "R$ 0,00";
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Erro ao buscar informações do cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}




        private void ListarPagamentosParciais(int parcelaID)
        {
            try
            {
                string query = @"SELECT 
                    PagamentoParcialID,
                    ParcelaID,
                    ValorPago,
                    DataPagamento
                FROM 
                    PagamentosParciais
                WHERE 
                    ParcelaID = @ParcelaID";

                string nomeParametro = "@ParcelaID";
                string valorParametro = parcelaID.ToString();
                Utilitario.PesquisarPorNomeMensagemSuprimida(query, nomeParametro, valorParametro, dgPagamentosParciais);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar pagamentos parciais: " + ex.Message);
            }
        }

        //******OUTRO MÉTODO
        public class Parcela
        {
            public int ParcelaID { get; set; }
            public int NumeroParcela { get; set; }
            public decimal ValorParcela { get; set; }
            public DateTime DataVencimento { get; set; }
            public decimal SaldoRestante { get; set; }
            public decimal ValorPago { get; set; }
            public bool Pago { get; set; }
        }
        private void AbrirFormBaixrConta()
        {
            if (dgvContasReceber.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvContasReceber.SelectedRows[0];

                Parcela parcela = new Parcela
                {
                    ParcelaID = Convert.ToInt32(row.Cells["ParcelaID"].Value),
                    NumeroParcela = Convert.ToInt32(row.Cells["NumeroParcela"].Value),
                    ValorParcela = Convert.ToDecimal(row.Cells["ValorParcela"].Value),
                    DataVencimento = Convert.ToDateTime(row.Cells["DataVencimento"].Value),
                    SaldoRestante = Convert.ToDecimal(row.Cells["SaldoRestante"].Value),
                    Pago = Convert.ToBoolean(row.Cells["Pago"].Value)
                };

                //Parcela parcela = new Parcela(); // Obtenha a instância de Parcela conforme necessário
                frmBaixarConta = new FrmBaixarConta(parcela);
                frmBaixarConta.ShowDialog();
                ListarContaReceber();
            }
            else
            {
                MessageBox.Show("Selecione uma parcela para baixar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnReceberConta_Click(object sender, EventArgs e)
        {
            AbrirFormBaixrConta();
        }
    }
}
