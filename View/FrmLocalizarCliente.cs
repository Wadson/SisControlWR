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
        public int numeroComZeros { get; set; }
        public string nomeCliente { get; set; }
        public FrmLocalizarCliente()
        {
            InitializeComponent();
            txtPesquisa.TextChanged += txtPesquisa_TextChanged;
        }      
        private void InicializaDataGridView()
        {
            //dataGridPesquisar.MultiSelect = false;

            //Configuração das linhas do DataGridView

            //Redimensiona o tamanho das colunas do DataGridView 
            dataGridPesquisar.Columns[0].Width = 100;
            dataGridPesquisar.Columns[1].Width = 200;
            dataGridPesquisar.Columns[2].Width = 110;
            dataGridPesquisar.Columns[3].Width = 110;
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
            string textoPesquisa = txtPesquisa.Text.ToLower();

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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLocalizarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Verifique se há linhas no dataGridPesquisar e se a linha atual é válida.
            if (dataGridPesquisar.Rows.Count > 0 && LinhaAtual >= 0 && LinhaAtual < dataGridPesquisar.Rows.Count)
            {
                // Obtém o ID do cliente da célula [0, LinhaAtual] do dataGridPesquisar e converte para inteiro.
                ClienteID = Convert.ToInt32(dataGridPesquisar[0, LinhaAtual].Value);

                // Acrescenta zeros à esquerda do ID do cliente até que ele tenha 4 dígitos.
                numeroComZeros = int.Parse(Utilitario.AcrescentarZerosEsquerda(ClienteID, 4));

                // Obtém o nome do cliente da célula [1, LinhaAtual] do dataGridPesquisar e converte para string.
                nomeCliente = dataGridPesquisar[1, LinhaAtual].Value.ToString();

                // Verifica se o formulário chamador é uma instância de FrmVendas.
                if (FormChamador is FrmPedido frmPedido)
                {
                    // Se for, define os textos dos campos txtClienteID e txtNomeCliente de FrmVendas.
                    frmPedido.ClienteID = numeroComZeros;
                    frmPedido.txtNomeCliente.Text = nomeCliente;
                }
                // Verifica se o formulário chamador é uma instância de FrmContaReceber.
                else if (FormChamador is FrmContaReceberr frmContaReceber)
                {
                    // Se for, define os textos dos campos txtClienteID e txtNomeCliente de FrmContaReceber.
                    frmContaReceber.txtClienteID.Text = numeroComZeros.ToString();
                    frmContaReceber.txtNomeCliente.Text = nomeCliente;
                }
            }
            else
            {
                MessageBox.Show("Nenhum cliente encontrado para selecionar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
