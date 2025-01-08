using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl.BLL
{
    internal class CategoriaBLL
    {
        CategoriaDALL categoriaDAL = null;

        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                categoriaDAL = new CategoriaDALL();
                dtable = categoriaDAL.ListarCategoria();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }


        public void Salvar(CategoriaMODEL categoria)
        {
            categoriaDAL = new CategoriaDALL();
            categoriaDAL.SalvarCategoria(categoria);
            try
            {
                
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(CategoriaMODEL categoria)
        {
            try
            {
                categoriaDAL = new CategoriaDALL();
                categoriaDAL.ExcluiCategoria(categoria);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(CategoriaMODEL categoria)
        {
            try
            {
                categoriaDAL = new CategoriaDALL();
                categoriaDAL.AtualizaCategoria(categoria);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public CategoriaMODEL PesquisaCategoria(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM Categoria WHERE CategoriaNome like '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                CategoriaMODEL objetocategoria = new CategoriaMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {
                    objetocategoria.CategoriaID = Convert.ToInt32(datareader["CategoriaID"]);
                    objetocategoria.NomeCategoria = datareader["NomeCategoria"].ToString();
                }
                return objetocategoria;
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
