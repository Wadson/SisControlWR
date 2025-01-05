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
    internal class ItemVendaDALL
    {
        public DataTable listaItensVenda()
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand comando = new SqlCommand("SELECT ItemVendaID, VendaID, ProdutoID, Quantidade, PrecoUnitario FROM ItemVenda", conn);

                SqlDataAdapter daItensVenda = new SqlDataAdapter();
                daItensVenda.SelectCommand = comando;

                DataTable dtItensVenda = new DataTable();
                daItensVenda.Fill(dtItensVenda);
                return dtItensVenda;
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

        public void SalvarItensVenda(ItemVendaMODEL itensvenda)
        {
            var conn = Conexao.Conex();

            SqlCommand sqlcomm = new SqlCommand("INSERT INTO ItemVenda (ItemVendaID, VendaID, ProdutoID, Quantidade, PrecoUnitario) VALUES (@ItemVendaID, @VendaID, @ProdutoID, @Quantidade, @PrecoUnitario)", conn);

            sqlcomm.Parameters.AddWithValue("@ItemVendaID", itensvenda.ItemVendaID);
            sqlcomm.Parameters.AddWithValue("@VendaID", itensvenda.VendaID);
            sqlcomm.Parameters.AddWithValue("@ProdutoID", itensvenda.ProdutoID);
            sqlcomm.Parameters.AddWithValue("@Quantidade", itensvenda.Quantidade);
            sqlcomm.Parameters.AddWithValue("@PrecoUnitario", itensvenda.PrecoUnitario);

            conn.Open();
            sqlcomm.ExecuteNonQuery();
            try
            {

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
        public void excluirItensVenda(ItemVendaMODEL itensvenda)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomando = new SqlCommand("DELETE FROM ItenVenda WHERE ItemVendaID = @ItemVendaID", conn);
                sqlcomando.Parameters.AddWithValue("@ItemVendaID", itensvenda.ItemVendaID);
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
        public void atualizaItensVenda(ItemVendaMODEL itensvenda)
        {
            var conn = Conexao.Conex();
            try
            {
                SqlCommand sqlcomm = new SqlCommand("UPDATE ItemVenda SET  ItemVendaID = @ItemVendaID, VendaID = @VendaID, ProdutoID = @ProdutoID, Quantidade = @Quantidade, PrecoUnitario = @PrecoUnitario", conn);

                sqlcomm.Parameters.AddWithValue("@ItemVendaID", itensvenda.ItemVendaID);
                sqlcomm.Parameters.AddWithValue("@VendaID", itensvenda.VendaID);
                sqlcomm.Parameters.AddWithValue("@ProdutoID", itensvenda.ProdutoID);
                sqlcomm.Parameters.AddWithValue("@Quantidade", itensvenda.Quantidade);
                sqlcomm.Parameters.AddWithValue("@PrecoUnitario", itensvenda.PrecoUnitario);

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
