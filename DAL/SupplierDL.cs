using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class SupplierDL
    {
        private static SupplierDL Instance;
        public static SupplierDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SupplierDL();
                }
                return Instance;
            }
        }


        #region Lấy Danh sach NCC
        public DataTable GetDanhSachNhaCungCap()
        {
            try
            {
                string sql = @"
                SELECT TOP (1000) [SupplierID]
                      ,[ContactName]
                      ,[ImgSupplier]
                      ,[Phone]
                      ,[Email]
                      ,[Address]
                      ,[CreatedAt],
                        check_Remove
                  FROM [WatchStore].[dbo].[Supplier]";

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

        #region Lấy Danh Sách NCC Cua tao
        public DataTable GetDanhSachNCC()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "SELECT SupplierId ,SupplierName ,Address AS N'Địa Chỉ NCC',Phone AS N'SĐT',Email AS 'Email' FROM Supplier";
                dt = DataProvider.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi database: " + ex.Message);
                return null;
            }
        }
        #endregion
    }
}
