using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace SisControl.DALL
{
    public class ItemVendaDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;"].ConnectionString;

        public void AddItemVenda(ItemVendaModel itemVenda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ItemVenda (VendaID, ProdutoID, Quantidade, PrecoUnitario, ItemVendaID) 
                             VALUES (@VendaID, @ProdutoID, @Quantidade, @PrecoUnitario, @ItemVendaID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", itemVenda.VendaID);
                command.Parameters.AddWithValue("@ProdutoID", itemVenda.ProdutoID);
                command.Parameters.AddWithValue("@Quantidade", itemVenda.Quantidade);
                command.Parameters.AddWithValue("@PrecoUnitario", itemVenda.PrecoUnitario);
                command.Parameters.AddWithValue("@ItemVendaID", itemVenda.ItemVendaID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateItemVenda(ItemVendaModel itemVenda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE ItemVenda SET ProdutoID = @ProdutoID, Quantidade = @Quantidade, PrecoUnitario = @PrecoUnitario 
                             WHERE ItemVendaID = @ItemVendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProdutoID", itemVenda.ProdutoID);
                command.Parameters.AddWithValue("@Quantidade", itemVenda.Quantidade);
                command.Parameters.AddWithValue("@PrecoUnitario", itemVenda.PrecoUnitario);
                command.Parameters.AddWithValue("@ItemVendaID", itemVenda.ItemVendaID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteItemVenda(int itemVendaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ItemVenda WHERE ItemVendaID = @ItemVendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemVendaID", itemVendaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ItemVendaModel> GetItensVenda(Guid vendaId)
        {
            List<ItemVendaModel> itens = new List<ItemVendaModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ItemVenda WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid itemVendaID;
                        Guid vendaID;

                        // Verificar e converter ItemVendaID e VendaID
                        if (Guid.TryParse(reader["ItemVendaID"].ToString(), out itemVendaID) &&
                            Guid.TryParse(reader["VendaID"].ToString(), out vendaID))
                        {
                            itens.Add(new ItemVendaModel
                            {
                                ItemVendaID = itemVendaID,
                                VendaID = Convert.ToInt32(vendaID),
                                ProdutoID = (int)reader["ProdutoID"],
                                Quantidade = (int)reader["Quantidade"],
                                PrecoUnitario = (decimal)reader["PrecoUnitario"]
                            });
                        }
                        else
                        {
                            // Lidando com falha de conversão
                            throw new Exception("Falha ao converter ItemVendaID ou VendaID para Guid.");
                        }
                    }
                }
            }
            return itens;
        }



        //public DataTable ObterItensDeVenda()
        //{
        //    DataTable dataTable = new DataTable();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT Nome, Preco FROM ItensDeVenda";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            connection.Open();
        //            SqlDataAdapter adapter = new SqlDataAdapter(command);
        //            adapter.Fill(dataTable);
        //        }
        //    }

        //    return dataTable;
        //}
    }
}
