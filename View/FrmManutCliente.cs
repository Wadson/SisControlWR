using SisControl.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmManutCliente : SisControl.FrmBaseManutencao
    {
        public FrmManutCliente()
        {
            InitializeComponent();
        }
        public void ListarCliente()
        {
            ClienteBLL clienteBll = new ClienteBLL();
            dataGridPesquisa.DataSource = clienteBll.Listar();
            PersonalizarDatagridView();
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
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

            this.dataGridPesquisa.Columns[0].Name = "ClienteID";
            this.dataGridPesquisa.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridPesquisa.Columns[1].Name = "NomeCliente";
            this.dataGridPesquisa.Columns[2].Name = "CpfCnpj";
            this.dataGridPesquisa.Columns[3].Name = "Endereco";
            this.dataGridPesquisa.Columns[4].Name = "Telefone";
            this.dataGridPesquisa.Columns[5].Name = "Email";
            this.dataGridPesquisa.Columns[6].Name = "CidadeID";

            DefinirFonteeCores();

            // Hide the column that contains the content that spans
            // multiple columns.
            //this.dataGridPesquisa.Columns[2].Visible = false;
        }
        private void CarregaDados()
        {
            FrmCadCliente cadCliente = new FrmCadCliente();

            try
            {
                if (StatusOperacao == "NOVO")
                {
                    cadCliente.Text = "SISCONTROL - NOVO CADASTRO DE USUÁRIO";
                    cadCliente.StatusOperacao = "NOVO";
                    cadCliente.ShowDialog();
                    
                    ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                }
                if (StatusOperacao == "ALTERAR")
                {
                    cadCliente.txtClienteID.Text = dataGridPesquisa.CurrentRow.Cells["ClienteID"].Value.ToString();
                    cadCliente.txtNomeCliente.Text = dataGridPesquisa.CurrentRow.Cells["NomeCliente"].Value.ToString();
                    cadCliente.txtCpfCnpj.Text = dataGridPesquisa.CurrentRow.Cells["CpfCnpj"].Value.ToString();
                    cadCliente.txtEndereco.Text = dataGridPesquisa.CurrentRow.Cells["Endereco"].Value.ToString();
                    cadCliente.txtTelefone.Text = dataGridPesquisa.CurrentRow.Cells["Telefone"].Value.ToString();
                    cadCliente.txtEmail.Text = dataGridPesquisa.CurrentRow.Cells["Email"].Value.ToString();
                    cadCliente.txtCidadeID.Text = dataGridPesquisa.CurrentRow.Cells["CidadeID"].Value.ToString();

                    cadCliente.Text = "SISCONTROL - ALTERAR REGISTRO";
                    cadCliente.StatusOperacao = "ALTERAR";
                   cadCliente.btnSalvar.Text = "Alterar";
                   cadCliente.btnNovo.Enabled = false;
                   cadCliente.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                   cadCliente.btnSalvar.Image = Properties.Resources.Alterar;
                    cadCliente.ShowDialog();
                    ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                }
                if (StatusOperacao == "EXCLUSÃO")
                {
                    cadCliente.txtClienteID.Text = dataGridPesquisa.CurrentRow.Cells["ClienteID"].Value.ToString();
                    cadCliente.txtNomeCliente.Text = dataGridPesquisa.CurrentRow.Cells["NomeCliente"].Value.ToString();
                    cadCliente.txtCpfCnpj.Text = dataGridPesquisa.CurrentRow.Cells["CpfCnpj"].Value.ToString();
                    cadCliente.txtEndereco.Text = dataGridPesquisa.CurrentRow.Cells["Endereco"].Value.ToString();
                    cadCliente.txtTelefone.Text = dataGridPesquisa.CurrentRow.Cells["Telefone"].Value.ToString();
                    cadCliente.txtEmail.Text = dataGridPesquisa.CurrentRow.Cells["Email"].Value.ToString();
                    cadCliente.txtCidadeID.Text = dataGridPesquisa.CurrentRow.Cells["CidadeID"].Value.ToString();

                    cadCliente.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                    cadCliente.StatusOperacao = "EXCLUSÃO";
                    cadCliente.btnSalvar.Text = "Excluir";
                    cadCliente.btnNovo.Enabled = false;
                    cadCliente.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                    cadCliente.btnSalvar.Image = Properties.Resources.Excluir2;

                    cadCliente.txtClienteID.Enabled = false;
                    cadCliente.txtNomeCliente.Enabled = false;
                    cadCliente.txtCpfCnpj.Enabled = false;
                    cadCliente.txtEndereco.Enabled = false;
                    cadCliente.txtTelefone.Enabled = false;
                    cadCliente.txtEmail.Enabled = false;
                    cadCliente.txtCidadeID.Enabled = false;

                    cadCliente.ShowDialog();
                    ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                }
                ListarCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro..." + ex.Message);
            }
            ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //LISTAR();
            timer1.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
