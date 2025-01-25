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
    internal class ProdutosDal
    {

        public List<ProdutosModel> Listar()
        {
            var connection = Conexao.Conex();

            var produtos = new List<ProdutosModel>();
            using (connection)
            {
                var query = "SELECT * FROM Produtos";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var produto = new ProdutosModel
                            {
                                ProdutoID = reader.GetInt32(reader.GetOrdinal("ProdutoID")),
                                NomeProduto = reader.GetString(reader.GetOrdinal("NomeProduto")),                               
                                PrecoCusto = reader.GetDecimal(reader.GetOrdinal("PrecoCusto")),
                                Lucro = reader.GetDecimal(reader.GetOrdinal("Lucro")),
                                PrecoDeVenda = reader.GetDecimal(reader.GetOrdinal("PrecoDeVenda")),
                                QuantidadeEmEstoque = reader.GetInt32(reader.GetOrdinal("QuantidadeEmEstoque")),
                                DataDeEntrada = reader.GetDateTime(reader.GetOrdinal("DataDeEntrada")),                              
                                Status = reader.GetString(reader.GetOrdinal("Status")),                               
                                Imagem = (byte[])reader.GetValue(reader.GetOrdinal("Imagem")),
                                Referencia = reader.GetString(reader.GetOrdinal("Referencia")), 
                                
                            };
                            produtos.Add(produto);
                        }
                    }
                }

              
            }
            return produtos;
        }
        public DataTable listarProdutos()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT ProdutoID, NomeProduto, PrecoCusto, Lucro, PrecoDeVenda, QuantidadeEmEstoque, DataDeEntrada, Status, Imagem, Referencia FROM Produtos", conn);              

                SqlDataAdapter daProduto = new SqlDataAdapter();
                daProduto.SelectCommand = comando;

                DataTable dtProduto= new DataTable();
                daProduto.Fill(dtProduto);
                return dtProduto;
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

        public void SalvarProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "INSERT INTO Produtos (ProdutoID, NomeProduto, PrecoCusto, Lucro, PrecoDeVenda, QuantidadeEmEstoque, DataDeEntrada, Status, Imagem, Referencia ) VALUES (@ProdutoID, @NomeProduto, @PrecoCusto, @Lucro, @PrecoDeVenda, @QuantidadeEmEstoque, @DataDeEntrada, @Status, @Imagem, @Referencia)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                    command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);                    
                    command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                    command.Parameters.AddWithValue("@Lucro", produto.Lucro);
                    command.Parameters.AddWithValue("@PrecoDeVenda", produto.PrecoDeVenda);
                    command.Parameters.AddWithValue("@QuantidadeEmEstoque", produto.QuantidadeEmEstoque);
                    command.Parameters.AddWithValue("@DataDeEntrada", produto.DataDeEntrada);                  
                    command.Parameters.AddWithValue("@Status", produto.Status);                   
                    command.Parameters.AddWithValue("@Imagem", produto.Imagem);
                    command.Parameters.AddWithValue("@Referencia", produto.Referencia);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AlterarProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "UPDATE Produtos SET NomeProduto = @NomeProduto, PrecoCusto = @PrecoCusto, Lucro = @Lucro, PrecoDeVenda = @PrecoDeVenda, QuantidadeEmEstoque = @QuantidadeEmEstoque, DataDeEntrada = @DataDeEntrada, Status = @Status, Imagem = @Imagem, Referencia = @Referencia WHERE ProdutoID = @ProdutoID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                    command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);                    
                    command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                    command.Parameters.AddWithValue("@Lucro", produto.Lucro);
                    command.Parameters.AddWithValue("@PrecoDeVenda", produto.PrecoDeVenda);
                    command.Parameters.AddWithValue("@QuantidadeEmEstoque", produto.QuantidadeEmEstoque);
                    command.Parameters.AddWithValue("@DataDeEntrada", produto.DataDeEntrada);                   
                    command.Parameters.AddWithValue("@Status", produto.Status);                   
                    command.Parameters.AddWithValue("@Imagem", produto.Imagem);
                    command.Parameters.AddWithValue("@Referencia", produto.Referencia);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void ExcluirProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "DELETE FROM Produtos WHERE ProdutoID = @ProdutoID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public ProdutosModel PesquisarPorCodigo(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {

                SqlCommand sql = new SqlCommand("SELECT * FROM Produto WHERE ProdutoID LIKE '" + pesquisa + "%' ", conn);
                conn.Open();
                SqlDataReader datareader;
                ProdutosModel obj_Produto = new ProdutosModel();

                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    obj_Produto.ProdutoID = Convert.ToInt32(datareader["ProdutoID"]);
                    obj_Produto.NomeProduto = datareader["NomeProduto"].ToString();
                    obj_Produto.PrecoCusto = Convert.ToDecimal(datareader["PrecoCusto"]);
                    obj_Produto.Lucro = Convert.ToDecimal(datareader["Lucro"]);
                    obj_Produto.PrecoDeVenda = Convert.ToDecimal(datareader["PrecoDeVenda"]);
                    obj_Produto.QuantidadeEmEstoque = Convert.ToInt32(datareader["QuantidadeEmEstoque"]);
                    obj_Produto.DataDeEntrada = Convert.ToDateTime(datareader["DataEntrada"]);
                    obj_Produto.Status = datareader["Status"].ToString();

                    if (datareader["Imagem"] != DBNull.Value)
                    {
                        obj_Produto.Imagem = (byte[])datareader["Imagem"];
                    }

                    obj_Produto.Referencia = datareader["Referencia"].ToString();
                }
                return obj_Produto;
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

        public ProdutosModel PesquisarPorNome(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {

                SqlCommand sql = new SqlCommand("SELECT ProdutoID, NomeProduto, PrecoCusto, Lucro, PrecoDeVenda, QuantidadeEmEstoque, DataDeEtrada, Status, Imagem, Referencia FROM Produto WHERE NomeProduto LIKE '" + pesquisa + "%' ", conn);
                conn.Open();
                SqlDataReader datareader;
                ProdutosModel obj_Produto = new ProdutosModel();

                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    obj_Produto.ProdutoID = Convert.ToInt32(datareader["ProdutoID"]);
                    obj_Produto.NomeProduto = datareader["NomeProduto"].ToString();
                    obj_Produto.PrecoCusto = Convert.ToDecimal(datareader["PrecoCusto"]);
                    obj_Produto.Lucro = Convert.ToDecimal(datareader["Lucro"]);
                    obj_Produto.PrecoDeVenda = Convert.ToDecimal(datareader["PrecoDeVenda"]);
                    obj_Produto.QuantidadeEmEstoque = Convert.ToInt32(datareader["QuantidadeEmEstoque"]);
                    obj_Produto.DataDeEntrada = Convert.ToDateTime(datareader["DataEntrada"]);
                    obj_Produto.Status = datareader["Status"].ToString();

                    if (datareader["Imagem"] != DBNull.Value)
                    {
                        obj_Produto.Imagem = (byte[])datareader["Imagem"];
                    }

                    obj_Produto.Referencia = datareader["Referencia"].ToString();
                }
                return obj_Produto;
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
//Exemplo de como usar o DataTable
//var dataTable = Conexao.SQL_data_adapter(query);
//foreach (DataRow row in dataTable.Rows)
//{
//    var produto = new ProdutosModel
//    {

//        ProdutoID = Convert.ToInt32(row["ProdutoID"]),
//        NomeProduto = row["NomeProduto"].ToString(),
//        Descricao = row["Descricao"].ToString(),
//        PrecoCusto = Convert.ToDecimal(row["PrecoCusto"]),
//        Lucro = Convert.ToDecimal(row["Lucro"]),
//        PrecoDeVenda = Convert.ToDecimal(row["PrecoDeVenda"]),
//        QuantidadeEmEstoque = Convert.ToInt32(row["QuantidadeEmEstoque"]),
//        DataDeEntrada = Convert.ToDateTime(row["DataDeEntrada"]),
//        CategoriaID = Convert.ToInt32(row["CategoriaID"]),
//        FabricanteID = Convert.ToInt32(row["FabricanteID"]),
//        UnidadeDeMedida = row["UnidadeDeMedida"].ToString(),
//        Status = row["Status"].ToString(),
//        DataDeVencimento = Convert.ToDateTime(row["DataDeVencimento"]),
//        Imagem = (byte[])row["Imagem"],
//        FornecedorID = Convert.ToInt32(row["FornecedorID"])
//    };

//    produtos.Add(produto);
//
// 
/*Outro exemplo é:
 * private void PopularDataGridView()
{
    var produtos = produtosDAL.ListarProdutos();
    dataGridViewProdutos.DataSource = produtos;
}

 * */