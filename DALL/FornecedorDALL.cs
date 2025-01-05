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
    internal class FornecedorDALL
    {
        public DataTable lista_Fornecedor()
        {
            var conn = Conexao.Conex();
            try
            {
                conn.Open();
                SqlCommand sqlcomando = new SqlCommand("SELECT * FROM Fornecedor", conn);
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
                SqlCommand sqlcomando = new SqlCommand("INSERT INTO Fornecedor (FornecedorID, NomeFornecedor, Cnpj, Endereco, Telefone, Email, CidadeID) VALUES  (@FornecedorID, @NomeFornecedor, @Cnpj, @Endereço, @Telefone, @Email, CidadeID)", conn);

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
                SqlCommand sqlcomando = new SqlCommand("UPDATE Fornecedor SET FornecedorID = @Fornecedor, NomeFornecedor = @NomeFornecedor, Cnpj = @Cnpj, Endereco = @Endereço, Telefone = @Telefone, Email = @Email, CidadeID = CidadeID", conn);

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
    }
}
