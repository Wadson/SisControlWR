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
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace SisControl.View
{
    public partial class FrmCadProdutos : FrmModeloForm
    {
        private string QueryProdutos = "SELECT MAX(ProdutoID)  FROM Produtos";
        
        private string StatusOperacao;
        private int ProdutoID;

        public FrmCadProdutos(string statusOperacao)
        {
            InitializeComponent();


            this.txtPrecoCusto.Enter += new System.EventHandler(this.txtPrecoCusto_Enter);
            this.txtPrecoCusto.Leave += new System.EventHandler(this.txtPrecoCusto_Leave);
            this.txtLucro.Enter += new System.EventHandler(this.txtLucro_Enter);
            this.txtLucro.Leave += new System.EventHandler(this.txtLucro_Leave);

            Utilitario.ConfigurarEventosDeFoco(this);
            

            this.StatusOperacao = statusOperacao;
        }
        #region ENTER COMO TAB **************************************************************************************

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.ActiveControl is KryptonButton)
                {
                    ((KryptonButton)this.ActiveControl).PerformClick();
                    return true;
                }
                else
                {
                    SelectNextControl(this.ActiveControl, true, true, true, true);
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        SelectNextControl(this.ActiveControl, true, true, true, true);
        //        return true;
        //    }

        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        //TECLA ENTER COMO ENTER




        #endregion ********************ENTER COMO TAB**********************************************************
        private void FrmCadProdutos_Load(object sender, EventArgs e)
        {
            Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoCusto);
            Utilitario.FormatTextBoxToCurrencyKrypton(txtLucro);
            Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoDeVenda);

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
            cmbStatus.SelectedIndex = 1;
        }

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


        private void FrmCadProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Muda o foco para o próximo controle
                this.SelectNextControl(this.ActiveControl, true, true, true, true);

                // Impede o som de alerta padrão do Windows
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void Salvar()
        {
            // Criar uma nova instância de ProdutoMODEL e preencher com os dados do formulário
            ProdutosModel produto = new ProdutosModel
            {
                ProdutoID = int.Parse(txtProdutoID.Text),
                NomeProduto = txtNomeProduto.Text,
                PrecoCusto = decimal.Parse(txtPrecoCusto.Text),
                Lucro = decimal.Parse(txtLucro.Text),
                PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text),
                QuantidadeEmEstoque = int.Parse(txtEstoque.Text),
                DataDeEntrada = dtpDataDeEntrada.Value,
                Status = cmbStatus.Text,

                Imagem = ImageToByteArray(pictureBoxProduto.Image), // Exemplo de conversão para byte array               
                Referencia = txtReferencia.Text
            };

            // Chamar o método SalvarProduto da BLL
            ProdutoBLL produtosbll = new ProdutoBLL();
            produtosbll.Salvar(produto);

            MessageBox.Show("Produto salvo com sucesso!");
            Utilitario.LimpaCampoKrypton(this);
            // Limpar o PictureBox
            pictureBoxProduto.Image = null;
            int NovoCodigo = Utilitario.GerarProximoCodigo(QueryProdutos);//RetornaCodigoContaMaisUm(QueryUsuario).ToString();
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(NovoCodigo, 4);
            txtProdutoID.Text = numeroComZeros;
            txtNomeProduto.Focus();
            ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
        }

        public void Excluir()
        {
            try
            {
                ProdutosModel objetoProduto = new ProdutosModel();

                objetoProduto.ProdutoID = Convert.ToInt32(txtProdutoID.Text);
                ProdutoBLL produtoBll = new ProdutoBLL();

                produtoBll.Excluir(objetoProduto);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }


        public void Alterar()
        {
            try
            {
                ProdutosModel objetoProduto = new ProdutosModel();

                objetoProduto.NomeProduto = txtNomeProduto.Text;
                objetoProduto.PrecoCusto = decimal.Parse(txtPrecoCusto.Text);
                objetoProduto.Lucro = decimal.Parse(txtLucro.Text);
                objetoProduto.PrecoDeVenda = decimal.Parse(txtPrecoDeVenda.Text);
                objetoProduto.QuantidadeEmEstoque = int.Parse(txtEstoque.Text);
                objetoProduto.DataDeEntrada = dtpDataDeEntrada.Value;
                objetoProduto.Status = cmbStatus.Text;               

                if (pictureBoxProduto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxProduto.Image.Save(ms, pictureBoxProduto.Image.RawFormat);
                        objetoProduto.Imagem = ms.ToArray();
                    }
                }

                objetoProduto.Referencia = txtReferencia.Text;
                objetoProduto.ProdutoID = int.Parse(txtProdutoID.Text);

                ProdutoBLL produtoBll = new ProdutoBLL();
                produtoBll.Alterar(objetoProduto);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                Utilitario.LimpaCampoKrypton(this);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar o registro!!! " + erro);
            }
        } 

      
        private void btnSalva_Click(object sender, EventArgs e)
        {
            FrmManutUsuario pesquisausuario = new FrmManutUsuario(StatusOperacao);

            if (StatusOperacao == "ALTERAR")
            {
                Alterar();
            }
            if (StatusOperacao == "NOVO")
            {
                Salvar();
                Utilitario.LimpaCampoKrypton(this);
                txtNomeProduto.Focus();

                ProdutoID = Utilitario.GerarProximoCodigo(QueryProdutos);
                int codigo = ProdutoID;
                txtProdutoID.Text = Utilitario.AcrescentarZerosEsquerda(codigo, 6);

                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Usuário: " + txtNomeProduto.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Excluir();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Utilitario.LimpaCampoKrypton(this);
            ProdutoID = Utilitario.GerarProximoCodigo("SELECT MAX(ProdutoID) FROM Produto");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      


        private void btnLocalizarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProduto.Image = new Bitmap(openFileDialog.FileName);
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
                Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoDeVenda);
            }
            Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoCusto);
        }

        private void txtLucro_Leave(object sender, EventArgs e)
        {
            /*Utilitario.FormatTextBoxToCurrency(txtLucro)*/
            ;
            txtLucro.BackColor = Color.White;

            // Formata apenas se não estiver vazio
            if (!string.IsNullOrWhiteSpace(txtLucro.Text))
            {
                CalcularPrecoVenda();
            }

            if (!string.IsNullOrWhiteSpace(txtPrecoDeVenda.Text))
            {
                Utilitario.FormatTextBoxToCurrencyKrypton(txtPrecoDeVenda);
            }
            Utilitario.FormatTextBoxToCurrencyKrypton(txtLucro);
        }

        private void txtPrecoCusto_Enter(object sender, EventArgs e)
        {
            KryptonTextBox textBox = sender as KryptonTextBox;

            
            if (textBox != null && textBox.Text == "0,00")
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    textBox.Text = string.Empty;
                });
            }
        }

        private void txtLucro_Enter(object sender, EventArgs e)
        {
            KryptonTextBox textBox = sender as KryptonTextBox;
                       
            if (textBox != null && textBox.Text == "0,00")
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    textBox.Text = string.Empty;
                });
            }
        }
    }
}

