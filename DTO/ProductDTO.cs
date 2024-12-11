using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public string categoryid { get; set; }
        public string dvt { get; set; }
        public int brand { get; set; }
        public int quantity { get; set; }
        public decimal inputprice { get; set; }
        public int profit { get; set; }
        public decimal outputprice { get; set; }
        public int khuyenmai { get; set; }
        public double tongdoanhthu { get; set; }
    }
}
