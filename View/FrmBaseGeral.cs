using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisControl
{
    public partial class FrmBaseGeral : Form
    {
        public FrmBaseGeral()
        {
            InitializeComponent();
        }
        
        
        public string RetornoEvitaDuplicado { get; set; }

        public string QueryUsuario = "SELECT MAX(UsuarioID) FROM Usuario";
        public string QueryFornecedor = "SELECT MAX(FornecedorID) FROM Fornecedor";
        public string QueryProduto = "SELECT MAX(ProdutoID) FROM Produto";
        public string QueryVendas = "SELECT MAX(VendaID) FROM Venda";
        public string QueryItensVenda = "SELECT MAX(ItemVendaID) FROM ItemVendaID";
        public string QueryParcela = "SELECT MAX(ParcelaID) FROM Parcela";
        public string QueryContaReceber = "SELECT MAX(ContaReceberID) FROM ContaReceberID";
        public string QueryCentro = "SELECT MAX(CategoriaID) FROM Categoria";
        public string QueryFormaPag = "SELECT MAX(FormaPgtoID) FROM FormaPgto";
        public string QuerySubCat = "SELECT MAX(SubCategoriaID) FROM SubCategoria";
        public string QueryCategoria = "SELECT MAX(CategoriaID) FROM Categoria";
        public string QueryClientes = "SELECT MAX(ClienteID)  FROM Cliente";

        public DateTime DataVencimento { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorTotal { get; set; }
        public int CategoriaID { get; set; }
        public int CidadeID { get; set; }
        public int ClienteID { get; set; }
        public int ContaPagarID { get; set; }
        public int ContaReceberID { get; set; }
        public int Estoque { get; set; }
        public int FornecedorID { get; set; }
        public int ItemVendaID { get; set; }
        public int NumeroParcela { get; set; }
        public int ParcelaID { get; set; }
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public int SubCategoriaID { get; set; }
        public int UsuarioID { get; set; }
        public int VendaID { get; set; }
        public int FormaPgtoID { get; set; }
        public string Cnpj { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeCategoria { get; set; }
        public string NomeSubCategoria { get; set; }
        public string NomeCliente { get; set; }
        public string NomeFornecedor { get; set; }
        public string NomeProduto { get; set; }
        public string NomeUsuario { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string TipoUsuario { get; set; }
        public string FormaPgto { get; set; }

        //public string reTornn { get; set; }
        public DateTime DataP { get; set; }
        public object reTornn { get; set; }
        public string StatusOperacao { get; set; }
        public String Contagem { get; set; }
        public string SqlString { get; set; }
        public int linhaAtual { get; set; }

        private bool mover;
        private int CX, CY;

       
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public virtual void preencherComboBoxT(System.Windows.Forms.ComboBox combo, string querY, string id, string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand cmd = new SqlCommand(querY, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();

                conn.Open();

                da.Fill(Dt);

                combo.DataSource = Dt;
                combo.DisplayMember = nome;
                combo.ValueMember = id;
            }
            catch (SqlException sqle)
            {
                MessageBox.Show("Erro de acesso ao SqlCe : " + sqle.Message, "Erro");
            }
            finally
            {
                conn.Close();
            }
        }

        public void FormataNumeroReplace(string valorsemformato, System.Windows.Forms.TextBox txtValor)
        {
            valorsemformato = txtValor.Text;
            valorsemformato = valorsemformato.Replace("R$", "").Replace(" ", "");
            txtValor.Text = valorsemformato;
        }
        public void MaiusculaUpper(System.Windows.Forms.TextBox txt)
        {
            txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
        }

        public void carregaGrid2Localizar(string comando, DataGridView DatagridParametro)
        {
            var conn = Conexao.Conex();
            SqlCommand criterioSQL = new SqlCommand(comando);

            criterioSQL.Connection = conn;
            try
            {
                conn.Open();
                System.Data.DataTable tabela = new System.Data.DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = criterioSQL;
                adapter.Fill(tabela);

                if (tabela.Rows.Count > 0)
                {
                    DatagridParametro.DataSource = tabela;
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally { conn.Close(); }
        }
        public void carregaGrid2LocalizarFormaPgto(string comando, DataGridView DatagridParametro)
        {
            var conn = Conexao.Conex();
            SqlCommand criterioSQL = new SqlCommand(comando);

            criterioSQL.Connection = conn;
            try
            {
                conn.Open();
                System.Data.DataTable tabela = new System.Data.DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = criterioSQL;
                adapter.Fill(tabela);

                if (tabela.Rows.Count > 0)
                {
                    DatagridParametro.DataSource = tabela;
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally { conn.Close(); }
        }



        public void HabilitaBotes(System.Windows.Forms.Button btnalterar, System.Windows.Forms.Button btnexcluir, System.Windows.Forms.Button btnpagar, DataGridView datagridi_pesquisa)
        {
            if (datagridi_pesquisa.DataSource != null)
            {
                btnalterar.Enabled = true;
                btnexcluir.Enabled = true;
                btnpagar.Enabled = true;
            }
            else
            {
                btnalterar.Enabled = false;
                btnexcluir.Enabled = false;
                btnpagar.Enabled = false;
            }
        }
        public void HabilitaBotes2(ToolStripButton btnalterar, ToolStripButton btnexcluir, ToolStripButton btnpagar, DataGridView datagridi_pesquisa, System.Windows.Forms.RadioButton rbQuitadas)
        {
            if (datagridi_pesquisa.DataSource != null & rbQuitadas.Checked == false)
            {
                btnalterar.Enabled = true;
                btnexcluir.Enabled = true;
                btnpagar.Enabled = true;
            }
            else if (datagridi_pesquisa.DataSource == null)
            {
                btnalterar.Enabled = false;
                btnexcluir.Enabled = false;
                btnpagar.Enabled = false;
            }
            else if (datagridi_pesquisa.DataSource != null & rbQuitadas.Checked == true)
            {
                btnalterar.Enabled = true;
                btnexcluir.Enabled = true;
                btnpagar.Enabled = false;
            }
        }

        public void PesquisarDinamicoDataGrid(string Sql1, string Sql2, DataGridView DataGridPesquisa, System.Windows.Forms.Label Mensagemm)
        {
            var conn = Conexao.Conex();

            SqlCommand comandos = new SqlCommand();
            comandos.CommandText = Convert.ToString(CommandType.Text);
            comandos.CommandText = Sql1 + Sql2;

            comandos.Connection = conn;

            try
            {
                conn.Open();

                System.Data.DataTable tabela = new System.Data.DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comandos;
                adapter.Fill(tabela);

                if (tabela.Rows.Count > 0)
                {
                    DataGridPesquisa.DataSource = tabela;
                    Mensagemm.Text = "";
                }
                else
                {
                    Mensagemm.Text = "Nenhum registro encontrado";

                    if (tabela.Rows.Count == 0)
                    {
                        DataGridPesquisa.DataSource = tabela;
                        tabela.Clear();
                    }
                }
            }
            catch (DataException ex)
            {
                MessageBox.Show("Atenção", ex.ToString());// ex,"Informe", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            finally { conn.Close(); }
        }

        public string ReplaceValoresTexBox(System.Windows.Forms.TextBox TxTValor)
        {
            string valorsemformato = TxTValor.Text;
            valorsemformato = valorsemformato.ToString().Replace("R$", "").Replace(" ", "");
            return valorsemformato;
        }
        public string ReplaceValoresMasketTexBox(System.Windows.Forms.MaskedTextBox TxTValor)
        {
            string valorsemformato = TxTValor.Text;
            valorsemformato = valorsemformato.ToString().Replace("R$", "").Replace(" ", "");
            return valorsemformato;
        }
        public virtual int RetornaUltimoCodigo(string query)
        {
            var conn = Conexao.Conex();
            object codigo = 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query.ToString();

                codigo = cmd.ExecuteScalar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro! +" + erro, "Atenção!" + erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if ((cmd != null))
                {
                    cmd.Dispose();
                }
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return (codigo == null || codigo == DBNull.Value) ? 1 : (Convert.ToInt32(codigo));
        }
        public virtual int RetornaCodigoContaMaisUm(string query)
        {
            var conn = Conexao.Conex();
            object codigo = 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query.ToString();

                codigo = cmd.ExecuteScalar();

            }
            catch (SqlException erro)
            {
                MessageBox.Show("Erro! +" + erro, "Atenção!" + erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if ((cmd != null))
                {
                    cmd.Dispose();
                }
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return (codigo == null || codigo == DBNull.Value) ? 1 : (Convert.ToInt32(codigo) + 1);
        }
        private void FrmBaseGeral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //this.Close();
                if (MessageBox.Show("Deseja sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        public virtual DataTable LocalizarGeral(SqlCommand comando)
        {
            var conn = Conexao.Conex();
            comando.Connection = conn;
            try
            {
                conn.Open();
                SqlDataAdapter daCliente = new SqlDataAdapter();
                daCliente.SelectCommand = comando;
                DataTable dtGeral = new DataTable();
                daCliente.Fill(dtGeral);

                return dtGeral;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }


        public void somarGeral(string sql, string parametro1, string parametro2, System.Windows.Forms.Label resultado)
        {
            try
            {
                using (var conn = Conexao.Conex())
                {
                    conn.Open();
                    using (var comm = conn.CreateCommand())
                    {
                        comm.CommandText = sql;//"SELECT SUM(valor_parc) FROM parcelas WHERE datavenc < @Data AND pago = 0";
                        comm.Parameters.AddWithValue(parametro1, parametro2);//"@Data", DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));

                        string retorno;
                        if (comm != null)
                        {
                            retorno = comm.ExecuteScalar().ToString();
                            double total_vencido = string.IsNullOrEmpty(retorno) ? 0 : double.Parse(retorno);
                            resultado.Text = total_vencido.ToString("N");
                        }
                        else
                        {
                            resultado.Text = "0,00";
                        }
                        conn.Close();
                    }
                }
            }
            catch
            {
            }
        }
        //**************************************************************

        public virtual int BuscarRetornoVariavel(string sqlComando, string Nomeparametro, string parametro, string campoTabela)
        {
            var Conn = Conexao.Conex();
            SqlCommand comando = new SqlCommand(sqlComando);
            comando.Parameters.AddWithValue(Nomeparametro, parametro);//("@criterio", txtPesquisa.Text + "%");
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.SelectCommand.Connection = Conn;
                adaptador.Fill(ds);
                reTornn = ds.Tables[0].Rows[0][campoTabela];

            }
            return Convert.ToInt32(reTornn);
        }
        public string BuscarRetornoVariavelString(string sqlComando, string Nomeparametro, string parametro, string campoTabela)
        {
            var Conn = Conexao.Conex();
            SqlCommand comando = new SqlCommand(sqlComando);
            comando.Parameters.AddWithValue(Nomeparametro, parametro);//("@criterio", txtPesquisa.Text + "%");
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.SelectCommand.Connection = Conn;
                adaptador.Fill(ds);
                reTornn = ds.Tables[0].Rows[0][campoTabela];

            }
            return Convert.ToString(reTornn);
        }

        public DateTime BuscarRetornoVariavelData(string sqlComando, string parametro, string parametro2, string campoTabela)
        {

            var Conn = Conexao.Conex();
            SqlCommand comando = new SqlCommand(sqlComando);
            comando.Parameters.AddWithValue(parametro, parametro2);//("@criterio", txtPesquisa.Text + "%");
            Conn.Open();

            if (Conn.State == ConnectionState.Open)
            {

                DataSet dt = new DataSet();
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                adaptador.SelectCommand.Connection = Conn;
                adaptador.Fill(dt);
                DataP = Convert.ToDateTime(dt.Tables[0].Rows[0][campoTabela]);

            }
            return Convert.ToDateTime(DataP);
        }
        private void FrmBaseGeral_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        public virtual void LimpaCampo()
        {
            foreach (System.Windows.Forms.Control c in Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                {
                    (c as System.Windows.Forms.TextBox).Text = "";
                }
                if (c is MaskedTextBox)
                {
                    (c as MaskedTextBox).Text = "";
                }
                if (c is DateTimePicker) c.Text = null;

                if (c is System.Windows.Forms.Panel)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i] is System.Windows.Forms.TextBox)
                        {
                            (c.Controls[i] as System.Windows.Forms.TextBox).Text = "";
                        }
                        if (c.Controls[i] is System.Windows.Forms.ComboBox)
                        {
                            (c.Controls[i] as System.Windows.Forms.ComboBox).SelectedIndex = -1;
                        }
                    }
                }
                if (c is System.Windows.Forms.ComboBox)
                {
                    (c as System.Windows.Forms.ComboBox).SelectedIndex = -1;
                }
                if (c is System.Windows.Forms.GroupBox)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i] is System.Windows.Forms.TextBox)
                        {
                            (c.Controls[i] as System.Windows.Forms.TextBox).Text = "";
                        }
                        if (c.Controls[i] is DateTimePicker)
                        {
                            (c.Controls[i] as DateTimePicker).Text = null;
                        }
                        if (c.Controls[i] is System.Windows.Forms.ComboBox)
                        {
                            (c.Controls[i] as System.Windows.Forms.ComboBox).SelectedIndex = -1;
                        }
                    }
                }
            }

        }

        public void AcrescenteZero_a_Esquerda2(System.Windows.Forms.TextBox TxtResultado)
        {
            string texto;
            string textofinal;
            int tamanho;
            textofinal = "";
            texto = TxtResultado.Text.ToString();
            if ((TxtResultado.Text.Length < 10))
            {
                tamanho = TxtResultado.Text.Length;
                for (int t = 1; (t <= (6 - tamanho)); t++)
                {
                    textofinal = (textofinal + "0");
                }

                TxtResultado.Text = (textofinal + TxtResultado.Text);
            }

            if ((TxtResultado.Text == ""))
            {
                MessageBox.Show("DEVE SER DIGITADO ALGUM VALOR NO CAMPO CÓDIGO.", "INFORMAÇÃO !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtResultado.Text = "000000";
            }
        }

        public virtual int RetornaUltimoCodigoCadastrado(string query)
        {
            var conn = Conexao.Conex();
            object codigo = 0;
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query.ToString();

                codigo = cmd.ExecuteScalar();

            }
            catch (SqlException erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                if ((cmd != null))
                {
                    cmd.Dispose();
                }
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            return (codigo == null || codigo == DBNull.Value) ? 1 : (Convert.ToInt32(codigo));
        }
        public virtual string EvitarDuplicado(string Tabela, string Campo, string CampoParametro)
        {
            var conn = Conexao.Conex();

            SqlCommand comando = new SqlCommand("SELECT COUNT(*) FROM " + Tabela + " WHERE " + Campo + " = @criterio", conn);

            try
            {
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@criterio";
                parametro.Value = CampoParametro;
                comando.Parameters.Add(parametro);

                conn.Open();
                RetornoEvitaDuplicado = comando.ExecuteScalar().ToString();

                if (RetornoEvitaDuplicado != "0")
                {
                    MessageBox.Show("Registro já cadastrado", "Atenção !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex);
            }
            finally
            {
                conn.Close();
            }
            return RetornoEvitaDuplicado;
        }

        private void FrmBaseGeral_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {            
        }

        private void FrmBaseGeral_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void panelFormat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CX = e.X;
                CY = e.Y;
                mover = true;
            }
        }
    }
    public static class VariavelGlobal
    {
        public static string NomeFormulario = "";
    }
}
