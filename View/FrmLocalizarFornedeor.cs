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
    public partial class FrmLocalizarFornedeor : FrmBasePesquisa
    {
        protected int LinhaAtual = -1;
        private int FornecedorID;
        public Form FormChamador { get; set; }
        public FrmLocalizarFornedeor()
        {
            InitializeComponent();
        }
      
        private void InicializaDataGridView()
        {
            // Inicializar propriedades básicas do DataGridView.         
            // dataGridPesquisa.BackgroundColor = Color.LightGray;
            //dataGridPesquisa.BorderStyle = BorderStyle.Fixed3D;

            dataGridPesquisar.MultiSelect = false;

            //Cores alternadas no DataGridView
            dataGridPesquisar.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridPesquisar.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisar.Columns[0].Width = 100;
            dataGridPesquisar.Columns[1].Width = 660;

            //Renomeia as colunas do DataGridView 
            dataGridPesquisar.Columns[0].HeaderText = "FornecedorID";
            dataGridPesquisar.Columns[1].HeaderText = "NomeFornecedor";
            dataGridPesquisar.Columns[2].HeaderText = "Cnpj";
            dataGridPesquisar.Columns[3].HeaderText = "Endereco";
            dataGridPesquisar.Columns[4].HeaderText = "Email";
            dataGridPesquisar.Columns[5].HeaderText = "CidadeID";     
        }
        public void ListarFornecedor()
        {
            FornecedorDALL FornecedorDao = new FornecedorDALL();
            dataGridPesquisar.DataSource = FornecedorDao.PesquisarGeral();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            FornecedorDALL FornecedorDao = new FornecedorDALL();

            if (rbtCodigo.Checked)
            {
                dataGridPesquisar.DataSource = FornecedorDao.PesquisarPorCodigo(nome);
            }
            else
            {
                dataGridPesquisar.DataSource = FornecedorDao.PesquisarPorNome(nome);
            }
        }

        private void dataGridPesquisar_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
        }

        private void FrmLocalizarFornedeor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Obtém o ID do cliente da célula [0, LinhaAtual] do dataGridPesquisar e converte para inteiro.
            FornecedorID = Convert.ToInt32(dataGridPesquisar[0, LinhaAtual].Value);

            // Acrescenta zeros à esquerda do ID do cliente até que ele tenha 4 dígitos.
            string numeroComZeros = Utilitario.AcrescentarZerosEsquerda(FornecedorID, 4);

            // Obtém o nome do cliente da célula [1, LinhaAtual] do dataGridPesquisar e converte para string.
            string nomeFornecedor = dataGridPesquisar[1, LinhaAtual].Value.ToString();

            // Verifica se o formulário chamador é uma instância de FrmVendas.
            if (FormChamador is FrmCadProdutos frmCadprodutos)
            {
                // Se for, define os textos dos campos txtClienteID e txtNomeCliente de FrmVendas.
                frmCadprodutos.txtFornecedor.Text = nomeFornecedor;
                frmCadprodutos.txtFornecedorID.Text = numeroComZeros;
            }
            // Verifica se o formulário chamador é uma instância de FrmContaReceber.
            else if (FormChamador is FrmContaReceber frmContaReceber)
            {
                // Se for, define os textos dos campos txtClienteID e txtNomeCliente de FrmContaReceber.
                frmContaReceber.txtClienteID.Text = numeroComZeros;
                frmContaReceber.txtNomeCliente.Text = nomeFornecedor;
            }
        }

        private void dataGridPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridPesquisar.CurrentRow != null)
            {
                LinhaAtual = dataGridPesquisar.CurrentRow.Index;
            }
        }

        private void FrmLocalizarFornedeor_Load(object sender, EventArgs e)
        {
            ListarFornecedor();
        }
    }
}
