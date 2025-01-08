using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisControl.DALL;

namespace SisControl.BLL
{
    internal class SubCategoriaBLL
    {
        SubCategoriaDALL SubCategoriaDAL = null;

        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                SubCategoriaDAL = new SubCategoriaDALL();
                dtable = SubCategoriaDAL.ListaSubCategoria();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }


        public void Salvar(SubCategoriaMODEL subCategoria)
        {
            try
            {
                SubCategoriaDAL = new SubCategoriaDALL();
                SubCategoriaDAL.Salvar(subCategoria);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(SubCategoriaMODEL subCategorias)
        {
            try
            {
                SubCategoriaDAL = new SubCategoriaDALL();
                SubCategoriaDAL.Excluir(subCategorias);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Alterar(SubCategoriaMODEL subCategoria)
        {
            try
            {
                SubCategoriaDAL = new SubCategoriaDALL();
                SubCategoriaDAL.Alterar(subCategoria);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public SubCategoriaMODEL Pesquisar (string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM SubCategoria WHERE NomeSubCategoria like '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                SubCategoriaMODEL objetosubCategoria = new SubCategoriaMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {
                    objetosubCategoria.SubCategoriaID = Convert.ToInt32(datareader["SubCategoriaID"]);
                    objetosubCategoria.NomeSubCategoria = datareader["NomeSubCategoria"].ToString();
                }
                return objetosubCategoria;
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
