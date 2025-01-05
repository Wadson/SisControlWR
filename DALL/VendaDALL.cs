using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.DALL
{
    internal class VendaDALL
    {
        public void SalvarVenda(VendaMODEL venda)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO Venda (VendaID, ClienteID, DataVenda, ValorTotal) " +
                "VALUES (@VendaID, @ClienteID, @DataVenda, @ValorTotal)", conn);

                sql.Parameters.AddWithValue("@VendaID", venda.VendaID);
                sql.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                sql.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                sql.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);

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
        public void excluirVenda(VendaMODEL venda)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Venda WHERE VendaID = @VendaID", conn);
                sql.Parameters.AddWithValue("@VendaID", venda.VendaID);
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

        public void atualizaVenda(VendaMODEL venda)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("UPDATE Venda SET VendaID = @VendaID, ClienteID = @ClienteID, DataVenda = @DataVenda, ValorTotal = @ValorTotal", conn);

                sql.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                sql.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                sql.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                sql.Parameters.AddWithValue("@VendaID", venda.VendaID);

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
