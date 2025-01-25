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
        private new string StatusOperacao;
        public FrmManutUsuario(string statusOperacao)
        {
            InitializeComponent();
            this.StatusOperacao = statusOperacao;
        }
      
        private void CarregaDados()
        {
            FrmCadUser cadUsuarios = new FrmCadUser(StatusOperacao);

            try
            {
                if (StatusOperacao == "NOVO")
                {
                    cadUsuarios.Text = "SISCONTROL - NOVO CADASTRO DE USUÁRIO";
                    StatusOperacao = "NOVO";  
                    cadUsuarios.ShowDialog();

                    ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                }
                if(StatusOperacao == "ALTERAR")
                {
                    cadUsuarios.txtUsarioID.Text =     dataGridPesquisar.CurrentRow.Cells["UsuarioID"].Value.ToString();
                    cadUsuarios.txtNomeUsuario.Text =      dataGridPesquisar.CurrentRow.Cells["NomeUsuario"].Value.ToString();
                    cadUsuarios.txtEmail.Text =         dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                    cadUsuarios.txtSenha.Text =         dataGridPesquisar.CurrentRow.Cells["Senha"].Value.ToString();
                    cadUsuarios.cmbTipoUsuario.Text =    dataGridPesquisar.CurrentRow.Cells["TipoUsuario"].Value.ToString();

                    cadUsuarios.Text = "SISCONTROL - ALTERAR REGISTRO";
                    StatusOperacao = "ALTERAR";
                    
                    cadUsuarios.btnSalvar.Text = "Alterar";
                    cadUsuarios.btnNovo.Enabled = false;
                                        cadUsuarios.ShowDialog();
                    ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
                }
                if (StatusOperacao == "EXCLUSÃO")
                {
                    cadUsuarios.txtUsarioID.Text = dataGridPesquisar.CurrentRow.Cells["UsuarioID"].Value.ToString();
                    cadUsuarios.txtNomeUsuario.Text = dataGridPesquisar.CurrentRow.Cells["NomeUsuario"].Value.ToString();
                    cadUsuarios.txtEmail.Text = dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                    cadUsuarios.txtSenha.Text = dataGridPesquisar.CurrentRow.Cells["Senha"].Value.ToString();
                    cadUsuarios.cmbTipoUsuario.Text = dataGridPesquisar.CurrentRow.Cells["TipoUsuario"].Value.ToString();

                    cadUsuarios.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                    StatusOperacao = "EXCLUSÃO";

                    cadUsuarios.btnSalvar.Text = "Excluir";
                    cadUsuarios.btnNovo.Enabled = false;                    
                    

                    cadUsuarios.txtUsarioID.Enabled = false;
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
        public void PersonalizarDataGridView(DataGridView dgv)
        {          

            //Alinhar o as colunas

            dataGridPesquisar.Columns["UsuarioID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            //dataGridPesquisar.Columns["Estoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

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
            //dgv.RowHeadersVisible = false;

            // Cor do grid
            dgv.GridColor = Color.Black;

            this.dataGridPesquisar.Columns[0].Name = "UsuarioID"   ;
            this.dataGridPesquisar.Columns[1].Name = "NomeUsuario" ;
            this.dataGridPesquisar.Columns[2].Name = "Email"       ;
            this.dataGridPesquisar.Columns[3].Name = "Senha"        ;
            this.dataGridPesquisar.Columns[4].Name = "TipoUsuario" ;
            // Ocultar a coluna, mas ainda manter o acesso aos valores
            dataGridPesquisar.Columns["UsuarioID"].Visible = false;
        }

        public void ListaUsuario()
        {
            UsuarioBLL usuariosBll = new UsuarioBLL();
            dataGridPesquisar.DataSource = usuariosBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
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
            dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
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