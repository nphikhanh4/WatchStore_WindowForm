using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHangBL
    {
        private static KhachHangBL Instance;
        public static KhachHangBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new KhachHangBL();
                }
                return Instance;
            }
        }

        public DataTable GetDanhSachKH()
        {
            return KhachHang.GetInstance.GetDanhSachKhachHang();
        }
        public DataTable SearchCustomer(string searchText)
        {
            return KhachHang.GetInstance.SearchCustomer(searchText);
        }
        public bool AddNewCustomer(string customerName, string customerEmail, string customerPhone,
                             string customerPassword, string customerAddress,
                             string customerGender, string imageFileName)
        {
            return KhachHang.GetInstance.InsertCustomer(customerName, customerEmail, customerPhone, customerPassword, customerAddress, customerGender, imageFileName) > 0;
        }
        #region Xóa khách hàng
        public bool DeleteCustomer(int CustomerID)
        {
            try
            {
                int result = KhachHang.GetInstance.DeleteCustomer(CustomerID);
                return result > 0;  // If more than 0 rows are affected, deletion is successful
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting customer: " + ex.Message);
            }
        }
        #endregion
        #region Update khách hàng

        public bool UpdateKhachHang(int customerid, string customerName, string customerEmail, string customerPhone,
                             string customerPassword, string customerAddress,
                             string customerGender, string imageFileName)
        {
            try
            {
                return KhachHang.GetInstance.UpdateCustomer(customerid, customerName, customerEmail, customerPhone, customerPassword, customerAddress, customerGender, imageFileName) > 0; ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in deleting customer: " + ex.Message);
            }
        }
        #endregion

    }
}
