using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

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


        //Sua SP
        public bool SuaSanPham(SanPhamDTO spDTO)
        {
            return SanPhamDL.GetInstance.SuaSanPham(spDTO);
        }

        //Them SP
        public bool ThemSanPham(SanPhamDTO spDTO)
        {
            return SanPhamDL.GetInstance.ThemSanPham(spDTO);
        }

        //Loc SP
        public DataTable GetDanhSachSanPhamTheoBoLoc(string TENSP, string MALOAISP, string MANCC)
        {
            return SanPhamDL.GetInstance.GetDanhSachSanPhamTheoBoLoc(TENSP, MALOAISP, MANCC);
        }
    }
}
