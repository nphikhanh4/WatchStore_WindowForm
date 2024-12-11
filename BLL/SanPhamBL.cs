using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SanPhamBL
    {
        private static SanPhamBL Instance;
        public static SanPhamBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new SanPhamBL();
                }
                return Instance;
            }
        }


        //Lay danh sách SP
        public DataTable GetDanhSachSanPham()
        {
            return SanPhamDL.GetInstance.GetDanhSachSanPham();
        }

        //xóa SP
        public bool NgungKinhDoanhSanPham(string MASP)
        {
            return SanPhamDL.GetInstance.NgungKinhDoanhSanPham(MASP);
        }


    }
}
