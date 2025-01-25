using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace SisControl.View
{
    public partial class FrmGerarParcelas : FrmModeloForm  
    {
        public int clienteID;
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
        public int parcelaID { get; set; }

        // Método público para definir o valor de parcelaID
        public void SetParcelaID(int id)
        {
            // Atribui o valor passado do parâmetro id para a variável pública parcelaID
            parcelaID = id;
        }


        public void PersonalizarDataGridViewParc(DataGridView dgv)
        { 
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
             
        }
        private void GerarParcelas()
        {
            try
            {
                int dias = Convert.ToInt32(txtDias.Text);
                string nomeCliente = txtNomeCliente.Text;
                int numeroParcelas = Convert.ToInt32(txtQtdParcelas.Text);
                decimal valorTotal = Convert.ToDecimal(txtTotal.Text);
                DateTime dataVencimento = Convert.ToDateTime(dtPrimeiraParc.Value).Date;
                decimal valorParcela = Math.Round(valorTotal / numeroParcelas, 2);

                DataTable dt = dataGrid_Parcelas.DataSource as DataTable;

                if (dt == null || dt.Columns.Count == 0)
                {
                    dt = new DataTable();
                    dt.Columns.Add("ParcelaID", typeof(int));
                    dt.Columns.Add("ValorParcela", typeof(decimal));
                    dt.Columns.Add("NumeroParcela", typeof(int));
                    dt.Columns.Add("DataVencimento", typeof(DateTime));

                    dataGrid_Parcelas.DataSource = dt;
                }
                else
                {
                    // Desvincula Temporariamente
                    dataGrid_Parcelas.DataSource = null;

                    dt.Rows.Clear();

                    // Reassocia a fonte de dados
                    dataGrid_Parcelas.DataSource = dt;
                }

                int parcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela");
                for (var i = 0; i < numeroParcelas; i++)
                {
                    dt.Rows.Add(parcelaID, valorParcela, i + 1, dataVencimento.AddDays(i * dias).Date);
                    parcelaID++;
                }

                FrmPedido frmPedidos = Application.OpenForms.OfType<FrmPedido>().FirstOrDefault();

                if (frmPedidos != null)
                {
                    frmPedidos.ReceberDadosParcelas(dt);
                }
                else
                {
                    MessageBox.Show("FrmVendas não está aberto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar parcelas: " + ex.Message + "\n" + ex.StackTrace, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //private void GerarParcelas()
        //{
        //    try
        //    {
        //        int dias = Convert.ToInt32(txtDias.Text);
        //        nomeCliente = txtNomeCliente.Text;
        //        numeroParcelas = Convert.ToInt32(txtQtdParcelas.Text);
        //        valorTotal = Convert.ToDecimal(txtTotal.Text);
        //        // Definir a data de vencimento para incluir apenas a data, sem a hora
        //        dataVencimento = Convert.ToDateTime(dtPrimeiraParc.Value).Date;
        //        valorParcela = Math.Round(valorTotal / numeroParcelas, 2); // Arredondar para duas casas decimais

        //        // Obter a fonte de dados do DataGridView, se houver
        //        DataTable dt = dataGrid_Parcelas.DataSource as DataTable;

        //        // Se a fonte de dados estiver vazia, inicialize-a
        //        if (dt == null || dt.Columns.Count == 0)
        //        {
        //            dt = new DataTable();

        //            // Definir colunas no DataTable apenas uma vez
        //            dt.Columns.Add("ParcelaID", typeof(int)); // Alterado para int
        //            dt.Columns.Add("ValorParcela", typeof(decimal));
        //            dt.Columns.Add("NumeroParcela", typeof(int));
        //            dt.Columns.Add("DataVencimento", typeof(DateTime));

        //            dataGrid_Parcelas.DataSource = dt;
        //        }
        //        else
        //        {
        //            // Limpar as linhas do DataTable antes de adicionar novas
        //            dt.Rows.Clear();
        //        }

        //        int parcelaID = Utilitario.GerarNovoCodigoID("ParcelaID", "Parcela"); // Gerar um novo ParcelaID para cada parcela
        //        // Adicionar linhas ao DataTable com novos ParcelaID gerados
        //        for (var i = 0; i < numeroParcelas; i++)
        //        {                   
        //            dt.Rows.Add(parcelaID, valorParcela, i + 1, dataVencimento.AddDays(i * dias).Date);
        //            parcelaID++;
        //        }

        //        // Tentar obter a instância correta do FrmVendas
        //        FrmPedido frmPedidos = Application.OpenForms.OfType<FrmPedido>().FirstOrDefault();

        //        if (frmPedidos != null)
        //        {
        //            frmPedidos.ReceberDadosParcelas(dt); // Passa o DataTable para o método no FrmVendas                    
        //        }
        //        else
        //        {
        //            MessageBox.Show("FrmVendas não está aberto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao gerar parcelas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        //private void GerarParcelas()
        //{
        //    try
        //    {
        //        int dias = Convert.ToInt32(txtDias.Value);
        //        nomeCliente = txtNomeCliente.Text;
        //        numeroParcelas = Convert.ToInt32(txtQtdParcelas.Value);
        //        valorTotal = Convert.ToDecimal(txtTotal.Text);
        //        // Definir a data de vencimento para incluir apenas a data, sem a hora
        //        dataVencimento = Convert.ToDateTime(dtPrimeiraParc.Value).Date;
        //        valorParcela = Math.Round(valorTotal / numeroParcelas, 2); // Arredondar para duas casas decimais

        //        // Obter a fonte de dados do DataGridView, se houver
        //        DataTable dt = dataGrid_Parcelas.DataSource as DataTable;

        //        // Se a fonte de dados estiver vazia, inicialize-a
        //        if (dt == null || dt.Columns.Count == 0)
        //        {
        //            dt = new DataTable();

        //            // Definir colunas no DataTable apenas uma vez
        //            dt.Columns.Add("ParcelaID", typeof(decimal));
        //            dt.Columns.Add("ValorParcela", typeof(decimal));
        //            dt.Columns.Add("NumeroParcela", typeof(int));
        //            dt.Columns.Add("DataVencimento", typeof(DateTime));

        //            dataGrid_Parcelas.DataSource = dt;
        //        }
        //        else
        //        {
        //            // Limpar as linhas do DataTable antes de adicionar novas
        //            dt.Rows.Clear();
        //        }

        //        // Adicionar linhas ao DataTable
        //        for (var i = 0; i < numeroParcelas; i++)
        //        {
        //            dt.Rows.Add(valorParcela, (i + 1), dataVencimento.AddDays(i * dias).Date);
        //        }

        //        // Tentar obter a instância correta do FrmVendas
        //        FrmVendas frmVendas = Application.OpenForms.OfType<FrmVendas>().FirstOrDefault();

        //        if (frmVendas != null)
        //        {
        //            frmVendas.ReceberDadosParcelas(dt); // Passa o DataTable para o método no FrmVendas                    
        //        }
        //        else
        //        {
        //            MessageBox.Show("FrmVendas não está aberto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao gerar parcelas: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        public List<ParcelaModel> ObterParcelas()
        {
            return parcelas;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {            
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {    
        }

        private void txtDias_ValueChanged(object sender, EventArgs e)
        {           
        }

        private void dtPrimeiraParc_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtQtdParcelas_ValueChanged(object sender, EventArgs e)
        {            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {           
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void txtQtdParcelas_Leave(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGerarParcelas_Click(object sender, EventArgs e)
        {
            GerarParcelas();
        }

        private void FrmGerarParcelas_Load(object sender, EventArgs e)
        {            
        }
    }
}
