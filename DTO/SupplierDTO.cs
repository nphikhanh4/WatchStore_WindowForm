using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class SupplierDTO
    {
        public int SupplierID { get; set; } // Primary key
        public string ContactName { get; set; } // Contact name
        public string ImgSupplier { get; set; } // Nullable image supplier path
        public string Phone { get; set; } // Phone number
        public string Email { get; set; } // Email address
        public string Address { get; set; } // Physical address
        public DateTime CreatedAt { get; set; } // Creation timestamp
    }
}
