using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DONGHO.Usercontrols
{
    public partial class UC_NhanVien : UserControl
    {
        private int adminid = 0;
        private string selectedImagePath = string.Empty;
        //private readonly NhanvienBL employeeBLL;
        public UC_NhanVien()
        {
            InitializeComponent();

            LoadDataGridView();
            LoadDanhSachNhanVien();
        }


        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy CustomerId từ cột trong DataGridView
                adminid = Convert.ToInt32(dgvNhanVien.Rows[e.RowIndex].Cells["AdminId"].Value);
                MessageBox.Show("Đã chọn Nhân Viên có ID: " + adminid);
                txtTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Adminname"].Value.ToString();
                txtPass.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                txtFullName.Text = dgvNhanVien.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtEmail.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                cboLoai.SelectedItem = dgvNhanVien.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                cboGioiTinh.SelectedItem = dgvNhanVien.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                //Hiển thị thông báo(tùy chọn, kiểm tra đã chọn CustomerId chưa)
                string imagePath = dgvNhanVien.Rows[e.RowIndex].Cells["ImgAdmin"].Value.ToString();  // Giả sử ImgAdmin chứa tên tệp ảnh
                                                                                                     //string imageFilePath = Path.Combine(Application.StartupPath, "Content", "Resources", imagePath); // Đường dẫn tới ảnh
                string imageFilePath = @"D:\BTL_W\BTL_W\BTL\Resources\" + imagePath;
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

        private void LoadDataGridView()
        {
            try
            {

                DataTable dt = NhanvienBL.GetInstance.GetDanhSachNV();
                dgvNhanVien.DataSource = dt;
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvNhanVien.AllowUserToResizeColumns = true;
                dgvNhanVien.ScrollBars = ScrollBars.Both;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                DataTable dt = NhanvienBL.GetInstance.GetDanhSachNV();
                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message);
            }

        }

        private void UC_NhanVien_Load(object sender, EventArgs e)
        {
            List<string> roles = new List<string> { "Quản lý", "Quản trị viên" };
            cboLocLoaiNhanVien.Items.AddRange(roles.ToArray());
            cboLocLoaiNhanVien.SelectedIndex = 0;
            LoadDanhSachNhanVien();
        }
        private void cboLocLoaiNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedRole = cboLocLoaiNhanVien.SelectedItem.ToString();
                DataTable dt = NhanvienBL.GetInstance.FilterDataByComboBox(selectedRole);
                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc nhân viên: " + ex.Message);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

            try
            {
                string searchText = txtTenNV.Text.Trim();
                if (string.IsNullOrEmpty(searchText))
                {
                    // Gọi hàm tìm kiếm với tên người dùng nhập
                    LoadDanhSachNhanVien();
                }
                else
                {
                    DataTable dt = NhanvienBL.GetInstance.SearchEmployees(searchText);
                    dgvNhanVien.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }

        }


        private void btnApDung_Click_1(object sender, EventArgs e)
        {

            try
            {
                string selectedRole = cboLocLoaiNhanVien.SelectedItem.ToString();
                DataTable dt = NhanvienBL.GetInstance.FilterDataByComboBox(selectedRole);
                dgvNhanVien.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi áp dụng lọc nhân viên: " + ex.Message);
            }
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string adminName = txtTen.Text;
                string adminPassword = txtPass.Text;
                string adminFullName = txtFullName.Text;
                string adminEmail = txtEmail.Text;
                string adminRole = cboLoai.SelectedItem.ToString();
                string adminPhone = txtSoDienThoai.Text;
                string adminGender = cboGioiTinh.SelectedItem.ToString();
                //string imageFileName = selectedImagePath != null ? System.IO.Path.GetFileName(selectedImagePath) : null;

                if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword) ||
                    string.IsNullOrEmpty(adminFullName) || string.IsNullOrEmpty(adminEmail) ||
                    string.IsNullOrEmpty(adminRole) || string.IsNullOrEmpty(adminPhone) ||
                    string.IsNullOrEmpty(adminGender))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
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


                bool result = NhanvienBL.GetInstance.AddNewAdmin(
                    adminName, adminPassword, adminFullName, adminEmail, adminRole, adminPhone, adminGender, imageFileName);

                if (result)
                {
                    MessageBox.Show("Thêm nhân viên thành công.");
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm nhân viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        private void LamMoi()
        {
            txtTen.Clear();
            txtEmail.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtSoDienThoai.Clear();
            cboGioiTinh.SelectedIndex = 0;
            cboLoai.SelectedIndex = 0;
            dateNgaySinh.Value = DateTime.Now;
            picHinhAnh.Image = null;
            txtTenNV.Clear();
            ResetColorControls();
        }

        private void ResetColorControls()
        {
            foreach (Control ctrl in pnlThongTinNhanVien.Controls)
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

        private void btnLamMoiThongTin_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSachNhanVien();
        }

        private void btnSaThai_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminid == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
                    return;
                }

                // Giả sử bạn có một cột AdminID trong DataGridView để chọn nhân viên cần xóa
                if (dgvNhanVien.SelectedRows.Count > 0)
                {
                    int selectedAdminId = Convert.ToInt32(dgvNhanVien.SelectedRows[0].Cells["AdminID"].Value);

                    // Gọi BLL để xóa nhân viên
                    bool success = NhanvienBL.GetInstance.DeleteAdmin(selectedAdminId);

                    if (success)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.");
                        LamMoi();
                        LoadDanhSachNhanVien(); // Tải lại danh sách sau khi xóa thành công
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {


            try
            {
                if (adminid == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên để cập nhật.");
                    return;
                }
                string adminName = txtTen.Text;
                string adminPassword = txtPass.Text;
                string adminFullName = txtFullName.Text;
                string adminEmail = txtEmail.Text;
                string adminRole = cboLoai.SelectedItem.ToString();
                string adminPhone = txtSoDienThoai.Text;
                string adminGender = cboGioiTinh.SelectedItem.ToString();
                //string imageFileName = selectedImagePath != null ? System.IO.Path.GetFileName(selectedImagePath) : null;

                if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword) ||
                    string.IsNullOrEmpty(adminFullName) || string.IsNullOrEmpty(adminEmail) ||
                    string.IsNullOrEmpty(adminRole) || string.IsNullOrEmpty(adminPhone) ||
                    string.IsNullOrEmpty(adminGender))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
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


                bool result = NhanvienBL.GetInstance.UpdateAdmin(adminid, adminName, adminPassword,
                                                                   adminFullName, adminEmail, adminRole, adminPhone,
                                                                   adminGender, imageFileName);
                if (result)
                {
                    MessageBox.Show("Update nhân viên thành công.");
                    LoadDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Lỗi khi update nhân viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi update nhân viên: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSachNhanVien();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
