using SisControl.BLL;
using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace SisControl
{
    public partial class FrmManutUsuario : SisControl.FrmBaseManutencao
    {
        public FrmManutUsuario()
        {
            InitializeComponent();
        }
      
        private void CarregaDados()
        {
            FrmCadUsuario cadUsuarios = new FrmCadUsuario();

            try
            {
                if (StatusOperacao == "NOVO")
                {
                    cadUsuarios.Text = "SISCONTROL - NOVO CADASTRO DE USUÁRIO";
                    cadUsuarios.StatusOperacao = "NOVO";  
                    cadUsuarios.ShowDialog();

                    ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                }
                if(StatusOperacao == "ALTERAR")
                {
                    cadUsuarios.txtUsuarioID.Text =     dataGridPesquisa.CurrentRow.Cells["UsuarioID"].Value.ToString();
                    cadUsuarios.txtNomeUsuario.Text =      dataGridPesquisa.CurrentRow.Cells["NomeUsuario"].Value.ToString();
                    cadUsuarios.txtEmail.Text =         dataGridPesquisa.CurrentRow.Cells["Email"].Value.ToString();
                    cadUsuarios.txtSenha.Text =         dataGridPesquisa.CurrentRow.Cells["Senha"].Value.ToString();
                    cadUsuarios.cmbTipoUsuario.Text =    dataGridPesquisa.CurrentRow.Cells["TipoUsuario"].Value.ToString();

                    cadUsuarios.Text = "SISCONTROL - ALTERAR REGISTRO";
                    cadUsuarios.StatusOperacao = "ALTERAR";
                    
                    cadUsuarios.btnSalvar.Text = "Alterar";
                    cadUsuarios.btnNovo.Enabled = false;
                    cadUsuarios.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                    cadUsuarios.btnSalvar.Image = Properties.Resources.Alterar;
                    cadUsuarios.ShowDialog();
                    ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                }
                if (StatusOperacao == "EXCLUSÃO")
                {
                    cadUsuarios.txtUsuarioID.Text = dataGridPesquisa.CurrentRow.Cells["UsuarioID"].Value.ToString();
                    cadUsuarios.txtNomeUsuario.Text = dataGridPesquisa.CurrentRow.Cells["NomeUsuario"].Value.ToString();
                    cadUsuarios.txtEmail.Text = dataGridPesquisa.CurrentRow.Cells["Email"].Value.ToString();
                    cadUsuarios.txtSenha.Text = dataGridPesquisa.CurrentRow.Cells["Senha"].Value.ToString();
                    cadUsuarios.cmbTipoUsuario.Text = dataGridPesquisa.CurrentRow.Cells["TipoUsuario"].Value.ToString();

                    cadUsuarios.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                    cadUsuarios.StatusOperacao = "EXCLUSÃO";

                    cadUsuarios.btnSalvar.Text = "Excluir";
                    cadUsuarios.btnNovo.Enabled = false;
                    cadUsuarios.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                    cadUsuarios.btnSalvar.Image = Properties.Resources.Excluir2;

                    cadUsuarios.txtUsuarioID.Enabled = false;
                    cadUsuarios.txtNomeUsuario.Enabled = false;
                    cadUsuarios.txtEmail.Enabled = false;
                    cadUsuarios.txtSenha.Enabled  = false;
                    cadUsuarios.cmbTipoUsuario.Enabled = false;
                    cadUsuarios.txtRepitaSenha.Enabled = false;
                    cadUsuarios.ShowDialog();
                    ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                }                
                ListaUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro..." + ex.Message);
            }
           //((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
        }
        private void FrmManutUsuario_Load(object sender, EventArgs e)
        {
            ListaUsuario();
        }
        private void DefinirFonteeCores()
        {
            this.dataGridPesquisa.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.dataGridPesquisa.DefaultCellStyle.ForeColor = Color.Blue;
            this.dataGridPesquisa.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridPesquisa.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dataGridPesquisa.DefaultCellStyle.SelectionBackColor = Color.Black;
        }
        public void PersonalizarDatagridView()
        {
            // Defina a altura da linha para acomodar o conteúdo que
            // abrange várias colunas.
            //this.dataGridPesquisa.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;

            // Inicializa outras propriedades DataGridView.
            this.dataGridPesquisa.AllowUserToAddRows = false;
            this.dataGridPesquisa.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            this.dataGridPesquisa.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridPesquisa.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Defina os nomes dos cabeçalhos das colunas.
            
            this.dataGridPesquisa.Columns[0].Name = "UsuarioID";
            this.dataGridPesquisa.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridPesquisa.Columns[1].Name = "NomeUsuario";
            this.dataGridPesquisa.Columns[2].Name = "Email";
            this.dataGridPesquisa.Columns[3].Name = "Senha";
            this.dataGridPesquisa.Columns[4].Name = "TipoUsuario";

            DefinirFonteeCores();

            // Hide the column that contains the content that spans
            // multiple columns.
            //this.dataGridPesquisa.Columns[2].Visible = false;
        }
       
        public void ListaUsuario()
        {
            UsuarioBLL usuariosBll = new UsuarioBLL();
            dataGridPesquisa.DataSource = usuariosBll.Listar();
            PersonalizarDatagridView();
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            ListaUsuario();
            timer1.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            StatusOperacao = "NOVO";
           CarregaDados();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            StatusOperacao = "ALTERAR";            
            CarregaDados();   
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            StatusOperacao = "EXCLUSÃO";           
            CarregaDados();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            UsuarioDALL dao = new UsuarioDALL();
            dataGridPesquisa.DataSource = dao.PesquisarPorNome(nome);
        }
    }
}
/*
 * // Set the background to red for negative values in the Balance column.
        if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Balance"))
        {
            Int32 intValue;
            if (Int32.TryParse((String)e.Value, out intValue) &&
                (intValue < 0))
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.SelectionBackColor = Color.DarkRed;
            }
        }

        // Replace string values in the Priority column with images.
        if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Priority"))
        {
            // Ensure that the value is a string.
            String stringValue = e.Value as string;
            if (stringValue == null) return;

            // Set the cell ToolTip to the text value.
            DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
            cell.ToolTipText = stringValue;

            // Replace the string value with the image value.
            switch (stringValue)
            {
                case "high":
                    e.Value = highPriImage;
                    break;
                case "medium":
                    e.Value = mediumPriImage;
                    break;
                case "low":
                    e.Value = lowPriImage;
                    break;
            }
        }
    }
 * */