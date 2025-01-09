using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisControl.DALL
{
    internal class ProdutosDALL
    {
        public DataTable ListaProduto()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT ProdutoID, NomeProduto, PrecoCusto, Estoque, PrecoVenda FROM Produto", conn);

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
                SqlCommand sql = new SqlCommand("INSERT INTO Produto (ProdutoID, NomeProduto, PrecoCusto, Estoque, PrecoVenda) VALUES (@ProdutoID, @NomeProduto, @Estoque, @PrecoCusto, @PrecoVenda)", conn);

                sql.Parameters.AddWithValue("@ProdutoID", produto.ProdutoID);
                sql.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                sql.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                sql.Parameters.AddWithValue("@Estoque", produto.Estoque);
                sql.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);                

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
                SqlCommand sql = new SqlCommand("UPDATE Produto SET NomeProduto = @NomeProduto, PrecoCusto = @PrecoCusto, Estoque = @Estoque, PrecoVenda = @PrecoVenda", conn);
                                
                sql.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                sql.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                sql.Parameters.AddWithValue("@Estoque", produto.PrecoVenda);
                sql.Parameters.AddWithValue("@PrecoVenda", produto.Estoque);           
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
        public DataTable PesquisarPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT ProdutoID, NomeProduto, PrecoCusto, Estoque, PrecoVenda WHERE NomeProduto LIKE @NomeProduto";

                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeProduto", nome);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
    }
}
