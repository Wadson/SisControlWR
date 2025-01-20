using SisControl.BLL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
        private string QueryFabricantes = "SELECT FabricanteID FROM Fabricantes WHERE NomeFabricante = @NomeFabricante";
        private string queryCategorias = "SELECT CategoriaID FROM Categoria WHERE NomeCategoria = @NomeCategoria";
        private string StatusOperacao;
        private int ProdutoID;
        public int CategoriaID, FabricanteID;

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

            Utilitario.FormatTextBoxToCurrency(txtPrecoCusto);
            Utilitario.FormatTextBoxToCurrency(txtLucro);
            Utilitario.FormatTextBoxToCurrency(txtPrecoDeVenda);

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
            cmbCategoria.SelectedIndex = 26;
            cmbFabricante.SelectedIndex = 12;
            cmbUnidadeDeMedida.SelectedIndex = 4;
            cmbStatus.SelectedIndex = 1;
        }

        //private void CalcularPrecoVenda()
        //{
        //    if (decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto) &&
        //   decimal.TryParse(txtLucro.Text, out decimal lucro))
        //    {
        //        decimal precoVenda = precoCusto + (precoCusto * lucro / 100);
        //        txtPrecoDeVenda.Text = String.Format(CultureInfo.CurrentCulture, "{0:N2}");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Por favor, insira valores válidos.");
        //    }
        //}
        private void CalcularPrecoVenda()
        {
            if (decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto) &&
                !string.IsNullOrWhiteSpace(txtLucro.Text))
            {
                decimal precoVenda = 0;

                if (txtLucro.Text.EndsWith("%"))
                {
                    string lucroPercentualStr = txtLucro.Text.TrimEnd('%');
                    if (decimal.TryParse(lucroPercentualStr, out decimal lucroPercentual))
                    {
                        precoVenda = precoCusto + (precoCusto * lucroPercentual / 100);
                    }
                }
                else if (decimal.TryParse(txtLucro.Text, out decimal lucro))
                {
                    precoVenda = precoCusto + lucro;
                }

                txtPrecoDeVenda.Text = String.Format(CultureInfo.CurrentCulture, "{0:N2}", precoVenda);
            }
            else
            {
                txtPrecoDeVenda.Text = string.Empty;
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
        #region Evento de Botões
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

            // Formata apenas se não estiver vazio
            if (!string.IsNullOrWhiteSpace(txtPrecoCusto.Text))
            {
                CalcularPrecoVenda();               
            }

            if (!string.IsNullOrWhiteSpace(txtPrecoDeVenda.Text))
            {
                Utilitario.FormatTextBoxToCurrency(txtPrecoDeVenda);
            }
            Utilitario.FormatTextBoxToCurrency(txtPrecoCusto);
        }

        private void txtLucro_Leave(object sender, EventArgs e)
        {
            /*Utilitario.FormatTextBoxToCurrency(txtLucro)*/;
            txtLucro.BackColor = Color.White;            

            // Formata apenas se não estiver vazio
            if (!string.IsNullOrWhiteSpace(txtLucro.Text))
            {
                CalcularPrecoVenda();               
            }

            if (!string.IsNullOrWhiteSpace(txtPrecoDeVenda.Text))
            {
                Utilitario.FormatTextBoxToCurrency(txtPrecoDeVenda);
            }
            Utilitario.FormatTextBoxToCurrency(txtLucro);
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
        #endregion 

        private void SalvarProduto()
        {
            // Criar uma nova instância de ProdutoMODEL e preencher com os dados do formulário
            ProdutosModel produto = new ProdutosModel
            {
                NomeProduto = txtNomeProduto.Text,
                Descricao = txtDescricao.Text,
                PrecoCusto = decimal.Parse(txtPrecoCusto.Text),
                Lucro = decimal.Parse(txtLucro.Text),
                PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text),
                QuantidadeEmEstoque = int.Parse(txtQuantidadeEmEstoque.Text),
                DataDeEntrada = DateTime.Parse(dtpDataDeEntrada.Text),
                CategoriaID = CategoriaID,//int.Parse(txtCategoriaID.Text),
                FabricanteID = FabricanteID,//int.Parse(txtFabricanteID.Text),
                UnidadeDeMedida = cmbUnidadeDeMedida.Text,
                Status = cmbStatus.Text,
                DataDeVencimento = DateTime.Parse(dtpDataDeVencimento.Text),
                Imagem = ImageToByteArray(pbImagem.Image), // Exemplo de conversão para byte array
                FornecedorID = int.Parse(txtFornecedorID.Text),
                Referencia = txtReferência.Text
            };

            // Chamar o método SalvarProduto da BLL
            ProdutosBll produtosBll = new ProdutosBll();
            produtosBll.SalvarProdutos(produto);
            MessageBox.Show("Produto salvo com sucesso!");
            Utilitario.LimpaCampo(this);

            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryProdutos);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
            txtProdutoID.Text = numeroComZeros;
            txtNomeProduto.Focus();
        }
        private void AbrirFrmLocalizarFornecedor()
        {
            FrmLocalizarFornedor frmLocalizarFornecedor = new FrmLocalizarFornedor();
            frmLocalizarFornecedor.FormChamador = this; // Define o formulário chamador
            frmLocalizarFornecedor.ShowDialog();
        }
        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarFornecedor();
        }       

        private void cmbCategoria_TextChanged(object sender, EventArgs e)
        {
            string nomeCategoria = cmbCategoria.Text;
            int codigoCategoria = Utilitario.ObterCodigoComboBox(queryCategorias, "@NomeCategoria", nomeCategoria);
            if (codigoCategoria != -1)
            {
                //txtCategoriaID.Text = codigoCategoria.ToString();
                CategoriaID = codigoCategoria;
            }
            else
            {
                //txtCategoriaID.Text = "";
                CategoriaID = 0;
            }
        }
        private void cmbFabricante_TextChanged(object sender, EventArgs e)
        {
            string nomeFabricante = cmbFabricante.Text;
            int codigoFabricante = Utilitario.ObterCodigoComboBox(QueryFabricantes, "@NomeFabricante", nomeFabricante);
            if (codigoFabricante != -1)
            {
                //txtFabricanteID.Text = codigoFabricante.ToString();
                FabricanteID = codigoFabricante;
            }
            else
            {
                //txtFabricanteID.Text = "";
                FabricanteID = 0;
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null; // Ou retorne um array vazio: return new byte[0];
            }

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
       
        // Cria uma instância do FrmLocalizarProduto e define o Owner como o FrmVendas       
    }
}
