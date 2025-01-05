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
    using DTO;
    using DONGHO.Forms;
    using System.Linq.Expressions;


    namespace DONGHO.Usercontrols
    {
        public partial class uc_SanPham : UserControl
        {
            public uc_SanPham()
            {
                InitializeComponent();

            }
            private void Uc_SanPham_Load(object sender, EventArgs e)
            {
                LoadDataGridView();
                LoadComboBoxData();
                LoadCboLocNCC();
                LoadCboLocLoaiSP();
            }

            //Bo loc tim kiem
            private void LoadCboLocNCC()
            {
                DataTable dt = SupplierBL.GetInstance.GetDanhSachNhaCungCap();

                // Kiểm tra null hoặc cột
                if (dt == null || !dt.Columns.Contains("SupplierID") || !dt.Columns.Contains("ContactName"))
                {
                    MessageBox.Show("Dữ liệu không hợp lệ hoặc không tải được danh sách nhà cung cấp!");
                    return;
                }

                // Thêm hàng "Tất cả"
                DataRow dr = dt.NewRow();
                dr["SupplierID"] = "-1"; // Không cần dấu ngoặc vuông
                dr["ContactName"] = "Tất cả"; // Không cần dấu ngoặc vuông
                dt.Rows.Add(dr);

                // Thiết lập DataSource cho ComboBox
                cboLocNCC.DataSource = dt;
                cboLocNCC.DisplayMember = "ContactName"; // Không có dấu ngoặc vuông
                cboLocNCC.ValueMember = "SupplierID";   // Không có dấu ngoặc vuông
                cboLocNCC.SelectedIndex = cboLocNCC.Items.Count - 1; // Chọn phần tử cuối cùng
            }

            private void LoadCboLocLoaiSP()
            {
                DataTable dt = CategoryBL.GetInstance.GetDanhSachLoaiSanPham();

                // Kiểm tra nếu DataTable null hoặc không hợp lệ
                if (dt == null || !dt.Columns.Contains("CategoryID") || !dt.Columns.Contains("CategoryName"))
                {
                    MessageBox.Show("Không thể tải danh sách loại sản phẩm. Dữ liệu không hợp lệ!");
                    return;
                }

                // Thêm dòng "Tất cả" vào DataTable
                DataRow dr = dt.NewRow();
                dr["CategoryID"] = "-1";  // ID mặc định cho "Tất cả"
                dr["CategoryName"] = "Tất cả";  // Tên hiển thị cho "Tất cả"
                dt.Rows.Add(dr);

                // Gán dữ liệu vào ComboBox
                cboLocLoaiSP.DataSource = dt;
                cboLocLoaiSP.DisplayMember = "CategoryName"; // Tên cột hiển thị
                cboLocLoaiSP.ValueMember = "CategoryID";     // Tên cột giá trị
                cboLocLoaiSP.SelectedIndex = cboLocLoaiSP.Items.Count - 1; // Chọn phần tử cuối
            }

            //tai du lieu loc
            private void LoadDataGridViewTheoBoLoc()
            {
                dgvSanPham.DataSource = SanPhamBL.GetInstance.GetDanhSachSanPhamTheoBoLoc(txtTenSP.Text.Trim(), cboLocLoaiSP.SelectedValue.ToString().Trim(), cboLocNCC.SelectedValue.ToString().Trim());
                dgvSanPham.ClearSelection();
            }

            private void LoadDataGridView()
            {
                try
                {
                    // Lấy dữ liệu từ tầng Business Logic
                    DataTable dt = SanPhamBL.GetInstance.GetDanhSachSanPhamTheoBoLoc(
                        txtTenSP.Text.Trim(),
                        cboLocLoaiSP.SelectedValue?.ToString()?.Trim(),
                        cboLocNCC.SelectedValue?.ToString()?.Trim()
                    );



                    // Xóa cột cũ trước khi thêm dữ liệu
                    dgvSanPham.Columns.Clear();
                    ResetColorControls();
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
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
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
                        try
                        {
                            // Load the image in a way that doesn't overload memory
                            using (Image image = Image.FromFile(imagePath))
                            {
                                dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = new Bitmap(image);  // Create a bitmap to avoid holding a reference to the original image
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exceptions, e.g., file not found or format issue
                            dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = null; // Set a default image
                            Console.WriteLine("Error loading image: " + ex.Message);
                        }
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







            //  Tai danh sach du lieu
            //private void LoadDataGridView()
            //{
            //    try
            //    {
            //        DataTable dt = SanPhamBL.GetInstance.GetDanhSachSanPham();



            //        // Xóa cột cũ trước khi thêm dữ liệu
            //        dgvSanPham.Columns.Clear();
            //        ResetColorControls();
            //        // Tạo cột hiển thị dữ liệu
            //        dgvSanPham.Columns.Add("ProductID", "Mã SP");
            //        dgvSanPham.Columns.Add("ProductName", "Tên SP");
            //        dgvSanPham.Columns.Add("Price", "Giá bán");
            //        dgvSanPham.Columns.Add("StockQuantity", "Số lượng");
            //        dgvSanPham.Columns.Add("CategoryID", "Mã loại SP");
            //        dgvSanPham.Columns.Add("SupplierID", "Mã NCC SP");
            //        dgvSanPham.Columns.Add("BrandID", "Mã nhãn hàng SP");
            //        dgvSanPham.Columns.Add("CreatedAt", "Ngày sản xuất");
            //        dgvSanPham.Columns.Add("Discount", "Giảm giá");
            //        dgvSanPham.Columns.Add("ImportPrice", "Giá vốn");
            //        dgvSanPham.Columns.Add("ProfitMargin", "Lợi nhuận");

            //        // Thêm cột ảnh
            //        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            //        {
            //            Name = "ImageColumn",
            //            HeaderText = "Image",
            //            ImageLayout = DataGridViewImageCellLayout.Zoom
            //        };
            //        dgvSanPham.Columns.Add(imgColumn);

            //        // Thêm dữ liệu vào DataGridView
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            int rowIndex = dgvSanPham.Rows.Add();

            //            dgvSanPham.Rows[rowIndex].Cells["ProductID"].Value = row["ProductID"];
            //            dgvSanPham.Rows[rowIndex].Cells["ProductName"].Value = row["ProductName"];
            //            dgvSanPham.Rows[rowIndex].Cells["Price"].Value = row["Price"];
            //            dgvSanPham.Rows[rowIndex].Cells["StockQuantity"].Value = row["StockQuantity"];
            //            dgvSanPham.Rows[rowIndex].Cells["CategoryID"].Value = row["CategoryID"];
            //            dgvSanPham.Rows[rowIndex].Cells["SupplierID"].Value = row["SupplierID"];
            //            dgvSanPham.Rows[rowIndex].Cells["BrandID"].Value = row["BrandID"];
            //            dgvSanPham.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
            //            dgvSanPham.Rows[rowIndex].Cells["Discount"].Value = row["Discount"];
            //            dgvSanPham.Rows[rowIndex].Cells["ImportPrice"].Value = row["ImportPrice"];
            //            dgvSanPham.Rows[rowIndex].Cells["ProfitMargin"].Value = row["ProfitMargin"];

            //            // Handle image
            //            string imagePath = Path.Combine(Application.StartupPath, "C:\\BTL_W\\BTL\\Images", row["ImageUrl"].ToString());
            //            if (File.Exists(imagePath))
            //            {
            //                dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = Image.FromFile(imagePath);
            //            }
            //            else
            //            {
            //                dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = null; // Set a default image
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            //    }
            //}



            int masp = 0;

            //Click vao mot hang cua datagirlview
            private void dgvSanPham_Click(object sender, EventArgs e)
            {
                try
                {
                    if (dgvSanPham.SelectedRows.Count == 1)
                    {
                        DataGridViewRow dr = dgvSanPham.SelectedRows[0];

                        ResetColorControls();

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

            // Tải dữ liệu cho ComboBox thong tin
            private void LoadComboBoxData()
            {

                LoadCboLoaiSP();
                LoadCboNCC();

                cboNhanHang.DataSource = BrandBL.GetInstance.GetDanhSachLoaiSanPham();
                cboNhanHang.ValueMember = "BrandID";
                cboNhanHang.DisplayMember = "BrandName";
            }

            private void LoadCboLoaiSP()
            {
                cboLoai.DataSource = CategoryBL.GetInstance.GetDanhSachLoaiSanPham();
                cboLoai.ValueMember = "CategoryID";
                cboLoai.DisplayMember = "CategoryName";
            }

            private void LoadCboNCC()
            {
                cboNCC.DataSource = SupplierBL.GetInstance.GetDanhSachNhaCungCap();
                cboNCC.ValueMember = "SupplierID";
                cboNCC.DisplayMember = "ContactName";
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
            //Set mau khi khong nhap du thong tin
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
              
                        LoadDataGridView();
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

            // Kiem tra co nhap du thong tin khong
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
                    if (ctrl is ComboBox)
                    {
                        if (ctrl.Text == "")
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

            //Cap nhat san pham\Sua san pham
            // Cập nhật sản phẩm
            private void btnCapNhatSP_Click(object sender, EventArgs e)
            {
                if (CheckControls()) // Kiểm tra các trường thông tin
                {

                    // Kiểm tra độ dài tên sản phẩm
                    if (txtTen.Text.Length <= 200)
                    {
                        // Kiểm tra khuyến mãi phải nhỏ hơn 100%
                        if (int.TryParse(txtKhuyenMai.Text, out int discount) && discount < 100)
                        {
                            // Kiểm tra lợi nhuận phải lớn hơn 0
                            if (decimal.TryParse(txtLoiNhuan.Text, out decimal profitMargin) && profitMargin > 0)
                            {
                                // Kiểm tra ngày hợp lệ
                                if (CheckDate())
                                {
                                    try
                                    {
                                        // Tạo DTO để truyền dữ liệu
                                        SanPhamDTO spDTO = new SanPhamDTO
                                        {
                                            ProductID = masp,
                                            ProductName = txtTen.Text,
                                            CreatedAt = dateNgaySX.Value,
                                            ProfitMargin = profitMargin,
                                            ImportPrice = decimal.Parse(txtGiaNhap.Text),
                                            Price = decimal.Parse(txtGiaBan.Text),
                                            Discount = discount,
                                            StockQuantity = int.Parse(txtSoLuong.Text),
                                            CategoryID = (int)cboLoai.SelectedValue,
                                            SupplierID = (int)cboNCC.SelectedValue,
                                            BrandID = (int)cboNhanHang.SelectedValue,
                                            // Cập nhật ImageUrl nếu có ảnh
                                            ImageUrl = picHinhAnh.Image != null ? SaveImageToFile(picHinhAnh.Image, picHinhAnh.ImageLocation) : null // Lưu ảnh nếu có
                                        };

                                        // Gọi hàm sửa sản phẩm từ BLL
                                        if (SanPhamBL.GetInstance.SuaSanPham(spDTO))
                                        {
                                            LoadDataGridView();
                                            LamMoi();
                                            this.Alert("Cập nhật sản phẩm thành công!", Form_Notification.enmType.Success);

                                        }
                                        else
                                        {
                                            this.Alert("Cập nhật sản phẩm thất bại.", Form_Notification.enmType.Error);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ngày sản xuất phải hợp lệ và không được trước ngày 01/01/2000!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lợi nhuận phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Khuyến mãi phải nhỏ hơn 100%!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên sản phẩm tối đa 200 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            private void btnThemSP_Click(object sender, EventArgs e)
            {
                if (CheckControls()) // Kiểm tra các trường thông tin
                {
                    // Kiểm tra độ dài tên sản phẩm
                    if (txtTen.Text.Length <= 200)
                    {
                        // Kiểm tra khuyến mãi phải nhỏ hơn 100%
                        if (int.TryParse(txtKhuyenMai.Text, out int discount) && discount < 100)
                        {
                            // Kiểm tra lợi nhuận phải lớn hơn 0
                            if (decimal.TryParse(txtLoiNhuan.Text, out decimal profitMargin) && profitMargin > 0)
                            {
                                if (CheckSoLuong())
                                {
                                    // Kiểm tra ngày hợp lệ
                                    if (CheckDate())
                                    {
                                        try
                                        {
                                            // Tạo DTO để truyền dữ liệu
                                            SanPhamDTO spDTO = new SanPhamDTO
                                            {
                                                ProductID = masp,
                                                ProductName = txtTen.Text,
                                                CreatedAt = dateNgaySX.Value,
                                                ProfitMargin = profitMargin,
                                                ImportPrice = decimal.Parse(txtGiaNhap.Text),
                                                Price = decimal.Parse(txtGiaBan.Text),
                                                Discount = discount,
                                                StockQuantity = int.Parse(txtSoLuong.Text),
                                                CategoryID = (int)cboLoai.SelectedValue,
                                                SupplierID = (int)cboNCC.SelectedValue,
                                                BrandID = (int)cboNhanHang.SelectedValue,
                                                // Cập nhật ImageUrl nếu có ảnh
                                                ImageUrl = picHinhAnh.Image != null ? SaveImageToFile(picHinhAnh.Image, picHinhAnh.ImageLocation) : null // Lưu ảnh nếu có
                                            };

                                            // Gọi hàm sửa sản phẩm từ BLL
                                            if (SanPhamBL.GetInstance.ThemSanPham(spDTO))
                                            {
                                                LoadDataGridView();
                                                LamMoi();
                                                this.Alert("Cập nhật sản phẩm thành công!", Form_Notification.enmType.Success);

                                            }
                                            else
                                            {
                                                this.Alert("Cập nhật sản phẩm thất bại.", Form_Notification.enmType.Error);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }


                                    else
                                    {
                                        MessageBox.Show("Ngày sản xuất phải hợp lệ và không được trước ngày 01/01/2000!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Số lượng phải được nhập ở kho");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lợi nhuận phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Khuyến mãi phải nhỏ hơn 100%!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tên sản phẩm tối đa 200 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            //Luu anh
            private string SaveImageToFile(Image image, string imageLocation)
            {
                try
                {
                    string folderPath = Path.Combine(Application.StartupPath, "C:\\BTL_W\\BTL\\Images");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Nếu ảnh có đường dẫn, lấy tên file từ đường dẫn
                    string fileName = Path.GetFileName(imageLocation); // Lấy tên file từ ImageLocation
                    if (string.IsNullOrEmpty(fileName))
                    {
                        // Nếu không có tên file gốc, tạo tên file ngẫu nhiên
                        fileName = Guid.NewGuid().ToString() + ".jpg"; // Tạo tên file ngẫu nhiên
                    }

                    string filePath = Path.Combine(folderPath, fileName);  // Đảm bảo đường dẫn thư mục đúng

                    image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg); // Lưu ảnh dưới định dạng JPEG
                    return fileName; // Trả về tên file để lưu vào cơ sở dữ liệu
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể lưu ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }

            //Kiem tra ngay
            private bool CheckDate()
            {
                // So sánh với ngày 1/1/2000
                DateTime minDate = new DateTime(2000, 1, 1);

                // Kiểm tra xem ngày được chọn có lớn hơn ngày 1/1/2000 không
                if (dateNgaySX.Value > minDate)
                {
                    return true;
                }

                return false;
            }

            private bool CheckSoLuong()
            {
                if (txtSoLuong.Text == "")
                {
                    return false;
                }
                return true;
            }

            //Loi nhuan

            private void txtLoiNhuan_TextChanged(object sender, EventArgs e)
            {
                // Kiểm tra nếu giá trị trong txtLoiNhuan rỗng
                if (string.IsNullOrWhiteSpace(txtLoiNhuan.Text))
                {
                    txtGiaBan.Clear();
                    return;
                }

                if (int.TryParse(txtLoiNhuan.Text.Replace(",", ""), out int loiNhuan) &&
                    int.TryParse(txtGiaNhap.Text.Replace(",", ""), out int giaNhap))
                {
                    if (loiNhuan > 0)
                    {
                        int giaBan = giaNhap + (giaNhap * loiNhuan / 100);
                        txtGiaBan.Text = ConvertTien((double)giaBan);
                    }
                    else
                    {
                        txtGiaBan.Clear();
                    }
                }
                else
                {
                    txtGiaBan.Clear(); // Xóa giá trị nếu nhập không hợp lệ
                }

            }
            private string ConvertTien(double gia)
            {
                // Định dạng chuỗi tiền tệ với dấu phẩy
                return gia.ToString("N0", System.Globalization.CultureInfo.InvariantCulture);
            }

            //Gia Nhap

            private void txtGiaNhap_TextChanged(object sender, EventArgs e)
            {
                if (decimal.TryParse(txtGiaNhap.Text.Replace(",", ""), out decimal giaNhap))
                {
                    // Định dạng lại số tiền theo định dạng có dấu phẩy
                    txtGiaNhap.Text = giaNhap.ToString("N0", System.Globalization.CultureInfo.InvariantCulture);
                    txtGiaNhap.Select(txtGiaNhap.Text.Length, 0);
                }
                else if (!string.IsNullOrWhiteSpace(txtGiaNhap.Text))
                {
                    // Nếu nhập không hợp lệ, reset lại giá trị
                    txtGiaNhap.Clear();
                }

            }


            //Tu do thanh trang
            private void txtTen_Click(object sender, EventArgs e)
            {
                if (txtTen.BackColor == Color.OrangeRed)
                {
                    txtTen.BackColor = Color.White;
                }
            }
            private void txtCombobox1_Click(object sender, EventArgs e)
            {
                if (cboLoai.BackColor == Color.OrangeRed)
                {
                    cboLoai.BackColor = Color.White;
                }
            }
            private void txtCombobox2_Click(object sender, EventArgs e)
            {
                if (cboNCC.BackColor == Color.OrangeRed)
                {
                    cboNCC.BackColor = Color.White;
                }
            }


            private void txtSoLuong_Click(object sender, EventArgs e)
            {
                if (txtSoLuong.BackColor == Color.OrangeRed)
                {
                    txtSoLuong.BackColor = Color.White;
                }
            }

            private void txtKhuyenMai_Click(object sender, EventArgs e)
            {
                if (txtKhuyenMai.BackColor == Color.OrangeRed)
                {
                    txtKhuyenMai.BackColor = Color.White;
                }
            }

            private void picHinhAnh_Click(object sender, EventArgs e)
            {
                if (picHinhAnh.BackColor == Color.OrangeRed)
                {
                    picHinhAnh.BackColor = Color.White;
                }
                Form_Img frm = new Form_Img();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    picHinhAnh.Image = frm.img;
                }

            }
            //Bo loc 
            //Lam moi
            private void btnLamMoi_Click(object sender, EventArgs e)
            {
                txtTenSP.Text = "";
                cboLocLoaiSP.SelectedIndex = cboLocLoaiSP.Items.Count - 1;
                cboLocNCC.SelectedIndex = cboLocNCC.Items.Count - 1;
            }
            //Ap dung
            private void btnApDung_Click(object sender, EventArgs e)
            {
                // LoadDataGridViewTheoBoLoc
                LoadDataGridView();
            }


            //Form NCC
            private void pnlNCC_Click(object sender, EventArgs e)
            {
                Form_NCC frm = new Form_NCC();
                frm.ShowDialog();
                if (frm.b)
                {
                    LoadCboNCC();
                    LoadCboLocNCC();
                }
            }

            //Form_Loai SP
            private void pnlLoaiSP_Click(object sender, EventArgs e)
            {
                Form_LoaiSP frm = new Form_LoaiSP();
                frm.ShowDialog();
                if (frm.b)
                {
                    LoadCboLoaiSP();
                    LoadCboLocLoaiSP();
                    //LoadDataGridViewTheoBoLoc();
                    LoadDataGridView();
                }
            }



            private void CboLoai_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void PnlThongTinSanPham_Paint(object sender, PaintEventArgs e)
            {

            }
        }
    }
