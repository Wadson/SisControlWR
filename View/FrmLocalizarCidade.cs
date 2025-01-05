using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmLocalizarCidade : SisControl.FrmBasePesquisa
    {
        public FrmLocalizarCidade()
        {
            InitializeComponent();
        }
        public void ListarCidade()
        {
            CidadeDALL dao = new CidadeDALL();
            dataGridPesquisa.DataSource = dao.PesquisarGeral();
        }
        private void FrmLocalizarCliente_Load(object sender, EventArgs e)
        {
            ListarCidade();
        }

        private void FrmLocalizarCidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmCadCliente FrmCadCli = new FrmCadCliente();

            try
            {
                if (dataGridPesquisa.DataSource != null)
                {
                    linhaAtual = dataGridPesquisa.CurrentRow.Index;
                    //((FrmVendas)Application.OpenForms["FrmVendas"]).txtIdCliente.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();
                    ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtCidadeID.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();
                    ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtNomeCidade.Text = dataGridPesquisa[1, linhaAtual].Value.ToString();
                    ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtEstadoCliente.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();                    
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Atenção", "Erro" + Ex, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            CidadeDALL dao = new CidadeDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisa.DataSource = dao.PesquisarPorNome(nome);
            }
            else
            {
                dataGridPesquisa.DataSource = dao.PesquisarPorNome(nome);
            }
        }
    }
}
