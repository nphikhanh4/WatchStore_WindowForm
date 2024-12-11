using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class CategoryBL
    {
        private static CategoryBL Instance;
        public static CategoryBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new CategoryBL();
                }
                return Instance;
            }
        }
        private CategoryBL() { }

        public DataTable GetDanhSachLoaiSanPham()
        {
            return CategoryDL.GetInstance.GetDanhSachLoaiSanPham();
        }
    }
}
