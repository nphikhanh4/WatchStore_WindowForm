using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDL
    {
        private static CategoryDL Instance;
        public static CategoryDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new CategoryDL();
                }
                return Instance;
            }
        }
        private CategoryDL() { }

        #region Lấy Danh Sách Loại Sản Phẩm
        public DataTable GetDanhSachLoaiSanPham()
        {
            try
            {
                string sql = "SELECT [CategoryID],[CategoryName]  FROM [WatchStore].[dbo].[Category]";
                DataTable dt = new DataTable();
                dt = DataProvider.GetTable(sql);
                return dt;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show("Lỗi database: " + ex.Message);
                return null;
            }
        }
        #endregion
    }
}