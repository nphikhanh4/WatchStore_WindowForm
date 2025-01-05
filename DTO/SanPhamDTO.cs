using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int BrandID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryID { get; set; }
        public string ImageUrl { get; set; }
        public int SupplierID { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int Discount { get; set; }
        public int Check_Remove { get; set; }
        public float AverageRating { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal Profit { get; set; }
        public decimal ProfitMargin { get; set; }
    }
}
