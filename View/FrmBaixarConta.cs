using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using SisControl.View;
using static SisControl.View.FrmContaReceberr;

namespace SisControl
{
    public partial class FrmBaixarConta : KryptonForm
    {
        private Parcela _parcela;       
        public FrmBaixarConta(Parcela parcela)
        {
            InitializeComponent();
           
            _parcela = parcela;            
            CarregarDadosParcela();
            txtValorPago.Leave += new EventHandler(txtValorPago_Leave);
        }
        private void CarregarDadosParcela()
        {
            txtParcelaID.Text = _parcela.ParcelaID.ToString();
            txtNumeroParcela.Text = _parcela.NumeroParcela.ToString();
            txtValorParcela.Text = _parcela.ValorParcela.ToString("N2");
            dtpDataVencimento.Value = _parcela.DataVencimento;
            txtSaldoRestante.Text = _parcela.SaldoRestante.ToString("N2");
            txtValorPago.Text = _parcela.ValorPago.ToString("N2");
        }

        private void FrmBaixarConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                //this.Close();
                if (MessageBox.Show("Deseja sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        private void BaixarConta()
        {
            // Capturar os valores dos TextBoxes
            int parcelaID = int.Parse(txtParcelaID.Text);
            decimal valorPagoParcial = decimal.Parse(txtValorPago.Text);
            DateTime dataPagamento = DateTime.Parse(dtpDataPagamento.Text);

            // Buscar os valores atuais da parcela
            decimal valorPagoAtual = 0;
            decimal saldoRestanteAtual = 0;

            using (var conn = Conexao.Conex())
            {
                conn.Open();

                // Buscar os valores atuais da parcela
                string selectParcelaQuery = "SELECT ValorRecebido, SaldoRestante FROM Parcela WHERE ParcelaID = @ParcelaID";

                using (SqlCommand cmdSelect = new SqlCommand(selectParcelaQuery, conn))
                {
                    cmdSelect.Parameters.AddWithValue("@ParcelaID", parcelaID);
                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            valorPagoAtual = reader.GetDecimal(0);
                            saldoRestanteAtual = reader.GetDecimal(1);
                        }
                    }
                }
            }

            // Calcular o novo valor pago e o novo saldo restante
            decimal novoValorPago = valorPagoAtual + valorPagoParcial;
            decimal novoSaldoRestante = saldoRestanteAtual - valorPagoParcial;
            bool pago = novoSaldoRestante <= 0;

            // Inserir registro na tabela PagamentoParcial
            string insertPagamentoParcialQuery = "INSERT INTO PagamentosParciais (ParcelaID, ValorPago, DataPagamento) VALUES (@ParcelaID, @ValorPago, @DataPagamento)";

            // Atualizar a tabela Parcela
            string updateParcelaQuery = "UPDATE Parcela SET Pago = @Pago, ValorRecebido = @ValorRecebido, SaldoRestante = @SaldoRestante WHERE ParcelaID = @ParcelaID";

            // Atualizar a tabela ContaReceber
            string updateContaReceberQuery = "UPDATE ContaReceber SET Pago = @Pago, ValorRecebido = @ValorRecebido, DataRecebimento = @DataRecebimento, SaldoRestante = @SaldoRestante WHERE ParcelaID = @ParcelaID";

            using (var conn = Conexao.Conex())
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Inserir na tabela PagamentoParcial
                        using (SqlCommand cmdPagamentoParcial = new SqlCommand(insertPagamentoParcialQuery, conn, transaction))
                        {
                            cmdPagamentoParcial.Parameters.AddWithValue("@ParcelaID", parcelaID);
                            cmdPagamentoParcial.Parameters.AddWithValue("@ValorPago", valorPagoParcial);
                            cmdPagamentoParcial.Parameters.AddWithValue("@DataPagamento", dataPagamento);
                            cmdPagamentoParcial.ExecuteNonQuery();
                        }

                        // Atualizar tabela Parcela
                        using (SqlCommand cmdParcela = new SqlCommand(updateParcelaQuery, conn, transaction))
                        {
                            cmdParcela.Parameters.AddWithValue("@Pago", pago);
                            cmdParcela.Parameters.AddWithValue("@ValorRecebido", novoValorPago);
                            cmdParcela.Parameters.AddWithValue("@SaldoRestante", novoSaldoRestante);
                            cmdParcela.Parameters.AddWithValue("@ParcelaID", parcelaID);
                            cmdParcela.ExecuteNonQuery();
                        }

                        // Atualizar tabela ContaReceber
                        using (SqlCommand cmdContaReceber = new SqlCommand(updateContaReceberQuery, conn, transaction))
                        {
                            cmdContaReceber.Parameters.AddWithValue("@Pago", pago);
                            cmdContaReceber.Parameters.AddWithValue("@ValorRecebido", novoValorPago);
                            cmdContaReceber.Parameters.AddWithValue("@DataRecebimento", dataPagamento);
                            cmdContaReceber.Parameters.AddWithValue("@SaldoRestante", novoSaldoRestante);
                            cmdContaReceber.Parameters.AddWithValue("@ParcelaID", parcelaID);
                            cmdContaReceber.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction in case of error
                        transaction.Rollback();
                        throw new Exception("Erro ao baixar conta: " + ex.Message);
                    }
                }
            }
            this.Close();
        }

        //private void BaixarConta()
        //{
        //    // Capturar os valores dos TextBoxes
        //    int parcelaID = int.Parse(txtParcelaID.Text);
        //    decimal valorPagoParcial = decimal.Parse(txtValorPago.Text);
        //    DateTime dataPagamento = DateTime.Parse(dtpDataPagamento.Text);

        //    // Buscar o valor pago e o saldo restante atuais da parcela no banco de dados
        //    decimal valorPagoAtual = 0;
        //    decimal saldoRestanteAtual = 0;

        //    using (var conn = Conexao.Conex())
        //    {
        //        conn.Open();

        //        // Buscar os valores atuais da parcela
        //        string selectParcelaQuery = "SELECT ValorRecebido, SaldoRestante FROM Parcela WHERE ParcelaID = @ParcelaID";

        //        using (SqlCommand cmdSelect = new SqlCommand(selectParcelaQuery, conn))
        //        {
        //            cmdSelect.Parameters.AddWithValue("@ParcelaID", parcelaID);
        //            using (SqlDataReader reader = cmdSelect.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    valorPagoAtual = reader.GetDecimal(0);
        //                    saldoRestanteAtual = reader.GetDecimal(1);
        //                }
        //            }
        //        }
        //        this.Close();
        //    }

        //    // Calcular o novo valor pago e o novo saldo restante
        //    decimal novoValorPago = valorPagoAtual + valorPagoParcial;
        //    decimal novoSaldoRestante = saldoRestanteAtual - valorPagoParcial;
        //    bool pago = novoSaldoRestante <= 0;

        //    // Atualizar a tabela Parcela
        //    string updateParcelaQuery = "UPDATE Parcela SET Pago = @Pago, ValorRecebido = @ValorRecebido, SaldoRestante = @SaldoRestante WHERE ParcelaID = @ParcelaID";

        //    // Atualizar a tabela ContaReceber
        //    string updateContaReceberQuery = "UPDATE ContaReceber SET Pago = @Pago, ValorRecebido = @ValorRecebido, DataRecebimento = @DataRecebimento, SaldoRestante = @SaldoRestante WHERE ParcelaID = @ParcelaID";

        //    using (var conn = Conexao.Conex())
        //    {
        //        conn.Open();

        //        // Atualizar tabela Parcela
        //        using (SqlCommand cmdParcela = new SqlCommand(updateParcelaQuery, conn))
        //        {
        //            cmdParcela.Parameters.AddWithValue("@Pago", pago);
        //            cmdParcela.Parameters.AddWithValue("@ValorRecebido", novoValorPago);
        //            cmdParcela.Parameters.AddWithValue("@SaldoRestante", novoSaldoRestante);
        //            cmdParcela.Parameters.AddWithValue("@ParcelaID", parcelaID);
        //            cmdParcela.ExecuteNonQuery();
        //        }

        //        // Atualizar tabela ContaReceber
        //        using (SqlCommand cmdContaReceber = new SqlCommand(updateContaReceberQuery, conn))
        //        {
        //            cmdContaReceber.Parameters.AddWithValue("@Pago", pago);
        //            cmdContaReceber.Parameters.AddWithValue("@ValorRecebido", novoValorPago);
        //            cmdContaReceber.Parameters.AddWithValue("@DataRecebimento", dataPagamento);
        //            cmdContaReceber.Parameters.AddWithValue("@SaldoRestante", novoSaldoRestante);
        //            cmdContaReceber.Parameters.AddWithValue("@ParcelaID", parcelaID);
        //            cmdContaReceber.ExecuteNonQuery();
        //        }
        //    }
        //    this.Close();
        //    // Atualizar DataGridView no formulário principal

        //}





        private void btnReceber_Click(object sender, EventArgs e)
        {
            BaixarConta();
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValorPago.Text, out decimal valorRecebido))
            {
                txtValorPago.Text = valorRecebido.ToString("N2");
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor válido.");
                txtValorPago.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
