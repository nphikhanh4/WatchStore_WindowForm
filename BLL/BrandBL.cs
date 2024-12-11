using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BrandBL
    {
        private static BrandBL Instance;
        public static BrandBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new BrandBL();
                }
                return Instance;
            }
        }
        private BrandBL() { }

        public DataTable GetDanhSachLoaiSanPham()
        {
            return BrandDL.GetInstance.GetDanhSachNhanHang();
        }
    }
}
