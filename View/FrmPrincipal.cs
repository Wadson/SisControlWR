using SisControl.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SisControl.View.FrmContaReceberr;

namespace SisControl
{
    public partial class FrmPrincipal : Form
    {
        private string StatusOperacao = "";
        private FrmContaReceberr _frmContaReceberr;
        private Parcela _parcela;
        public FrmPrincipal()
        {
            InitializeComponent();
            _frmContaReceberr = new FrmContaReceberr();
            StatusOperacao = "";
        }
        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

       

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            string currentPath = Path.GetDirectoryName(Application.ExecutablePath);

            //lblUsuarioLogado.Text = FrmLogin.usuarioConectado + "  |  Previlégio:" + FrmLogin.NivelAcesso + "  |  Diretório:" + currentPath + @"\Money.exe";

            string data = DateTime.Now.ToLongDateString();
            data = data.Substring(0, 1).ToUpper() + data.Substring(1, data.Length - 1);
            toolStripStatusData.Text = data;

            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            var informacao = Environment.UserName;
            var nomeComputador = Environment.MachineName;

            toolStripStatusExecutablePath.Text = path;            
            toolStripStatusCommonAppDataPath.Text = nomeComputador + " | " + informacao;

            lblEstação.Text = nomeComputador;
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHoraAtual.Text = DateTime.Now.ToString("HH:mm:ss");            
        }

        private void btnFUNCIONARIOS_Click(object sender, EventArgs e)
        {
            FrmTelaPrincipal telaPrincipal = new FrmTelaPrincipal();
            telaPrincipal.ShowDialog();
            //FrmManutUsuario frm = new FrmManutUsuario();
            ////AbrirFormInPanel(frm);
            //frm.ShowDialog();            
        }

        private void btnCadCli_Click(object sender, EventArgs e)
        {
            FrmManutCliente frm = new FrmManutCliente(StatusOperacao);
            StatusOperacao = "NOVO";
            AbrirFormInPanel(frm);  
        }

        private void btnFORNECEDORES_Click(object sender, EventArgs e)
        {
            FrmManutFornecedor frm = new FrmManutFornecedor(StatusOperacao);
            AbrirFormInPanel(frm);  
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {            
        }

        private void btnSubCateg_Click(object sender, EventArgs e)
        {           
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            FrmManutProduto frm = new FrmManutProduto(StatusOperacao);
            AbrirFormInPanel(frm);            
        }

        private void btnContasReceber_Click(object sender, EventArgs e)
        {
            // Suponha que você tenha uma instância de Parcela
            Parcela parcela = new Parcela();

            // Chama o construtor de FrmContaReceberr com os parâmetros necessários
            FrmContaReceberr frm = new FrmContaReceberr(_frmContaReceberr, parcela);
            frm.Show();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            //FrmVendas frm = new FrmVendas();             
            //frm.ShowDialog();   
            FrmPedido frm = new FrmPedido();
            frm.ShowDialog();
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
        }

        private void btnRELATORIOS_Click(object sender, EventArgs e)
        {

        }

        private void btnFerramenta_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEstorno_Click(object sender, EventArgs e)
        {

        }

        private void brnPesquisadinamica_Click(object sender, EventArgs e)
        {

        }

        private void btnFerramentas_Click(object sender, EventArgs e)
        {

        }

        private void btnGerarBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnRestauraBackup_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManutCategoria frm = new FrmManutCategoria(StatusOperacao);
            frm.ShowDialog();
        }

        private void fabricanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManutFabricante frm = new FrmManutFabricante(StatusOperacao);
            frm.ShowDialog();
        }
    }
}
