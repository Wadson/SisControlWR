using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisControl
{
    public partial class FrmBaseManutencao : Form
    {
        public FrmBaseManutencao()
        {
            InitializeComponent();
        }

        public string RetornoEvitaDuplicado { get; set; }
        
        public string QueryProduto = "SELECT MAX(ProdutoID) FROM Produto";
        public string QueryGrupo = "SELECT MAX(CategoriaID) FROM Categoria";
        public string QueryParcelasReceitas = "SELECT MAX(ParcelaID) FROM Parcela";
        public string QueryUsuario = "SELECT MAX(UsuarioID) FROM Usuario";
        public string QueryFornecedor = "SELECT MAX(FornecedorID) FROM Fornecedor";
        public string QueryCliente = "SELECT MAX(ClienteID) FROM Cliente";
        public string QueryCentro = "SELECT MAX(CategoriaID) FROM Categoria";
        public string QueryContasReceber = "SELECT MAX(ContaReceberID) FROM ContaReceber";

        public string NomeUsuario { get; set; }
        public string NivelAcesso { get; set; }
        public string NomeCliente { get; set; }
        public string NomeProduto { get; set; }
        public string NomeCategoria { get; set; }
        public string NomeCidade { get; set; }
        public int ProdutoID { get; set; }
        public int UsuarioID { get; set; }
        public int SubCategoriaID { get; set; }
        public int CategoriaID { get; set; }
        public string queryfor { get; set; }

        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string EventoBotao { get; set; }
        public string Descricao { get; set; }
        public string Parcela { get; set; }
        public string Documento { get; set; }
        public string String_Busca_codigo { get; set; }
        public string Capturavalor { get; set; }
        public string Contagem { get; set; }
        public string criterio { get; set; }
        public string sqlString { get; set; }
        public string sqlString1 { get; set; }
        public string sqlString2 { get; set; }
        public int linhaAtual { get; set; }
        public double Valor { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime Pagamento { get; set; }
        public DateTime Data { get; set; }
        public DateTime dtNascimento { get; set; }
        public bool umavez { get; set; }
        public bool parcelado { get; set; }
        public string Status { get; set; }
        public string FormaPgto { get; set; }
        public int FormaPgtoID { get; set; }
        public int VendaID { get; set; }
        public int ParcelaID { get; set; }
        public int IdParcelaR { get; set; }
        public int FornecedorID { get; set; }
        public int ClienteID { get; set; }
        public int ContaReceberID { get; set; }
        public int CidadeID { get; set; }
        public int Qtd_caractere { get; set; }
        public string NomeFornecedor { get; set; } //1
        public string FormadePgto { get; set; }
        public string Cliente { get; set; }

        public string StatusOperacao { get; set; }
        public DateTime PrevReceb { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Datas { get; set; }
        public DateTime DtNascimento { get; set; }


        public virtual void LimpaCampo()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                }
                if (c is MaskedTextBox)
                {
                    (c as MaskedTextBox).Text = "";
                }

                if (c is DateTimePicker) c.Text = null; if (c is ComboBox) c.Text = string.Empty; //Implementado por Wadson só esta linha

                if (c is Panel)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i] is TextBox)
                        {
                            (c.Controls[i] as TextBox).Text = "";
                        }
                        if (c.Controls[i] is MaskedTextBox)
                        {
                            (c.Controls[i] as MaskedTextBox).Text = "";
                        }
                        if (c.Controls[i] is ComboBox)
                        {
                            (c.Controls[i] as ComboBox).Text = "";
                        }
                    }
                }

                if (c is GroupBox)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i] is TextBox)
                        {
                            (c.Controls[i] as TextBox).Text = "";
                        }
                        if (c.Controls[i] is ComboBox)
                        {
                            (c.Controls[i] as ComboBox).Text = "";
                        }
                        //********************IMPLEMENTADO POR WADSON RODRIGUS LIMA
                        if (c.Controls[i] is MaskedTextBox)
                        {
                            (c.Controls[i] as MaskedTextBox).Text = "";
                        }
                        if (c.Controls[i] is DateTimePicker)
                        {
                            (c.Controls[i] as DateTimePicker).Text = null;
                        }//*********************FIM DA IMPLEMENTAÇÃO 
                    }
                }
                if (c is DataGridView)
                {
                    (c as DataGridView).DataSource = null;
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
                DataTable dt = new DataTable();
                daCliente.Fill(dt);

                return dt;
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
            return (codigo == null || codigo == DBNull.Value) ? 1 : (Convert.ToInt32(codigo) + 1);
        }
        private void BasePesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                if (MessageBox.Show("Deseja sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        public virtual void carregaGrid2Localizar(SqlCommand criterioSQL, DataGridView DatagridParametro)
        {
            var conn = Conexao.Conex();
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

                    //txtPesquisa.Focus();
                    //txtPesquisa.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally { conn.Close(); }
        }
        private void BasePesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
