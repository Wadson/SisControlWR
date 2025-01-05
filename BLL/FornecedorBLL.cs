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
    internal class FornecedorBLL
    {
        FornecedorDALL fornecedordal = null;

        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                fornecedordal = new FornecedorDALL();
                dtable = fornecedordal.lista_Fornecedor();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(FornecedorMODEL fornecedor)
        {
            try
            {
                fornecedordal = new FornecedorDALL();
                fornecedordal.gravaFornecedor(fornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(FornecedorMODEL fornecedor)
        {
            try
            {
                fornecedordal = new FornecedorDALL();
                fornecedordal.excluiFornecedor(fornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Alterar(FornecedorMODEL fornecedor)
        {
            try
            {
                fornecedordal = new FornecedorDALL();
                fornecedordal.atualizaFornecedor(fornecedor);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public FornecedorMODEL pesquisar(string pesquisa)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM Fornecedor WHERE NomeFornecedor LIKE '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                FornecedorMODEL obj_fornecedor = new FornecedorMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    if (datareader.IsDBNull(0))
                    {
                        string erro;
                        erro = "Nenhum registro encontrado";
                        Console.Write(erro);
                    }
                    else
                    {
                        obj_fornecedor.FornecedorID = Convert.ToInt32(datareader["FornecedorID"]);
                        obj_fornecedor.NomeFornecedor = datareader["NomeFornecedor"].ToString();
                    }
                }
                return obj_fornecedor;
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
        public FornecedorMODEL PesquisaFornecedorEspecial(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT Fornecedor FROM Fornecedor WHERE Fornecedo LIKE '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                FornecedorMODEL obj_fornecedor = new FornecedorMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    if (datareader.IsDBNull(0))
                    {
                        string erro;
                        erro = "Nenhum registro encontrado";
                        Console.Write(erro);
                    }
                    else
                    {
                        obj_fornecedor.FornecedorID = Convert.ToInt32(datareader["FornecedorID"]);
                    }
                }
                return obj_fornecedor;
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
        public FornecedorMODEL PesquisaFornecedorCod(string pesquisa)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand sql = new SqlCommand("SELECT Fornecedor FROM Fornecedor  WHERE FornecedorID LIKE '" + pesquisa + "%' ", conn);//AND Pago = false
                conn.Open();
                SqlDataReader datareader;

                FornecedorMODEL obj_fornecedor = new FornecedorMODEL();


                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);
                while (datareader.Read())
                {
                    if (datareader.IsDBNull(0))
                    {
                        string erros = "Nenhum registro ENCONTRADO";
                        Console.WriteLine(erros);
                    }
                    else
                        obj_fornecedor.NomeFornecedor = datareader["NomeFornecedor"].ToString();
                }
                return obj_fornecedor;
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
