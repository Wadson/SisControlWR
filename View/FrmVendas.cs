using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmVendas : SisControl.FrmBaseGeral
    {
        public FrmVendas()
        {
            InitializeComponent();
        }
        private void NovoCodigo()
        {//Traz o último código cadastrado + 1, para novo cadastro
            VendaID = RetornaCodigoContaMaisUm(QueryVendas);
            ItemVendaID = RetornaCodigoContaMaisUm(QueryItensVenda);
            ContaReceberID = RetornaCodigoContaMaisUm(QueryContaReceber);
            ParcelaID = RetornaCodigoContaMaisUm(QueryParcela);
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            NovoCodigo();
            txtIdVenda.Text = VendaID.ToString();
        }
        public void ToMoney(System.Windows.Forms.TextBox text, string format = "N")
        {
            double value;
            if (double.TryParse(text.Text, out value))
            {
                text.Text = value.ToString(format);
            }
            else
            {
                text.Text = "0,00";
            }
        }
        private void TirarZeroEsquerda(System.Windows.Forms.TextBox tx)
        {
            string valor = tx.Text;
            string NovoValorSemZero = valor.TrimStart('0');
            tx.Text = NovoValorSemZero;
        }

        private void btnLocalizarProduto_Click(object sender, EventArgs e)
        {
            if (txtIdVenda.Text != "" && txtNomeCliente.Text != "")
            {
                //FrmLocalizaProduto localizaProduto = new FrmLocalizaProduto();
                //localizaProduto.lblTitulo.Text = "Localizar Produtos";
                //localizaProduto.ShowDialog();

                //ToMoney(txtValorProduto);
                //ToMoney(txtTotal);
                //txtQuantidade.Focus();
                //CalculaPrecoTotal();
            }
            else
            {
                MessageBox.Show("Antes de localizar um produto, é necessário escolher um cliente!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }
    }
}
