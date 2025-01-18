using SisControl.BLL;
using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmManutFabricante : SisControl.FrmBaseManutencao
    {
        private new string StatusOperacao;
        private FabricanteDal fabricanteDal;
        public FrmManutFabricante(string statusOperacao)
        {
            this.StatusOperacao = statusOperacao;
            InitializeComponent();
        }
        public void ListarFabricante()
        {
            FabricanteDal dao = new FabricanteDal();
            dataGridViewFabricantes.DataSource = dao.listarFabricante();

            PersonalizarDataGridView(dataGridViewFabricantes);
        }

        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
        private void Listar()
        {
            List<FabricanteModel> fabricantes = fabricanteDal.ObterTodosFabricantes();
            foreach (var fabricante in fabricantes)
            {
                dataGridViewFabricantes.Rows.Add(fabricante.FabricanteID, fabricante.NomeFabricante, fabricante.Endereco, fabricante.Telefone);
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

            this.dataGridViewFabricantes.Columns[0].Name = "FabricanteID"   ;
            this.dataGridViewFabricantes.Columns[1].Name = "NomeFabricante" ;            
            this.dataGridViewFabricantes.Columns[2].Name = "Endereco"      ;
            this.dataGridViewFabricantes.Columns[3].Name = "Telefone"    ;           
           
        }
      
        private void CarregaDados()
        {
            FrmCadFabricantes frm = new  FrmCadFabricantes(StatusOperacao);

            if (StatusOperacao == "NOVO")
            {
                frm.Text = "SISCONTROL - NOVO CADASTRO DE CLIENTE";
                StatusOperacao = "NOVO";
                frm.ShowDialog();

                ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
            }
            if (StatusOperacao == "ALTERAR")
            {
                try
                {
                    // Verificar se a DataGridView contém alguma linha
                    if (dataGridViewFabricantes.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                    else
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        frm.txtFabricanteID.Text = dataGridViewFabricantes.CurrentRow.Cells["FabricanteID"].Value.ToString();
                        frm.txtNomeFabricante.Text = dataGridViewFabricantes.CurrentRow.Cells["NomeFabricante"].Value.ToString();                        
                        frm.txtEndereco.Text = dataGridViewFabricantes.CurrentRow.Cells["Endereco"].Value.ToString();
                        frm.txtTelefone.Text = dataGridViewFabricantes.CurrentRow.Cells["Telefone"].Value.ToString();

                        frm.Text = "SISCONTROL - ALTERAR REGISTRO";
                        StatusOperacao = "ALTERAR";
                        frm.btnSalvar.Text = "Alterar";
                        frm.btnNovo.Enabled = false;
                        frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        frm.btnSalvar.Image = Properties.Resources.Alterar;
                        frm.ShowDialog();                        
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
                    if (dataGridViewFabricantes.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        frm.txtFabricanteID.Text = dataGridViewFabricantes.CurrentRow.Cells["FabricanteID"].Value.ToString();
                        frm.txtNomeFabricante.Text = dataGridViewFabricantes.CurrentRow.Cells["NomeFabricante"].Value.ToString();
                        frm.txtEndereco.Text = dataGridViewFabricantes.CurrentRow.Cells["Endereco"].Value.ToString();
                        frm.txtTelefone.Text = dataGridViewFabricantes.CurrentRow.Cells["Telefone"].Value.ToString();

                        frm.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                        StatusOperacao = "EXCLUSÃO";
                        frm.btnSalvar.Text = "Excluir";
                        frm.btnNovo.Enabled = false;
                        frm.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        frm.btnSalvar.Image = Properties.Resources.Excluir2;

                        frm.txtFabricanteID.Enabled = false;
                        frm.txtNomeFabricante.Enabled = false;
                        frm.txtEndereco.Enabled = false;                        
                        frm.txtTelefone.Enabled = false;                       

                        frm.ShowDialog();
                        ((FrmManutCliente)Application.OpenForms["FrmManutCliente"]).HabilitarTimer(true);
                    }                  
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }       
            }
            Listar();
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
            ListarFabricante();
            timer1.Enabled = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {            
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            FabricanteDal dao = new FabricanteDal();
            dataGridViewFabricantes.DataSource = dao.PesquisarPorNome(nome);
        }

        private void FrmManutCliente_Load(object sender, EventArgs e)
        {
            ListarFabricante();
        }
    }
}
