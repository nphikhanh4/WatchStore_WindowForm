using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class SignupBL
    {
        private static SignupBL Instance;
        public static SignupBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SignupBL();
                }
                return Instance;
            }
        }
        private SignupBL() { }
        // Kiểm tra đăng nhập
        public bool CheckLogin(string username, string password)
        {
            // Xử lý logic nếu cần trước khi gọi DAL
            return SignupDL.GetInstance.CheckLogin(username, password);
        }

        // Lấy quyền người dùng
        public string GetRole(string username)
        {
            return SignupDL.GetInstance.GetRole(username);
        }
        // Lấy ten người dùng
        public string GetName(string username)
        {
            return SignupDL.GetInstance.GetName(username);
        }
        // Doi mat khau
        public bool DoiMatKhau(string username, string newPassword)
        {
            try
            {
                return SignupDL.GetInstance.ChangePassword(username, newPassword);
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                throw new Exception("Error while changing password.", ex);
            }
        }

        public DataTable GetDanhSachAdmin()
        {
            return SignupDL.GetInstance.GetDanhSachAdmin();
        }

    }
}
