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

namespace SisControl
{
    public partial class FrmBasePesquisa : Form
    {
        public FrmBasePesquisa()
        {
            InitializeComponent();
        }
       
        private void txtPesquisa_Enter(object sender, EventArgs e)
        {
            txtPesquisa.BackColor = Color.AliceBlue;
        }

        private void txtPesquisa_Leave(object sender, EventArgs e)
        {
            txtPesquisa.BackColor = Color.White;
        }
        public string QueryFornecedor = "SELECT MAX(FornecedorID) FROM Fornecedor";
        public string QueryCentro = "SELECT MAX(CategoriaID) FROM Categoria";
        public string QueryReceita = "SELECT MAX(ContaReceberID) FROM ContaReceber";
        public string QueryParcela = "SELECT MAX(ParcelaID) FROM Parcela";
        public string QueryContas = "SELECT MAX(VendaID) FROM Venda";
                
        public string NivelAcesso { get; set; }
        public int VendaID { get; set; }
        public int ClienteID { get; set; }
        public int CategoriaID { get; set; }
        public int ParcelaID { get; set; }
        public int FornecedorID { get; set; }
        public int ContaReceberID { get; set; }
        public int UsuarioID { get; set; }               
        public string Situacao { get; set; }
        public string NomeFornecedor { get; set; }        
        public string Marca { get; set; }
        public string NomeUsuario { get; set; }
        public string Cliente { get; set; }
        public string NomeCategoria { get; set; }
        public string EventoBotao { get; set; }
        public string Descricao { get; set; }
        public string NumeroParcela { get; set; }
        public string Documento { get; set; }
        public string String_Busca_codigo { get; set; }
        public string Capturavalor { get; set; }
        public string Contagem { get; set; }

        public int linhaAtual { get; set; }
        public string TipoPesquisa { get; set; }
        public string criterio { get; set; }
        public string sqlString { get; set; }       
        public double ValorProduto { get; set; }

        public DateTime PrevReceb { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        private DateTime Data { get; set; }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        public void carregaGrid2Localizar(SqlCommand criterioSQL, DataGridView dataGridPesqParam)
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
                    dataGridPesqParam.DataSource = tabela;
                }
                else
                {
                    MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    txtPesquisa.Focus();
                    txtPesquisa.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally { conn.Close(); }
        }

        private void FrmBasePesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Deseja sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void rbtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }

        private void rbtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            txtPesquisa.Text = "";
            txtPesquisa.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
