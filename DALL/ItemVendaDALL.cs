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
        public void AddItemVenda(ItemVendaModel itemVenda)
        {
            using (var connection = Conexao.Conex())
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
            using (var connection = Conexao.Conex())
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
            using (var connection = Conexao.Conex())
            {
                string query = "DELETE FROM ItemVenda WHERE ItemVendaID = @ItemVendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemVendaID", itemVendaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ItemVendaModel> GetItensVenda(int vendaId)
        {
            List<ItemVendaModel> itens = new List<ItemVendaModel>();
            using (var connection = Conexao.Conex())
            {
                string query = "SELECT * FROM ItemVenda WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int itemVendaID = (int)reader["ItemVendaID"];
                        int vendaID = (int)reader["VendaID"];

                        itens.Add(new ItemVendaModel
                        {
                            ItemVendaID = itemVendaID,
                            VendaID = vendaID,
                            ProdutoID = (int)reader["ProdutoID"],
                            Quantidade = (int)reader["Quantidade"],
                            PrecoUnitario = (decimal)reader["PrecoUnitario"]
                        });
                    }
                }
            }
            return itens;
        }       
    }
}
