using SisControl.BLL;
using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            
            this.dataGridPesquisa.Columns[0].Name = "Usuario ID";
            this.dataGridPesquisa.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridPesquisa.Columns[1].Name = "Nome Usuario";
            this.dataGridPesquisa.Columns[2].Name = "Email";
            this.dataGridPesquisa.Columns[3].Name = "Senha";
            this.dataGridPesquisa.Columns[3].Name = "Tipo Usuario";

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
        private void btnNovo_Click(object sender, EventArgs e)
        {
            FrmCadUsuario childForm = new FrmCadUsuario();
            childForm.Text = "SISCONTROL - CADASTRO DE USUÁRIO";
            childForm.StatusOperacao = "NOVO";
            childForm.ShowDialog();
            ((FrmManutUsuario)Application.OpenForms["FrmManutUsuario"]).HabilitarTimer(true);
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