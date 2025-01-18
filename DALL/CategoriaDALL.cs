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
    internal class CategoriaDALL
    {
        public DataTable ListarCategoria()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM Categoria", conn);

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

        public void SalvarCategoria(CategoriaMODEL categoria)
        {
            var conn = Conexao.Conex();

            SqlCommand sql = new SqlCommand("INSERT INTO Categoria (CategoriaID, NomeCategoria) VALUES (@CategoriaID, @NomeCategoria)", conn);

            sql.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);
            sql.Parameters.AddWithValue("@NomeCategoria", categoria.NomeCategoria);

            conn.Open();
            sql.ExecuteNonQuery();


            try
            {
                
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
        public void ExcluiCategoria(CategoriaMODEL categoria)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Categoria WHERE CategoriaID = @CategoriaID ", conn);
                sql.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);

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

        public void AtualizaCategoria(CategoriaMODEL categoria)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand Sql = new SqlCommand("UPDATE Categoria SET NomeCategoria = @NomeCategoria WHERE CategoriaID = @CategoriaID", conn);

                
                Sql.Parameters.AddWithValue("@NomeCategoria", categoria.NomeCategoria);
                Sql.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);

                conn.Open();
                Sql.ExecuteNonQuery();
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

        public DataTable PesquisarGeral()
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT TOP (30) CategoriaID, NomeCategoria FROM Categoria";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                //cmd.Parameters.AddWithValue("@NomeCategoria", nome);
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

        public DataTable PesquisarPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT TOP (30) CategoriaID, NomeCategoria FROM  Categoria WHERE NomeCategoria LIKE @NomeCategoria";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeCategoria", nome);
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
        public DataTable PesquisarPorCodigo(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT TOP (30) CategoriaID, NomeCategoria FROM Categoria WHERE CategoriaID  LIKE @CategoriaID";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@CategoriaID", nome);
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
