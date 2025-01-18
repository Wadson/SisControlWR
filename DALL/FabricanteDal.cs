using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SisControl.DALL
{
    internal class FabricanteDal
    {
       
        public List<FabricanteModel> ObterTodosFabricantes()
        {
            List<FabricanteModel> fabricantes = new List<FabricanteModel>();
            using (var connection = Conexao.Conex())
            {
                string query = "SELECT FabricanteID, NomeFabricante, Endereco, Telefone FROM Fabricantes";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FabricanteModel fabricante = new FabricanteModel
                        {
                            FabricanteID = reader.GetInt32(0),
                            NomeFabricante = reader.GetString(1),
                            Endereco = reader.GetString(2),
                            Telefone = reader.GetString(3)
                        };
                        fabricantes.Add(fabricante);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter fabricantes: " + ex.Message);
                }
            }
            return fabricantes;
        }

        public void InserirFabricante(FabricanteModel fabricante)
        {
            using (var connection = Conexao.Conex())
            {
                string query = "INSERT INTO Fabricantes (FabricanteID, NomeFabricante, Endereco, Telefone) VALUES (@FabricanteID, @NomeFabricante, @Endereco, @Telefone)";
                
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FabricanteID", fabricante.FabricanteID);
                command.Parameters.AddWithValue("@NomeFabricante", fabricante.NomeFabricante);
                command.Parameters.AddWithValue("@Endereco", fabricante.Endereco);
                command.Parameters.AddWithValue("@Telefone", fabricante.Telefone);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao inserir fabricante: " + ex.Message);
                }
            }
        }

        public void AtualizarFabricante(FabricanteModel fabricante)
        {
            using (var connection = Conexao.Conex())
            {
                string query = "UPDATE Fabricantes SET NomeFabricante = @NomeFabricante, Endereco = @Endereco, Telefone = @Telefone WHERE FabricanteID = @FabricanteID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeFabricante", fabricante.NomeFabricante);
                command.Parameters.AddWithValue("@Endereco", fabricante.Endereco);
                command.Parameters.AddWithValue("@Telefone", fabricante.Telefone);
                command.Parameters.AddWithValue("@FabricanteID", fabricante.FabricanteID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar fabricante: " + ex.Message);
                }
            }
        }

        public void RemoverFabricante(int fabricanteID)
        {
            using (var connection = Conexao.Conex())
            {
                string query = "DELETE FROM Fabricantes WHERE FabricanteID = @FabricanteID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FabricanteID", fabricanteID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao remover fabricante: " + ex.Message);
                }
            }
        }
        public List<FabricanteModel> ObterFabricantesPorNome(string nome)
        {
            List<FabricanteModel> fabricantes = new List<FabricanteModel>();
            using (var connection = Conexao.Conex())
            {
                string query = "SELECT FabricanteID, NomeFabricante, Endereco, Telefone FROM Fabricantes WHERE NomeFabricante LIKE @Nome";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", $"%{nome}%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        FabricanteModel fabricante = new FabricanteModel
                        {
                            FabricanteID = reader.GetInt32(0),
                            NomeFabricante = reader.GetString(1),
                            Endereco = reader.GetString(2),
                            Telefone = reader.GetString(3)
                        };
                        fabricantes.Add(fabricante);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter fabricantes: " + ex.Message);
                }
            }
            return fabricantes;
        }
        public DataTable listarFabricante()
        {
            //DataTable ListaUsuario = Conexao.SQL_data_adapter("SELECT idusuario,nome, usuario, dtnascimento, nivelacesso, senha FROM usuario");

            var conn = Conexao.Conex();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT FabricanteID, NomeFabricante, Endereco, Telefone FROM Fabricantes", conn);
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
        public DataTable PesquisarPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT FabricanteID, NomeFabricante, Endereco, Telefone FROM Fabricantes WHERE NomeFabricante  LIKE @NomeFabricante";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeFabricante", nome);
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
        public DataTable PesquisarPorCodigo(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT FabricanteID, NomeFabricante, Endereco, Telefone WHERE FabricanteID  LIKE @FabricanteID";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@FabricanteID", nome);
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
