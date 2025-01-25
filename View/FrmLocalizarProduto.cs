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

        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        private decimal PrecoUnitario;
        public Form FormChamador { get; set; }        

        public FrmLocalizarProduto()
        {
            InitializeComponent();
            
            // Configurar o TextBox para capturar o evento KeyDown
            txtPesquisa.KeyDown += new KeyEventHandler(dataGridPesquisar_KeyDown);

            // Configurar o DataGridView (apenas exemplo, configure conforme necessário)
            dataGridPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void PersonalizarDataGridView(DataGridView dgv)
        {
            // Tornar o grid somente leitura
            dgv.ReadOnly = true;

            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisar.Columns[0].Width = 100;
            dataGridPesquisar.Columns[1].Width = 200;
            dataGridPesquisar.Columns[2].Width = 110;
            dataGridPesquisar.Columns[3].Width = 100;            
            dataGridPesquisar.Columns[4].Width = 130;
            dataGridPesquisar.Columns[5].Width = 100;
            dataGridPesquisar.Columns[6].Width = 110;
            dataGridPesquisar.Columns[7].Width = 110;

            //this.dataGridPesquisar.Columns[0].Name = "Cód.Prod.";
            //this.dataGridPesquisar.Columns[1].Name = "Produto";
            //this.dataGridPesquisar.Columns[2].Name = "Custo (R$)";
            //this.dataGridPesquisar.Columns[3].Name = "Lucro (R$)";
            //this.dataGridPesquisar.Columns[4].Name = "Prc. Venda  (R$)";
            //this.dataGridPesquisar.Columns[5].Name = "Estoque";
            //this.dataGridPesquisar.Columns[6].Name = "Dta Entrada";
            //this.dataGridPesquisar.Columns[7].Name = "Status";
            //this.dataGridPesquisar.Columns[8].Name = "Imagem";
            //this.dataGridPesquisar.Columns[9].Name = "Referência";

        }
        public new int ObterLinhaAtual()
        {
            return LinhaAtual;
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
            ProdutosDal dao = new ProdutosDal();

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
            // Verifica se o processo de seleção de produto já está em andamento
            if (isSelectingProduct) return;
            isSelectingProduct = true;

            try
            {
                // Obtém a linha atual selecionada na grid
                LinhaAtual = ObterLinhaAtual();
                if (LinhaAtual < 0 || LinhaAtual >= dataGridPesquisar.Rows.Count)
                {
                    // Verifica se a linha obtida é válida
                    MessageBox.Show("Linha inválida.");
                    return;
                }
                                // Verifica e obtém os valores das células NomeProduto e PrecoDeVenda
                if (dataGridPesquisar["NomeProduto", LinhaAtual]?.Value == null ||
                    dataGridPesquisar["PrecoDeVenda", LinhaAtual]?.Value == null ||
                    !decimal.TryParse(dataGridPesquisar["PrecoDeVenda", LinhaAtual].Value.ToString(), out PrecoUnitario))
                {
                    // Caso os valores não sejam válidos, exibe uma mensagem de erro
                    MessageBox.Show("Dados do produto inválidos.");
                    return;
                }

                // Converte o valor da célula NomeProduto para string
                ProdutoID  = int.Parse(dataGridPesquisar["ProdutoID", LinhaAtual].Value.ToString());
                NomeProduto =          dataGridPesquisar["NomeProduto", LinhaAtual].Value.ToString();
                // Acrescenta zeros à esquerda do ProdutoID
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(ProdutoID, 4);

                // Obtém a instância do formulário FrmPedido (ou usa uma existente)
                FrmPedido frmPedido = (FrmPedido)this.Owner;
                if (frmPedido == null)
                {
                    // Caso a instância de FrmPedido não esteja disponível, exibe uma mensagem de erro
                    MessageBox.Show("A instância de FrmPedido não está disponível.");
                    return;
                }

                // Preenche os campos no formulário FrmPedido com os dados do produto
                frmPedido.ProdutoID = ProdutoID;
                frmPedido.txtNomeProduto.Text = NomeProduto;
                frmPedido.txtValorProduto.Text = PrecoUnitario.ToString();
                frmPedido.txtQuantidade.Text = "1";

                // Calcula o subtotal
                frmPedido.CalcularSubtotal();

                // Fecha o formulário FrmLocalizarProduto
                this.Close();
            }
            finally
            {
                // Certifica-se de que a variável isSelectingProduct seja false ao final do processo
                isSelectingProduct = false;
            }
        }
   // Alterado em 23/01/2025***************ACIMA
   
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
                    frmVendas.ProdutoID = int.Parse(produtoId);
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


/*//dataGridPesquisar_SelectionChanged
 * 
 * if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
 * */
/*//KeyDown
 *  if (dataGridPesquisar.CurrentRow != null)
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
 * */