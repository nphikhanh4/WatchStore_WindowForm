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

        public string GetTenSP(int MASP)
        {
            return ProductDL.GetInstance.GetTenSP(MASP);
        }
        public DataTable GetDanhSachSanPhamTheoNCC(int MANCC)
        {
            return ProductDL.GetInstance.GetDanhSachSanPhamTheoNCC(MANCC);
        }
        public bool NgungKinhDoanhSanPham(string MASP)
        {
            return ProductDL.GetInstance.NgungKinhDoanhSanPham(MASP);
        }
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
        public double GetDoanhThuHomNay()
        {
            return ProductDL.GetInstance.GetDoanhThuHomNay();
        }
        public DataTable GetProductToPrint(int id)
        {
            return ProductDL.GetInstance.GetProductToPrint(id);
        }
    }
}
