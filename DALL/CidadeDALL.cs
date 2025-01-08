using SisControl.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisControl.DALL
{
    internal class CidadeDALL
    {
        public DataTable Listar_Cidades()
        {
            var conn = Conexao.Conex();
            try
            {
                conn.Open();
                SqlCommand sqlcomando = new SqlCommand("SELECT TOP (30) Cidade.CidadeID, Cidade.Nome, Cidade.EstadoID, Estado.Nome AS Expr1, Estado.Uf FROM Cidade INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID", conn);
                SqlDataAdapter daReceitas = new SqlDataAdapter();
                daReceitas.SelectCommand = sqlcomando;
                DataTable dtReceitas = new DataTable();
                daReceitas.Fill(dtReceitas);
                return dtReceitas;
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

        public void gravaCidades(CidadeMODEL Cidades)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("INSERT INTO Cidade (CidadeID, NomeCidade, EstadoID, Ibge) VALUES  (@CidadeID, @NomeCidade, @EstadoID, @Ibge)", conn);
                                
                sqlcomando.Parameters.AddWithValue("@CidadeID", Cidades.CidadeID);
                sqlcomando.Parameters.AddWithValue("@NomeCidade", Cidades.NomeCidade);
                sqlcomando.Parameters.AddWithValue("@EstadoID", Cidades.EstadoID);
                sqlcomando.Parameters.AddWithValue("@Ibge", Cidades.Ibge);

                conn.Open();
                sqlcomando.ExecuteNonQuery();
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

        public void ExcluiCidade(CidadeMODEL Cidades)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("DELETE FROM Cidade WHERE CidadeID = @CidadeID", conn);
                sqlcomando.Parameters.AddWithValue("@Id", Cidades.CidadeID);
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

        public void AtualizaCidade(CidadeMODEL Cidades)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("UPDATE Cidade SET CidadeID = @CidadeID, NomeCidade = @NomeCidade, EstadoID = @EstadoID, Ibge = @Ibge", conn);

                sqlcomando.Parameters.AddWithValue("@CidadeID", Cidades.CidadeID);
                sqlcomando.Parameters.AddWithValue("@NomeCidade", Cidades.NomeCidade);
                sqlcomando.Parameters.AddWithValue("@EstadoID", Cidades.EstadoID);
                sqlcomando.Parameters.AddWithValue("@Ibge", Cidades.Ibge);

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
        public DataTable PesquisarPorNome(string nome)
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();

                string sqlconn = "SELECT TOP (30) Cidade.CidadeID, Cidade.NomeCidade, Cidade.EstadoID, Estado.NomeEstado FROM  Cidade INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID WHERE NomeCidade LIKE @NomeCidade";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeCidade", nome);
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

                string sqlconn = "SELECT TOP (30) Cidade.CidadeID, Cidade.NomeCidade, Cidade.EstadoID, Estado.NomeEstado FROM  Cidade INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID WHERE CidadeID  LIKE @CidadeID";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@CidadeID", nome);
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
        public DataTable PesquisarGeral()
        {
            var conn = Conexao.Conex();
            try
            {
                DataTable dt = new DataTable();
                string sqlconn = "SELECT TOP (30) Cidade.CidadeID, Cidade.NomeCidade, Cidade.EstadoID, Estado.NomeEstado FROM  Cidade INNER JOIN Estado ON Cidade.EstadoID = Estado.EstadoID";
                                 //WHERE Cidade.NomeCidade = @NomeCidade);
                                
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                //cmd.Parameters.AddWithValue("@NomeCidade", nome);
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
