using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisControl
{
    internal class Conexao
    {
        public static SqlConnection Conex()
        {
            try
            {
                //DESKTOP 
                //string conn = "Data Source=NOTEBOOK-DELL\\SQLEXPRESS;Initial Catalog=bdsiscontrol;Integrated Security=True;";
                string conn = "Server=DESKTOP-WR\\SQLEXPRESS;Database=bdsiscontrol;Trusted_Connection=True;";
                //NOTEBOOK
                //string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Money\\Data\\bdmoney.mdf;Integrated Security=True;";

                SqlConnection myConn = new SqlConnection(conn);
                return myConn;
            }
            catch (SqlException ex) // SqlException
            {
                throw new Exception(ex.Message);
            }
        }
        public static SqlDataReader Sql_DataReader(string queryString)
        {
            var conexao = Conexao.Conex();
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = queryString;
            comando.Connection = conexao;

            SqlDataReader reader = comando.ExecuteReader();
            return reader;
        }

        public static DataTable SQL_data_adapter(string query_String)
        {
            DataTable DataTableC = new DataTable();
            var conexao = Conexao.Conex();

            try
            {
                conexao.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query_String, conexao);

                adapter.Fill(DataTableC);

                conexao.Dispose();
                adapter.Dispose();
            }
            catch
            {
            }
            return DataTableC;
        }
        public static bool execute_NON_query(string query_String, string ParametroBase, string parametroReal)
        {
            try
            {
                var conexao = Conexao.Conex();

                conexao.Open();

                SqlCommand comando = new SqlCommand(query_String, conexao);

                comando.Parameters.AddWithValue(ParametroBase, parametroReal);
                comando.ExecuteNonQuery();

                conexao.Dispose();
                comando.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
