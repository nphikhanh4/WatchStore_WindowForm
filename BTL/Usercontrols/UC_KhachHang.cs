using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DONGHO.Usercontrols
{
    public partial class UC_KhachHang : UserControl
    {
        private int customerid = 0;
        private string selectedImagePath = string.Empty;
        public UC_KhachHang()
        {
            InitializeComponent();
            LoadDataGridView();
            LoadDanhSachKhachHang();
        }


        private void LoadDataGridView()
        {
            try
            {

                DataTable dt = KhachHangBL.GetInstance.GetDanhSachKH();
                dgvKhachHang.DataSource = dt;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }
        }

        private void LoadDanhSachKhachHang()
        {
            try
            {
                DataTable dt = KhachHangBL.GetInstance.GetDanhSachKH();
                dgvKhachHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{


        //}
        private void LamMoi()
        {
            txtTen.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            txtSoDienThoai.Clear();
            cboGioiTinh.SelectedIndex = 0;
            txtDiaChi.Clear();
            dateNgayDangKy.Value = DateTime.Now;
            picHinhAnh.Image = null;
            txtTenKH.Clear();
            ResetColorControls();
        }
        private void ResetColorControls()
        {
            foreach (Control ctrl in pnlThongTinKhachHang.Controls)
            {
                if (ctrl is TextBox)
                {
                    if (ctrl.BackColor == Color.OrangeRed)
                    {
                        ctrl.BackColor = Color.White;
                    }
                }
            }
        }


        private void btnXoa_Click_1(object sender, EventArgs e)

        {
            try
            {
                if (customerid == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
                    return;
                }

                // Giả sử bạn có một cột AdminID trong DataGridView để chọn nhân viên cần xóa
                if (dgvKhachHang.SelectedRows.Count > 0)
                {
                    int selectedCustomerId = Convert.ToInt32(dgvKhachHang.SelectedRows[0].Cells["CustomerID"].Value);

                    // Gọi BLL để xóa nhân viên
                    bool success = KhachHangBL.GetInstance.DeleteCustomer(selectedCustomerId);

                    if (success)
                    {
                        MessageBox.Show("Xóa khách hàng thành công.");
                        LamMoi();
                        LoadDanhSachKhachHang(); // Tải lại danh sách sau khi xóa thành công
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để xóa.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
            }
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu chưa chọn nhân viên
                if (customerid == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để cập nhật.");
                    return;
                }

                // Lấy dữ liệu từ các TextBox
                string customerName = txtTen.Text;
                string customerEmail = txtEmail.Text;
                string customerPhone = txtSoDienThoai.Text;
                string customerPassword = txtPass.Text;
                string customerAddress = txtDiaChi.Text;
                string customerGender = cboGioiTinh.SelectedItem.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerEmail) ||
                   string.IsNullOrEmpty(customerPhone) || string.IsNullOrEmpty(customerPassword) ||
                   string.IsNullOrEmpty(customerAddress) || string.IsNullOrEmpty(customerGender))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin.");
                    return;
                }
                if (string.IsNullOrEmpty(selectedImagePath))
                {
                    MessageBox.Show("Vui lòng chọn ảnh khách hàng.");
                    return;
                }
                string imageFileName = Path.GetFileName(selectedImagePath);

                string targetPath = Path.Combine(@"D:\WINFORM - master\WINFORM - master\vidu\Resources\", imageFileName); // Đường dẫn tới thư mục lưu ảnh
                File.Copy(selectedImagePath, targetPath, true); // Sao chép ảnh vào thư mục

                // Câu lệnh SQL để cập nhật thông tin nhân viên


                bool result = KhachHangBL.GetInstance.UpdateKhachHang(
               customerid, customerName, customerEmail, customerPhone, customerPassword, customerAddress, customerGender, imageFileName);
                //LamMoi();
                if (result)
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên thành công.");
                    LoadDanhSachKhachHang();  // Tải lại dữ liệu sau khi cập nhật
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin nhân viên.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thông tin nhân viên: " + ex.Message);
            }
        }

        private void btnLamMoiThongTin_Click_1(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSachKhachHang();

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                string customerName = txtTen.Text;
                string customerEmail = txtEmail.Text;
                string customerPhone = txtSoDienThoai.Text;
                string customerPassword = txtPass.Text;
                string customerAddress = txtDiaChi.Text;
                string customerGender = cboGioiTinh.SelectedItem.ToString();

                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerEmail) ||
                    string.IsNullOrEmpty(customerPhone) || string.IsNullOrEmpty(customerPassword) ||
                    string.IsNullOrEmpty(customerAddress) || string.IsNullOrEmpty(customerGender))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin.");
                    return;
                }
                if (string.IsNullOrEmpty(selectedImagePath))
                {
                    MessageBox.Show("Vui lòng chọn ảnh khách hàng.");
                    return;
                }
                string imageFileName = Path.GetFileName(selectedImagePath);
                string targetPath = Path.Combine(@"C:\Users\LENOVO\source\repos\BTLWinForm\BTLWinForm\Content\Resources\", imageFileName); // Đường dẫn tới thư mục lưu ảnh
                File.Copy(selectedImagePath, targetPath, true); // Sao chép ảnh vào thư mục
                bool result = KhachHangBL.GetInstance.AddNewCustomer(
                   customerName, customerEmail, customerPhone, customerPassword, customerAddress, customerGender, imageFileName);
                //LamMoi();
                if (result)
                {
                    MessageBox.Show("Thêm khách hàng thành công.");
                    LamMoi();
                    LoadDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm khách hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSachKhachHang();

        }

        private void dgvKhachHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)

            {
                // Lấy CustomerId từ cột trong DataGridView
                customerid = Convert.ToInt32(dgvKhachHang.Rows[e.RowIndex].Cells["CustomerID"].Value);
                MessageBox.Show("Đã chọn Nhân Viên có ID: " + customerid);
                txtTen.Text = dgvKhachHang.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtPass.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                txtEmail.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                cboGioiTinh.SelectedItem = dgvKhachHang.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                string imagePath = dgvKhachHang.Rows[e.RowIndex].Cells["ImgCustomer"].Value.ToString();
                string imageFilePath = @"C:\Users\LENOVO\source\repos\BTLWinForm\BTLWinForm\Content\Resources\" + imagePath;




                if (File.Exists(imageFilePath))
                {
                    picHinhAnh.Image = Image.FromFile(imageFilePath);  // Gán ảnh vào PictureBox
                }
                else
                {
                    MessageBox.Show("Ảnh không tồn tại.");
                }
            }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Hạn chế loại file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu đường dẫn ảnh vào biến selectedImagePath
                selectedImagePath = openFileDialog.FileName;

                // Hiển thị ảnh lên PictureBox (tùy chọn)
                picHinhAnh.Image = Image.FromFile(selectedImagePath);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTenKH.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    // Gọi hàm tìm kiếm với tên người dùng nhập
                    LoadDanhSachKhachHang();


                }
                else
                {
                    DataTable dt = KhachHangBL.GetInstance.SearchCustomer(searchText);
                    dgvKhachHang.DataSource = dt;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Hạn chế loại file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu đường dẫn ảnh vào biến selectedImagePath
                selectedImagePath = openFileDialog.FileName;

                // Hiển thị ảnh lên PictureBox (tùy chọn)
                picHinhAnh.Image = Image.FromFile(selectedImagePath);
            }
        }
    }
}
