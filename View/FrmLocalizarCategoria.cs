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
    public partial class FrmLocalizarCategoria : SisControl.FrmBasePesquisa
    {
        protected int LinhaAtual = -1;
        public FrmLocalizarCategoria()
        {
            InitializeComponent();
        }
        public new int ObterLinhaAtual()
        {
            return LinhaAtual;
        }
        private void InicializaDataGridView()
        {
            // Inicializar propriedades básicas do DataGridView.         
            // dataGridPesquisa.BackgroundColor = Color.LightGray;
            //dataGridPesquisa.BorderStyle = BorderStyle.Fixed3D;

            dataGridPesquisar.MultiSelect = false;

            //Configuração das linhas do DataGridView

            //Cores alternadas no DataGridView
            dataGridPesquisar.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisar.Columns[0].Width = 100;
            dataGridPesquisar.Columns[1].Width = 660;
           

            //Renomeia as colunas do DataGridView 
            dataGridPesquisar.Columns[0].HeaderText = "CategoriaID";
            dataGridPesquisar.Columns[1].HeaderText = "NomeCategoria";
           
        }
        public void ListarCategoria()
        {
            CategoriaDALL CategoriaDao = new CategoriaDALL();
            dataGridPesquisar.DataSource = CategoriaDao.PesquisarGeral();

            //InicializaDataGridView();
        }
        private void FrmLocalizarCategoria_Load(object sender, EventArgs e)
        {
            ListarCategoria();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            CategoriaDALL CategoriaDao = new CategoriaDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisar.DataSource = CategoriaDao.PesquisarPorCodigo(nome);
            }
            else
            {
                dataGridPesquisar.DataSource = CategoriaDao.PesquisarPorNome(nome);
            }
        }
        private void ExemploDataGridView()
        {
           
        }

        private void FrmLocalizarCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmCadSubCategoria FrmCadSubCat = new FrmCadSubCategoria();

            try
            {
                // Verificar se a DataGridView contém alguma linha
                if (dataGridPesquisar.Rows.Count == 0)
                {
                    // Lançar exceção personalizada
                    //throw new Exception("A DataGridView está vazia. Não há dados para serem processados.");
                    MessageBox.Show("A DataGridView está vazia. Não há dados para serem processados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtPesquisa.Focus();
                    txtPesquisa.Text = string.Empty;
                }

                // Execução do código desejado
                foreach (DataGridViewRow row in dataGridPesquisar.Rows)
                {
                    // Exemplo: Acessar a primeira célula de cada linha
                    //  var valor = row.Cells[0].Value;
                    LinhaAtual = dataGridPesquisar.CurrentRow.Index;
                    //((FrmVendas)Application.OpenForms["FrmVendas"]).txtIdCliente.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();
                    ((FrmCadSubCategoria)Application.OpenForms["FrmCadSubCategoria"]).txtCategoriaID.Text = dataGridPesquisar[0, LinhaAtual].Value.ToString();
                    ((FrmCadSubCategoria)Application.OpenForms["FrmCadSubCategoria"]).txtNomeCategoria.Text = dataGridPesquisar[1, LinhaAtual].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                // Exibir uma mensagem de erro para o usuário
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void FrmLocalizarCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
        }
    }
}
