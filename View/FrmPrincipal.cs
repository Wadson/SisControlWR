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

namespace SisControl
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
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
            FrmManutUsuario frm = new FrmManutUsuario();
            //AbrirFormInPanel(frm);
            frm.ShowDialog();

            //Form1 form1 = new Form1();

            //// Definir o evento de fechamento do Form2 quando Form1 é aberto
            //form1.FormClosed += (s, args) => this.Close();

            //// Mostra o Form1
            //form1.Show();

            //// Esconder o Form2
            //this.Hide();
        }

        private void btnCadCli_Click(object sender, EventArgs e)
        {
            FrmManutCliente frm = new FrmManutCliente();
            frm.ShowDialog();
        }

        private void btnFORNECEDORES_Click(object sender, EventArgs e)
        {
            FrmManutFornecedor frm = new FrmManutFornecedor();
            frm.ShowDialog();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            FrmManutCategoria frm = new FrmManutCategoria();
            frm.ShowDialog();
        }

        private void btnSubCateg_Click(object sender, EventArgs e)
        {
            FrmManutSubCategoria frmManutSubCat = new FrmManutSubCategoria();
            frmManutSubCat.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {

        }

        private void btnContasReceber_Click(object sender, EventArgs e)
        {

        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            FrmVendas frm = new FrmVendas();
            AbrirFormInPanel(frm);
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
    }
}
