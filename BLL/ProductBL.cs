using DataAccessLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ProductBL
    {
        private static ProductBL Instance;
        public static ProductBL GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new ProductBL();
                }
                return Instance;
            }
        }
        private ProductBL() { }
        //public int GetTongSanPhamDaBan()
        //{
        //    return ProductDL.GetInstance.GetTongSanPhamDaBan();
        //}
        //public int GetMaSPMoi()
        //{
        //    return ProductDL.GetInstance.GetMaSPMax() + 1;
        //}
        public string GetTenSP(int MASP)
        {
            return ProductDL.GetInstance.GetTenSP(MASP);
        }
        public DataTable GetDanhSachSanPhamTheoNCC(int MANCC)
        {
            return ProductDL.GetInstance.GetDanhSachSanPhamTheoNCC(MANCC);
        }
        //public bool CheckMaSP(string MASP)
        //{
        //    return ProductDL.GetInstance.CheckMaSP(MASP);
        //}
        public bool NgungKinhDoanhSanPham(string MASP)
        {
            return ProductDL.GetInstance.NgungKinhDoanhSanPham(MASP);
        }
        //public bool ThemSanPham(ProductDTO spDTO)
        //{
        //    return ProductDL.GetInstance.ThemSanPham(spDTO);
        //}
        //public bool SuaSanPham(ProductDTO spDTO)
        //{
        //    return ProductDL.GetInstance.SuaSanPham(spDTO);
        //}
        public DataTable GetDanhSachSanPhamTheoBoLoc(string TENSP, string MALOAISP, string MANCC)
        {
            return ProductDL.GetInstance.GetDanhSachSanPhamTheoBoLoc(TENSP, MALOAISP, MANCC);
        }
        public bool CapNhatSoLuong(int MaSP, int SoLuong)
        {
            return ProductDL.GetInstance.CapNhatSoLuong(MaSP, SoLuong);
        }
        public bool CapNhatSoLuongKhiBanHang(int MaSP, int SoLuong)
        {
            return ProductDL.GetInstance.CapNhatSoLuongKhiBanHang(MaSP, SoLuong);
        }
        public DataTable GetDanhSachSanPham()
        {
            return ProductDL.GetInstance.GetDanhSachSanPham();
        }
        public double GetTongDoanhThu()
        {
            return ProductDL.GetInstance.GetTongDoanhThu();
        }
        public int GetTongKhachHang()
        {
            return ProductDL.GetInstance.GetTongKhachHang();
        }
        //public List<ProductDTO> GetTop10SP(int top)
        //{
        //    return ProductDL.GetInstance.GetTop10SP(top);
        //}
        public double GetDoanhThuHomNay()
        {
            return ProductDL.GetInstance.GetDoanhThuHomNay();
        }
    }
}
