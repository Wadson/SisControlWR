using SisControl.DALL;
using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisControl.BLL
{
    internal class UsuarioBLL
    {
        UsuarioDALL usuariodal = null;

        public DataTable Listar()
        {
            DataTable dtable = new DataTable();
            try
            {
                usuariodal = new UsuarioDALL();
                dtable = usuariodal.listaUsuario();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtable;
        }

        public void Salvar(UsuarioMODEL usuarios)
        {
            try
            {
                usuariodal = new UsuarioDALL();
                usuariodal.gravaUsuario(usuarios);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(UsuarioMODEL usuarios)
        {
            try
            {
                usuariodal = new UsuarioDALL();
                usuariodal.excluiUsuario(usuarios);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
        public void Alterar(UsuarioMODEL usuarios)
        {
            try
            {
                usuariodal = new UsuarioDALL();
                usuariodal.atualizaUsuario(usuarios);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void AtualizaUsuarioDalSenha(UsuarioMODEL usuarios)
        {
            try
            {
                usuariodal = new UsuarioDALL();
                usuariodal.atualizaUsuarioSenha(usuarios);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
      
        public UsuarioMODEL PesquisarNo(DataGridView DataGridPesquisa, string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario like '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                UsuarioMODEL obj_usuario = new UsuarioMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {
                    obj_usuario.UsuarioID = Convert.ToInt32(datareader["UsuarioID"]);
                    obj_usuario.NomeUsuario = datareader["NomeUsuario"].ToString();
                }
                return obj_usuario;
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
        public UsuarioMODEL PesquisarCodigo(string pesquisa)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM Usuario WHERE UsuarioID like '" + pesquisa + "%'", conn);
                conn.Open();
                SqlDataReader datareader;
                UsuarioMODEL obj_usuario = new UsuarioMODEL();
                datareader = sql.ExecuteReader(CommandBehavior.CloseConnection);

                while (datareader.Read())
                {
                    obj_usuario.UsuarioID = Convert.ToInt32(datareader["UsuarioID"]);
                    obj_usuario.NomeUsuario = datareader["NomeUsuario"].ToString();
                }
                return obj_usuario;
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
