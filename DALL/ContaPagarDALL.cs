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
    internal class ContaPagarDALL
    {
        public DataTable lista_controle()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM ContaPagar  WHERE ContaPagarID = 0 ORDER BY DataVencimento", conn);


                SqlDataAdapter daControle = new SqlDataAdapter();
                daControle.SelectCommand = sql;
                DataTable dtcontrole = new DataTable();
                daControle.Fill(dtcontrole);
                return dtcontrole;
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
        public DataTable lista_controleOpcional()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM ContaPagar)", conn);

                SqlDataAdapter daControle = new SqlDataAdapter();
                daControle.SelectCommand = sql;
                DataTable dtcontrole = new DataTable();
                daControle.Fill(dtcontrole);
                return dtcontrole;
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
        public void SalvarConta(ContaPagarMODEL conta)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO ContaPagar (ContaPagarID, FornecedorID, ValorTotal, DataVencimento) VALUES (@ContaPagarID, @FornecedorID, @ValorTotal, @DataVencimento)", conn);

                sql.Parameters.AddWithValue("@ContaPagarID", conta.ContaPagarID);
                sql.Parameters.AddWithValue("@FornecedorID", conta.FornecedorID);
                sql.Parameters.AddWithValue("@ValorTotal", conta.ValorTotal);
                sql.Parameters.AddWithValue("@DataVencimento", conta.DataVencimento);


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
        public void excluiConta(ContaPagarMODEL contas)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM ContaPagar WHERE ContaPagarID = @ContaPagarID ", conn);

                sql.Parameters.AddWithValue("@ContaPagarID", contas.ContaPagarID);
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
        public void DeletarConta(ContaPagarMODEL contas)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM contas, parcelas USING contas, parcelas WHERE contas.idconta = @IdCont AND parcelas.idconta = @IdCont", conn);

                sql.Parameters.AddWithValue("@IdCont", contas.ContaPagarID);
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

        public void atualiza_contas(ContaPagarMODEL contas)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("UPDATE ContaPagar SET ContaPagarID = @ContaPagarID, FornecedorID = @FornecedorID, ValorTotal = @ValorTotal, DataVencimento = @DataVencimento", conn);

                sql.Parameters.AddWithValue("@ContaPagarID", contas.ContaPagarID);
                sql.Parameters.AddWithValue("@FornecedorID", contas.FornecedorID);
                sql.Parameters.AddWithValue("@ValorTotal", contas.ValorTotal);
                sql.Parameters.AddWithValue("@DataVencimento", contas.DataVencimento);

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
        public void darBaixaConta(ContaPagarMODEL contas)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("UPDATE ContaPagar SET ContaPagarID = @ContaPagarID, FornecedorID = @FornecedorID, ValorTotal = @ValorTotal, DataVencimento = @DataVencimento", conn);

                sql.Parameters.AddWithValue("@FornecedorID", contas.FornecedorID);
                sql.Parameters.AddWithValue("@ValorTotal", contas.ValorTotal);
                sql.Parameters.AddWithValue("@DataVencimento", contas.DataVencimento);
                sql.Parameters.AddWithValue("@ContaPagarID", contas.ContaPagarID);

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
    }
}
