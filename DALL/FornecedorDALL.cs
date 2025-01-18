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
    internal class FornecedorDALL
    {
        public DataTable lista_Fornecedor()
        {
            var conn = Conexao.Conex();
            try
            {
                conn.Open();
                SqlCommand sqlcomando = new SqlCommand("SELECT Fornecedor.FornecedorID, Fornecedor.NomeFornecedor, Fornecedor.Cnpj, Fornecedor.Endereco, Fornecedor.Telefone, Fornecedor.Email, Fornecedor.CidadeID, Cidade.NomeCidade FROM Fornecedor INNER JOIN Cidade ON Fornecedor.CidadeID = Cidade.CidadeID", conn);
                SqlDataAdapter daFornecedor = new SqlDataAdapter();
                daFornecedor.SelectCommand = sqlcomando;
                DataTable dtFornecedor = new DataTable();
                daFornecedor.Fill(dtFornecedor);
                return dtFornecedor;
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

        public void gravaFornecedor(FornecedorMODEL fornecedor)
        {
            var conn = Conexao.Conex();

            try
            {
                SqlCommand sqlcomando = new SqlCommand("INSERT INTO Fornecedor (FornecedorID, NomeFornecedor, Cnpj, Endereco, Telefone, Email, CidadeID) VALUES  (@FornecedorID, @NomeFornecedor, @Cnpj, @Endereco, @Telefone, @Email, @CidadeID)", conn);

                sqlcomando.Parameters.AddWithValue("@FornecedorID", fornecedor.FornecedorID);
                sqlcomando.Parameters.AddWithValue("@NomeFornecedor", fornecedor.NomeFornecedor);
                sqlcomando.Parameters.AddWithValue("@Cnpj", fornecedor.Cnpj);
                sqlcomando.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                sqlcomando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
                sqlcomando.Parameters.AddWithValue("@Email", fornecedor.Email);
                sqlcomando.Parameters.AddWithValue("@CidadeID", fornecedor.CidadeID);


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

        public void excluiFornecedor(FornecedorMODEL fornecedor)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("DELETE FROM Fornecedor WHERE  FornecedorID = @FornecedorID", conn);
                sqlcomando.Parameters.AddWithValue("@FornecedorID", fornecedor.FornecedorID);
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

        public void atualizaFornecedor(FornecedorMODEL fornecedor)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("UPDATE Fornecedor SET NomeFornecedor = @NomeFornecedor, Cnpj = @Cnpj, Endereco = @Endereco, Telefone = @Telefone, Email = @Email, CidadeID = CidadeID WHERE FornecedorID = @FornecedorID", conn);

                sqlcomando.Parameters.AddWithValue("@NomeFornecedor", fornecedor.NomeFornecedor);
                sqlcomando.Parameters.AddWithValue("@Cnpj", fornecedor.Cnpj);
                sqlcomando.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);
                sqlcomando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
                sqlcomando.Parameters.AddWithValue("@Email", fornecedor.Email);
                sqlcomando.Parameters.AddWithValue("@CidadeID", fornecedor.CidadeID);
                sqlcomando.Parameters.AddWithValue("@FornecedorID", fornecedor.FornecedorID);

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

                string sqlconn = "SELECT FornecedorID, NomeFornecedor, Cnpj, Endereco, Telefone, Email, CidadeID FROM Fornecedor WHERE NomeFornecedor LIKE @NomeFornecedor";


                //string sqlconn = "SELECT TOP (30) * FROM Cliente WHERE NomeCliente LIKE @NomeCliente";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@NomeFornecedor", nome);
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

                string sqlconn = "SELECT FornecedorID, NomeFornecedor, Cnpj, Endereco, Telefone, Email, CidadeID FROM Fornecedor WHERE FornecedorID LIKE @FornecedorID";


                //string sqlconn = "SELECT TOP (30) * FROM Cliente WHERE NomeCliente LIKE @NomeCliente";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                cmd.Parameters.AddWithValue("@FornecedorID", nome);
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

                string sqlconn = "SELECT TOP (30) FornecedorID, NomeFornecedor, Cnpj,   Endereco, Telefone, Email, CidadeID FROM Fornecedor";
                SqlCommand cmd = new SqlCommand(sqlconn, conn);
                //cmd.Parameters.AddWithValue("@NomeCategoria", nome);
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
