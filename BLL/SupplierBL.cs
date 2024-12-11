using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class SupplierBL
    {
        private static SupplierBL Instance;
        public static SupplierBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SupplierBL();
                }
                return Instance;
            }
        }

        public DataTable GetDanhSachNhaCungCap()
        {
            return SupplierDL.GetInstance.GetDanhSachNhaCungCap();
        }

        public DataTable GetDanhSachNCC()
        {
            return SupplierDL.GetInstance.GetDanhSachNCC();
        }
    }
}
