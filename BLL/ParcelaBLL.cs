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
    internal class ParcelaBLL
    {
        ParcelaDALL parceladal = null;

        public void Salvar(ParcelaMODEL parcela)
        {
            parceladal = new ParcelaDALL();
            parceladal.SalvarParcelas(parcela);

            try
            {

            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }

        public void ExcluirTodas(ParcelaMODEL parcela)
        {
            try
            {
                parceladal = new ParcelaDALL();
                parceladal.ExcluirTodasParcela(parcela);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        public void ExcluirUma(ParcelaMODEL parcelas)
        {
            try
            {
                parceladal = new ParcelaDALL();
                parceladal.ExcluiParcelaUnica(parcelas);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void Atualizar(ParcelaMODEL parcela)
        {
            try
            {
                parceladal = new ParcelaDALL();
                parceladal.AtualizaParcela(parcela);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //public void BaixarParcelas(ParcelaMODEL baixaconta)
        //{
        //    try
        //    {
        //        parceladal = new ParcelaDALL();
        //        parceladal(baixaconta);
        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //}

        //public void PagarParcelaDAL(ParcelaMODEL parcela)
        //{
        //    try
        //    {
        //        parceladal = new ParcelaDALL();
        //        parceladal.bai(parcela);
        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //}

        //public ParcelaModel PesquisaParcela(string pesquisa)
        //{
        //    var conexao = Conexao.Conex();

        //    try
        //    {               
        //SqlCommand sql = new SqlCommand("SELECT  SELECT  fornecedor.fornecedor, parcelas.valor_parc, parcelas.datavenc, parcelas.datapgto FROM   parcelas, fornecedor  WHERE idconta LIKE '" + pesquisa + "%' AND pago = false", conexao);
        //conexao.Open();
        //SqlDataReader datareader;
        //ParcelaModel obj_parcela = new ParcelaModel();

        //datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
        //while (datareader.Read())
        //{
        //    obj_parcela.Idparcela = Convert.ToInt32(datareader["id_parcela"]);
        //    obj_parcela.IdVenda = Convert.ToInt32(datareader["id_venda"]);
        //    obj_parcela.Valor_parc = Convert.ToDecimal(datareader["valor_parcela"]);
        //    obj_parcela.Datavenc = Convert.ToDateTime(datareader["dt_vcto_parcela"]);                   
        //}
        //return obj_parcela;
        //    }
        //    catch (Exception erro)
        //    {
        //        throw erro;
        //    }
        //    finally
        //    {
        //        conexao.Close();
        //    }
        //}

        public ParcelaMODEL pesquisar(string pesquisa)
        {
            var conexao = Conexao.Conex();

            try
            {
                SqlCommand sql = new SqlCommand("SELECT  fornecedor.fornecedor, parcelas.valor_parc, parcelas.datavenc, parcelas.datapgto FROM   parcelas WHERE fornecedor LIKE '" + pesquisa + "%' AND pago = false", conexao);
                conexao.Open();
                SqlDataReader datareader;
                ParcelaMODEL obj_parcela = new ParcelaMODEL();


                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    //obj_parcela.Idparcela = Convert.ToInt32(datareader["id_parcela"]);
                    //obj_parcela.IdVenda = Convert.ToInt32(datareader["idvenda"]);
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
