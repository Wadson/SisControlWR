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
                    if (dataGridPesquisar.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    // Execução do código desejado

                    frm.txtFornecedorID.Text = dataGridPesquisar.CurrentRow.Cells["FornecedorID"].Value.ToString();
                    frm.txtNomeFornecedor.Text = dataGridPesquisar.CurrentRow.Cells["NomeFornecedor"].Value.ToString();
                    frm.txtCnpjCpf.Text = dataGridPesquisar.CurrentRow.Cells["Cnpj"].Value.ToString();
                    frm.txtEndereco.Text = dataGridPesquisar.CurrentRow.Cells["Endereco"].Value.ToString();
                    frm.txtTelefone.Text = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();
                    frm.txtEmail.Text = dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                    frm.txtNomeCidade.Text = dataGridPesquisar.CurrentRow.Cells["NomeCidade"].Value.ToString();
                    frm.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();

                    frm.Text = "SISCONTROL - ALTERAR REGISTRO";
                    frm.StatusOperacao = "ALTERAR";
                    frm.btnSalvar.Text = "Alterar";
                    frm.btnNovo.Enabled = false;
                    frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                    frm.btnSalvar.Image = Properties.Resources.Alterar;
                    frm.ShowDialog();
                    //foreach (DataGridViewRow row in dataGridPesquisar.Rows)
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
                    if (dataGridPesquisar.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    // Exemplo: Acessar a primeira célula de cada linha
                    //  var valor = row.Cells[0].Value;
                    frm.txtFornecedorID.Text = dataGridPesquisar.CurrentRow.Cells["FornecedorID"].Value.ToString();
                    frm.txtNomeFornecedor.Text = dataGridPesquisar.CurrentRow.Cells["NomeFornecedor"].Value.ToString();
                    frm.txtCnpjCpf.Text = dataGridPesquisar.CurrentRow.Cells["Cnpj"].Value.ToString();
                    frm.txtEndereco.Text = dataGridPesquisar.CurrentRow.Cells["Endereco"].Value.ToString();
                    frm.txtTelefone.Text = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();
                    frm.txtEmail.Text = dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                    frm.txtNomeCidade.Text = dataGridPesquisar.CurrentRow.Cells["NomeCidade"].Value.ToString();
                    frm.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
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
                    //foreach (DataGridViewRow row in dataGridPesquisar.Rows)
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
       
        public void PersonalizarDataGridView(DataGridView dgv)
        {
            // Configuração dos cabeçalhos das colunas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false; // Necessário para aplicar as cores personalizadas no cabeçalho

            // Estilo alternado das linhas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Alinhamento e fonte das células
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = new Font("Arial", 10);

            //Alinhar o as colunas

            //dataGridPesquisar.Columns["ProdutoID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            //dataGridPesquisar.Columns["Estoque"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

            // Ajustar colunas automaticamente
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

            this.dataGridPesquisar.Columns[0].Name = "FornecedorID";
            this.dataGridPesquisar.Columns[1].Name = "NomeFornecedor";
            this.dataGridPesquisar.Columns[2].Name = "Cnpj";
            this.dataGridPesquisar.Columns[3].Name = "Endereco";
            this.dataGridPesquisar.Columns[4].Name = "Telefone";
            this.dataGridPesquisar.Columns[5].Name = "Email";
            this.dataGridPesquisar.Columns[6].Name = "CidadeID";
            this.dataGridPesquisar.Columns[7].Name = "NomeCidade";
        }
        public void ListarFornecedor()
        {
            FornecedorBLL objetoBll = new FornecedorBLL();
            dataGridPesquisar.DataSource = objetoBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
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

            dataGridPesquisar.DataSource = fornecedorDAL.PesquisarPorNome(nome);
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
