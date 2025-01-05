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
    internal class ClienteDALL
    {
        public DataTable ListarClientes()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT Cliente.ClienteID, Cliente.ClienteNome, Cliente.CpfCnpj, Cliente.Endereco, Cliente.Telefone, Cliente.Email, Cliente.CidadeID, Cidade.NomeCidade AS Expr1, Cidade.EstadoID, Estado.NomeEstado AS Expr2, Estado.Uf " +
"FROM Cliente INNER JOIN Cidade ON Cliente.CidadeID = Cidade.CidadeID INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID", conn);

                SqlDataAdapter daCliente = new SqlDataAdapter();
                daCliente.SelectCommand = sql;
                DataTable dtcliente = new DataTable();
                daCliente.Fill(dtcliente);
                return dtcliente;
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

        public void salvaCliente(ClienteMODEL cliente)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("INSERT INTO ClienteID, NomeCliente, CpfCnpj, Endereco, Telefone, Email, CidadeID) VALUES (ClienteID = @ClienteID, NomeCliente = @NomeCliente, CpfCnpj = @CpfCnpj, Endereco = @Endereco, Telefone = @Telefone, Email = @Email, CidadeID = @CidadeID)", conn);


                sql.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                sql.Parameters.AddWithValue("@NomeCliente", cliente.NomeCliente);
                sql.Parameters.AddWithValue("@CpfCnpj", cliente.CpfCnpj);
                sql.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                sql.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                sql.Parameters.AddWithValue("@Email", cliente.Email);
                sql.Parameters.AddWithValue("@CidadeID", cliente.CidadeID);

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
        public void excluiCliente(ClienteMODEL cliente)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("DELETE FROM Cliente WHERE ClienteID = @ClienteID ", conn);
                sql.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);


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

        public void atualiza_Cliente(ClienteMODEL cliente)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand Sql = new SqlCommand("UPDATE Cliente SET ClienteID = @ClienteID, NomeCliente = @NomeCliente, CpfCnpj = @CpfCnpj, Endereco = @Endereco, Telefone = @Telefone, Email = @Email, CidadeID = @CidadeID) WHERE ClienteID = @ClienteID", conn);

                Sql.Parameters.AddWithValue("@NomeCliente", cliente.NomeCliente);
                Sql.Parameters.AddWithValue("@CpfCnpj", cliente.CpfCnpj);
                Sql.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                Sql.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                Sql.Parameters.AddWithValue("@Email", cliente.Email);
                Sql.Parameters.AddWithValue("@CidadeID", cliente.CidadeID);
                Sql.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);

                conn.Open();
                Sql.ExecuteNonQuery();
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
