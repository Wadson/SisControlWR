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
    internal class RegistroPagamentoBLL
    {
        PagamentoDALL registroPagamentodal = null;

        public void Salvar(PagamentoMODEL registroagamento)
        {
            try
            {
                registroPagamentodal = new PagamentoDALL();
                registroPagamentodal.SalvarRegistroPagamento(registroagamento);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void Excluir(PagamentoMODEL registropagamento)
        {
            try
            {
                registroPagamentodal = new PagamentoDALL();
                registroPagamentodal.excluirTodosPagamentos(registropagamento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void ExcluirUmaParcela(PagamentoMODEL excluirumaparcela)
        {
            try
            {
                registroPagamentodal = new PagamentoDALL();
                registroPagamentodal.excluiParcelaUnica(excluirumaparcela);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(PagamentoMODEL registropagamento)
        {
            try
            {
                registroPagamentodal = new PagamentoDALL();
                registroPagamentodal.atualizaRegistroPagamento(registropagamento);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public PagamentoMODEL pesquisaRegistroPagamento(string pesquisa)
        {
            var conexao = Conexao.Conex();

            try
            {
                SqlCommand sql = new SqlCommand("SELECT PagamentoID, ParcelaID, DataPagamento, ValorPago FROM  Pagamento WHERE PagamentoID LIKE '" + pesquisa + "%' AND pago = false", conexao);
                conexao.Open();
                SqlDataReader datareader;
                PagamentoMODEL obj_parcela = new PagamentoMODEL();

                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    obj_parcela.PagamentoID = Convert.ToInt32(datareader["PagamentoID"]);
                    obj_parcela.ParcelaID = Convert.ToInt32(datareader["ParcelaID"]);
                    obj_parcela.DataPagamento = Convert.ToDateTime(datareader["DataPagamento"]);
                    obj_parcela.ValorPago = Convert.ToDecimal(datareader["ValorPago"]);
                }
                return obj_parcela;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }

        public PagamentoMODEL pesquisaPrecosCodigo(string pesquisa)
        {
            var conexao = Conexao.Conex();

            try
            {
                SqlCommand sql = new SqlCommand("SELECT  fornecedor.fornecedor, parcelas.valor_parc, parcelas.datavenc, parcelas.datapgto FROM   parcelas WHERE fornecedor LIKE '" + pesquisa + "%' AND pago = false", conexao);
                conexao.Open();
                SqlDataReader datareader;
                PagamentoMODEL obj_parcela = new PagamentoMODEL();


                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    //obj_parcela.Idparcela = Convert.ToInt32(datareader["id_parcela"]);
                    //obj_parcela.IdVenda = Convert.ToInt32(datareader["id_venda"]);
                    //obj_parcela.Valor_parc = Convert.ToDecimal(datareader["valor_parcela"]);
                    //obj_parcela.Datavenc = Convert.ToDateTime(datareader["dt_vcto_parcela"]);
                }
                return obj_parcela;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
