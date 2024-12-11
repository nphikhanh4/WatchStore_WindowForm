using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DONGHO.Forms;

namespace DONGHO.Usercontrols
{
    public partial class uc_SanPham : UserControl
    {
        public uc_SanPham()
        {
            InitializeComponent();
            LoadDataGridView();
            LoadComboBoxData();
        }


        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = SanPhamBL.GetInstance.GetDanhSachSanPham();

                // Xóa cột cũ trước khi thêm dữ liệu
                dgvSanPham.Columns.Clear();

                // Tạo cột hiển thị dữ liệu
                dgvSanPham.Columns.Add("ProductID", "Mã SP");
                dgvSanPham.Columns.Add("ProductName", "Tên SP");
                dgvSanPham.Columns.Add("Price", "Giá bán");
                dgvSanPham.Columns.Add("StockQuantity", "Số lượng");
                dgvSanPham.Columns.Add("CategoryID", "Mã loại SP");
                dgvSanPham.Columns.Add("SupplierID", "Mã NCC SP");
                dgvSanPham.Columns.Add("BrandID", "Mã nhãn hàng SP");
                dgvSanPham.Columns.Add("CreatedAt", "Ngày sản xuất");
                dgvSanPham.Columns.Add("Discount", "Giảm giá");
                dgvSanPham.Columns.Add("ImportPrice", "Giá vốn");
                dgvSanPham.Columns.Add("ProfitMargin", "Lợi nhuận");

                // Thêm cột ảnh
                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    Name = "ImageColumn",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvSanPham.Columns.Add(imgColumn);

                // Thêm dữ liệu vào DataGridView
                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = dgvSanPham.Rows.Add();

                    dgvSanPham.Rows[rowIndex].Cells["ProductID"].Value = row["ProductID"];
                    dgvSanPham.Rows[rowIndex].Cells["ProductName"].Value = row["ProductName"];
                    dgvSanPham.Rows[rowIndex].Cells["Price"].Value = row["Price"];
                    dgvSanPham.Rows[rowIndex].Cells["StockQuantity"].Value = row["StockQuantity"];
                    dgvSanPham.Rows[rowIndex].Cells["CategoryID"].Value = row["CategoryID"];
                    dgvSanPham.Rows[rowIndex].Cells["SupplierID"].Value = row["SupplierID"];
                    dgvSanPham.Rows[rowIndex].Cells["BrandID"].Value = row["BrandID"];
                    dgvSanPham.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                    dgvSanPham.Rows[rowIndex].Cells["Discount"].Value = row["Discount"];
                    dgvSanPham.Rows[rowIndex].Cells["ImportPrice"].Value = row["ImportPrice"];
                    dgvSanPham.Rows[rowIndex].Cells["ProfitMargin"].Value = row["ProfitMargin"];

                    // Handle image
                    string imagePath = Path.Combine(Application.StartupPath, "C:\\BTL_W\\BTL\\Images", row["ImageUrl"].ToString());
                    if (File.Exists(imagePath))
                    {
                        dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = Image.FromFile(imagePath);
                    }
                    else
                    {
                        dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = null; // Set a default image
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        int masp = 0;
        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSanPham.SelectedRows.Count == 1)
                {
                    DataGridViewRow dr = dgvSanPham.SelectedRows[0];



                    // Assign form fields
                    txtTen.Text = dr.Cells["ProductName"].Value?.ToString()?.Trim() ?? "";
                    cboLoai.SelectedValue = dr.Cells["CategoryID"].Value?.ToString();
                    cboNCC.SelectedValue = dr.Cells["SupplierID"].Value?.ToString();
                    cboNhanHang.SelectedValue = dr.Cells["BrandID"].Value?.ToString();


                    //ma sp
                    masp = int.Parse(dr.Cells["ProductID"].Value.ToString().Trim());
                    
                    // Handle date conversion
                    if (DateTime.TryParse(dr.Cells["CreatedAt"].Value?.ToString(), out DateTime createdAt))
                    {
                        dateNgaySX.Value = createdAt;
                    }
                    else
                    {
                        dateNgaySX.Value = DateTime.Now; // Default date
                    }

                    // Handle numeric fields
                    txtGiaNhap.Text = dr.Cells["ImportPrice"].Value?.ToString() ?? "";
                    txtLoiNhuan.Text = dr.Cells["ProfitMargin"].Value?.ToString() ?? "";
                    txtGiaBan.Text = dr.Cells["Price"].Value?.ToString() ?? "";
                    txtSoLuong.Text = dr.Cells["StockQuantity"].Value?.ToString() ?? "";
                    txtKhuyenMai.Text = dr.Cells["Discount"].Value?.ToString() ?? "";

                    // Handle image
                    if (dr.Cells["ImageColumn"].Value is Image img)
                    {
                        picHinhAnh.Image = img;
                    }
                    else
                    {
                        picHinhAnh.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Tải dữ liệu cho ComboBox
        private void LoadComboBoxData()
        {
            cboLoai.DataSource = CategoryBL.GetInstance.GetDanhSachLoaiSanPham();
            cboLoai.ValueMember = "CategoryID";
            cboLoai.DisplayMember = "CategoryName";

            cboNCC.DataSource = SupplierBL.GetInstance.GetDanhSachNhaCungCap();
            cboNCC.ValueMember = "SupplierID";
            cboNCC.DisplayMember = "ContactName";

            cboNhanHang.DataSource = BrandDL.GetInstance.GetDanhSachNhanHang();
            cboNhanHang.ValueMember = "BrandID";
            cboNhanHang.DisplayMember = "BrandName";
        }


        //Làm mới
        private void LamMoi()
        {
            txtTen.Clear();
            txtSoLuong.Clear();
            txtKhuyenMai.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtGiaNhap.Clear();
            txtLoiNhuan.Clear();
            cboNhanHang.SelectedIndex = 0;
            if (cboLoai.Items.Count > 0)
                cboLoai.SelectedIndex = 0;
            if (cboNCC.Items.Count > 0)
                cboNCC.SelectedIndex = 0;
            dateNgaySX.Value = DateTime.Now;

            picHinhAnh.Image = null;
            ResetColorControls();
        }

        private void ResetColorControls()
        {
            foreach (Control ctrl in pnlThongTinSanPham.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (ctrl.BackColor == Color.OrangeRed)
                    {
                        ctrl.BackColor = Color.White;
                    }
                }
            }
            if (picHinhAnh.BackColor == Color.OrangeRed)
            {
                picHinhAnh.BackColor = Color.White;
            }
        }
        //Làm mới
        private void BtnLamMoiThongTin_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

  


        //btn xóa 
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (CheckControls())
            {
                if (SanPhamBL.GetInstance.NgungKinhDoanhSanPham(masp.ToString()))
                {
                    LamMoi();
                   // LoadDataGridViewTheoBoLoc();
                  
                    this.Alert("Đã ngừng kinh doanh...", Form_Notification.enmType.Success);
                }
            }
            else
            {
                Form_ThongBao frm = new Form_ThongBao();
                frm.lblThongBao.Text = "Bạn chưa chọn sản phẩm cần ngừng kinh doanh!";
                frm.ShowDialog();
            }
        }


        //Thong bao THANH CONG
        public void Alert(string msg, Form_Notification.enmType type)
        {
            Form_Notification frm = new Form_Notification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
         
        }


        private bool CheckControls()
        {
            int r = 0;
            foreach (Control ctrl in pnlThongTinSanPham.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (ctrl.Text == "" && ctrl.Name != "txtSoLuong" && ctrl.Name != "txtGiaBan")
                    {
                        ctrl.BackColor = Color.OrangeRed;
                        r = 1;
                    }
                }
            }
            if (picHinhAnh.Image == null)
            {
                r = 1;
                picHinhAnh.BackColor = Color.OrangeRed;
            }
            if (r == 0)
                return true;
            return false;
        }
        private void PicHinhAnh_Click(object sender, EventArgs e)
        {

        }
    }
}
