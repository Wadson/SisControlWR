using Microsoft.Identity.Client;
using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
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
            
            InicializaDataGridView();
        }
        private void FrmLocalizarCliente_Load(object sender, EventArgs e)
        {
            ListarCidade();
        }
        private void InicializaDataGridView()
        {
            // Inicializar propriedades básicas do DataGridView.         
           // dataGridPesquisa.BackgroundColor = Color.LightGray;
           //dataGridPesquisa.BorderStyle = BorderStyle.Fixed3D;
           
           dataGridPesquisa.MultiSelect = false;

            //Configuração das linhas do DataGridView

            //Cores alternadas no DataGridView
            dataGridPesquisa.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridPesquisa.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisa.Columns[0].Width = 100;
            dataGridPesquisa.Columns[1].Width = 660;
            dataGridPesquisa.Columns[2].Width = 200;
            dataGridPesquisa.Columns[3].Width = 350;


            //Renomeia as colunas do DataGridView 
            dataGridPesquisa.Columns[0].HeaderText = "Cidade ID";
            dataGridPesquisa.Columns[1].HeaderText = "Nome Cidade";
            dataGridPesquisa.Columns[2].HeaderText = "Cód. Estado";
            dataGridPesquisa.Columns[3].HeaderText = "UF";
        }
       
        private void FrmLocalizarCidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VariavelGlobal.NomeFormulario == "FrmCadCliente")
            {
                linhaAtual = dataGridPesquisa.CurrentRow.Index;
                //((FrmVendas)Application.OpenForms["FrmVendas"]).txtIdCliente.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();
                ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtCidadeID.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();
                ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtNomeCidade.Text = dataGridPesquisa[1, linhaAtual].Value.ToString();
                ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtEstadoCliente.Text = dataGridPesquisa[3, linhaAtual].Value.ToString();
            }
            if(VariavelGlobal.NomeFormulario == "FrmCadFornecedor")
            {
                linhaAtual = dataGridPesquisa.CurrentRow.Index;
                ((FrmCadFornecedor)Application.OpenForms["FrmCadFornecedor"]).txtCidadeID.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();
                ((FrmCadFornecedor)Application.OpenForms["FrmCadFornecedor"]).txtNomeCidade.Text = dataGridPesquisa[1, linhaAtual].Value.ToString();
                ((FrmCadFornecedor)Application.OpenForms["FrmCadFornecedor"]).txtNomeEstado.Text = dataGridPesquisa[3, linhaAtual].Value.ToString();
            }


        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            CidadeDALL dao = new CidadeDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisa.DataSource = dao.PesquisarPorCodigo(nome);
            }
            else
            {
                dataGridPesquisa.DataSource = dao.PesquisarPorNome(nome);
            }
        }
    }
}
