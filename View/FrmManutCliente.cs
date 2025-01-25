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
        private new string StatusOperacao;
        public FrmManutCliente(string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();
        }
        public void ListarCliente()
        {
            ClienteBLL objetoBll = new ClienteBLL();
            dataGridPesquisar.DataSource = objetoBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
        public void PersonalizarDataGridView(DataGridView dgv)
        {
            //// Ajustar colunas automaticamente
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tornar o grid somente leitura
            dgv.ReadOnly = true;

            //// Estilo das bordas das células
            //dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            //// Estilo da seleção das células
            //dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            //dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            ////dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgv.MultiSelect = false;
            //// Esconder a coluna de cabeçalho de linha
            ////dgv.RowHeadersVisible = false;

            // Cor do grid
            //dgv.GridColor = Color.Black;

            this.dataGridPesquisar.Columns[0].Name = "ClienteID"   ;
            this.dataGridPesquisar.Columns[1].Name = "NomeCliente" ;
            this.dataGridPesquisar.Columns[2].Name = "Cpf"         ;
            this.dataGridPesquisar.Columns[3].Name = "Endereco"      ;
            this.dataGridPesquisar.Columns[4].Name = "Telefone"    ;
            this.dataGridPesquisar.Columns[5].Name = "Email"        ;
            this.dataGridPesquisar.Columns[6].Name = "CidadeID"     ;
            this.dataGridPesquisar.Columns[7].Name = "NomeCidade"         ;
            this.dataGridPesquisar.Columns[8].Name = "NomeEstado"        ;           
           
        }
      
        private void CarregaDados()
        {
            FrmCadCliente cadCliente = new FrmCadCliente(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                cadCliente.Text = "SISCONTROL - NOVO CADASTRO DE CLIENTE";
                StatusOperacao = "NOVO";
                cadCliente.ShowDialog();

                ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
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
                    else
                    {
                        // Exemplo: Acessar a primeira célula de cada linha                        
                        cadCliente.txtClienteID.Text = dataGridPesquisar.CurrentRow.Cells["ClienteID"].Value.ToString();
                        cadCliente.txtNomeCliente.Text = dataGridPesquisar.CurrentRow.Cells["NomeCliente"].Value.ToString();
                        cadCliente.txtCpf.Text = dataGridPesquisar.CurrentRow.Cells["Cpf"].Value.ToString();
                        cadCliente.txtEndereco.Text = dataGridPesquisar.CurrentRow.Cells["Endereco"].Value.ToString();
                        cadCliente.txtTelefone.Text = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();
                        cadCliente.txtEmail.Text = dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                        cadCliente.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
                        cadCliente.txtNomeCidade.Text = dataGridPesquisar.CurrentRow.Cells["NomeCidade"].Value.ToString();
                        cadCliente.txtEstadoCliente.Text = dataGridPesquisar.CurrentRow.Cells["NomeEstado"].Value.ToString();
                        cadCliente.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
                        
                        
                        

                        cadCliente.Text = "SISCONTROL - ALTERAR REGISTRO";
                        StatusOperacao = "ALTERAR";
                        cadCliente.btnSalvar.Text = "Alterar";
                        cadCliente.btnNovo.Enabled = false;
                      
                        cadCliente.ShowDialog();
                        ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                    }
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
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadCliente.txtClienteID.Text = dataGridPesquisar.CurrentRow.Cells["ClienteID"].Value.ToString();
                        cadCliente.txtNomeCliente.Text = dataGridPesquisar.CurrentRow.Cells["NomeCliente"].Value.ToString();
                        cadCliente.txtCpf.Text = dataGridPesquisar.CurrentRow.Cells["Cpf"].Value.ToString();
                        cadCliente.txtEndereco.Text = dataGridPesquisar.CurrentRow.Cells["Endereco"].Value.ToString();
                        cadCliente.txtTelefone.Text = dataGridPesquisar.CurrentRow.Cells["Telefone"].Value.ToString();
                        cadCliente.txtEmail.Text = dataGridPesquisar.CurrentRow.Cells["Email"].Value.ToString();
                        cadCliente.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();
                        cadCliente.txtNomeCidade.Text = dataGridPesquisar.CurrentRow.Cells["NomeCidade"].Value.ToString();
                        cadCliente.txtEstadoCliente.Text = dataGridPesquisar.CurrentRow.Cells["NomeEstado"].Value.ToString();
                        cadCliente.txtCidadeID.Text = dataGridPesquisar.CurrentRow.Cells["CidadeID"].Value.ToString();

                        cadCliente.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                        StatusOperacao = "EXCLUSÃO";
                        cadCliente.btnSalvar.Text = "Excluir";
                        cadCliente.btnNovo.Enabled = false;
                       

                        cadCliente.txtClienteID.Enabled = false;
                        cadCliente.txtNomeCliente.Enabled = false;
                        cadCliente.txtCpf.Enabled = false;
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

            dataGridPesquisar.DataSource = clienteDao.PesquisarPorNome(nome);
            PersonalizarDataGridView(dataGridPesquisar);
        }

        private void FrmManutCliente_Load(object sender, EventArgs e)
        {
            ListarCliente();
        }
    }
}
