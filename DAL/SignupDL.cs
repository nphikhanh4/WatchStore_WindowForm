using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SignupDL
    {

        private static SignupDL Instance;
        public static SignupDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SignupDL();
                }
                return Instance;
            }
        }
        private SignupDL() { }

        private string connectionString = DataProvider.getConnectionString();

        // Kiểm tra đăng nhập
        public bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Admin WHERE AdminName = @username AND Password = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }

        // Lấy quyền của người dùng
        public string GetRole(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Role FROM Admin WHERE AdminName = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                conn.Open();
                return (string)cmd.ExecuteScalar();
            }
        }
        // Lấy ten của người dùng
        public string GetName(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Adminname FROM Admin WHERE AdminName = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", name);

                conn.Open();
                return (string)cmd.ExecuteScalar();
            }
        }



        // Đổi mật khẩu
        public bool ChangePassword(string username, string newPassword)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Admin SET Password = @newPassword WHERE AdminName = @username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@newPassword", newPassword);
                    cmd.Parameters.AddWithValue("@username", username);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while changing the password in the database.", ex);
            }
        }
        #region Lấy Danh sach admin
        public DataTable GetDanhSachAdmin()
        {
            try
            {
                string sql = @"SELECT TOP (1000) [AdminID]
                              ,[Adminname]
                              ,[Password]
                              ,[ImgAdmin]
                              ,[FullName]
                              ,[Email]
                              ,[Role]
                              ,[CreatedAt]
                              ,[Phone]
                              ,[Gender]
                              ,[check_Remove]
                          FROM [WatchStore].[dbo].[Admin]";

                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {
                //   MessageBox.Show("Lỗi database: " + ex.Message);
                return null;
            }
        }
        #endregion

    }
}
