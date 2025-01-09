using SisControl.BLL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SisControl.View
{
    public partial class FrmCadProduto : SisControl.FrmBaseGeral
    {
        public FrmCadProduto()
        {
            InitializeComponent();
        }
      
        private void TexBoxMoeda(System.Windows.Forms.TextBox textBox1)
        {
            // Remove non-numeric characters except for comma
            string value = textBox1.Text.Replace("R$", "").Trim();

            if (decimal.TryParse(value, NumberStyles.AllowDecimalPoint, new CultureInfo("pt-BR"), out decimal decimalValue))
            {
                // Format the value as currency
                textBox1.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C2}", decimalValue);
            }
            else
            {
                textBox1.Text = string.Empty;
            }
        }
        public void SalvarRegistro()
        {
            try
            {
                ProdutoMODEL objetoModel = new ProdutoMODEL();

                PrecoCusto = FormataNumeroReplace(txtPrecoCusto.Text);
                PrecoVenda = FormataNumeroReplace(txtPrecoVenda.Text);

                objetoModel.ProdutoID = Convert.ToInt32(txtProdutoID.Text);
                objetoModel.NomeProduto = txtNomeProduto.Text;
                objetoModel.PrecoCusto = PrecoCusto;
                objetoModel.Estoque = Convert.ToInt32(txtEstoque.Text);
                objetoModel.PrecoVenda = PrecoVenda;

                ProdutoBLL objetoBll = new ProdutoBLL();

                objetoBll.Salvar(objetoModel);
                MessageBox.Show("REGISTRO gravado com sucesso! ", "Informação!!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
            }
            catch (OverflowException ov)
            {
                MessageBox.Show("Overfow Exeção deu erro! " + ov);
            }
            catch (Win32Exception erro)
            {
                MessageBox.Show("Win32 Win32!!! \n" + erro);
            }
        }
        public void AlterarRegistro()
        {
            try
            {
                ProdutoMODEL objetoModel = new ProdutoMODEL();

                objetoModel.ProdutoID = Convert.ToInt32(txtProdutoID.Text);
                objetoModel.NomeProduto = txtNomeProduto.Text;
                objetoModel.PrecoCusto = Convert.ToDecimal(txtPrecoCusto.Text);
                objetoModel.Estoque = Convert.ToInt32(txtEstoque.Text);
                objetoModel.PrecoVenda = Convert.ToDecimal(txtPrecoVenda.Text);
                

                ProdutoBLL objetoBll = new ProdutoBLL();
                objetoBll.Alterar(objetoModel);

                MessageBox.Show("Registro Alterado com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                LimpaCampo();
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Alterar o registro!!! " + erro);
            }
        }
        public void ExcluirRegistro()
        {
            try
            {
                ProdutoMODEL objetoModel = new ProdutoMODEL();

                objetoModel.ProdutoID = Convert.ToInt32(txtProdutoID.Text);
                ProdutoBLL objetoBll = new ProdutoBLL();

                objetoBll.Excluir(objetoModel);
                MessageBox.Show("Registro Excluído com sucesso!", "Alteração!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);// Habilita Timer do outro form Obs: O timer no outro form executa um Método.    
                LimpaCampo();
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Excluir o registro!!! " + erro);
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                AlterarRegistro();
            }
            if (StatusOperacao == "NOVO")
            {
                EvitarDuplicado("Produto", "NomeProduto", txtNomeProduto.Text);
                if (RetornoEvitaDuplicado == "0")
                {
                    SalvarRegistro();
                    LimpaCampo();
                    txtNomeProduto.Focus();

                    txtProdutoID.Text = RetornaCodigoContaMaisUm(QueryFornecedor).ToString();
                    UsuarioID = RetornaCodigoContaMaisUm(QueryFornecedor);
                    AcrescenteZero_a_Esquerda2(txtProdutoID);
                    ((FrmManutProduto)Application.OpenForms["FrmManutProduto"]).HabilitarTimer(true);
                }
            }
            if (StatusOperacao == "EXCLUSÃO")
            {
                if (MessageBox.Show("Deseja Excluir? \n\n O Usuário: " + txtNomeProduto.Text + " ??? ", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExcluirRegistro();
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampo();
            txtProdutoID.Text = RetornaCodigoContaMaisUm(QueryFornecedor).ToString();
            AcrescenteZero_a_Esquerda2(txtProdutoID);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCadProduto_Load(object sender, EventArgs e)
        {
            if (StatusOperacao == "ALTERAR")
            {
                return;
            }
            if (StatusOperacao == "NOVO")
            {
                txtProdutoID.Text = RetornaCodigoContaMaisUm(QueryProduto).ToString();
                txtNomeProduto.Focus();
                AcrescenteZero_a_Esquerda2(txtProdutoID);
            }
        }

        private void txtPrecoCusto_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Allow only one comma
            if (e.KeyChar == ',' && txtPrecoCusto.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void txtPrecoCusto_Leave(object sender, EventArgs e)
        {
            TexBoxMoeda(txtPrecoCusto);          
        }

        private void txtPrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Allow only one comma
            if (e.KeyChar == ',' && txtPrecoCusto.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void txtPrecoVenda_Leave(object sender, EventArgs e)
        {
            TexBoxMoeda(txtPrecoVenda);
        }

        private void txtPrecoCusto_KeyUp(object sender, KeyEventArgs e)
        {            
        }

        private void txtPrecoCusto_TextChanged(object sender, EventArgs e)
        {
            TexBoxMoeda(txtPrecoCusto);
        }

        private void txtPrecoVenda_TextChanged(object sender, EventArgs e)
        {
            TexBoxMoeda(txtPrecoVenda);
        }
    }
}
