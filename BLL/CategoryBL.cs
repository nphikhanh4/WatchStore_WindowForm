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

        //Lay ra danh sach
        public DataTable GetDanhSachLoaiSanPham()
        {
            return CategoryDL.GetInstance.GetDanhSachLoaiSanPham();
        }

        //Them loai Sp
        public bool ThemLoaiSanPham(CategoryDTO lspDTO)
        {
            return CategoryDL.GetInstance.ThemLoaiSanPham(lspDTO);
        }
        //Xoa
        public bool NgungKinhDoanh(string MALOAISP)
        {
            return CategoryDL.GetInstance.NgungKinhDoanh(MALOAISP);
        }

        //Cap nhat
        public bool CapNhatLoaiSanPham(CategoryDTO lspDTO)
        {
            return CategoryDL.GetInstance.CapNhatLoaiSanPham(lspDTO);
        }
    }
}
