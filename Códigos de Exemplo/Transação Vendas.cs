using System;
using System.Data;
using System.Data.SqlClient;

public class VendaService
{
    private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Data Source=DESKTOP-WR\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;"].ConnectionString;

    public void InserirVenda(Venda venda)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                // Inserir Venda
                string insertVendaQuery = "INSERT INTO Vendas (VendaID, DataVenda, ClienteID, ValorTotal) OUTPUT INSERTED.VendaID VALUES (@VendaID, @DataVenda, @ClienteID, @ValorTotal)";
                SqlCommand cmdVenda = new SqlCommand(insertVendaQuery, con, transaction);
                cmdVenda.Parameters.AddWithValue("@VendaID", venda.VendaID);
                cmdVenda.Parameters.AddWithValue("@DataVenda", venda.DataVenda);
                cmdVenda.Parameters.AddWithValue("@ClienteID", venda.ClienteID);
                cmdVenda.Parameters.AddWithValue("@ValorTotal", venda.ValorTotal);
                int vendaId = (int)cmdVenda.ExecuteScalar();

                // Inserir Itens da Venda
                foreach (var item in venda.ItensVenda)
                {
                    string insertItemVendaQuery = "INSERT INTO ItensVenda (ItemVendaID, VendaID, ProdutoID, Quantidade, PrecoUnitario) VALUES (@ItemVendaID, @VendaID, @ProdutoID, @Quantidade, @PrecoUnitario)";
                    SqlCommand cmdItemVenda = new SqlCommand(insertItemVendaQuery, con, transaction);
                    cmdItemVenda.Parameters.AddWithValue("@ItemVendaID", vendaId);
                    cmdItemVenda.Parameters.AddWithValue("@VendaID", vendaId);
                    cmdItemVenda.Parameters.AddWithValue("@ProdutoID", item.ProdutoId);
                    cmdItemVenda.Parameters.AddWithValue("@Quantidade", item.Quantidade);
                    cmdItemVenda.Parameters.AddWithValue("@PrecoUnitario", item.Preco);
                    cmdItemVenda.ExecuteNonQuery();
                }

                // Inserir Parcelas
                foreach (var parcela in venda.Parcelas)
                {
                    string insertParcelaQuery = "INSERT INTO Parcelas (ParcelaID, VendaID, NumeroParcela, DataVencimento, ValorParcela) VALUES (ParcelaID, @VendaID, @NumeroParcela, @DataVencimento, @ValorParcela)";
                    SqlCommand cmdParcela = new SqlCommand(insertParcelaQuery, con, transaction);
                    
                    cmdParcela.Parameters.AddWithValue("@ParcelaID", vendaId);
                    cmdParcela.Parameters.AddWithValue("@VendaID", vendaId);
                    cmdParcela.Parameters.AddWithValue("@NumeroParcela", parcela.NumeroParcela);
                    cmdParcela.Parameters.AddWithValue("@DataVencimento", parcela.DataVencimento);
                    cmdParcela.Parameters.AddWithValue("@ValorParcela", parcela.Valor);
                    cmdParcela.Parameters.AddWithValue("@Pago", parcela.Pago);
                    cmdParcela.ExecuteNonQuery();
                }

                // Inserir Contas a Receber
                foreach (var conta in venda.ContasReceber)
                {
                    string insertContaQuery = "INSERT INTO ContasReceber (VendaId, DataRecebimento, ValorRecebido) VALUES (@VendaId, @DataRecebimento, @ValorRecebido)";
                    SqlCommand cmdConta = new SqlCommand(insertContaQuery, con, transaction);
                    cmdConta.Parameters.AddWithValue("@VendaId", vendaId);
                    cmdConta.Parameters.AddWithValue("@DataRecebimento", conta.DataRecebimento.HasValue ? (object)conta.DataRecebimento.Value : DBNull.Value);
                    cmdConta.Parameters.AddWithValue("@ValorRecebido", conta.ValorRecebido.HasValue ? (object)conta.ValorRecebido.Value : DBNull.Value);
                    cmdConta.ExecuteNonQuery();
                }

                transaction.Commit();
                Console.WriteLine("Venda inserida com sucesso.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Erro ao inserir venda: " + ex.Message);
            }
        }
    }
}

