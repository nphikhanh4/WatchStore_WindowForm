using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class SupplierProductDL
    {
        public static int SelectedSupplierID { get; set; }
        public static String img { get; set; }
        public static String fileImg { get; set; }


        private static SupplierProductDL Instance;
        public static SupplierProductDL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SupplierProductDL();
                }
                return Instance;
            }
        }

        #region Lấy Danh sách sản phẩm trong kho
        public DataTable GetProductInStock()
        {
            try
            {
                string sql = @"
                  SELECT
                  ProductID,
                  SupplierProduct.SupplierID as 'supId',
                  SupplierProduct.CategoryID as 'cateId',
                  SupplierProduct.BrandID as 'brId',                    
                  br.BrandName as 'brName',
                   sp.SupplierName as 'supName',
                   cg.CategoryName as 'cateName',
                   ProductName,
                   Price,
                   Status,
                   Quantity,
                   SupplierProduct.CreatedAt,
                   Img
                FROM SupplierProduct
                  join [dbo].[Brand] as br on br.BrandID = SupplierProduct.BrandID
                  join [dbo].[Supplier] as sp on sp.SupplierID = SupplierProduct.SupplierID
                  join [dbo].[Category] as cg on cg.CategoryID = SupplierProduct.CategoryID";
                DataTable dt = new DataTable();
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

        #region Lấy Danh Sách Sản Phẩm trong cửa hanng
        public DataTable GetProduct()
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
                FROM [Product]
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

        // Thêm sản phẩm mới vào bảng Product
        public int AddProduct(string productName, int supplierID, decimal price, DateTime createdAt, int stockQuantity, string imageFileName, int BrandID, int CategoryID)
        {
            string sql = @"
        INSERT INTO Product (ProductName, SupplierID, ImportPrice, CreatedAt, StockQuantity, ImageUrl, BrandID, CategoryID)
        VALUES (@ProductName, @SupplierID, @ImportPrice, @CreatedAt, @StockQuantity, @Img, @BrandID, @CategoryID);
         ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductName", SqlDbType.NVarChar) { Value = productName },
                new SqlParameter("@SupplierID", SqlDbType.Int) { Value = supplierID },
                new SqlParameter("@ImportPrice", SqlDbType.Decimal) { Value = price }, // Tham số giá nhập
                new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = createdAt },
                new SqlParameter("@StockQuantity", SqlDbType.Int) { Value = stockQuantity },
                new SqlParameter("@Img", imageFileName) ,// Chỉ lưu tên file hình ảnh vào CSDL
                new SqlParameter("@BrandID", SqlDbType.Int) { Value = BrandID },
                new SqlParameter("@CategoryID", SqlDbType.Int) { Value = CategoryID },

            };

            return DataProvider.JustExcuteWithParameter(sql, parameters);
        }

        // update lại status
        public bool UpdateProductStatus(int productId, int newStatus)
        {
            string sql = @"
                UPDATE SupplierProduct
                SET Status = @Status
                WHERE ProductID = @ProductID;
                  ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ProductID", SqlDbType.Int) { Value = productId },
                new SqlParameter("@Status", SqlDbType.Int) { Value = newStatus }
            };

            return DataProvider.JustExcuteWithParameter(sql, parameters) > 0;
        }
        //brand NAme
        public string GetBrandNameById(int brandID)
        {
            string a = brandID.ToString();
            try
            {
                string sql = "SELECT BrandName FROM [WatchStore].[dbo].[Brand] WHERE BrandID =" + a;

                DataTable dt = DataProvider.GetTable(sql);
                return dt.Rows[0]["BrandName"].ToString(); // Trả về tên thương hiệu
            }
            catch (Exception ex)
            {
                // Xử lý lỗi chi tiết hơn để dễ debug
                Console.WriteLine("Lỗi khi truy vấn dữ liệu DL: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }
        }

        //The loai
        public string GetCategoryNameById(int categoryID)
        {
            string a = categoryID.ToString();
            try
            {
                string sql = "SELECT CategoryName FROM [WatchStore].[dbo].[Category] WHERE CategoryID =" + a;

                DataTable dt = DataProvider.GetTable(sql);
                return dt.Rows[0]["CategoryName"].ToString(); // Trả về tên danh mục
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi truy vấn dữ liệu DL: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }
        }
        // ncc
        public string GetSupplierNameById(int supplierID)
        {
            string a = supplierID.ToString();
            try
            {
                // Câu lệnh SQL để truy vấn tên nhà cung cấp theo SupplierID
                string sql = "SELECT ContactName FROM [WatchStore].[dbo].[Supplier] WHERE SupplierID =" + a;

                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable dt = DataProvider.GetTable(sql);
                return dt.Rows[0]["ContactName"].ToString(); // Trả về tên nhà cung cấp

            }
            catch (Exception ex)
            {
                // Xử lý lỗi chi tiết hơn để dễ debug
                Console.WriteLine("Lỗi khi truy vấn dữ liệu DL: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }
        }
        // xong nua

        // xoa ncc
        public bool UpdateSupplierRemove(int SupplierID, int check_Remove)
        {
            string sql = @"
                UPDATE Supplier
                SET check_Remove = @check_Remove
                WHERE SupplierID = @SupplierID;
                  ";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SupplierID", SqlDbType.Int) { Value = SupplierID },
                new SqlParameter("@check_Remove", SqlDbType.Int) { Value = check_Remove }
            };

            return DataProvider.JustExcuteWithParameter(sql, parameters) > 0;
        }

        // update ncc
        public bool UpdateSupplier(int SupplierID, string ContactName, string Phone, string Email, string Address)
        {
            try
            {
                string sql = @"
            UPDATE Supplier
            SET
                ContactName = @ContactName,
                Phone = @Phone,
                Email = @Email,
                Address = @Address
            WHERE SupplierID = @SupplierID;
              ";

                // Tạo các tham số SQL
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SupplierID", SqlDbType.Int) { Value = SupplierID },
                    new SqlParameter("@ContactName", SqlDbType.NVarChar, 100) { Value = ContactName },
                    new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = Phone },
                    new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = Email },
                    new SqlParameter("@Address", SqlDbType.NVarChar, 255) { Value = Address },
                };

                // Thực thi câu lệnh SQL
                int result = DataProvider.JustExcuteWithParameter(sql, parameters);

                // Kiểm tra kết quả
                return result > 0; // Nếu có bản ghi bị ảnh hưởng thì trả về true
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
                return false; // Nếu có lỗi thì trả về false
            }
        }
        // add ncc
        public bool AddSupplier(string ContactName, string Phone, string Email, string Address)
        {
            try
            {
                // Kiểm tra nếu email đã tồn tại trong cơ sở dữ liệu
                string checkEmailSql = "SELECT COUNT(*) FROM Supplier WHERE Email = @Email";
                SqlParameter[] checkEmailParams = new SqlParameter[]
                {
            new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = Email }
                };

                // Sử dụng phương thức ExecuteScalar để kiểm tra số lượng email trùng
                int emailCount = Convert.ToInt32(DataProvider.ExecuteScalar(checkEmailSql, checkEmailParams));

                if (emailCount > 0)
                {
                    // Nếu email đã tồn tại
                    //MessageBox.Show("Email đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Nếu email chưa tồn tại, thực hiện thêm nhà cung cấp mới
                string sql = @"
                    INSERT INTO Supplier (ContactName, Phone, Email, Address, CreatedAt)
                    VALUES (@ContactName, @Phone, @Email, @Address, @CreatedAt);
                    ";

                // Lấy ngày hiện tại
                DateTime currentDate = DateTime.Now;

                // Tạo các tham số SQL
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ContactName", SqlDbType.NVarChar, 100) { Value = ContactName },
            new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = Phone },
            new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = Email },
            new SqlParameter("@Address", SqlDbType.NVarChar, 255) { Value = Address },
            new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = currentDate } // Thêm ngày tạo
                };

                // Thực thi câu lệnh SQL
                int result = DataProvider.JustExcuteWithParameter(sql, parameters);

                // Kiểm tra kết quả
                return result > 0; // Nếu có bản ghi bị ảnh hưởng thì trả về true
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Lỗi khi thêm nhà cung cấp: " + ex.Message);
                return false; // Nếu có lỗi thì trả về false
            }
        }
        // find
        public int AddSupplierProduct(int supplierID, string productName, decimal price, int status, int quantity, string img, int categoryID, int brandID)
        {
            try
            {
                string sql = @"
            INSERT INTO SupplierProduct (
                SupplierID,
                ProductName,
                Price,
                Status,
                Quantity,
            
                Img,
                CategoryID,
                BrandID
            ) VALUES (
                @SupplierID,
                @ProductName,
                @Price,
                @Status,
                @Quantity,
             
                @Img,
                @CategoryID,
                @BrandID
            )";
                DateTime currentDate = DateTime.Now;
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@SupplierID", SqlDbType.Int) { Value = supplierID },
                    new SqlParameter("@ProductName", SqlDbType.NVarChar) { Value = productName },
                    new SqlParameter("@Price", SqlDbType.Decimal) { Value = price },
                    new SqlParameter("@Status", SqlDbType.Int) { Value = status },
                    new SqlParameter("@Quantity", SqlDbType.Int) { Value = quantity },
                    new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = currentDate },
                    new SqlParameter("@Img", SqlDbType.NVarChar) { Value = img ?? (object)DBNull.Value },
                    new SqlParameter("@CategoryID", SqlDbType.Int) { Value = categoryID },
                    new SqlParameter("@BrandID", SqlDbType.Int) { Value = brandID }
                };

                return DataProvider.JustExcuteWithParameter(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm sản phẩm: " + ex.Message);
                return -1; // Trả về -1 nếu có lỗi
            }
        }




    }
}