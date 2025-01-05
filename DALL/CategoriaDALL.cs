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
            try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO CategoriaID, NomeCategoria) VALUES (@CategoriaID, @NomeCategoria)", conn);

                sql.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);
                sql.Parameters.AddWithValue("@NomeCategoria", categoria.NomeCategoria);
               
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
                SqlCommand Sql = new SqlCommand("UPDATE Categoria SET CategoriaID = @CategoriaID, NomeCategoria = @NomeCategoria", conn);

                Sql.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);
                Sql.Parameters.AddWithValue("@NomeCategoria", categoria.NomeCategoria);

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
    }
}
