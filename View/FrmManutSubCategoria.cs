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
                cadSubCategoria.StatusOperacao = "NOVO";
                cadSubCategoria.ShowDialog();
                
                ((FrmManutSubCategoria)Application.OpenForms["FrmManutSubCategoria"]).HabilitarTimer(true);
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
                    foreach (DataGridViewRow row in dataGridPesquisa.Rows)
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadSubCategoria.txtSubCatID.Text = dataGridPesquisa.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadSubCategoria.txtNomeSubCat.Text = dataGridPesquisa.CurrentRow.Cells["NomeCategoria"].Value.ToString();
                        cadSubCategoria.Text = "SISCONTROL - ALTERAR REGISTRO";
                        cadSubCategoria.StatusOperacao = "ALTERAR";
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
                    if (dataGridPesquisa.Rows.Count == 0)
                    {
                        // Lançar exceção personalizada
                        //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                        MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }

                    // Execução do código desejado
                    foreach (DataGridViewRow row in dataGridPesquisa.Rows)
                    {
                        // Exemplo: Acessar a primeira célula de cada linha
                        //  var valor = row.Cells[0].Value;
                        cadSubCategoria.txtSubCatID.Text = dataGridPesquisa.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadSubCategoria.txtNomeSubCat.Text = dataGridPesquisa.CurrentRow.Cells["NomeCategoria"].Value.ToString();
                        cadSubCategoria.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                        cadSubCategoria.StatusOperacao = "EXCLUSÃO";
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
            this.dataGridPesquisa.Columns[0].Name = "CategoriaID";
            this.dataGridPesquisa.Columns[1].Name = "NomeCategoria";

            DefinirFonteeCores();

            // Hide the column that contains the content that spans
            // multiple columns.
            //this.dataGridPesquisa.Columns[2].Visible = false;
        }
        private void DefinirFonteeCores()
        {
            this.dataGridPesquisa.DefaultCellStyle.Font = new Font("Tahoma", 9);
            this.dataGridPesquisa.DefaultCellStyle.ForeColor = Color.Blue;
            this.dataGridPesquisa.DefaultCellStyle.BackColor = Color.Beige;
            this.dataGridPesquisa.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            this.dataGridPesquisa.DefaultCellStyle.SelectionBackColor = Color.Black;
        }
        public void ListarSubCategoria()
        {
            SubCategoriaBLL suBcategoriaBll = new SubCategoriaBLL();
            dataGridPesquisa.DataSource = suBcategoriaBll.Listar();
            PersonalizarDatagridView();
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

            dataGridPesquisa.DataSource = CategoriaDao.PesquisarPorNome(nome);
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
