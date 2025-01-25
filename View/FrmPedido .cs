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
using ComponentFactory.Krypton.Toolkit;
using System.Transactions;


namespace SisControl.View
{
    public partial class FrmPedido : SisControl.FrmModeloForm
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

        
        public FrmPedido()
        {
            InitializeComponent();

            nextItemVendaID = Utilitario.GerarNovoCodigoID("ItemVendaID", "ItemVenda");

            // Registrar o evento KeyDown

            // Configurar a seleção de linha inteira
            dgvParcelas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           // dgvItensVenda.KeyDown += new KeyEventHandler(dgvItensVenda_KeyDown);

            Utilitario.ConfigurarEventosDeFocoKrypton(this);// Texbox fundo amarelo quando em foco            
                        
            // Definir os valores iniciais dos TextBox
            txtValorProduto.Text = "0,00";
            txtValorRecebido.Text = "0,00";
            txtSubTotal.Text = "0,00";
            txtQuantidade.Text = "1";

            InicializarDataGridViewItensVenda();            

            txtQuantidade.Leave += new EventHandler(txtQuantidade_Leave);
            txtValorProduto.Leave += new EventHandler(txtValorProduto_Leave); 
            txtValorRecebido.Leave += new EventHandler(txtValorRecebido_Leave);
        }
        // Método para excluir a linha selecionada
        private void ExcluirItemSelecionado()
        {
            if (dgvItensVenda.SelectedRows.Count > 0)
            {
                // Confirmar exclusão
                var confirmResult = MessageBox.Show(
                    "Tem certeza de que deseja excluir o(s) item(ns) selecionado(s)?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    // Iterar pelas linhas selecionadas e removê-las
                    foreach (DataGridViewRow linha in dgvItensVenda.SelectedRows)
                    {
                        if (!linha.IsNewRow)
                        {
                            dgvItensVenda.Rows.Remove(linha);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        }

        private void IncluirItens()
        {
            try
            {
                int _ProdutoID = ProdutoID;
                int Quantidade = int.Parse(txtQuantidade.Text);
                decimal ValorProduto = decimal.Parse(txtValorProduto.Text);
                decimal SubTotal = Quantidade * ValorProduto;

                // Obter a fonte de dados do DataGridView
                DataTable dt = dgvItensVenda.DataSource as DataTable;

                if (dt == null)
                {
                    MessageBox.Show("A fonte de dados do DataGridView não está configurada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verificar se o produto já existe no DataTable
                DataRow linhaExistente = null;
                foreach (DataRow row in dt.Rows)
                {
                    if (row.Field<int>("ProdutoID") == _ProdutoID) // Substitua "ProdutoID" pelo nome exato da coluna no DataTable
                    {
                        linhaExistente = row;
                        break;
                    }
                }

                if (linhaExistente != null)
                {
                    // Produto já existe, atualizar quantidade e subtotal
                    int quantidadeAtual = linhaExistente.Field<int>("Quantidade");
                    linhaExistente["Quantidade"] = quantidadeAtual + Quantidade;
                    linhaExistente["SubTotal"] = (quantidadeAtual + Quantidade) * ValorProduto;
                }
                else
                {
                    // Produto não existe, adicionar nova linha
                    dt.Rows.Add(nextItemVendaID++, _ProdutoID, Quantidade, ValorProduto, SubTotal);
                }

                // Atualizar o subtotal total (soma dos subtotais de todos os itens)
                SomarSubtotal();

                // Limpar os campos
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



        //private void IncluirItens()
        //{
        //    try
        //    {
        //        int _ProdutoID = ProdutoID;
        //        int Quantidade = int.Parse(txtQuantidade.Text);
        //        decimal ValorProduto = decimal.Parse(txtValorProduto.Text);
        //        decimal SubTotal = decimal.Parse(txtSubTotal.Text);

        //        // Obter a fonte de dados do DataGridView
        //        DataTable dt = dgvItensVenda.DataSource as DataTable;

        //        // Remover a linha dt.Rows.Clear();

        //        // Adicionar linhas ao DataTable
        //        for (var i = 0; i < numeroParcelas; i++)
        //        {
        //            dt.Rows.Add(nextItemVendaID++, _ProdutoID, Quantidade, ValorProduto, SubTotal);
        //            SomarSubtotal();
        //        }
        //        txtValorProduto.Text = "0,00";
        //        txtValorRecebido.Text = "0,00";
        //        txtSubTotal.Text = "0,00";
        //        txtQuantidade.Text = "1";
        //        txtNomeProduto.Text = "";
        //        txtNomeProduto.Select();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao inserir os dados no datagridview: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Utilitario.PreencherComboBoxKrypton(cmbFormaPgto, QueryFormaPgto, "NomeFormaPgto", "FormaPgtoID");
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

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            NovoCodigo();            
        }
        public void ToMoney(KryptonTextBox text, string format = "N")
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

        public void ReceberDadosParcelas(DataTable dt)
        {
            try
            {
                // Verifica se as colunas do DataGridView estão definidas
                if (dgvParcelas.Columns.Count == 0)
                {
                    dgvParcelas.Columns.Add("ParcelaID", "Parcela ID");
                    dgvParcelas.Columns.Add("ValorParcela", "Valor da Parcela");
                    dgvParcelas.Columns.Add("NumeroParcela", "Número da Parcela");
                    dgvParcelas.Columns.Add("DataVencimento", "Data de Vencimento");
                }

                // Desvincula o DataGridView da fonte de dados
                dgvParcelas.DataSource = null;

                // Limpa as linhas existentes no DataGridView
                dgvParcelas.Rows.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    DateTime dataVencimento = Convert.ToDateTime(row["DataVencimento"]).Date;

                    // Adiciona linhas no DataGridView
                    dgvParcelas.Rows.Add(
                        row["ParcelaID"],
                        row["ValorParcela"],
                        row["NumeroParcela"],
                        row["DataVencimento"],
                        dataVencimento
                    );
                }

                // Configura o formato da célula para mostrar apenas a data
                foreach (DataGridViewRow dgvRow in dgvParcelas.Rows)
                {
                    dgvRow.Cells["DataVencimento"].Value = Convert.ToDateTime(dgvRow.Cells["DataVencimento"].Value).ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao receber dados das parcelas: " + ex.Message + "\n" + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparFormulario()
        {
            try
            {
                // Limpar campos de texto
                txtValorProduto.Text = "0,00";
                txtValorRecebido.Text = "0,00";
                txtSubTotal.Text = "0,00";
                txtQuantidade.Text = "1";
                txtNomeProduto.Text = "";
                txtNomeCliente.Text = "";

                // Limpar o DataGridView (verificando se há uma fonte de dados vinculada)
                if (dgvItensVenda.DataSource is DataTable dt)
                {
                    dt.Clear(); // Limpa o DataTable diretamente
                }
                else
                {
                    dgvItensVenda.Rows.Clear(); // Limpa as linhas manualmente
                }

                if (dgvParcelas.DataSource is DataTable dtt)
                {
                    dtt.Clear(); // Limpa o DataTable diretamente
                }
                else
                {
                    dgvParcelas.Rows.Clear(); // Limpa as linhas manualmente
                }

                // Chamar NovoCodigo para redefinir o estado inicial
                NovoCodigo();
            }
            catch (Exception ex)
            {
                Log($"Erro ao limpar o formulário: {ex.Message}");
                MessageBox.Show($"Erro ao limpar o formulário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void LimparFormulario()
        //{
        //    try
        //    {
        //        // Limpar campos de texto
        //        txtValorProduto.Text = "0,00";
        //        txtValorRecebido.Text = "0,00";
        //        txtSubTotal.Text = "0,00";
        //        txtQuantidade.Text = "1";
        //        txtNomeProduto.Text = "";
        //        txtNomeCliente.Text = "";

        //        // Limpar o DataGridView (certifique-se de que ele não esteja com uma fonte de dados ativa)
        //        if (dgvItensVenda.DataSource is DataTable dt && dgvParcelas.DataSource is DataTable dtt)
        //        {
        //            dt.Clear(); // Limpa o DataTable diretamente
        //            dtt.Clear();
        //        }
        //        else
        //        {
        //            dgvItensVenda.Rows.Clear(); // Limpa as linhas do DataGridView manualmente
        //            dgvParcelas.Rows.Clear();
        //        }
        //        NovoCodigo();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log($"Erro ao limpar o formulário: {ex.Message}");
        //        throw; // Relança o erro para tratamento em um nível superior, se necessário
        //    }
        //}

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
                            Log("Inserindo dados da venda...");
                            InserirVenda(connection, transaction);

                            Log("Inserindo itens da venda...");
                            InserirItensVenda(connection, transaction);

                            Log("Inserindo parcelas e contas a receber...");
                            InserirParcelasEContasReceber(connection, transaction);

                            // Commit da transação
                            Log("Finalizando transação com commit...");
                            transaction.Commit();

                            Log("Venda finalizada com sucesso.");
                            MessageBox.Show("Venda finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Limpar campos e resetar controles
                            try
                            {
                                Log("Limpando campos e resetando controles...");
                                LimparFormulario();
                                NovoCodigo();
                            }
                            catch (Exception clearEx)
                            {
                                Log($"Erro ao limpar os campos: {clearEx.Message}");
                                MessageBox.Show($"Erro ao limpar os campos: {clearEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log($"Erro durante a execução da venda: {ex.Message}");
                            try
                            {
                                Log("Desfazendo transação (rollback)...");
                                transaction.Rollback();
                            }
                            catch (Exception rbEx)
                            {
                                Log($"Erro ao realizar o rollback: {rbEx.Message}");
                            }
                            finally
                            {
                                transaction.Dispose();
                            }
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


        //public void GravarVenda()
        //{
        //    Log("Iniciando gravação da venda...");
        //    try
        //    {
        //        using (var connection = Conexao.Conex())
        //        {
        //            connection.Open();
        //            using (var transaction = connection.BeginTransaction())
        //            {
        //                try
        //                {
        //                    Log("Inserindo dados da venda...");
        //                    InserirVenda(connection, transaction);

        //                    Log("Inserindo itens da venda...");
        //                    InserirItensVenda(connection, transaction);

        //                    Log("Inserindo parcelas e contas a receber...");
        //                    InserirParcelasEContasReceber(connection, transaction);

        //                    // Commit da transação
        //                    Log("Finalizando transação com commit...");
        //                    transaction.Commit();

        //                    Log("Venda finalizada com sucesso.");
        //                    MessageBox.Show("Venda finalizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //                    Utilitario.LimpaCampoKrypton(this);
        //                    NovoCodigo();
        //                }
        //                catch (Exception ex)
        //                {
        //                    Log($"Erro durante a execução da venda: {ex.Message}");
        //                    try
        //                    {
        //                        Log("Desfazendo transação (rollback)...");
        //                        transaction.Rollback();
        //                    }
        //                    catch (Exception rbEx)
        //                    {
        //                        Log($"Erro ao realizar o rollback: {rbEx.Message}");
        //                    }
        //                    finally
        //                    {
        //                        transaction.Dispose();
        //                    }
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

            if (dgvParcelas.Rows.Count == 0 || dgvParcelas.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                // Se o DataGridView estiver vazio, pegue os dados dos TextBoxes
                var parcela = new ParcelaModel
                {
                    ParcelaID = ParcelaID,
                    VendaID = VendaID,
                    NumeroParcela = 1,
                    DataVencimento = DateTime.Parse(dtpVencimento.Text),
                    ValorParcela = decimal.Parse(txtValorTotal.Text),
                    ValorRecebido = 0,
                    SaldoRestante = decimal.Parse(txtValorTotal.Text),
                    Pago = false
                };

                parcelas.Add(parcela);
            }
            else
            {
                // Loop através das linhas do DataGridView se ele não estiver vazio
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
        }
            
        private void AbrirFrmLocalizarCliente()
        {
            FrmLocalizarCliente frmLocalizarCliente = new FrmLocalizarCliente();
            frmLocalizarCliente.FormChamador = this; // Define o formulário chamador
            frmLocalizarCliente.ShowDialog();
        }

       
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

        private void rbUmaParcela_CheckedChanged(object sender, EventArgs e)
        {            
        }

        private void rbParcelar_CheckedChanged(object sender, EventArgs e)
        {           
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
        }

        private void txtQuantidade_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
            {
                txtQuantidade.Text = "0";
            }
            CalcularSubtotal();
        }

        private void txtValorProduto_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValorProduto.Text))
            {
                txtValorProduto.Text = "0,00";
            }
            CalcularSubtotal();
        }

        private void txtValorRecebido_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValorRecebido.Text))
            {
                txtValorRecebido.Text = "0,00";
            }
            CalcularSubtotal();
        }

        private void txtNomeProduto_KeyUp_1(object sender, KeyEventArgs e)
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

        private void cmbFormaPgto_SelectedIndexChanged_1(object sender, EventArgs e)
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
        //*******************************GERAR PARCELAS********************UMA PARCELA

       

        //***************************FIM DO METODO GERAR PARCELAS********************************
        private void btnIncluir_Click_1(object sender, EventArgs e)
        {           
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            GravarVenda();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtValorProduto_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void txtValorRecebido_Leave(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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

                if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
                {
                    MessageBox.Show("Por favor, informe uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtValorProduto.Text) || decimal.TryParse(txtValorProduto.Text, out decimal valor) && valor <= 0)
                {
                    MessageBox.Show("Por favor, informe um valor de produto válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNomeProduto.Text))
                {
                    MessageBox.Show("Por favor, informe o nome do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnParcelar_Click_1(object sender, EventArgs e)
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
                gerarparc.txtQtdParcelas.Text = 2.ToString();

                // Passa o parcelaID como Guid para o formulário de gerar parcelas
                gerarparc.parcelaID = ParcelaID;

                gerarparc.ShowDialog();
                gerarparc.Text = "Gerar Parcelas para o Cliente:" + txtNomeCliente.Text;                
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

        private void dgvItensVenda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ExcluirItemSelecionado();
            }
        }

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarCliente();
            ToMoney(txtValorProduto);
            ToMoney(txtValorTotal);
            txtQuantidade.Focus();
        }

        private void btnLocalizarProduto_Click(object sender, EventArgs e)
        {
            LocalizarProduto();
        }

        private void btnReceberConta_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }
    }
}


/*
 *  private void GerarParcelas()
        {
            // Após inserir o item de venda, verificar se radioSim está marcado
            if (dgvItensVenda.Rows.Count > 0)
            {
                try
                {
                    int dias = 30;
                    string nomeCliente = txtNomeCliente.Text;
                    numeroParcelas = 1;
                    valorTotal = Convert.ToDecimal(txtValorTotal.Text);
                    // Definir a data de vencimento para incluir apenas a data, sem a hora
                    DateTime dataVencimento = Convert.ToDateTime(dtpVencimento.Value).Date;
                    decimal valorParcela = Math.Round(valorTotal / numeroParcelas, 2); // Arredondar para duas casas decimais

                    // Obter a fonte de dados do DataGridView, se houver
                    DataTable dt = dgvParcelas.DataSource as DataTable;

                    // Se a fonte de dados estiver vazia, inicialize-a
                    if (dt == null || dt.Columns.Count == 0)
                    {
                        dt = new DataTable();

                        // Definir colunas no DataTable apenas uma vez
                        dt.Columns.Add("ParcelaID", typeof(int)); // Alterado para int
                        dt.Columns.Add("ValorParcela", typeof(decimal));
                        dt.Columns.Add("NumeroParcela", typeof(int));
                        dt.Columns.Add("DataVencimento", typeof(DateTime));

                        dgvParcelas.DataSource = dt;
                    }
                    else
                    {
                        // Limpar as linhas do DataTable antes de adicionar novas
                        dt.Rows.Clear();
                    }

                    int parcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela"); // Gerar um novo ParcelaID para cada parcela
                                                                                          // Adicionar linhas ao DataTable com novos ParcelaID gerados
                    for (var i = 0; i < numeroParcelas; i++)
                    {
                        dt.Rows.Add(parcelaID, valorParcela, i + 1, dataVencimento.AddDays(i * dias).Date);
                        parcelaID++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gerar parcelas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
           
        }
 * */