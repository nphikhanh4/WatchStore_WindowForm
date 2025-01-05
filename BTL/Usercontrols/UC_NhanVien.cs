using BLL;
using DAL;
using DONGHO.Forms;
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

        Form_ThongBao frm = new Form_ThongBao();
        //private readonly NhanvienBL employeeBLL;
        public UC_NhanVien()
        {
            InitializeComponent();
            LoadDanhSachNhanVien();
        }


        private void LoadDanhSachNhanVien()
        {
            try
            {
                if (dgvNhanVien.Columns.Count == 0)
                {
                    dgvNhanVien.Columns.Add("AdminID", "Mã NV");
                    dgvNhanVien.Columns.Add("ImgAdminPath", "Đường dẫn ảnh");
                    dgvNhanVien.Columns["ImgAdminPath"].Visible = false; // Ẩn cột này
                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                    {
                        Name = "ImageColumn",
                        HeaderText = "Image",
                        ImageLayout = DataGridViewImageCellLayout.Zoom
                    };
                    dgvNhanVien.Columns.Add(imgColumn);
                    dgvNhanVien.Columns.Add("Adminname", "Tên");
                    dgvNhanVien.Columns.Add("FullName", "Họ và Tên");
                    dgvNhanVien.Columns.Add("Email", "Email");
                    dgvNhanVien.Columns.Add("Password", "Mật Khẩu");
                    dgvNhanVien.Columns.Add("Phone", "SĐT");
                    dgvNhanVien.Columns.Add("Role", "Quyền");
                    dgvNhanVien.Columns.Add("CreatedAt", "Ngày Tạo TK");
                    dgvNhanVien.Columns.Add("Gender", "Giới Tính");
                }
                dgvNhanVien.Rows.Clear();

                DataTable dt = NhanvienBL.GetInstance.GetDanhSachNV();
                foreach (DataRow row in dt.Rows)
                {

                    int rowIndex = dgvNhanVien.Rows.Add();

                    dgvNhanVien.Rows[rowIndex].Cells["AdminID"].Value = row["AdminID"];
                    dgvNhanVien.Rows[rowIndex].Cells["Adminname"].Value = row["Adminname"];
                    dgvNhanVien.Rows[rowIndex].Cells["FullName"].Value = row["FullName"];
                    dgvNhanVien.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                    dgvNhanVien.Rows[rowIndex].Cells["Password"].Value = row["Password"];
                    dgvNhanVien.Rows[rowIndex].Cells["Phone"].Value = row["Phone"];
                    dgvNhanVien.Rows[rowIndex].Cells["Role"].Value = row["Role"];
                    dgvNhanVien.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                    dgvNhanVien.Rows[rowIndex].Cells["Gender"].Value = row["Gender"];

                    string imagePath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Resources\", row["ImgAdmin"].ToString());
                    dgvNhanVien.Rows[rowIndex].Cells["ImgAdminPath"].Value = imagePath; // Lưu đường dẫn vào cột ẩn

                    if (File.Exists(imagePath))
                    {
                        dgvNhanVien.Rows[rowIndex].Cells["ImageColumn"].Value = Image.FromFile(imagePath);

                    }
                    //else
                    //{
                    //    //dgvKhachHang.Rows[rowIndex].Cells["ImageColumn"].Value = null; // Set a default image
                    //    MessageBox.Show("Lỗi không xác định: " + imagePath);
                    //}

                }

            }



            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }

        }
        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Lấy CustomerId từ cột trong DataGridView
                adminid = Convert.ToInt32(dgvNhanVien.Rows[e.RowIndex].Cells["AdminId"].Value);
                frm.lblThongBao.Text = "Đã chọn Nhân Viên có ID: " + adminid;
                frm.ShowDialog();

                txtTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Adminname"].Value.ToString();
                txtPass.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                txtFullName.Text = dgvNhanVien.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtEmail.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = dgvNhanVien.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                cboLoai.SelectedItem = dgvNhanVien.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                cboGioiTinh.SelectedItem = dgvNhanVien.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                dateNgaySinh.Value = (DateTime)dgvNhanVien.Rows[e.RowIndex].Cells["CreatedAt"].Value;
                //Hiển thị thông báo(tùy chọn, kiểm tra đã chọn CustomerId chưa)
                string imagePath = dgvNhanVien.Rows[e.RowIndex].Cells["ImgAdminPath"].Value.ToString();
                if (File.Exists(imagePath))
                {
                    picHinhAnh.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Ảnh không tồn tại." + imagePath);
                    //picHinhAnh.Image = null; // Optional: Set to default image
                }

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
                frm.lblThongBao.Text = "Khong tim thay nhan vien ";
                frm.ShowDialog();
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTenNV.Text.Trim(); // Get the search text entered by the user

                if (string.IsNullOrEmpty(searchText))
                {
                    // If no search text is provided, load all customers
                    LoadDanhSachNhanVien();
                }
                else
                {
                    // Search for customers based on the search text
                    DataTable dt = NhanvienBL.GetInstance.SearchEmployees(searchText);

                    // Clear existing rows
                    dgvNhanVien.Rows.Clear();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            int rowIndex = dgvNhanVien.Rows.Add();

                            dgvNhanVien.Rows[rowIndex].Cells["AdminID"].Value = row["AdminID"];
                            dgvNhanVien.Rows[rowIndex].Cells["FullName"].Value = row["FullName"];
                            dgvNhanVien.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                            dgvNhanVien.Rows[rowIndex].Cells["Password"].Value = row["Password"];
                            dgvNhanVien.Rows[rowIndex].Cells["Phone"].Value = row["Phone"];
                            dgvNhanVien.Rows[rowIndex].Cells["Role"].Value = row["Role"];
                            dgvNhanVien.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                            dgvNhanVien.Rows[rowIndex].Cells["Gender"].Value = row["Gender"];

                            string imagePath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Resources\", row["ImgAdmin"].ToString());
                            dgvNhanVien.Rows[rowIndex].Cells["ImgAdminPath"].Value = imagePath; // Lưu đường dẫn vào cột ẩn

                            if (File.Exists(imagePath))
                            {
                                dgvNhanVien.Rows[rowIndex].Cells["ImageColumn"].Value = Image.FromFile(imagePath);
                            }
                        }
                    }
                    else
                    {
                        frm.lblThongBao.Text = "Khong tim thay nhan vien ";
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                MessageBox.Show("Error while searching for Admin: " + ex.Message);
            }
        }


        private void btnApDung_Click_1(object sender, EventArgs e)
        {


            try
            {
                string selectedRole = cboLocLoaiNhanVien.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(selectedRole))
                {
                    // If no role is selected, load all employees
                    LoadDanhSachNhanVien();
                }
                else
                {
                    // Filter data by the selected role
                    DataTable dt = NhanvienBL.GetInstance.FilterDataByComboBox(selectedRole);

                    // Clear existing rows
                    // Clear only the rows, not the columns
                    dgvNhanVien.Rows.Clear();
                    if (dt != null && dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            int rowIndex = dgvNhanVien.Rows.Add();

                            // Add data to each column
                            dgvNhanVien.Rows[rowIndex].Cells["AdminID"].Value = row["AdminID"];
                            dgvNhanVien.Rows[rowIndex].Cells["Adminname"].Value = row["Adminname"];
                            dgvNhanVien.Rows[rowIndex].Cells["FullName"].Value = row["FullName"];
                            dgvNhanVien.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                            dgvNhanVien.Rows[rowIndex].Cells["Password"].Value = row["Password"];
                            dgvNhanVien.Rows[rowIndex].Cells["Phone"].Value = row["Phone"];
                            dgvNhanVien.Rows[rowIndex].Cells["Role"].Value = row["Role"];
                            dgvNhanVien.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                            dgvNhanVien.Rows[rowIndex].Cells["Gender"].Value = row["Gender"];

                            // Handle image path
                            string imagePath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Resources\", row["ImgAdmin"].ToString());
                            dgvNhanVien.Rows[rowIndex].Cells["ImgAdminPath"].Value = imagePath; // Store image path in a hidden column

                            // Check if the image exists, then load it into the DataGridView
                            if (File.Exists(imagePath))
                            {
                                dgvNhanVien.Rows[rowIndex].Cells["ImageColumn"].Value = Image.FromFile(imagePath);
                            }
                            else
                            {
                                dgvNhanVien.Rows[rowIndex].Cells["ImageColumn"].Value = null; // If no image, set the cell value to null
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No employees found matching the search criteria.");
                    }
                }
            }
            catch (Exception ex)
            {
                frm.lblThongBao.Text = "Khong tim thay nhan vien ";
                frm.ShowDialog();
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
                    frm.lblThongBao.Text = "Nhập đầy đủ thông tin để thêm. ";
                    frm.ShowDialog();
                }
                string imageFileName = string.Empty;
                if (!string.IsNullOrEmpty(selectedImagePath)) // If a new image is selected
                {
                    string fileExtension = Path.GetExtension(selectedImagePath);
                    string newFileName = $"{Guid.NewGuid()}{fileExtension}";  // Create a unique name for the image
                    string targetPath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Resources\", newFileName);

                    if (!File.Exists(selectedImagePath))
                    {
                        MessageBox.Show("Source image does not exist: " + selectedImagePath);
                        return;
                    }

                    try
                    {
                        File.Copy(selectedImagePath, targetPath, true); // Copy the image to the target folder
                        imageFileName = newFileName; // Store the new image file name
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying image: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    // If no new image, set imageFileName to empty or use existing one if needed
                    imageFileName = string.Empty;
                }

                // Add new customer using Business Layer (BL)

                bool result = NhanvienBL.GetInstance.AddNewAdmin(
                   adminName, adminPassword, adminFullName, adminEmail, adminRole, adminPhone, adminGender, imageFileName);
                if (result)
                {
                    frm.lblThongBao.Text = "Admin added successfully. ";
                    frm.ShowDialog();
                    LamMoi(); // Clear fields
                    LoadDanhSachNhanVien(); // Reload customer data
                }
                else
                {
                    MessageBox.Show("");
                }
            }
            catch (Exception ex)
            {
                frm.lblThongBao.Text = "Nhập đầy đủ thông tin để thêm. ";
                frm.ShowDialog();
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
                    frm.lblThongBao.Text = "Vui long chon nhan vien delete: ";
                    frm.ShowDialog();
                }

                // Confirm deletion
                DialogResult dialogResult = MessageBox.Show("Ban chac chan muon delete?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = NhanvienBL.GetInstance.DeleteAdmin(adminid);
                    dgvNhanVien.Rows.Clear();
                    if (result)
                    {

                        frm.lblThongBao.Text = "Nhân viên mã số " + adminid + " đã bị sa thải";
                        frm.ShowDialog();
                        LamMoi(); // Clear fields
                        LoadDanhSachNhanVien(); // Reload customer data
                    }
                    else
                    {
                        frm.lblThongBao.Text = "Error deleting admin. ";
                        frm.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                frm.lblThongBao.Text = "Quyền hạn ko đủ để xóa.";
                frm.ShowDialog();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu chưa chọn nhân viên
                if (adminid == 0)
                {
                    frm.lblThongBao.Text = "Vui lòng chọn nhân viên để cập nhật.";
                    frm.ShowDialog();

                    return;
                }

                // Lấy dữ liệu từ các TextBox
                string adminName = txtTen.Text.Trim();
                string adminFullname = txtFullName.Text.Trim();
                string adminEmail = txtEmail.Text.Trim();
                string adminPhone = txtSoDienThoai.Text.Trim();
                string adminPassword = txtPass.Text.Trim();
                string adminRole = cboLoai.Text.Trim();
                string adminGender = cboGioiTinh.SelectedItem?.ToString();

                // Biến để lưu tên ảnh
                string imageFileName = string.Empty;
                if (!string.IsNullOrEmpty(selectedImagePath)) // Nếu có ảnh mới được chọn
                {
                    // Tạo tên ảnh mới để tránh trùng
                    string fileExtension = Path.GetExtension(selectedImagePath);
                    string newFileName = $"{Guid.NewGuid()}{fileExtension}";  // Tạo tên ảnh duy nhất sử dụng GUID
                    string targetPath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Resources\", newFileName);

                    // Kiểm tra xem ảnh có tồn tại tại nguồn không
                    if (!File.Exists(selectedImagePath))
                    {
                        MessageBox.Show("Ảnh nguồn không tồn tại: " + selectedImagePath);
                        return;
                    }

                    // Thử sao chép ảnh vào thư mục đích
                    try
                    {
                        File.Copy(selectedImagePath, targetPath, true); // Ghi đè nếu ảnh đã tồn tại
                        imageFileName = newFileName; // Lưu tên ảnh mới
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi sao chép ảnh: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    // Nếu không có ảnh mới, giữ nguyên ảnh cũ
                    DataGridViewRow selectedRow = dgvNhanVien.CurrentRow;
                    if (selectedRow != null)
                    {
                        imageFileName = selectedRow.Cells["ImgAdminPath"].Value.ToString();
                    }
                    else
                    {
                        frm.lblThongBao.Text="Không thể lấy ảnh cũ.";
                        frm.ShowDialog();
                        return;
                    }
                }
                // Cập nhật thông tin nhân viên
                bool result = NhanvienBL.GetInstance.UpdateAdmin(
                    adminid,
                    string.IsNullOrEmpty(adminName) ? null : adminName, // Cập nhật tên nếu có thay đổi
                    string.IsNullOrEmpty(adminPassword) ? null : adminPassword, // Cập nhật mật khẩu nếu có thay đổi
                    string.IsNullOrEmpty(adminFullname) ? null : adminFullname,
                    string.IsNullOrEmpty(adminEmail) ? null : adminEmail, // Cập nhật email nếu có thay đổi
                    string.IsNullOrEmpty(adminRole) ? null : adminRole, // Cập nhật vai trò nếu có thay đổi
                    string.IsNullOrEmpty(adminPhone) ? null : adminPhone, // Cập nhật số điện thoại nếu có thay đổi
                    string.IsNullOrEmpty(adminGender) ? null : adminGender, // Cập nhật giới tính nếu có thay đổi
                    imageFileName // Cập nhật ảnh nếu có
                );

                if (result)
                {
                    frm.lblThongBao.Text = "Cập nhật thông tin nhân viên thành công.";
                    frm.ShowDialog();

                    LoadDanhSachNhanVien(); // Tải lại dữ liệu sau khi cập nhật
                }
                else
                {
                    frm.lblThongBao.Text = "Lỗi khi cập nhật thông tin nhân viên: ";
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                frm.lblThongBao.Text = "Lỗi khi cập nhật thông tin nhân viên: ";
                frm.ShowDialog();
            }
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            LoadDanhSachNhanVien();
        }


    }
}