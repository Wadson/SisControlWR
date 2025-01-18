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
    public partial class FrmLocalizarProduto : SisControl.FrmBasePesquisa
    {
        private string _ClienteID;
        protected int LinhaAtual = -1;

        private int ProdutoID;
        private string NomeProduto;
        private decimal PrecoUnitario;
        public Form FormChamador { get; set; }        

        public FrmLocalizarProduto()
        {
            InitializeComponent();

            // Configurar o TextBox
            // Configurar o TextBox para capturar o evento KeyDown
            txtPesquisa.KeyDown += new KeyEventHandler(dataGridPesquisar_KeyDown);

            // Configurar o DataGridView (apenas exemplo, configure conforme necessário)
            dataGridPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public new int ObterLinhaAtual()
        {
            return LinhaAtual;
        }
        public void PersonalizarDataGridView(DataGridView dgv)
        {

            // Inicializar propriedades básicas do DataGridView.         
            // dataGridPesquisa.BackgroundColor = Color.LightGray;
            //dataGridPesquisa.BorderStyle = BorderStyle.Fixed3D;

            dataGridPesquisar.MultiSelect = false;

            //Configuração das linhas do DataGridView

            //Cores alternadas no DataGridView
            dataGridPesquisar.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
           
        }
        public void ListarProduto()
        {
            ProdutoBLL objetoBll = new ProdutoBLL();
            dataGridPesquisar.DataSource = objetoBll.Listar();
            PersonalizarDataGridView(dataGridPesquisar);
        }
        private void FrmLocalizarProduto_Load(object sender, EventArgs e)
        {
            ListarProduto();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            ProdutosDALL dao = new ProdutosDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorCodigo(nome);
            }
            else
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
            }
        }

        private void FrmLocalizarProduto_FormClosing(object sender, FormClosingEventArgs e)
        {
            SelecionarProduto();
        }

        // No FrmLocalizarProduto, após selecionar o produto e fechar o formulário
        private bool isSelectingProduct = false;

        private void SelecionarProduto()
        {
            if (isSelectingProduct) return;
            isSelectingProduct = true;

            try
            {
                // Supondo que você tenha os dados do produto selecionado em variáveis
                LinhaAtual = ObterLinhaAtual();

                ProdutoID = Convert.ToInt32(dataGridPesquisar["ProdutoID", LinhaAtual].Value);

                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(ProdutoID, 4);
                NomeProduto = dataGridPesquisar["NomeProduto", LinhaAtual].Value.ToString();
                PrecoUnitario = Convert.ToDecimal(dataGridPesquisar["PrecoVenda", LinhaAtual].Value);


                // Cria uma instância do FrmVendas (ou usa uma existente)
                FrmVendas frmVendas = (FrmVendas)this.Owner;

                // Preenche os campos no FrmVendas
                ((FrmVendas)Application.OpenForms["FrmVendas"]).txtProdutoID.Text = numeroComZeros;
                ((FrmVendas)Application.OpenForms["FrmVendas"]).txtNomeProduto.Text = dataGridPesquisar["NomeProduto", LinhaAtual].Value.ToString();
                ((FrmVendas)Application.OpenForms["FrmVendas"]).txtValorProduto.Text = dataGridPesquisar["PrecoVenda", LinhaAtual].Value.ToString();
                ((FrmVendas)Application.OpenForms["FrmVendas"]).txtQuantidade.Text = "1";

                // Calcula o subtotal
                frmVendas.CalcularSubtotal();

                // Fecha o FrmLocalizarProduto
                this.Close();
            }
            finally
            {
                isSelectingProduct = false;
            }
        }
        private void dataGridPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a linha clicada é válida
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridPesquisar.Rows[e.RowIndex];
                string produtoId = row.Cells["ProdutoID"].Value.ToString();
                string nomeProduto = row.Cells["NomeProduto"].Value.ToString();
                string precoUnitario = row.Cells["PrecoUnitario"].Value.ToString();

                // Obter a instância do FrmVendas (Owner)
                if (this.Owner is FrmVendas frmVendas)
                {
                    // Preencher os campos do FrmVendas
                    frmVendas.txtProdutoID.Text = produtoId;
                    frmVendas.txtNomeProduto.Text = nomeProduto;
                    frmVendas.txtValorProduto.Text = precoUnitario;
                    frmVendas.txtQuantidade.Text = "1"; // Define a quantidade padrão como 1

                    // Calcular o subtotal
                    frmVendas.CalcularSubtotal();
                }

                // Fecha o FrmLocalizarProduto
                this.Close();
            }
        }

        private void dataGridPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
            // Verifica se a tecla pressionada foi a seta para baixo
            if (e.KeyCode == Keys.Down)
            {
                // Move o foco para o DataGridView
                dataGridPesquisar.Focus();

                // Seleciona a primeira linha se houver linhas
                if (dataGridPesquisar.Rows.Count > 0)
                {
                    dataGridPesquisar.ClearSelection();
                    dataGridPesquisar.Rows[0].Selected = true;
                }
            }
        }

        private void dataGridPesquisar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
        }
    }
}
