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
        private new string StatusOperacao;
        public FrmManutFornecedor( string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();
        }
        private void CarregaDados()
        {
            FrmCadFornecedor frm = new FrmCadFornecedor(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                frm.Text = "SISCONTROL - NOVO CADASTRO DE FORNECEDOR";                
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
                    StatusOperacao = "ALTERAR";
                    
                    frm.btnNovo.Enabled = false;
                  
                    frm.ShowDialog();                   
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
                    StatusOperacao = "EXCLUSÃO";
                   
                    frm.btnNovo.Enabled = false;
                   

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
           
            //Alinhar o as colunas

            dgv.Columns["FornecedorID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgv.Columns["CidadeID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                       

            this.dataGridPesquisar.Columns[0].Name = "FornecedorID"   ;
            this.dataGridPesquisar.Columns[1].Name = "NomeFornecedor" ;
            this.dataGridPesquisar.Columns[2].Name = "Cnpj"           ;
            this.dataGridPesquisar.Columns[3].Name = "Endereco"        ;
            this.dataGridPesquisar.Columns[4].Name = "Telefone"           ;
            this.dataGridPesquisar.Columns[5].Name = "Email"          ;
            this.dataGridPesquisar.Columns[6].Name = "CidadeID"            ;
            this.dataGridPesquisar.Columns[7].Name = "NomeCidade"          ;

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
