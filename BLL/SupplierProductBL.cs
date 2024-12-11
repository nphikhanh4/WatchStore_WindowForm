using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SupplierProductBL
    {
        private static SupplierProductBL Instance;

        public static SupplierProductBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SupplierProductBL();
                }
                return Instance;
            }
        }

        public DataTable GetProductInStock()
        {
            return SupplierProductDL.GetInstance.GetProductInStock();
        }

        public DataTable GetProduct()
        {
            return SupplierProductDL.GetInstance.GetProduct();
        }

        private SupplierProductDL SupplierProductDL = new SupplierProductDL();

        // Thêm sản phẩm vào bảng Product
        public bool AddProduct(string productName, int supplierID, decimal price, DateTime createdAt, int stockQuantity, string imageFileName, int BrandID, int CategoryID)
        {
            return SupplierProductDL.AddProduct(productName, supplierID, price, createdAt, stockQuantity, imageFileName, BrandID, CategoryID) >= 0;
        }
        
        public bool UpdateProductStatus(int productId, int newStatus)
        {
            return SupplierProductDL.UpdateProductStatus(productId, newStatus);
        }

        //private SupplierProductDL supplierProductDL = new SupplierProductDL();  // Khởi tạo đối tượng SupplierProductDL

        public string GetBrandNameById(int brandID)
        {
            return SupplierProductDL.GetInstance.GetBrandNameById(brandID); // Gọi phương thức từ DAL
        }
        
        public string GetCategoryNameById(int categoryID)
        {
            return SupplierProductDL.GetInstance.GetCategoryNameById(categoryID); // Gọi phương thức từ DAL
        }
        
        public string GetSupplierNameById(int supplierID)
        {
            return SupplierProductDL.GetInstance.GetSupplierNameById(supplierID); // Gọi phương thức từ DAL
        }

        public bool UpdateSupplierRemove(int SupplierID, int check_Remove)
        {
            return SupplierProductDL.GetInstance.UpdateSupplierRemove(SupplierID, check_Remove);
        }
        
        public bool UpdateSupplier(int SupplierID, string ContactName, string Phone, string Email, string Address)
        {
            return SupplierProductDL.GetInstance.UpdateSupplier(SupplierID, ContactName, Phone, Email, Address);
        }

        public bool AddSupplier(string ContactName, string Phone, string Email, string Address)
        {
            return SupplierProductDL.GetInstance.AddSupplier(ContactName, Phone, Email, Address);
        }

        public bool AddSupplierProduct(int supplierID, string productName, decimal price, int status, int quantity, string img, int categoryID, int brandID)
        {
            return SupplierProductDL.GetInstance.AddSupplierProduct(supplierID, productName, price, status, quantity, img, categoryID, brandID) > 0;
        }
    }
}