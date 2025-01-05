using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace DAL
{
    public class DataProvider
    {
        public static SqlConnection Openconnect()
        {
            string sChuoiKetNoi = @"Server=LAPTOP-4TC8L8F1;Database=WatchStore;Trusted_Connection=True;TrustServerCertificate=true;";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();
            return con;
        }
        public static void Disconnect(SqlConnection con)
        {
            con.Close();
        }

        public static string getConnectionString()
        {
           return @"Server=LAPTOP-4TC8L8F1;Database=WatchStore;Trusted_Connection=True;TrustServerCertificate=true;";
        }

        public static int JustExcuteNoParameter(string sql)
        {
            SqlConnection con = Openconnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            int rows = cmd.ExecuteNonQuery();
            Disconnect(con);
            if (rows > 0)
            {
                return rows;
            }
            else
            {
                return -1;
            }
        }

        public static int JustExcuteWithParameter(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(sql))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetTable(string sql)
        {
            SqlConnection con = Openconnect();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Disconnect(con);
            return dt;
        }

        public static DataTable GetTable1(string sql, SqlParameter[] parameters = null)
        {
            SqlConnection con = null;
            try
            {
                con = Openconnect();
                SqlCommand cmd = new SqlCommand(sql, con);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thực thi GetTable: {ex.Message}");
                return null;
            }
            finally
            {
                if (con != null)
                {
                    Disconnect(con);
                }
            }
        }
        //TÍNH /
        ///ktra email
        public static object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            string connectionString = getConnectionString();

            using (SqlConnection conn = new SqlConnection(connectionString))  // connectionString là chuỗi kết nối của bạn
            {
                try
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Thêm tham số vào câu lệnh SQL
                        cmd.Parameters.AddRange(parameters);

                        // Thực thi câu lệnh và trả về giá trị scalar (đơn)
                        return cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thực thi câu lệnh SQL: " + ex.Message);
                    return null;
                }
            }
        }
        public static int ExecuteCommand(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = Openconnect())
            {
                //conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static DataTable GetTableWithParameters(string sql, SqlParameter[] parameters)
        {
            

            using (SqlConnection con = new SqlConnection(getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
