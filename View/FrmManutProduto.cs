using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmManutProduto : SisControl.FrmBaseManutencao
    {
        public FrmManutProduto()
        {
            InitializeComponent();
        }
        private void CarregaDados()
        {
            FrmCadCliente cadCliente = new FrmCadCliente();

            if (StatusOperacao == "NOVO")
            {
                cadCliente.Text = "SISCONTROL - NOVO CADASTRO DE CLIENTE";
                cadCliente.StatusOperacao = "NOVO";
                cadCliente.ShowDialog();

                //((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
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
                    else
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadCliente.txtClienteID.Text = dataGridPesquisa.CurrentRow.Cells["ClienteID"].Value.ToString();
                        cadCliente.txtNomeCliente.Text = dataGridPesquisa.CurrentRow.Cells["NomeCliente"].Value.ToString();
                        cadCliente.txtCpfCnpj.Text = dataGridPesquisa.CurrentRow.Cells["CpfCnpj"].Value.ToString();
                        cadCliente.txtEndereco.Text = dataGridPesquisa.CurrentRow.Cells["Endereco"].Value.ToString();
                        cadCliente.txtTelefone.Text = dataGridPesquisa.CurrentRow.Cells["Telefone"].Value.ToString();
                        cadCliente.txtEmail.Text = dataGridPesquisa.CurrentRow.Cells["Email"].Value.ToString();
                        cadCliente.txtCidadeID.Text = dataGridPesquisa.CurrentRow.Cells["CidadeID"].Value.ToString();
                        cadCliente.txtNomeCidade.Text = dataGridPesquisa.CurrentRow.Cells["Expr1"].Value.ToString();
                        //cadCliente.tx.Text = dataGridPesquisa.CurrentRow.Cells["EstadoID"].Value.ToString();

                        cadCliente.Text = "SISCONTROL - ALTERAR REGISTRO";
                        cadCliente.StatusOperacao = "ALTERAR";
                        cadCliente.btnSalvar.Text = "Alterar";
                        cadCliente.btnNovo.Enabled = false;
                        cadCliente.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        cadCliente.btnSalvar.Image = Properties.Resources.Alterar;
                        cadCliente.ShowDialog();
                        ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                    }

                    //// Execução do código desejado
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
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadCliente.txtClienteID.Text = dataGridPesquisa.CurrentRow.Cells["ClienteID"].Value.ToString();
                        cadCliente.txtNomeCliente.Text = dataGridPesquisa.CurrentRow.Cells["NomeCliente"].Value.ToString();
                        cadCliente.txtCpfCnpj.Text = dataGridPesquisa.CurrentRow.Cells["CpfCnpj"].Value.ToString();
                        cadCliente.txtEndereco.Text = dataGridPesquisa.CurrentRow.Cells["Endereco"].Value.ToString();
                        cadCliente.txtTelefone.Text = dataGridPesquisa.CurrentRow.Cells["Telefone"].Value.ToString();
                        cadCliente.txtEmail.Text = dataGridPesquisa.CurrentRow.Cells["Email"].Value.ToString();
                        cadCliente.txtCidadeID.Text = dataGridPesquisa.CurrentRow.Cells["CidadeID"].Value.ToString();
                        cadCliente.txtNomeCidade.Text = dataGridPesquisa.CurrentRow.Cells["Expr1"].Value.ToString();

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
                        cadCliente.txtNomeCidade.Enabled = false;
                        cadCliente.txtEstadoCliente.Enabled = false;
                        cadCliente.btnLocalizar.Enabled = false;

                        cadCliente.ShowDialog();
                        ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                    }
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
        private void txtPesquisa_TextChanged(object sender, EventArgs e)
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
