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
    public partial class FrmManutSubCategoria : SisControl.FrmBaseManutencao
    {
        public FrmManutSubCategoria()
        {
            InitializeComponent();
        }


        private void CarregaDados()
        {
            FrmCadSubCategoria cadSubCategoria = new FrmCadSubCategoria();

            if (StatusOperacao == "NOVO")
            {
                cadSubCategoria.Text = "SISCONTROL - NOVO CADASTRO DE SUBCATEGORIA";
                StatusOperacao = "NOVO";
                cadSubCategoria.ShowDialog();
                
                ((FrmManutSubCategoria)Application.OpenForms["FrmManutSubCategoria"]).HabilitarTimer(true);
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
                    foreach (DataGridViewRow row in dataGridPesquisar.Rows)
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadSubCategoria.txtSubCatID.Text = dataGridPesquisar.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadSubCategoria.txtNomeSubCat.Text = dataGridPesquisar.CurrentRow.Cells["NomeCategoria"].Value.ToString();
                        cadSubCategoria.Text = "SISCONTROL - ALTERAR REGISTRO";
                        StatusOperacao = "ALTERAR";
                        cadSubCategoria.btnSalvar.Text = "Alterar";
                        cadSubCategoria.btnNovo.Enabled = false;
                        cadSubCategoria.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        cadSubCategoria.btnSalvar.Image = Properties.Resources.Alterar;
                        cadSubCategoria.ShowDialog();
                        ((FrmManutSubCategoria)Application.OpenForms["FrmManutSubCategoria"]).HabilitarTimer(true);

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

                    // Execução do código desejado
                    foreach (DataGridViewRow row in dataGridPesquisar.Rows)
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadSubCategoria.txtSubCatID.Text = dataGridPesquisar.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadSubCategoria.txtNomeSubCat.Text = dataGridPesquisar.CurrentRow.Cells["NomeCategoria"].Value.ToString();
                        cadSubCategoria.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                        StatusOperacao = "EXCLUSÃO";
                        cadSubCategoria.btnSalvar.Text = "Excluir";
                        cadSubCategoria.btnNovo.Enabled = false;
                        cadSubCategoria.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        cadSubCategoria.btnSalvar.Image = Properties.Resources.Excluir2;
                        cadSubCategoria.txtSubCatID.Enabled = false;
                        cadSubCategoria.txtNomeSubCat.Enabled = false;
                        cadSubCategoria.ShowDialog();
                        ((FrmManutSubCategoria)Application.OpenForms["FrmManutSubCategoria"]).HabilitarTimer(true);

                    }
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            ListarSubCategoria();

            //try
            //{

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Erro..." + ex.Message);
            //}

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

            this.dataGridPesquisar.Columns[0].Name = "SubCategoriaID";
            this.dataGridPesquisar.Columns[1].Name = "NomeSubCategoria";           
        }
        public void ListarSubCategoria()
        {
            SubCategoriaBLL suBcategoriaBll = new SubCategoriaBLL();
            dataGridPesquisar.DataSource = suBcategoriaBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
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
            CategoriaDALL CategoriaDao = new CategoriaDALL();

            dataGridPesquisar.DataSource = CategoriaDao.PesquisarPorNome(nome);
        }

        private void FrmManutSubCategoria_Load(object sender, EventArgs e)
        {
            ListarSubCategoria();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarSubCategoria();
            timer1.Enabled = false;
        }
    }
}
