using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SisControl.DALL
{
    internal class UsuarioDALL
    {
        public DataTable listaUsuario()
        {
            //DataTable ListaUsuario = Conexao.SQL_data_adapter("SELECT idusuario,nome, usuario, dtnascimento, nivelacesso, senha FROM usuario");

            var conn = Conexao.Conex();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT UsuarioID, NomeUsuario, Email, Senha, TipoUsuario FROM Usuario", conn);
                //id_usuario, nome_usuario, user_usuario, dt_nascimento, nivelacesso_usuario, senha_usuario, email_usuario, dt_nascimento

                SqlDataAdapter daUsuario = new SqlDataAdapter();
                daUsuario.SelectCommand = comando;

                DataTable dtUsuario = new DataTable();
                daUsuario.Fill(dtUsuario);
                return dtUsuario;
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

        public void gravaUsuario(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand sqlcomm = new SqlCommand("INSERT INTO Usuario (UsuarioID, NomeUsuario, Email, Senha, TipoUsuario) VALUES (@UsuarioID, @NomeUsuario, @Email, @Senha, @TipoUsuario)", conn);

                sqlcomm.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);
                sqlcomm.Parameters.AddWithValue("@NomeUsuario", usuarios.NomeUsuario);
                sqlcomm.Parameters.AddWithValue("@Email", usuarios.Email);
                sqlcomm.Parameters.AddWithValue("@Senha", usuarios.Senha);
                sqlcomm.Parameters.AddWithValue("@TipoUsuario", usuarios.TipoUsuario);

                conn.Open();
                sqlcomm.ExecuteNonQuery();
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
        // ***********E  X  C  L  U  I         U  S  U  A  R  I  O***********************************
        public void excluiUsuario(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("DELETE FROM Usuario WHERE UsuarioID = @UsuarioID", conn);
                sqlcomando.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);
                conn.Open();
                sqlcomando.ExecuteNonQuery();
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
        //********A  T  U  A  L  I  Z  A     U  S  U  A  R  I  O  *****************************************************
        public void atualizaUsuario(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomm = new SqlCommand("UPDATE Usuario SET NomeUsuario = @NomeUsuario, Email = @Email, Senha = @Senha, TipoUsuario = @TipoUsuario WHERE UsuarioID = @UsuarioID", conn);

                sqlcomm.Parameters.AddWithValue("@NomeUsuario", usuarios.NomeUsuario);
                sqlcomm.Parameters.AddWithValue("@Email", usuarios.Email);
                sqlcomm.Parameters.AddWithValue("@Senha", usuarios.Senha);
                sqlcomm.Parameters.AddWithValue("@TipoUsuario", usuarios.Email);
                sqlcomm.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);

                conn.Open();
                sqlcomm.ExecuteNonQuery();

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

        public void atualizaUsuarioSenha(UsuarioMODEL usuarios)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomm = new SqlCommand("UPDATE Usuario SET Senha = @Senha WHERE UsuarioID = @UsuarioID", conn);

                sqlcomm.Parameters.AddWithValue("@Senha", usuarios.Senha);
                sqlcomm.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);

                conn.Open();
                sqlcomm.ExecuteNonQuery();

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
        public DataTable PesquisarPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT UsuarioID, NomeUsuario, Email, Senha, TipoUsuario FROM Usuario WHERE NomeUsuario  LIKE @NomeUsuario";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", nome);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
        public DataTable PesquisarPorCodigo(string codigo)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT UsuarioID, NomeUsuario, Email, Senha, TipoUsuario FROM Usuario WHERE NomeUsuario  LIKE @UsuarioID";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@UsuarioID", codigo);
                conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar a pesquisa: " + ex);
                return null;
            }
        }
    }
}
