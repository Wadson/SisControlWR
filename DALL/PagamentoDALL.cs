using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.DALL
{
    internal class PagamentoDALL
    {
        public void SalvarRegistroPagamento(PagamentoMODEL pagamento)
        {
            var conn = Conexao.Conex(); try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO Pagamento (PagamentoID, ParcelaID, DataPagamento, ValorPago) VALUES (@PagamentoID, @ParcelaID, @DataPagamento, @ValorPago)", conn);

                sql.Parameters.AddWithValue("@PagamentoID",   pagamento.PagamentoID);
                sql.Parameters.AddWithValue("@ParcelaID",   pagamento.ParcelaID);
                sql.Parameters.AddWithValue("@DataPagamento",   pagamento.DataPagamento);
                sql.Parameters.AddWithValue("@ValorPago", pagamento.ValorPago);
                
                conn.Open();
                sql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            conn.Close();

        }

        public void ExcluirTodosPagamentos(PagamentoMODEL parcela)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Pagamento WHERE PagamentoID = @PagamentoID", conn);
                sql.Parameters.AddWithValue("@PagamentoID", parcela.PagamentoID);
                conn.Open();
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }
        public void ExcluiUnicoPagamento(PagamentoMODEL pagamento)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Pagamento WHERE PagamentoID = @PagamentoID", conn);
                sql.Parameters.AddWithValue("@PagamentoID", pagamento.PagamentoID);
                conn.Open();
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }
        public void AtualizaRegistroPagamento(PagamentoMODEL pagamento)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("UPDATE Pagamento SET PagamentoID = @PagamentoID, ParcelaID = @ParcelaID, DataPagamento = @DataPagamento, ValorPago = @ValorPago", conn);
                                
                sql.Parameters.AddWithValue("@ParcelaID", pagamento.ParcelaID);
                sql.Parameters.AddWithValue("@DataPagamento", pagamento.DataPagamento);
                sql.Parameters.AddWithValue("@ValorPago", pagamento.ValorPago);
                sql.Parameters.AddWithValue("@PagamentoID", pagamento.PagamentoID);

                conn.Open();
                sql.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
