using SisControl.DALL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmLocalizarCliente : SisControl.FrmBasePesquisa
    {
        private int ClienteID;
        protected int LinhaAtual = -1;
        public FrmLocalizarCliente()
        {
            InitializeComponent();
        }
        public new int ObterLinhaAtual()
        {
            return LinhaAtual;
        }
        private void InicializaDataGridView()
        {
            // Inicializar propriedades básicas do DataGridView.         
            // dataGridPesquisa.BackgroundColor = Color.LightGray;
            //dataGridPesquisa.BorderStyle = BorderStyle.Fixed3D;

            dataGridPesquisar.MultiSelect = false;

            //Configuração das linhas do DataGridView

            //Cores alternadas no DataGridView
            dataGridPesquisar.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisar.Columns[0].Width = 100;
            dataGridPesquisar.Columns[1].Width = 660;
            dataGridPesquisar.Columns[2].Width = 200;
            dataGridPesquisar.Columns[3].Width = 350;


            //Renomeia as colunas do DataGridView 
            //dataGridPesquisa.Columns[0].HeaderText = "Cidade ID";
            //dataGridPesquisa.Columns[1].HeaderText = "Nome Cidade";
            //dataGridPesquisa.Columns[2].HeaderText = "Cód. Estado";
            //dataGridPesquisa.Columns[3].HeaderText = "UF";
        }
        public void ListarCliente()
        {
            ClienteDALL dao = new ClienteDALL();
            dataGridPesquisar.DataSource = dao.PesquisarGeral();

            InicializaDataGridView();
        }

        private void FrmLocalizarCliente_Load(object sender, EventArgs e)
        {
            ListarCliente();
        }

        private void FrmLocalizarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClienteID = Convert.ToInt32(dataGridPesquisar[0, LinhaAtual].Value);            
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(ClienteID, 6);



            ((FrmVendas)Application.OpenForms["FrmVendas"]).txtClienteID.Text = numeroComZeros;
            ((FrmVendas)Application.OpenForms["FrmVendas"]).txtNomeCliente.Text = dataGridPesquisar[1, LinhaAtual].Value.ToString();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            ClienteDALL dao = new ClienteDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorCodigo(nome);
            }
            else
            {
                dataGridPesquisar.DataSource = dao.PesquisarPorNome(nome);
            }
        }

        private void dataGridPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
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
