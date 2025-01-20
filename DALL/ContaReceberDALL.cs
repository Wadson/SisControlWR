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
    public class ContaReceberDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;"].ConnectionString;

        public void AddContaReceber(ContaReceberModel contaReceber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO ContaReceber (VendaID, ParcelaID, DataRecebimento, ValorRecebido, SaldoRestante Observacao, ContaReceberID) 
                             VALUES (@VendaID, @ParcelaID, @DataRecebimento, @ValorRecebido,@SaldoRestante, @Observacao, @Pago, @ContaReceberID)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", contaReceber.VendaID);
                command.Parameters.AddWithValue("@ParcelaID", contaReceber.ParcelaID);
                command.Parameters.AddWithValue("@DataRecebimento", contaReceber.DataRecebimento);
                command.Parameters.AddWithValue("@ValorRecebido", contaReceber.ValorRecebido);
                command.Parameters.AddWithValue("@SaldoRestante", contaReceber.SaldoRestante);
                command.Parameters.AddWithValue("@Pago", contaReceber.Pago);
                command.Parameters.AddWithValue("@ContaReceberID", contaReceber.ContaReceberID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateContaReceber(ContaReceberModel contaReceber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE ContaReceber SET ParcelaID = @ParcelaID, DataRecebimento = @DataRecebimento, ValorRecebido = @ValorRecebido, MetodoRecebimento = @MetodoRecebimento, Observacao = @Observacao 
                             WHERE ContaReceberID = @ContaReceberID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@VendaID", contaReceber.VendaID);
                command.Parameters.AddWithValue("@ParcelaID", contaReceber.ParcelaID);
                command.Parameters.AddWithValue("@DataRecebimento", contaReceber.DataRecebimento);
                command.Parameters.AddWithValue("@ValorRecebido", contaReceber.ValorRecebido);
                command.Parameters.AddWithValue("@SaldoRestante", contaReceber.SaldoRestante);
                command.Parameters.AddWithValue("@Pago", contaReceber.Pago);
                command.Parameters.AddWithValue("@ContaReceberID", contaReceber.ContaReceberID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteContaReceber(int contaReceberId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ContaReceber WHERE ContaReceberID = @ContaReceberID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ContaReceberID", contaReceberId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<ContaReceberModel> GetContasReceber(Guid parcelaId)
        {
            List<ContaReceberModel> contasReceber = new List<ContaReceberModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ContaReceber WHERE ParcelaID = @ParcelaID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParcelaID", parcelaId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int contaReceberID;
                        int parcelaID;

                        // Verificar e converter ContaReceberID
                        if (int.TryParse(reader["ContaReceberID"].ToString(), out contaReceberID) &&
                            int.TryParse(reader["ParcelaID"].ToString(), out parcelaID))
                        {
                            contasReceber.Add(new ContaReceberModel
                            {
                                ContaReceberID = contaReceberID,
                                ParcelaID = parcelaID,
                                DataRecebimento = reader["DataRecebimento"] != DBNull.Value ? (DateTime)reader["DataRecebimento"] : (DateTime?)null,
                                ValorRecebido = (decimal)reader["ValorRecebido"],
                                SaldoRestante = (decimal)reader["SaldoRestante"],
                                Pago = (bool)reader["Pago"]
                            });
                        }
                        else
                        {
                            // Lidando com falha de conversão
                            throw new Exception("Falha ao converter ContaReceberID ou ParcelaID para Guid.");
                        }
                    }
                }
            }
            return contasReceber;
        }


    }
}
