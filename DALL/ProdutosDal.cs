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

        public List<ProdutosModel> ListarProdutos()
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
                                Descricao = reader.GetString(reader.GetOrdinal("Descricao")),
                                PrecoCusto = reader.GetDecimal(reader.GetOrdinal("PrecoCusto")),
                                Lucro = reader.GetDecimal(reader.GetOrdinal("Lucro")),
                                PrecoDeVenda = reader.GetDecimal(reader.GetOrdinal("PrecoDeVenda")),
                                QuantidadeEmEstoque = reader.GetInt32(reader.GetOrdinal("QuantidadeEmEstoque")),
                                DataDeEntrada = reader.GetDateTime(reader.GetOrdinal("DataDeEntrada")),
                                CategoriaID = reader.GetInt32(reader.GetOrdinal("CategoriaID")),
                                FabricanteID = reader.GetInt32(reader.GetOrdinal("FabricanteID")),
                                UnidadeDeMedida = reader.GetString(reader.GetOrdinal("UnidadeDeMedida")),
                                Status = reader.GetString(reader.GetOrdinal("Status")),
                                DataDeVencimento = reader.GetDateTime(reader.GetOrdinal("DataDeVencimento")),
                                Imagem = (byte[])reader.GetValue(reader.GetOrdinal("Imagem")),
                                FornecedorID = reader.GetInt32(reader.GetOrdinal("FornecedorID"))
                            };
                            produtos.Add(produto);
                        }
                    }
                }

              
            }
            return produtos;
        }


        public void AddProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "INSERT INTO Produtos (NomeProduto, Descricao, PrecoCusto, Lucro, PrecoDeVenda, QuantidadeEmEstoque, DataDeEntrada, CategoriaID, FabricanteID, UnidadeDeMedida, Status, DataDeVencimento, Imagem, FornecedorID) VALUES (@NomeProduto, @Descricao, @PrecoCusto, @Lucro, @PrecoDeVenda, @QuantidadeEmEstoque, @DataDeEntrada, @CategoriaID, @FabricanteID, @UnidadeDeMedida, @Status, @DataDeVencimento, @Imagem, @FornecedorID)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                    command.Parameters.AddWithValue("@Lucro", produto.Lucro);
                    command.Parameters.AddWithValue("@PrecoDeVenda", produto.PrecoDeVenda);
                    command.Parameters.AddWithValue("@QuantidadeEmEstoque", produto.QuantidadeEmEstoque);
                    command.Parameters.AddWithValue("@DataDeEntrada", produto.DataDeEntrada);
                    command.Parameters.AddWithValue("@CategoriaID", produto.CategoriaID);
                    command.Parameters.AddWithValue("@FabricanteID", produto.FabricanteID);
                    command.Parameters.AddWithValue("@UnidadeDeMedida", produto.UnidadeDeMedida);
                    command.Parameters.AddWithValue("@Status", produto.Status);
                    command.Parameters.AddWithValue("@DataDeVencimento", produto.DataDeVencimento);
                    command.Parameters.AddWithValue("@Imagem", produto.Imagem);
                    command.Parameters.AddWithValue("@FornecedorID", produto.FornecedorID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void AlterProduto(ProdutosModel produto)
        {
            var connection = Conexao.Conex();
            using (connection)
            {
                var query = "UPDATE Produtos SET NomeProduto = @NomeProduto, Descricao = @Descricao, PrecoCusto = @PrecoCusto, Lucro = @Lucro, PrecoDeVenda = @PrecoDeVenda, QuantidadeEmEstoque = @QuantidadeEmEstoque, DataDeEntrada = @DataDeEntrada, CategoriaID = @CategoriaID, FabricanteID = @FabricanteID, UnidadeDeMedida = @UnidadeDeMedida, Status = @Status, DataDeVencimento = @DataDeVencimento, Imagem = @Imagem, FornecedorID = @FornecedorID WHERE ProdutoID = @ProdutoID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                    command.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                    command.Parameters.AddWithValue("@Lucro", produto.Lucro);
                    command.Parameters.AddWithValue("@PrecoDeVenda", produto.PrecoDeVenda);
                    command.Parameters.AddWithValue("@QuantidadeEmEstoque", produto.QuantidadeEmEstoque);
                    command.Parameters.AddWithValue("@DataDeEntrada", produto.DataDeEntrada);
                    command.Parameters.AddWithValue("@CategoriaID", produto.CategoriaID);
                    command.Parameters.AddWithValue("@FabricanteID", produto.FabricanteID);
                    command.Parameters.AddWithValue("@UnidadeDeMedida", produto.UnidadeDeMedida);
                    command.Parameters.AddWithValue("@Status", produto.Status);
                    command.Parameters.AddWithValue("@DataDeVencimento", produto.DataDeVencimento);
                    command.Parameters.AddWithValue("@Imagem", produto.Imagem);
                    command.Parameters.AddWithValue("@FornecedorID", produto.FornecedorID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
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