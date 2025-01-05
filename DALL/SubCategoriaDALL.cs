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
    internal class SubCategoriaDALL
    {
        public DataTable ListaCategoria()
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Categoria", conn);

                SqlDataAdapter dacategoria = new SqlDataAdapter();
                dacategoria.SelectCommand = comando;
                DataTable dtcategoria = new DataTable();
                dacategoria.Fill(dtcategoria);
                return dtcategoria;
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

        public void Salvar(SubCategoriaMODEL subcategoria)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand sqlcomm = new SqlCommand("INSERT INTO SubCategoria (SubCategoriaID, NomeSubCategoria, CategoriaID) VALUES (@SubCategoriaID, @NomeSubCategoria, @CategoriaID)", conn);

                sqlcomm.Parameters.AddWithValue("@SubCategoriaID", subcategoria.SubCategoriaID);
                sqlcomm.Parameters.AddWithValue("@NomeSubCategoria", subcategoria.NomeSubCategoria);
                sqlcomm.Parameters.AddWithValue("@CategoriaID", subcategoria.CategoriaID);

                conn.Open();
                sqlcomm.ExecuteNonQuery();
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
        public void Excluir(SubCategoriaMODEL categoria)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("DELETE FROM Categoria WHERE CategoriaID = @CategoriaID", conn);
                sqlcomando.Parameters.AddWithValue("@CategoriaID", categoria.CategoriaID);

                conn.Open();
                sqlcomando.ExecuteNonQuery();
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
        public void Alterar(SubCategoriaMODEL Subcategoria)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand sqlcomm = new SqlCommand("UPDATE SubCategoria SET SubCategoriaID = @SubCategoriaID, NomeSubCategoria = @NomeSubCategoria, CategoriaID = @CategoriaID", conn);

                sqlcomm.Parameters.AddWithValue("@SubCategoriaID", Subcategoria.SubCategoriaID);
                sqlcomm.Parameters.AddWithValue("@NomeSubCategoria", Subcategoria.NomeSubCategoria);
                sqlcomm.Parameters.AddWithValue("@CategoriaID", Subcategoria.CategoriaID);

                conn.Open();
                sqlcomm.ExecuteNonQuery();

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
