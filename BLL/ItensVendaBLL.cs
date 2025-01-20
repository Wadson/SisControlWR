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
    internal class ItensVendaBLL
    {
        ItemVendaDAL itensvendasdall = null;
        // ************************LISTA USUARIO*********************************************
        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                //itensvendasdall = new ItemVendaDAL();
                //dtable = itensvendasdall.listaItensVenda();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(ItemVendaModel itensvenda)
        {
            try
            {
                //itensvendasdall = new ItemVendaDAL();
                //itensvendasdall.SalvarItensVenda(itensvenda);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(ItemVendaModel itensvenda)
        {
            try
            {
                //itensvendasdall = new ItemVendaDAL();
                //itensvendasdall.excluirItensVenda(itensvenda);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Atualizar(ItemVendaModel itensvenda)
        {
            try
            {
                //itensvendasdall = new ItemVendaDAL();
                //itensvendasdall.atualizaItensVenda(itensvenda);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public ItemVendaModel PesquisaItemVenda(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM ItemVenda WHERE ItemVendaID like @Pesquisa + '%'", conn);
                sql.Parameters.AddWithValue("@Pesquisa", pesquisa);

                conn.Open();
                SqlDataReader datareader;
                ItemVendaModel obj_Itensvenda = new ItemVendaModel();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {
                    int ItemVendaID = 0;
                    if (int.TryParse(datareader["ItemVendaID"].ToString(), out ItemVendaID))
                    {
                        obj_Itensvenda.ItemVendaID = ItemVendaID;
                    }
                    else
                    {
                        throw new Exception("Falha ao converter ItemVendaID para int.");
                    }
                }
                return obj_Itensvenda;
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
