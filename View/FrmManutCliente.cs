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
    public partial class FrmManutCliente : SisControl.FrmBaseManutencao
    {
        public FrmManutCliente()
        {
            InitializeComponent();
        }
        public void ListarCliente()
        {
            ClienteBLL objetoBll = new ClienteBLL();
            dataGridPesquisa.DataSource = objetoBll.Listar();
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

            
            this.dataGridPesquisa.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            this.dataGridPesquisa.Columns[0].Name = "ClienteID";
            this.dataGridPesquisa.Columns[1].Name = "NomeCliente";
            this.dataGridPesquisa.Columns[2].Name = "CpfCnpj";
            this.dataGridPesquisa.Columns[3].Name = "Endereco";
            this.dataGridPesquisa.Columns[4].Name = "Telefone";
            this.dataGridPesquisa.Columns[5].Name = "Email";
            this.dataGridPesquisa.Columns[6].Name = "CidadeID";
            this.dataGridPesquisa.Columns[7].Name = "Expr1";
            this.dataGridPesquisa.Columns[8].Name = "EstadoID";
            

            DefinirFonteeCores();

            // Hide the column that contains the content that spans
            // multiple columns.
            //this.dataGridPesquisa.Columns[2].Visible = false;
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
            ListarCliente();
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
            ListarCliente();
            timer1.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {            
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            ClienteDALL clienteDao = new ClienteDALL();

            dataGridPesquisa.DataSource = clienteDao.PesquisarPorNome(nome);
            PersonalizarDatagridView();
        }

        private void FrmManutCliente_Load(object sender, EventArgs e)
        {
            ListarCliente();
        }
    }
}
