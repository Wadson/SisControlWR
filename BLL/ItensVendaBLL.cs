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
        ItemVendaDALL itensvendasdall = null;
        // ************************LISTA USUARIO*********************************************
        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                itensvendasdall = new ItemVendaDALL();
                dtable = itensvendasdall.listaItensVenda();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(ItemVendaMODEL itensvenda)
        {
            try
            {
                itensvendasdall = new ItemVendaDALL();
                itensvendasdall.SalvarItensVenda(itensvenda);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(ItemVendaMODEL itensvenda)
        {
            try
            {
                itensvendasdall = new ItemVendaDALL();
                itensvendasdall.excluirItensVenda(itensvenda);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Atualizar(ItemVendaMODEL itensvenda)
        {
            try
            {
                itensvendasdall = new ItemVendaDALL();
                itensvendasdall.atualizaItensVenda(itensvenda);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public ItemVendaMODEL PesquisaItemVenda(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM ItemVenda WHERE ItemVendaID like '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                ItemVendaMODEL obj_Itensvenda = new ItemVendaMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {

                    obj_Itensvenda.ItemVendaID = Convert.ToInt32(datareader["ItemVendaID"]);
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
