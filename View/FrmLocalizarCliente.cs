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
        public Form FormChamador { get; set; }
        public FrmLocalizarCliente()
        {
            InitializeComponent();
        }      
        private void InicializaDataGridView()
        {
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLocalizarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Obtém o ID do cliente da célula [0, LinhaAtual] do dataGridPesquisar e converte para inteiro.
            ClienteID = Convert.ToInt32(dataGridPesquisar[0, LinhaAtual].Value);

            // Acrescenta zeros à esquerda do ID do cliente até que ele tenha 4 dígitos.
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(ClienteID, 4);

            // Obtém o nome do cliente da célula [1, LinhaAtual] do dataGridPesquisar e converte para string.
            string nomeCliente = dataGridPesquisar[1, LinhaAtual].Value.ToString();

            // Verifica se o formulário chamador é uma instância de FrmVendas.
            if (FormChamador is FrmVendas frmVendas)
            {
                // Se for, define os textos dos campos txtClienteID e txtNomeCliente de FrmVendas.
                frmVendas.txtClienteID.Text = numeroComZeros;
                frmVendas.txtNomeCliente.Text = nomeCliente;
            }
            // Verifica se o formulário chamador é uma instância de FrmContaReceber.
            else if (FormChamador is FrmContaReceber frmContaReceber)
            {
                // Se for, define os textos dos campos txtClienteID e txtNomeCliente de FrmContaReceber.
                frmContaReceber.txtClienteID.Text = numeroComZeros;
                frmContaReceber.txtNomeCliente.Text = nomeCliente;
            }
        }       
    }
}
