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
        private string connectionString = ConfigurationManager.ConnectionStrings["Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;"].ConnectionString;

        public void AddVenda(VendaModel venda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Venda (DataVenda, ClienteID, ValorTotal, VendaID) 
                             VALUES (@DataVenda, @ClienteID, @ValorTotal, @VendaID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                command.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                command.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                command.Parameters.AddWithValue("@VendaID", venda.VendaID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateVenda(VendaModel venda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Venda WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public VendaModel GetVenda(Guid vendaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
                            VendaID = Guid.Parse(reader["VendaID"].ToString()),
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
