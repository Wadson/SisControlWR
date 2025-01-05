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
    internal class UsuarioDALL
    {
        public DataTable listaUsuario()
        {
            //DataTable ListaUsuario = Conexao.SQL_data_adapter("SELECT idusuario,nome, usuario, dtnascimento, nivelacesso, senha FROM usuario");

            var conn = Conexao.Conex();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", conn);
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


            SqlCommand sqlcomm = new SqlCommand("INSERT INTO Usuario (NomeUsuario, Email, Senha, TipoUsuario) VALUES (@NomeUsuario, @Email, @Senha, @TipoUsuario)", conn);

            //sqlcomm.Parameters.AddWithValue("@UsuarioID", usuarios.UsuarioID);
            sqlcomm.Parameters.AddWithValue("@NomeUsuario", usuarios.NomeUsuario);
            sqlcomm.Parameters.AddWithValue("@Email", usuarios.Email);
            sqlcomm.Parameters.AddWithValue("@Senha", usuarios.Senha);
            sqlcomm.Parameters.AddWithValue("@TipoUsuario", usuarios.Email);


            conn.Open();
            sqlcomm.ExecuteNonQuery();
            conn.Close();
            try
            {

            }
            catch (SqlException ex)
            {
                throw new ApplicationException(ex.ToString());
            }
            finally
            {
                //conn.Close();
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
                SqlCommand sqlcomm = new SqlCommand("UPDATE Usuario SET UsuarioID = @UsuarioID, NomeUsuario = @NomeUsuario, Email = @ Email, Senha = @Senha, TipoUsuario = @TipoUsuario", conn);

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
    }
}
