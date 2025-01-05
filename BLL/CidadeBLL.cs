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
    internal class CidadeBLL
    {
        CidadeDALL CidadeDal = null;
        // ************************LISTA USUARIO*********************************************
        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                CidadeDal = new CidadeDALL();
                dtable = CidadeDal.Listar_Cidades();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(CidadeMODEL cidades)
        {
            try
            {
                CidadeDal = new CidadeDALL();
                CidadeDal.gravaCidades(cidades);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(CidadeMODEL cidades)
        {
            try
            {
                CidadeDal = new  CidadeDALL();
                CidadeDal.ExcluiCidade(cidades);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Atualizar(CidadeMODEL cidades)
        {
            try
            {
                CidadeDal = new CidadeDALL();
                CidadeDal.AtualizaCidade(cidades);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public CidadeMODEL Pesquisar(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM Cidade WHERE NomeCidade like '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                CidadeMODEL obj_cidade = new CidadeMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {
                    obj_cidade.CidadeID = Convert.ToInt32(datareader["CidadeID"]);
                    obj_cidade.NomeCidade = datareader["NomeCidade"].ToString();
                }
                return obj_cidade;
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
