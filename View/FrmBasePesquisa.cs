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
