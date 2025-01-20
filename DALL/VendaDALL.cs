using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SisControl.DALL
{
    public class VendaDAL
    {   
        public void AddVenda(VendaModel venda)
        { 
            using (var conn = Conexao.Conex())  
            {
                string query = @"INSERT INTO Venda (DataVenda, ClienteID, ValorTotal, VendaID) 
                             VALUES (@DataVenda, @ClienteID, @ValorTotal, @VendaID)";
                SqlCommand command = new SqlCommand(query, conn);//connection);
                command.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                command.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                command.Parameters.AddWithValue("@VendaID", venda.VendaID);
                 
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateVenda(VendaModel venda)
        {
            using (var connection = Conexao.Conex())
            {
                string query = @"UPDATE Venda SET DataVenda = @DataVenda, ClienteID = @ClienteID, ValorTotal = @ValorTotal 
                             WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                command.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                command.Parameters.AddWithValue("@VendaID", venda.VendaID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteVenda(int vendaId)
        {
            var connection = Conexao.Conex();
            using ( connection )
            {
                string query = "DELETE FROM Venda WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public VendaModel GetVenda(int vendaId)
        {
            
            using (var connection = Conexao.Conex())
            {
                string query = "SELECT * FROM Venda WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new VendaModel
                        {
                            VendaID = int.Parse(reader["VendaID"].ToString()),
                            DataVenda = (DateTime)reader["DataVenda"],
                            ClienteID = (int)reader["ClienteID"],
                            ValorTotal = (decimal)reader["ValorTotal"]
                        };
                    }
                }
            }
            return null;
        }
    }
}
