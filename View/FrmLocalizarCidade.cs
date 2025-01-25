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
        protected int LinhaAtual = -1;
        public FrmLocalizarCidade()
        {
            InitializeComponent();

            // Configurar o DataGridView (apenas exemplo, configure conforme necessário)
            dataGridPesquisar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public new int ObterLinhaAtual()
        {
            return LinhaAtual;
        }
        public void ListarCidade()
        {
            CidadeDALL dao = new CidadeDALL();
            dataGridPesquisar.DataSource = dao.PesquisarGeral();
            
            InicializaDataGridView();
        }
        private void FrmLocalizarCliente_Load(object sender, EventArgs e)
        {
            ListarCidade();
        }
        private void InicializaDataGridView()
        {
            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisar.Columns[0].Width = 100;
            dataGridPesquisar.Columns[1].Width = 170;
            dataGridPesquisar.Columns[2].Width = 110;
            dataGridPesquisar.Columns[3].Width = 100;

            //Renomeia as colunas do DataGridView 
            dataGridPesquisar.Columns[0].HeaderText = "Cidade ID";
            dataGridPesquisar.Columns[1].HeaderText = "Nome Cidade";
            dataGridPesquisar.Columns[2].HeaderText = "Cód. Estado";
            dataGridPesquisar.Columns[3].HeaderText = "UF";
        }
       
        private void FrmLocalizarCidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridPesquisar.Rows.Count == 0 || dataGridPesquisar.CurrentRow == null)
            {
                // O DataGridView está vazio, então saia do método
                return;
            }

            if (VariavelGlobal.NomeFormulario == "FrmCadCliente")
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
                //((FrmVendas)Application.OpenForms["FrmVendas"]).txtIdCliente.Text = dataGridPesquisa[0, linhaAtual].Value.ToString();
                ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtCidadeID.Text = dataGridPesquisar[0, LinhaAtual].Value?.ToString();
                ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtNomeCidade.Text = dataGridPesquisar[1, LinhaAtual].Value?.ToString();
                ((FrmCadCliente)Application.OpenForms["FrmCadCliente"]).txtEstadoCliente.Text = dataGridPesquisar[3, LinhaAtual].Value?.ToString();
            }
            if (VariavelGlobal.NomeFormulario == "FrmCadFornecedor")
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;

                ((FrmCadFornecedor)Application.OpenForms["FrmCadFornecedor"]).txtCidadeID.Text = dataGridPesquisar[0, LinhaAtual].Value?.ToString();
                ((FrmCadFornecedor)Application.OpenForms["FrmCadFornecedor"]).txtNomeCidade.Text = dataGridPesquisar[1, LinhaAtual].Value?.ToString();
                ((FrmCadFornecedor)Application.OpenForms["FrmCadFornecedor"]).txtEstado.Text = dataGridPesquisar[3, LinhaAtual].Value?.ToString();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            CidadeDALL dao = new CidadeDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorCodigo(nome);
            }
            else
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
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
/*
 private void dataGridPesquisar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
        } 
//**********************************************

 *  private void dataGridPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
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
 * */