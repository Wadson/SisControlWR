using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmGerarParcelas : SisControl.FrmBaseGeral
    {
        public int parcelaID, clienteID;
        public int vendaID;
        public List<ParcelaModel> parcelas;
        public decimal valorParcela, valorTotal;
        public int numeroParcelas;
        public string nomeCliente = "";
        public DateTime dataVencimento;
        private string QueryParcela = "SELECT MAX(ParcelaID)  FROM Parcela";
        public FrmGerarParcelas()
        {
            InitializeComponent();
            
            this.valorTotal = valorTotal;
            this.numeroParcelas = numeroParcelas;
            this.parcelas = new List<ParcelaModel>();
            PersonalizarDataGridViewParc(dataGrid_Parcelas);
        }
       
        public void PersonalizarDataGridViewParc(DataGridView dgv)
        {
            // Configuração dos cabeçalhos das colunas
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false; // Necessário para aplicar as cores personalizadas no cabeçalho

            // Estilo alternado das linhas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Alinhamento e fonte das células
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = new Font("Arial", 10);

            // Ajustar colunas automaticamente
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Tornar o grid somente leitura
            dgv.ReadOnly = true;

            // Estilo das bordas das células
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Estilo da seleção das células
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Esconder a coluna de cabeçalho de linha
            dgv.RowHeadersVisible = false;

            // Cor do grid
            dgv.GridColor = Color.Black;
          
            // Ocultar coluna específica se necessário
            //if (dgv.Columns.Contains("ParcelaID"))
            //{
            //    dgv.Columns["ParcelaID"].Visible = false; // Oculta a coluna "ParcelaID"
            //}
            //if (dgv.Columns.Contains("VendaID"))
            //{
            //    dgv.Columns["VendaID"].Visible = false; // Oculta a coluna "VendaID"
            //}
        }

        private void GerarParcelas()
        {
            try
            {
                int dias = Convert.ToInt32(txtDias.Value);
                nomeCliente = txtNomeCliente.Text;
                numeroParcelas = Convert.ToInt32(txtQtdParcelas.Value);
                valorTotal = Convert.ToDecimal(txtTotal.Text);
                // Definir a data de vencimento para incluir apenas a data, sem a hora
                dataVencimento = Convert.ToDateTime(dtPrimeiraParc.Value).Date;
                valorParcela = Math.Round(valorTotal / numeroParcelas, 2); // Arredondar para duas casas decimais

                // Obter a fonte de dados do DataGridView, se houver
                DataTable dt = dataGrid_Parcelas.DataSource as DataTable;

                // Se a fonte de dados estiver vazia, inicialize-a
                if (dt == null || dt.Columns.Count == 0)
                {
                    dt = new DataTable();

                    // Definir colunas no DataTable apenas uma vez                    
                    dt.Columns.Add("ValorParcela", typeof(decimal));
                    dt.Columns.Add("NumeroParcela", typeof(int));
                    dt.Columns.Add("DataVencimento", typeof(DateTime));

                    dataGrid_Parcelas.DataSource = dt;
                }
                else
                {
                    // Limpar as linhas do DataTable antes de adicionar novas
                    dt.Rows.Clear();
                }

                // Adicionar linhas ao DataTable
                for (var i = 0; i < numeroParcelas; i++)
                {
                    dt.Rows.Add(valorParcela, (i + 1), dataVencimento.AddDays(i * dias).Date);
                }

                // Tentar obter a instância correta do FrmVendas
                FrmVendas frmVendas = Application.OpenForms.OfType<FrmVendas>().FirstOrDefault();

                if (frmVendas != null)
                {
                    frmVendas.ReceberDadosParcelas(dt); // Passa o DataTable para o método no FrmVendas                    
                }
                else
                {
                    MessageBox.Show("FrmVendas não está aberto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar parcelas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public List<ParcelaModel> ObterParcelas()
        {
            return parcelas;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {            
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtDias_ValueChanged(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void dtPrimeiraParc_ValueChanged(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void txtQtdParcelas_ValueChanged(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void FrmGerarParcelas_Load(object sender, EventArgs e)
        {            
        }
    }
}
