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
    public partial class FrmManutCategoria : SisControl.FrmBaseManutencao
    {
        public FrmManutCategoria()
        {
            InitializeComponent();
        }
        private void CarregaDados()
        {
            FrmCadCategoria cadCategoria = new FrmCadCategoria();

            if (StatusOperacao == "NOVO")
            {
                cadCategoria.Text = "SISCONTROL - NOVO CADASTRO DE CATEGORIA";
                cadCategoria.StatusOperacao = "NOVO";
                cadCategoria.ShowDialog();

                ((FrmManutCategoria)Application.OpenForms["FrmManutCategoria"]).HabilitarTimer(true);
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
                        cadCategoria.txtCodigo.Text = dataGridPesquisa.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadCategoria.txtNome.Text = dataGridPesquisa.CurrentRow.Cells["NomeCategoria"].Value.ToString();

                        cadCategoria.Text = "SISCONTROL - ALTERAR REGISTRO";
                        cadCategoria.StatusOperacao = "ALTERAR";
                        cadCategoria.btnSalvar.Text = "Alterar";
                        cadCategoria.btnNovo.Enabled = false;
                        cadCategoria.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        cadCategoria.btnSalvar.Image = Properties.Resources.Alterar;
                        cadCategoria.ShowDialog();
                        ((FrmManutCategoria)Application.OpenForms["FrmManutCategoria"]).HabilitarTimer(true);

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
                        cadCategoria.txtCodigo.Text = dataGridPesquisa.CurrentRow.Cells["CategoriaID"].Value.ToString();
                        cadCategoria.txtNome.Text = dataGridPesquisa.CurrentRow.Cells["NomeCategoria"].Value.ToString();

                        cadCategoria.Text = "SISCONTROL - EXCLUSÃO DE REGISTRO";
                        cadCategoria.StatusOperacao = "EXCLUSÃO";
                        cadCategoria.btnSalvar.Text = "Excluir";
                        cadCategoria.btnNovo.Enabled = false;
                        cadCategoria.btnSalvar.TextAlign = ContentAlignment.MiddleRight;//AlinhamentoDeConteúdo.MiddleLeft; =  StringAlignment
                        cadCategoria.btnSalvar.Image = Properties.Resources.Excluir2;

                        cadCategoria.txtCodigo.Enabled = false;
                        cadCategoria.txtNome.Enabled = false;

                        cadCategoria.ShowDialog();
                        ((FrmManutCategoria)Application.OpenForms["FrmManutCategoria"]).HabilitarTimer(true);

                    }
                }
                catch (Exception ex)
                {
                    // Exibir uma mensagem de erro para o usuário
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
            }
            ListarCategoria();

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
        public void ListarCategoria()
        {
            CategoriaBLL categoriaBll = new CategoriaBLL();
            dataGridPesquisa.DataSource = categoriaBll.Listar();
            PersonalizarDatagridView();
        }
        private void FrmManutCategoria_Load(object sender, EventArgs e)
        {
            ListarCategoria();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            CategoriaDALL CategoriaDao = new CategoriaDALL();

            dataGridPesquisa.DataSource = CategoriaDao.PesquisarPorNome(nome);
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
        }
        public void HabilitarTimer(bool habilitar)
        {
            timer1.Enabled = habilitar;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarCategoria();
            timer1.Enabled = false;
        }
    }
}
