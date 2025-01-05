using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.DALL
{
    internal class ParcelaDALL
    {
        public void SalvarParcelas(ParcelaMODEL parcela)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO Parcela (ParcelaID, ContaReceberID, NumeroParcela,  ValorParcela, DataVencimento) VALUES (@ParcelaID, @ContaReceberID, @NumeroParcela, @ValorParcela, @DataVencimento)", conn);

                sql.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);
                sql.Parameters.AddWithValue("@ContaReceberID", parcela.ContaReceberID);
                sql.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                sql.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
                sql.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);

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
        }

        public void ExcluirTodasParcela(ParcelaMODEL parcela)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Parcela WHERE ContaReceberID = @ContaReceberID", conn);
                sql.Parameters.AddWithValue("@ContaReceberID", parcela.ContaReceberID);
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
        public void ExcluiParcelaUnica(ParcelaMODEL parcelas)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Parcela WHERE ParcelaID = @ParcelaID", conn);
                sql.Parameters.AddWithValue("@ParcelaID", parcelas.ParcelaID);

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
        public void AtualizaParcela(ParcelaMODEL parc)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("UPDATE Parcela SET ParcelaID = @ParcelaID, ContaReceberID = @ContaReceberID, NumeroParcela = @NumeroParcela,  ValorParcela = @ValorParcela, DataVencimento = @DataVencimento WHERE ParcelaID = @ParcelaID", conn);

                sql.Parameters.AddWithValue("@ContaReceberID", parc.ContaReceberID);
                sql.Parameters.AddWithValue("@NumeroParcela", parc.NumeroParcela);
                sql.Parameters.AddWithValue("@ValorParcela", parc.ValorParcela);
                sql.Parameters.AddWithValue("@DataVencimento", parc.DataVencimento);
                sql.Parameters.AddWithValue("@ParcelaID", parc.ParcelaID);

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
