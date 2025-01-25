using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SisControl.BLL
{
    internal class ProdutoBLL
    {
        ProdutosDal produtodall = null;

        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                produtodall = new ProdutosDal();
                dtable = produtodall.listarProdutos();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(ProdutosModel produto)
        {
            produtodall = new ProdutosDal();
            produtodall.SalvarProduto(produto);
            try
            {
               
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void Alterar(ProdutosModel produto)
        {
            try
            {
                produtodall = new ProdutosDal();
                produtodall.AlterarProduto(produto);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void Excluir(ProdutosModel produto)
        {
            try
            {
                produtodall = new ProdutosDal();
                produtodall.ExcluirProduto(produto);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void PesquisarPorNome(ProdutosModel produto, string ParametroNome )
        {
            try
            {
                produtodall = new ProdutosDal();
                produtodall.PesquisarPorNome(ParametroNome);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void PesquisarPorCodigo(ProdutosModel produto, string ParametroCodigo)
        {
            try
            {
                produtodall = new ProdutosDal();
                produtodall.PesquisarPorNome(ParametroCodigo);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
    }
}
