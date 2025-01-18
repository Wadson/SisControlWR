using SisControl.BLL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisControl.View
{
    public partial class FrmCadProdutos : FrmBaseGeral
    {
        private string QueryProdutos = "SELECT MAX(ProdutoID)  FROM Produtos";
        private string QueryCategoria = "SELECT MAX(CategoriaID) FROM Categoria";
        private string StatusOperacao;
        private int ProdutoID;
        public FrmCadProdutos(string statusOperacao)
        {
            InitializeComponent();
            // Adicionar evento TextChanged ao ComboBox
            cmbCategoria.TextChanged += new EventHandler(cmbCategoria_TextChanged);
            this.StatusOperacao = statusOperacao;
        }
        private string queryCategoria = "SELECT * FROM Categoria";
        private string queryFabricante = "SELECT * FROM Fabricantes";
        
        private void FrmCadProdutos_Load(object sender, EventArgs e)
        {
            Utilitario.PreencherComboBox(cmbCategoria, queryCategoria, "NomeCategoria", "CategoriaID");
            Utilitario.PreencherComboBox(cmbFabricante, queryFabricante, "NomeFabricante", "FabricanteID");
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                int NovoCodigo = Utilitario.GerarProximoCodigo(QueryProdutos);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
                string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
                txtProdutoID.Text = numeroComZeros;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampo(this);
            ProdutoID = Utilitario.GerarProximoCodigo("SELECT MAX(ProdutoID) FROM Produto");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarProduto();
        }

        private void FrmCadProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Deseja sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            if (e.KeyCode == Keys.Enter) 
            { 
                if (this.GetNextControl(ActiveControl, true) != null) 
                { 
                    e.Handled = true; this.GetNextControl(ActiveControl, true).Focus(); 
                }
            }
        }

        private void txtNomeProduto_Enter(object sender, EventArgs e)
        {
            txtNomeProduto.BackColor = Color.LightBlue;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void cmbStatus_Enter(object sender, EventArgs e)
        {
            cmbStatus.BackColor = Color.LightBlue;
        }

        private void cmbUnidadeDeMedida_Enter(object sender, EventArgs e)
        {
            cmbUnidadeDeMedida.BackColor = Color.LightBlue;
        }

        private void txtFornecedor_Enter(object sender, EventArgs e)
        {
            txtFornecedor.BackColor = Color.LightBlue;
        }

        private void txtPrecoCusto_Enter(object sender, EventArgs e)
        {
            txtPrecoCusto.BackColor = Color.LightBlue;  
        }

        private void txtLucro_Enter(object sender, EventArgs e)
        {
            txtLucro.BackColor = Color.LightBlue;
        }

        private void txtPrecoDeVenda_Enter(object sender, EventArgs e)
        {
            txtPrecoDeVenda.BackColor = Color.LightBlue;
        }

        private void txtQuantidadeEmEstoque_Enter(object sender, EventArgs e)
        {
            txtQuantidadeEmEstoque.BackColor = Color.LightBlue;
        }

        private void cmbCategoria_Enter(object sender, EventArgs e)
        {
            cmbCategoria.BackColor = Color.LightBlue;
        }

        private void cmbFabricante_Enter(object sender, EventArgs e)
        {
            cmbFabricante.BackColor = Color.LightBlue;
        }

        private void txtNomeProduto_Leave(object sender, EventArgs e)
        {
            txtNomeProduto.BackColor = Color.White;
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.White;
        }

        private void cmbStatus_Leave(object sender, EventArgs e)
        {
            cmbStatus.BackColor = Color.White;
        }

        private void cmbUnidadeDeMedida_Leave(object sender, EventArgs e)
        {
            cmbUnidadeDeMedida.BackColor = Color.White;
        }

        private void txtFornecedor_Leave(object sender, EventArgs e)
        {
            txtFornecedor.BackColor = Color.White;
        }

        private void txtPrecoCusto_Leave(object sender, EventArgs e)
        {
            txtPrecoCusto.BackColor = Color.White;
        }

        private void txtLucro_Leave(object sender, EventArgs e)
        {
            txtLucro.BackColor = Color.White;
        }

        private void txtPrecoDeVenda_Leave(object sender, EventArgs e)
        {
            txtPrecoDeVenda.BackColor = Color.White;
        }

        private void txtQuantidadeEmEstoque_Leave(object sender, EventArgs e)
        {
            txtQuantidadeEmEstoque.BackColor = Color.White;
        }

        private void cmbCategoria_Leave(object sender, EventArgs e)
        {
            cmbCategoria.BackColor = Color.White;
        }

        private void cmbFabricante_Leave(object sender, EventArgs e)
        {
            cmbFabricante.BackColor = Color.White;  
        }
        private void SalvarProduto()
        {
            // Criar uma nova instância de ProdutoMODEL e preencher com os dados do formulário
            ProdutosModel produto = new  ProdutosModel
            {
                NomeProduto = txtNomeProduto.Text,
                Descricao = txtDescricao.Text,
                PrecoCusto = decimal.Parse(txtPrecoCusto.Text),
                Lucro = decimal.Parse(txtLucro.Text),
                PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text),
                QuantidadeEmEstoque = int.Parse(txtQuantidadeEmEstoque.Text),
                DataDeEntrada = DateTime.Parse(dtpDataDeEntrada.Text),
                CategoriaID = int.Parse(txtCategoriaID.Text),
                FabricanteID = int.Parse(txtFabricanteID.Text),
                UnidadeDeMedida = cmbUnidadeDeMedida.Text,
                Status = cmbStatus.Text,
                DataDeVencimento = DateTime.Parse(dtpDataDeVencimento.Text),
                Imagem = ImageToByteArray(pbImagem.Image), // Exemplo de conversão para byte array
                FornecedorID = int.Parse(txtFornecedorID.Text)
            };

            // Chamar o método SalvarProduto da BLL
            ProdutosBll produtosBll = new ProdutosBll();
            produtosBll.SalvarProdutos(produto);
            MessageBox.Show("Produto salvo com sucesso!");
        }
        private void AbrirFrmLocalizarFornecedor()
        {
            FrmLocalizarFornedeor frmLocalizarFornecedor = new FrmLocalizarFornedeor();
            frmLocalizarFornecedor.FormChamador = this; // Define o formulário chamador
            frmLocalizarFornecedor.ShowDialog();
        }
        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarFornecedor();
        }
        private int ObterCodigoCategoria(string nomeCategoria)
        {
            int codigoCategoria = -1;
            using (var connection = Conexao.Conex())
            {
                string query = "SELECT CategoriaID FROM Categoria WHERE NomeCategoria = @NomeCategoria";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeCategoria", nomeCategoria);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        codigoCategoria = (int)result;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao buscar categoria: " + ex.Message);
                }
            }
            return codigoCategoria;
        }

        private void cmbCategoria_TextChanged(object sender, EventArgs e)
        {
            string nomeCategoria = cmbCategoria.Text;
            int codigoCategoria = ObterCodigoCategoria(nomeCategoria);
            if (codigoCategoria != -1)
            {
                txtCategoriaID.Text = codigoCategoria.ToString();
            }
            else
            {
                txtCategoriaID.Text = "";
            }
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private void btnLocalizarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImagem.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void cmbFabricante_VisibleChanged(object sender, EventArgs e)
        {            
        }

        private void cmbFabricante_TextChanged(object sender, EventArgs e)
        {
            string nomeFabricante = cmbFabricante.Text;
            int codigoFabricante = ObterCodigoCategoria(nomeFabricante);
            if (codigoFabricante != -1)
            {
                txtFabricanteID.Text = codigoFabricante.ToString();
            }
            else
            {
                txtFabricanteID.Text = "";
            }
        }
        // Cria uma instância do FrmLocalizarProduto e define o Owner como o FrmVendas       
    }
}
