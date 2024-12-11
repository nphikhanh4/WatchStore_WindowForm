
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAL
{
    public class SanPhamDL
    {
        private static SanPhamDL Instance;
        public static SanPhamDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SanPhamDL();
                }
                return Instance;
            }
        }

        #region Lấy Danh Sách Sản Phẩm
        public DataTable GetDanhSachSanPham()
        {
            try
            {
                string sql = @"
                SELECT
                  [ProductID], [ProductName], [BrandID], [Price], 
                  [Description], [StockQuantity], [CategoryID], 
                  [ImageUrl], [SupplierID], [CreatedAt], [CreatedBy], 
                  [Discount], [Check_Remove], [AverageRating], 
                  [ImportPrice], [Profit], [ProfitMargin]              
                FROM [WatchStore].[dbo].[Product]
                WHERE Check_Remove = 1";

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

        #region Ngừng Kinh Doanh Sản Phẩm
        public bool NgungKinhDoanhSanPham(string MASP)
        {
            try
            {
                string sql = " UPDATE Product SET Check_Remove = 0 WHERE [ProductID] ='" + MASP + "'";
                
                int rows = DataProvider.JustExcuteNoParameter(sql);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Lỗi database: " + ex.Message);
               Console.WriteLine("Lỗi database: " + ex.Message);
                return false;
            }
        }
        #endregion
    }
}
