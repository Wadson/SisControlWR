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
    internal class ClienteBLL
    {
        ClienteDALL clienteDAL = null;

        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                clienteDAL = new ClienteDALL();
                dtable = clienteDAL.ListarClientes();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(ClienteMODEL clienteS)
        {

            clienteDAL = new ClienteDALL();
            clienteDAL.salvaCliente(clienteS);
            try
            {
               
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void Alterar(ClienteMODEL clienteS)
        {
            try
            {
                clienteDAL = new ClienteDALL();
                clienteDAL.atualiza_Cliente(clienteS);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public void Excluir(ClienteMODEL clienteS)
        {
            try
            {
                clienteDAL = new ClienteDALL();
                clienteDAL.excluiCliente(clienteS);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
        }
        public ClienteMODEL PesquisarPorCodigo(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {

                SqlCommand sql = new SqlCommand("SELECT * FROM Cliente WHERE ClienteID LIKE '" + pesquisa + "%' ", conn);
                conn.Open();
                SqlDataReader datareader;
                ClienteMODEL obj_cliente = new ClienteMODEL();

                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    obj_cliente.ClienteID = Convert.ToInt32(datareader["ClienteID"]);
                    obj_cliente.NomeCliente = datareader["NomeCliente"].ToString();
                    obj_cliente.CpfCnpj = datareader["CpfCnpj"].ToString();
                    obj_cliente.Endereco = datareader["Endereco"].ToString();
                    obj_cliente.Telefone = datareader["Telefone"].ToString();
                    obj_cliente.Email = datareader["Email"].ToString();
                    obj_cliente.CidadeID = Convert.ToInt32(datareader["CidadeID"]);
                }
                return obj_cliente;
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
