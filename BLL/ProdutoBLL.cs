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
    internal class ProdutoBLL
    {
        ProdutosDALL produtodall = null;

        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                produtodall = new ProdutosDALL();
                dtable = produtodall.ListaProduto();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(ProdutoMODEL produto)
        {
            try
            {
                produtodall = new ProdutosDALL();
                produtodall.SalvarProduto(produto);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void Alterar(ProdutoMODEL produto)
        {
            try
            {
                produtodall = new ProdutosDALL();
                produtodall.AtualizaProduto(produto);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void Excluir(ProdutoMODEL produto)
        {
            try
            {
                produtodall = new ProdutosDALL();
                produtodall.ExcluirProduto(produto);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public ProdutoMODEL PesquisarPorCodigo(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {

                SqlCommand sql = new SqlCommand("SELECT * FROM Produto WHERE ProdutoID LIKE '" + pesquisa + "%' ", conn);
                conn.Open();
                SqlDataReader datareader;
                ProdutoMODEL obj_Produto = new ProdutoMODEL();

                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    obj_Produto.ProdutoID = Convert.ToInt32(datareader["ProdutoID"]);
                    obj_Produto.NomeProduto = datareader["NomeProduto"].ToString();
                    obj_Produto.Descricao = datareader["Descricao"].ToString();
                    obj_Produto.PrecoProduto = Convert.ToDecimal(datareader["PrecoProduto"]);
                    obj_Produto.Estoque = Convert.ToInt32(datareader["Estoque"]);
                    obj_Produto.CategoriaID = Convert.ToInt32(datareader["CategoriaID"]);
                }
                return obj_Produto;
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
