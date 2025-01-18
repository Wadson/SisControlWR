using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SisControl.View
{
    public partial class FrmContaReceber : SisControl.FrmBaseGeral
    {
        public FrmContaReceber()
        {
            InitializeComponent();            
        }
        private TextBox txtProdutoID;
        private TextBox txtNomeProduto;


        private void RealizarPagamento(int id)
        {
            // Simulação de atualização no banco de dados ou na lógica de negócios
            Log($"Pagamento realizado para a conta ID: {id}");

            // Atualiza a interface
            foreach (DataGridViewRow row in dgvContasReceber.Rows)
            {
                if (Convert.ToInt32(row.Cells["Id"].Value) == id)
                {
                    row.Cells["Pago"].Value = true;
                }
            }

            MessageBox.Show($"Pagamento realizado para a conta ID: {id}");
        }

        // Método de log (como previamente discutido)
        private void Log(string message)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}: {message}\n");
        }
        private void AbrirFrmLocalizarCliente()
        {
            if (!Application.OpenForms.OfType<FrmLocalizarCliente>().Any())
            {
                FrmLocalizarCliente frmLocalizarCliente = new FrmLocalizarCliente();
                frmLocalizarCliente.FormChamador = this; // Define o formulário chamador
                frmLocalizarCliente.ShowDialog();
            }
        }



        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            AbrirFrmLocalizarCliente();            
        }

        private void CarregarContasAReceber(string cliente = "", DateTime? dataVencimentoInicio = null, DateTime? dataVencimentoFim = null)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                // Construir a consulta SQL com filtros opcionais
                string query = @"SELECT V.ClienteID, C.NomeCliente, CR.VendaID, CR.ParcelaID, CR.DataRecebimento, CR.ValorRecebido, CR.SaldoRestante, CR.Pago, CR.ContaReceberID, V.DataVenda, V.ValorTotal, P.NumeroParcela, P.DataVencimento, P.ValorParcela, P.Pago, P.ParcelaID 
FROM ContaReceber CR 
INNER JOIN Parcela P ON CR.ParcelaID = P.ParcelaID 
INNER JOIN Venda V ON CR.VendaID = V.VendaID AND P.VendaID = V.VendaID 
INNER JOIN Cliente C ON V.ClienteID = C.ClienteID 
INNER JOIN Recebimentos R ON CR.ContaReceberID = R.ContaReceberID AND P.ParcelaID = R.ParcelaID AND V.VendaID = R.VendaID;
";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cliente", cliente);
                command.Parameters.AddWithValue("@DataVencimentoInicio", dataVencimentoInicio.HasValue ? (object)dataVencimentoInicio.Value : DBNull.Value);
                command.Parameters.AddWithValue("@DataVencimentoFim", dataVencimentoFim.HasValue ? (object)dataVencimentoFim.Value : DBNull.Value);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvContasReceber.DataSource = dataTable;                
            }
        }
    private void txtNomeCliente_TextChanged(object sender, EventArgs e)
    {
        FiltrarContasAReceber();
    }

    private void dtpDataVencimentoInicio_ValueChanged(object sender, EventArgs e)
    {
        FiltrarContasAReceber();
    }

    private void dtpDataVencimentoFim_ValueChanged(object sender, EventArgs e)
    {
        FiltrarContasAReceber();
    }

    private void FiltrarContasAReceber()
    {
        string cliente = txtNomeCliente.Text;
        DateTime? dataVencimentoInicio = dtpDataVencimentoInicio.Checked ? (DateTime?)dtpDataVencimentoInicio.Value : null;
        DateTime? dataVencimentoFim = dtpDataVencimentoFim.Checked ? (DateTime?)dtpDataVencimentoFim.Value : null;

        CarregarContasAReceber(cliente, dataVencimentoInicio, dataVencimentoFim);
    }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmContaReceber_Load(object sender, EventArgs e)
        {
            CarregarContasAReceber();
        }
    }
}
