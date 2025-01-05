using BLL;
using DAL;
using DONGHO.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
using static System.Reflection.Metadata.BlobBuilder;
using SystemImage = System.Drawing.Image;
using SystemFont = System.Drawing.Font;

namespace DONGHO.Usercontrols
{
    public partial class UC_KhachHang : UserControl
    {
        private int customerid = 0;
        private string selectedImagePath = string.Empty;
        Form_ThongBao frm = new Form_ThongBao();

        public UC_KhachHang()
        {
            InitializeComponent();
            //LoadDataGridView();
            LoadDanhSachKhachHang();
        }


        private void LoadDanhSachKhachHang()
        {

            try
            {
                if (dgvKhachHang.Columns.Count == 0)
                {
                    dgvKhachHang.Columns.Add("CustomerID", "Mã KH");
                    dgvKhachHang.Columns.Add("ImgCustomerPath", "Đường dẫn ảnh");
                    dgvKhachHang.Columns["ImgCustomerPath"].Visible = false; // Ẩn cột này
                    DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                    {
                        Name = "ImageColumn",
                        HeaderText = "Image",
                        ImageLayout = DataGridViewImageCellLayout.Zoom
                    };
                    dgvKhachHang.Columns.Add(imgColumn);
                    dgvKhachHang.Columns.Add("FullName", "Họ và Tên");
                    dgvKhachHang.Columns.Add("Email", "Email");
                    dgvKhachHang.Columns.Add("Password", "Mật Khẩu");
                    dgvKhachHang.Columns.Add("Phone", "SĐT");
                    dgvKhachHang.Columns.Add("Address", "Địa Chỉ");
                    dgvKhachHang.Columns.Add("CreatedAt", "Ngày Tạo TK");
                    dgvKhachHang.Columns.Add("Gender", "Giới Tính");

                }
                dgvKhachHang.Rows.Clear();
                DataTable dt = KhachHangBL.GetInstance.GetDanhSachKH();
                foreach (DataRow row in dt.Rows)
                {

                    int rowIndex = dgvKhachHang.Rows.Add();

                    dgvKhachHang.Rows[rowIndex].Cells["CustomerID"].Value = row["CustomerID"];
                    dgvKhachHang.Rows[rowIndex].Cells["FullName"].Value = row["FullName"];
                    dgvKhachHang.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                    dgvKhachHang.Rows[rowIndex].Cells["Password"].Value = row["Password"];
                    dgvKhachHang.Rows[rowIndex].Cells["Phone"].Value = row["Phone"];
                    dgvKhachHang.Rows[rowIndex].Cells["Address"].Value = row["Address"];
                    dgvKhachHang.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                    dgvKhachHang.Rows[rowIndex].Cells["Gender"].Value = row["Gender"];

                    string imagePath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Resources\", row["ImgCustomer"].ToString());
                    dgvKhachHang.Rows[rowIndex].Cells["ImgCustomerPath"].Value = imagePath; // Lưu đường dẫn vào cột ẩn

                    if (File.Exists(imagePath))
                    {
                        dgvKhachHang.Rows[rowIndex].Cells["ImageColumn"].Value = SystemImage.FromFile(imagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
            }
        }

        private void LamMoi()
        {
            txtTen.Clear();
            txtEmail.Clear();
            txtPass.Clear();
            txtSoDienThoai.Clear();
            cboGioiTinh.SelectedIndex = -1;
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
                    MessageBox.Show("Please select a customer to delete.");
                    return;
                }

                // Confirm deletion
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = KhachHangBL.GetInstance.DeleteCustomer(customerid);
                    dgvKhachHang.Rows.Clear();
                    if (result)
                    {
                        frm.lblThongBao.Text = "Khách hàng xóa thành công.";
                        frm.ShowDialog();

                        LamMoi(); // Clear fields
                        LoadDanhSachKhachHang(); // Reload customer data
                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                string customerName = txtTen.Text.Trim();
                string customerEmail = txtEmail.Text.Trim();
                string customerPhone = txtSoDienThoai.Text.Trim();
                string customerPassword = txtPass.Text.Trim();
                string customerAddress = txtDiaChi.Text.Trim();
                string customerGender = cboGioiTinh.SelectedItem?.ToString();

                // Xử lý ảnh
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
                    DataGridViewRow selectedRow = dgvKhachHang.CurrentRow;
                    if (selectedRow != null)
                    {
                        imageFileName = selectedRow.Cells["ImgCustomerPath"].Value.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy ảnh cũ.");
                        return;
                    }
                }

                // Cập nhật thông tin khách hàng - chỉ cập nhật những trường đã thay đổi
                bool result = KhachHangBL.GetInstance.UpdateKhachHang(
                    customerid,
                    string.IsNullOrEmpty(customerName) ? null : customerName, // Cập nhật tên nếu có thay đổi
                    string.IsNullOrEmpty(customerEmail) ? null : customerEmail, // Cập nhật email nếu có thay đổi
                    string.IsNullOrEmpty(customerPhone) ? null : customerPhone, // Cập nhật số điện thoại nếu có thay đổi
                    string.IsNullOrEmpty(customerPassword) ? null : customerPassword, // Cập nhật mật khẩu nếu có thay đổi
                    string.IsNullOrEmpty(customerAddress) ? null : customerAddress, // Cập nhật địa chỉ nếu có thay đổi
                    string.IsNullOrEmpty(customerGender) ? null : customerGender, // Cập nhật giới tính nếu có thay đổi
                    imageFileName // Cập nhật ảnh nếu có thay đổi
                );
                dgvKhachHang.Rows.Clear();
                if (result)
                {


                    frm.lblThongBao.Text = "Cập nhật thông tin khách hàng thành công";
                    frm.ShowDialog();
                    LoadDanhSachKhachHang(); // Tải lại dữ liệu sau khi cập nhật
                }
                else
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin khách hàng.");
                }
            }
            catch (Exception ex)
            {

                frm.lblThongBao.Text = "Cần thay đổi thông tin mới để cập nhật";
                frm.ShowDialog();

            }
        }


        private void btnLamMoiThongTin_Click_1(object sender, EventArgs e)
        {

            LamMoi();
            dgvKhachHang.Rows.Clear();
            LoadDanhSachKhachHang();

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string customerName = txtTen.Text.Trim();
                string customerEmail = txtEmail.Text.Trim();
                string customerPhone = txtSoDienThoai.Text.Trim();
                string customerPassword = txtPass.Text.Trim();
                string customerAddress = txtDiaChi.Text.Trim();
                string customerGender = cboGioiTinh.SelectedItem?.ToString();

                // Handle image path
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
                bool result = KhachHangBL.GetInstance.AddNewCustomer(customerName, customerEmail, customerPhone, customerPassword, customerAddress, customerGender, imageFileName);

                if (result)
                {
                    frm.lblThongBao.Text = "Customer added successfully. ";
                    frm.ShowDialog();
                    LamMoi(); // Clear fields
                    LoadDanhSachKhachHang(); // Reload customer data
                }
                else
                {
                    MessageBox.Show("Error adding customer.");
                }
            }
            catch (Exception ex)
            {

                frm.lblThongBao.Text = "Cần điền đầy đủ thông tin để thêm";
                frm.ShowDialog();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
            dgvKhachHang.Rows.Clear();
            LoadDanhSachKhachHang();

        }

        private void dgvKhachHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Retrieve customer data from the selected row
                customerid = Convert.ToInt32(dgvKhachHang.Rows[e.RowIndex].Cells["CustomerID"].Value);
                frm.lblThongBao.Text = "Đã chọn khách hàng có ID: " + customerid;
                frm.ShowDialog();

                txtTen.Text = dgvKhachHang.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtPass.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                txtEmail.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtSoDienThoai.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                cboGioiTinh.SelectedItem = dgvKhachHang.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                dateNgayDangKy.Value = (DateTime)dgvKhachHang.Rows[e.RowIndex].Cells["CreatedAt"].Value;


                // Handle image loading
                string imagePath = dgvKhachHang.Rows[e.RowIndex].Cells["ImgCustomerPath"].Value.ToString();
                if (File.Exists(imagePath))
                {
                    picHinhAnh.Image = SystemImage.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Ảnh không tồn tại." + imagePath);
                    //picHinhAnh.Image = null; // Optional: Set to default image
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
                picHinhAnh.Image = SystemImage.FromFile(selectedImagePath);
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
                picHinhAnh.Image = SystemImage.FromFile(selectedImagePath);
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTenKH.Text.Trim(); // Get the search text entered by the user

                if (string.IsNullOrEmpty(searchText))
                {
                    // If no search text is provided, load all customers
                    LoadDanhSachKhachHang();
                }
                else
                {
                    // Search for customers based on the search text
                    DataTable dt = KhachHangBL.GetInstance.SearchCustomer(searchText);

                    // Clear existing rows
                    dgvKhachHang.Rows.Clear();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            int rowIndex = dgvKhachHang.Rows.Add();

                            dgvKhachHang.Rows[rowIndex].Cells["CustomerID"].Value = row["CustomerID"];
                            dgvKhachHang.Rows[rowIndex].Cells["FullName"].Value = row["FullName"];
                            dgvKhachHang.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                            dgvKhachHang.Rows[rowIndex].Cells["Password"].Value = row["Password"];
                            dgvKhachHang.Rows[rowIndex].Cells["Phone"].Value = row["Phone"];
                            dgvKhachHang.Rows[rowIndex].Cells["Address"].Value = row["Address"];
                            dgvKhachHang.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                            dgvKhachHang.Rows[rowIndex].Cells["Gender"].Value = row["Gender"];

                            string imagePath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Resources\", row["ImgCustomer"].ToString());
                            dgvKhachHang.Rows[rowIndex].Cells["ImgCustomerPath"].Value = imagePath; // Lưu đường dẫn vào cột ẩn

                            if (File.Exists(imagePath))
                            {
                                dgvKhachHang.Rows[rowIndex].Cells["ImageColumn"].Value = SystemImage.FromFile(imagePath);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No customers found matching the search criteria.");
                    }
                }
            }
            catch (Exception ex)
            {

                frm.lblThongBao.Text = "Không tìm thấy khách hàng";
                frm.ShowDialog();
            }
        }
        private void inDSKH()
        {
            try
            {
                // Đăng ký mã hóa
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                // Tạo tài liệu PDF
                iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f);
                string outputPath = "D:/DanhSachKhachHang..pdf";
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));
                document.Open();

                // Font chữ
                string fontPath = @"C:\Windows\Fonts\tahoma.ttf";
                if (!File.Exists(fontPath))
                {
                    MessageBox.Show("Font chữ không tồn tại. Kiểm tra đường dẫn font.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(baseFont, 12);
                iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 20, iTextSharp.text.Font.BOLD);

                // Tiêu đề
                iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph("DANH SÁCH KHÁCH HÀNG", headerFont);
                header.Alignment = Element.ALIGN_CENTER;
                document.Add(header);

                // Đường kẻ ngang
                iTextSharp.text.Paragraph dashedLine = new iTextSharp.text.Paragraph("-------------------------------------------", vietnameseFont);
                dashedLine.Alignment = Element.ALIGN_CENTER;
                document.Add(dashedLine);

                // Ngày lập
                iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph($"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}", vietnameseFont);
                date.Alignment = Element.ALIGN_RIGHT;
                document.Add(date);
                document.Add(new iTextSharp.text.Paragraph("\n"));

                // Thông tin cửa hàng
                document.Add(new iTextSharp.text.Paragraph("Cửa hàng: Watch Store", vietnameseFont));
                document.Add(new iTextSharp.text.Paragraph("Địa chỉ: 450-451 Lê Văn Việt, Phường Tăng Nhơn Phú A, Hồ Chí Minh, Việt Nam", vietnameseFont));
                document.Add(new iTextSharp.text.Paragraph("Nhân viên: Nguyễn Văn A", vietnameseFont));
                document.Add(dashedLine);

                // Bảng thông tin khách hàng
                iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(4);
                table.WidthPercentage = 100;

                float[] columnWidths = new float[] { 7f, 30f, 30f, 30f };
                table.SetWidths(columnWidths);

                // Thêm dữ liệu vào bảng
                table.AddCell(new iTextSharp.text.Phrase("STT", vietnameseFont));
                table.AddCell(new iTextSharp.text.Phrase("Tên khách hàng", vietnameseFont));
                table.AddCell(new iTextSharp.text.Phrase("Email", vietnameseFont));
                table.AddCell(new iTextSharp.text.Phrase("Phone", vietnameseFont));

                // Lấy danh sách khách hàng
                DataTable pd = KhachHangBL.GetInstance.GetDanhSachKH();
                if (pd == null || pd.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu khách hàng để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Duyệt qua danh sách khách hàng
                int i = 1;
                foreach (DataRow row in pd.Rows)
                {
                    table.AddCell(new iTextSharp.text.Phrase(i.ToString(), vietnameseFont));
                    table.AddCell(new iTextSharp.text.Phrase(row["FullName"]?.ToString() ?? "N/A", vietnameseFont));
                    table.AddCell(new iTextSharp.text.Phrase(row["Email"]?.ToString() ?? "N/A", vietnameseFont));
                    table.AddCell(new iTextSharp.text.Phrase(row["Phone"]?.ToString() ?? "N/A", vietnameseFont));
                    i++;
                }

                // Thêm bảng vào tài liệu
                document.Add(table);
                document.Add(new iTextSharp.text.Paragraph("\n"));
                document.Add(dashedLine);

                // Lời cảm ơn
                iTextSharp.text.Font thankFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.ITALIC);
                iTextSharp.text.Paragraph thank = new iTextSharp.text.Paragraph($"Cảm ơn quý khách đã mua hàng ở Watch Store\nChúc quý khách một ngày tốt lành!", thankFont);
                thank.Alignment = Element.ALIGN_CENTER;
                document.Add(thank);

                // Đóng tài liệu
                document.Close();
                MessageBox.Show("Danh sách khách hàng đã được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở file PDF
                try
                {
                    var processInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = outputPath, // Đường dẫn file
                        UseShellExecute = true // Mở bằng ứng dụng mặc định
                    };
                    System.Diagnostics.Process.Start(processInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể mở file PDF. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tạo danh sách khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inDSKH();
        }
    }
}