using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.DALL
{
    internal class ProdutosDALL
    {
        public DataTable ListaProduto()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT ProdutoID, Nome, Descricao, Preco, Estoque, CategoriaID FROM Produto", conn);

                SqlDataAdapter daCliente = new SqlDataAdapter();
                daCliente.SelectCommand = sql;
                DataTable dtcliente = new DataTable();
                daCliente.Fill(dtcliente);
                return dtcliente;
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

        public void SalvarProduto(ProdutoMODEL produto)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO Produto (ProdutoID, NomeProduto, Descricao, PrecoProduto, Estoque, CategoriaID, SubCategoriaID) VALUES (@ProdutoID, @NomeProduto, @Descricao, @PrecoProduto, @Estoque, @CategoriaID, @SubCategoriaID)", conn);

                sql.Parameters.AddWithValue("@ProdutoID",    produto.ProdutoID);
                sql.Parameters.AddWithValue("@NomeProduto",    produto.NomeProduto);
                sql.Parameters.AddWithValue("@Descricao",    produto.Descricao);
                sql.Parameters.AddWithValue("@PrecoProduto",    produto.PrecoProduto);
                sql.Parameters.AddWithValue("@Estoque",     produto.Estoque);
                sql.Parameters.AddWithValue("@CategoriaID",    produto.CategoriaID);
                sql.Parameters.AddWithValue("@SubCategoriaID", produto.SubCategoriaID);

                conn.Open();
                sql.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public void ExcluirProduto(ProdutoMODEL produto)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Produto WHERE ProdutoID = @ProdutoID ", conn);
                sql.Parameters.AddWithValue("@ProdutoID", produto);

                conn.Open();
                sql.ExecuteNonQuery();
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

        public void AtualizaProduto(ProdutoMODEL produto)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("UPDATE Produto SET ProdutoID = @ProdutoID, NomeProduto = @NomeProduto, Descricao = @Descricao, PrecoProduto = @PrecoProduto, Estoque = @Estoque, CategoriaID = @CategoriaID, SubCategoriaID = @SubCategoriaID", conn);
                                
                sql.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                sql.Parameters.AddWithValue("@Descricao", produto.Descricao);
                sql.Parameters.AddWithValue("@PrecoProduto", produto.PrecoProduto);
                sql.Parameters.AddWithValue("@Estoque", produto.Estoque);
                sql.Parameters.AddWithValue("@CategoriaID", produto.CategoriaID);
                sql.Parameters.AddWithValue("@SubCategoriaID", produto.SubCategoriaID);
                sql.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);

                conn.Open();
                sql.ExecuteNonQuery();
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
