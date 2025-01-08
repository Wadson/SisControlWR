using SisControl.BLL;
using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmManutFornecedor : SisControl.FrmBaseManutencao
    {
        public FrmManutFornecedor()
        {
            InitializeComponent();
        }
        private void CarregaDados()
        {
            FrmCadFornecedor frm = new FrmCadFornecedor();

            if (StatusOperacao == "NOVO")
            {
                frm.Text = "SISCONTROL - NOVO CADASTRO DE FORNECEDOR";
                frm.StatusOperacao = "NOVO";
                frm.ShowDialog();
            }
            if (StatusOperacao == "ALTERAR")
            {
                try
                {
                    // Verificar se a DataGridView contém alguma linha
                    if (dataGridPesquisa.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // Execução do código desejado

                    frm.txtFornecedorID.Text = dataGridPesquisa.CurrentRow.Cells["FornecedorID"].Value.ToString();
                    frm.txtNomeFornecedor.Text = dataGridPesquisa.CurrentRow.Cells["NomeFornecedor"].Value.ToString();
                    frm.txtCnpjCpf.Text = dataGridPesquisa.CurrentRow.Cells["Cnpj"].Value.ToString();
                    frm.txtEndereco.Text = dataGridPesquisa.CurrentRow.Cells["Endereco"].Value.ToString();
                    frm.txtTelefone.Text = dataGridPesquisa.CurrentRow.Cells["Telefone"].Value.ToString();
                    frm.txtNomeCidade.Text = dataGridPesquisa.CurrentRow.Cells["NomeCidade"].Value.ToString();
                    frm.txtCidadeID.Text = dataGridPesquisa.CurrentRow.Cells["CidadeID"].Value.ToString();

                    frm.Text = "SISCONTROL - ALTERAR REGISTRO";
                    frm.StatusOperacao = "ALTERAR";
                    frm.btnSalvar.Text = "Alterar";
                    frm.btnNovo.Enabled = false;
                    frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                    frm.btnSalvar.Image = Properties.Resources.Alterar;
                    frm.ShowDialog();
                    //foreach (DataGridViewRow row in dataGridPesquisa.Rows)
                    //{
                    //    // Exemplo: Acessar a primeira célula de cada linha
                    //    //  var valor = row.Cells[0].Value;                     
                    //}
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                try
                {
                    // Verificar se a DataGridView contém alguma linha
                    if (dataGridPesquisa.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    // Exemplo: Acessar a primeira célula de cada linha
                    //  var valor = row.Cells[0].Value;
                    frm.txtFornecedorID.Text = dataGridPesquisa.CurrentRow.Cells["FornecedorID"].Value.ToString();
                    frm.txtNomeFornecedor.Text = dataGridPesquisa.CurrentRow.Cells["NomeFornecedor"].Value.ToString();
                    frm.txtCnpjCpf.Text = dataGridPesquisa.CurrentRow.Cells["Cnpj"].Value.ToString();
                    frm.txtEndereco.Text = dataGridPesquisa.CurrentRow.Cells["Endereco"].Value.ToString();
                    frm.txtTelefone.Text = dataGridPesquisa.CurrentRow.Cells["Telefone"].Value.ToString();
                    frm.txtNomeCidade.Text = dataGridPesquisa.CurrentRow.Cells["NomeCidade"].Value.ToString();
                    frm.txtCidadeID.Text = dataGridPesquisa.CurrentRow.Cells["CidadeID"].Value.ToString();
                    frm.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                    frm.StatusOperacao = "EXCLUSÃO";
                    frm.btnSalvar.Text = "Excluir";
                    frm.btnNovo.Enabled = false;
                    frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                    frm.btnSalvar.Image = Properties.Resources.Excluir2;

                    frm.txtFornecedorID.Enabled = false;
                    frm.txtNomeFornecedor.Enabled = false;
                    frm.txtCnpjCpf.Enabled = false;
                    frm.txtEndereco.Enabled = false;
                    frm.txtTelefone.Enabled = false;
                    frm.ShowDialog();
                    // Execução do código desejado
                    //foreach (DataGridViewRow row in dataGridPesquisa.Rows)
                    //{

                    //}
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
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
            //this.dataGridPesquisa.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridPesquisa.Columns[0].Name = "FornecedorID";
            this.dataGridPesquisa.Columns[1].Name = "NomeFornecedor";
            this.dataGridPesquisa.Columns[2].Name = "Cnpj";
            this.dataGridPesquisa.Columns[3].Name = "Endereco";
            this.dataGridPesquisa.Columns[4].Name = "Telefone";
            this.dataGridPesquisa.Columns[5].Name = "Email";
            this.dataGridPesquisa.Columns[6].Name = "CidadeID";
            this.dataGridPesquisa.Columns[7].Name = "NomeCidade";
                       

            DefinirFonteeCores();
        }
        private void DefinirFonteeCores()
        {
            this.dataGridPesquisa.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.dataGridPesquisa.DefaultCellStyle.ForeColor = Color.Blue;
            this.dataGridPesquisa.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridPesquisa.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dataGridPesquisa.DefaultCellStyle.SelectionBackColor = Color.Black;
        }
        public void ListarFornecedor()
        {
            FornecedorBLL objetoBll = new FornecedorBLL();
            dataGridPesquisa.DataSource = objetoBll.Listar();
            PersonalizarDatagridView();
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
        private void FrmManutCategoria_Load(object sender, EventArgs e)
        {
            ListarFornecedor();
        }
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            FornecedorDALL fornecedorDAL = new FornecedorDALL();

            dataGridPesquisa.DataSource = fornecedorDAL.PesquisarPorNome(nome);
        }

        private void FrmManutFornecedor_Load(object sender, EventArgs e)
        {
            ListarFornecedor();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarFornecedor();
            timer1.Enabled = false;
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            StatusOperacao = "EXCLUSÃO";
            CarregaDados();
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            StatusOperacao = "ALTERAR";
            CarregaDados();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            StatusOperacao = "NOVO";
            CarregaDados();
        }
    }
}
