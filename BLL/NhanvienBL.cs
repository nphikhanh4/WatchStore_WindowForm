using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanvienBL
    {
        private static NhanvienBL Instance;
        public static NhanvienBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new NhanvienBL();
                }
                return Instance;
            }
        }

        public bool AddNewAdmin(string adminName, string adminPassword, string adminFullName,
                                       string adminEmail, string adminRole, string adminPhone,
                                       string adminGender, string imageFileName)
        {
            return Nhanvien.GetInstance.InsertAdmin(adminName, adminPassword, adminFullName, adminEmail, adminRole, adminPhone, adminGender, imageFileName) > 0;
        }

        //Lay danh sách SP
        public DataTable GetDanhSachNV()
        {
            return Nhanvien.GetInstance. GetDanhSachNhanVien();
        }
        public DataTable SearchEmployees(string searchText)
        {
            return Nhanvien.GetInstance.SearchEmployees(searchText);
        }

        public DataTable FilterDataByComboBox(string rol)
        {
            return Nhanvien.GetInstance.FilterEmployeesByRole(rol);
        }
        #region Xóa Nhân Viên
        public bool DeleteAdmin(int adminId)
        {
            try
            {
                int result = Nhanvien.GetInstance.DeleteAdmin(adminId);
                return result > 0;  // If more than 0 rows are affected, deletion is successful
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting employee: " + ex.Message);
            }
        }
        #endregion
        #region Update Nhân Viên

         public bool UpdateAdmin(int adminId, string adminName, string adminPassword, string adminFullName,
                                string adminEmail, string adminRole, string adminPhone, string adminGender, string imageFileName)
        {
            try
            {
                return Nhanvien.GetInstance.UpdateAdmin(adminId, adminName, adminPassword, adminFullName, adminEmail, adminRole, adminPhone, adminGender, imageFileName) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting employee: " + ex.Message);
            }
        }
        #endregion

    }
}
