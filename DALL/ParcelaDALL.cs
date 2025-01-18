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
    public class ParcelaDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;"].ConnectionString;

        public void AddParcela(ParcelaModel parcela)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Parcela (ParcelaID, VendaID, NumeroParcela, DataVencimento, ValorParcela, ValorRecebido, SaldoRestante, Pago) 
                             VALUES (@ParcelaID, @VendaID, @NumeroParcela, @DataVencimento, @ValorParcela, @ValorRecebido, @SaldoRestante, @Pago)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", parcela.VendaID);
                command.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                command.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                command.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
                command.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);                
                command.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
                command.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);
                command.Parameters.AddWithValue("@Pago", parcela.Pago);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateParcela(ParcelaModel parcela)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Parcela SET DataVencimento = @DataVencimento, ValorParcela = @ValorParcela, StatusParcela = @StatusParcela, FormaPagamento = @FormaPagamento 
                             WHERE ParcelaID = @ParcelaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", parcela.VendaID);
                command.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                command.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                command.Parameters.AddWithValue("@ValorParcela", parcela.ValorParcela);
                command.Parameters.AddWithValue("@ValorRecebido", parcela.ValorRecebido);
                command.Parameters.AddWithValue("@SaldoRestante", parcela.SaldoRestante);
                command.Parameters.AddWithValue("@ParcelaID", parcela.ParcelaID);
                command.Parameters.AddWithValue("@Pago", parcela.Pago);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteParcela(int parcelaId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Parcela WHERE ParcelaID = @ParcelaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParcelaID", parcelaId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ParcelaModel> GetParcelas(Guid vendaId)
        {
            List<ParcelaModel> parcelas = new List<ParcelaModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Parcela WHERE VendaID = @VendaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", vendaId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guid parcelaID;
                        Guid vendaID;

                        // Verificar e converter ParcelaID e VendaID
                        if (Guid.TryParse(reader["ParcelaID"].ToString(), out parcelaID) &&
                            Guid.TryParse(reader["VendaID"].ToString(), out vendaID))
                        {
                            parcelas.Add(new ParcelaModel
                            {
                                ParcelaID = parcelaID,
                                VendaID = vendaID,
                                NumeroParcela = (int)reader["NumeroParcela"],
                                DataVencimento = (DateTime)reader["DataVencimento"],
                                ValorParcela = (decimal)reader["ValorParcela"],
                                ValorRecebido = (decimal)reader["ValorRecebido"],
                                SaldoRestante = (decimal)reader["SaldoRestante"],
                                Pago = (bool)reader["Pago"]
                            });
                        }
                        else
                        {
                            // Lidando com falha de conversão
                            throw new Exception("Falha ao converter ParcelaID ou VendaID para Guid.");
                        }
                    }
                }
            }
            return parcelas;
        }

    }
}
