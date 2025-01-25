using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SisControl.DALL
{
    internal class PagamentoParcialDal
    {
        public void InserirPagamentoParcial(PagamentoParcialModel pagamentoParcial)
        {
            using (var conn = Conexao.Conex())
            {
                conn.Open();
                string query = "INSERT INTO PagamentosParciais (ParcelaID, ValorPago, DataPagamento) VALUES (@ParcelaID, @ValorPago, @DataPagamento)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ParcelaID", pagamentoParcial.ParcelaID);
                    cmd.Parameters.AddWithValue("@ValorPago", pagamentoParcial.ValorPago);
                    cmd.Parameters.AddWithValue("@DataPagamento", pagamentoParcial.DataPagamento);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PagamentoParcialModel> ObterPagamentosParciaisPorParcela(int parcelaID)
        {
            List<PagamentoParcialModel> pagamentosParciais = new List<PagamentoParcialModel>();

            using (var conn = Conexao.Conex())
            {
                conn.Open();
                string query = "SELECT PagamentoParcialID, ParcelaID, ValorPago, DataPagamento FROM PagamentosParciais WHERE ParcelaID = @ParcelaID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ParcelaID", parcelaID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PagamentoParcialModel pagamentoParcial = new PagamentoParcialModel
                            {
                                PagamentoParcialID = reader.GetInt32(0),
                                ParcelaID = reader.GetInt32(1),
                                ValorPago = reader.GetDecimal(2),
                                DataPagamento = reader.GetDateTime(3)
                            };
                            pagamentosParciais.Add(pagamentoParcial);
                        }
                    }
                }
            }

            return pagamentosParciais;
        }
    }
}
