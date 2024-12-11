
using BLL;
using DAL;
using DONGHO.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DONGHO.Usercontrols
{
    public partial class UC_WareHouse : UserControl
    {
        private int selectedRowIndex = -1;
        Form_ChonNCC formChonNCC = new Form_ChonNCC();
        public UC_WareHouse()
        {
            InitializeComponent();
            LoadDataGridView();
            LoadProductInStock(); // do cai lon nay ne
            LoadComboBoxData();
            ConfigureDataGridView();
        }

        private void LoadProductInStock()
        {
            try
            {
                // Lấy danh sách sản phẩm trong kho từ BL
                DataTable dt = SupplierProductBL.GetInstance.GetProductInStock();

                // Lọc các dòng có Status = 1
                DataRow[] filteredRows = dt.Select("Status = 1");

                // Xóa cột cũ trước khi thêm dữ liệu
                dgvPhieuNhap.Columns.Clear();

                // Tạo các cột dữ liệu
                dgvPhieuNhap.Columns.Add("ProductID", "Mã SP");

                dgvPhieuNhap.Columns.Add("ProductName", "Tên sản phẩm");
                dgvPhieuNhap.Columns.Add("SupplierName", "Tên NCC");
                dgvPhieuNhap.Columns.Add("brandName", "Hãng");
                dgvPhieuNhap.Columns.Add("CategoryName", "Thể loại");

                dgvPhieuNhap.Columns.Add("Price", "Giá bán");
                dgvPhieuNhap.Columns.Add("Quantity", "Số lượng");
                dgvPhieuNhap.Columns.Add("Status", "Tình trạng");
                dgvPhieuNhap.Columns.Add("CreatedAt", "Ngày nhập");

                dgvPhieuNhap.Columns.Add("CategoryID", "Thể loại");
                dgvPhieuNhap.Columns["CategoryID"].Visible = false;

                dgvPhieuNhap.Columns.Add("BrandID", "brand ẩn");
                dgvPhieuNhap.Columns["BrandID"].Visible = false;

                dgvPhieuNhap.Columns.Add("SupplierID", "Tên NCC");
                dgvPhieuNhap.Columns["SupplierID"].Visible = false;



                // Tạo cột hiển thị hình ảnh
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "Img";
                imageColumn.HeaderText = "Hình ảnh";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Cài đặt để hình ảnh tự động phóng to hoặc thu nhỏ
                dgvPhieuNhap.Columns.Add(imageColumn);

                dgvPhieuNhap.Columns.Add("ImageName", "Tên hình ảnh");

                foreach (DataRow row in filteredRows)
                {
                    int rowIndex = dgvPhieuNhap.Rows.Add();

                    dgvPhieuNhap.Rows[rowIndex].Cells["ProductID"].Value = row["ProductID"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["SupplierName"].Value = row["supName"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["SupplierID"].Value = row["supId"];


                    dgvPhieuNhap.Rows[rowIndex].Cells["ProductName"].Value = row["ProductName"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["Price"].Value = row["Price"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["Quantity"].Value = row["Quantity"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["Status"].Value = row["Status"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];

                    dgvPhieuNhap.Rows[rowIndex].Cells["brandName"].Value = row["brName"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["BrandID"].Value = row["brId"];


                    dgvPhieuNhap.Rows[rowIndex].Cells["CategoryName"].Value = row["cateName"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["CategoryID"].Value = row["cateId"];

                    // Kiểm tra xem có hình ảnh hay không
                    if (row["Img"] != DBNull.Value)
                    {
                        string imageName = row["Img"].ToString();  // Lấy tên file từ CSDL
                        string imagePath = Path.Combine("D:\\BTL_W\\BTL_W\\BTL", imageName);

                        // Kiểm tra xem file có tồn tại không
                        if (File.Exists(imagePath))
                        {
                            Image img = Image.FromFile(imagePath); // Tải hình ảnh từ file
                            dgvPhieuNhap.Rows[rowIndex].Cells["Img"].Value = img;  // Gán đối tượng Image vào DataGridView
                            dgvPhieuNhap.Rows[rowIndex].Cells["ImageName"].Value = imageName;  // Lưu tên file vào cột ImageName
                        }
                        else
                        {
                            dgvPhieuNhap.Rows[rowIndex].Cells["Img"].Value = null;  // Nếu file không tồn tại, không hiển thị hình ảnh
                            dgvPhieuNhap.Rows[rowIndex].Cells["ImageName"].Value = null;  // Xóa tên file
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi lỗi vào file hoặc hiển thị thông báo chi tiết hơn
                MessageBox.Show($"Lỗi khi tải dữ liệu View: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = SupplierProductBL.GetInstance.GetProduct();

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
                    string imagePath = Path.Combine(Application.StartupPath, "D:\\BTL_W\\BTL_W\\BTL", row["ImageUrl"].ToString());
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

        private void Button7_Click(object sender, EventArgs e)
        {

        }

        private void UC_Sales_Load(object sender, EventArgs e)
        {

        }

        private void UC_Sales_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRowIndex = e.RowIndex; // Lưu chỉ số dòng được chọn
            }
        }

        private void UC_Sales_Load_2(object sender, EventArgs e)
        {

        }

        private void btnDaNhap_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ dòng được chọn
            var selectedRow = dgvPhieuNhap.Rows[selectedRowIndex];

            string productName = selectedRow.Cells["ProductName"].Value?.ToString();
            int supplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
            string status = selectedRow.Cells["Status"].Value?.ToString();
            DateTime createdAt = Convert.ToDateTime(selectedRow.Cells["CreatedAt"].Value);
            string imageName = selectedRow.Cells["ImageName"].Value?.ToString(); // Đây là tên file từ CSDL, không phải Bitmap

            int BrandID = Convert.ToInt32(selectedRow.Cells["BrandID"].Value);
            int CategoryID = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);

            // Hiển thị thông tin trước khi lưu
            MessageBox.Show($"tên: {productName}\n giá: {price}\n Số lượng: {quantity}\n ncc:{supplierID} \n trang thai: {status} \n ngay nhap {createdAt} \n file hinh:{imageName}");

            // Gọi hàm AddProduct để thêm sản phẩm vào cơ sở dữ liệu
            // Hiển thị hộp thoại thông báo yêu cầu xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
            {
                // Gọi hàm thêm sản phẩm và cập nhật trạng thái
                bool success = SupplierProductBL.GetInstance.AddProduct(productName, supplierID, price, createdAt, quantity, imageName, BrandID, CategoryID);

                // Lấy ID sản phẩm từ DataGridView
                int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                bool successStatus = SupplierProductBL.GetInstance.UpdateProductStatus(productId, 0);

                // Kiểm tra kết quả và thông báo cho người dùng
                if (success && successStatus)
                {
                    MessageBox.Show("Sản phẩm đã được thêm vào hệ thống và trạng thái đã được cập nhật.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Reload lại dữ liệu trong DataGridView
                    LoadDataGridView();
                    LoadProductInStock();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm hoặc cập nhật trạng thái.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu người dùng chọn "No", không làm gì
                MessageBox.Show("Hành động bị hủy.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }

        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            Form_ChonNCC frm = new Form_ChonNCC();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {

            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
        }
        private int selectedBrandID;
        private int selectedCategoryID;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các TextBox
                string txtName = textBox1.Text.Trim();       // Tên sản phẩm
                string txtSL = txtSoLuong.Text.Trim();      // Số lượng
                string txtPrice = textBox2.Text.Trim();     // Giá bán

                // Kiểm tra các trường không được trống
                if (string.IsNullOrEmpty(txtName) || string.IsNullOrEmpty(txtSL) || string.IsNullOrEmpty(txtPrice))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra nếu không có ảnh được chọn
                if (string.IsNullOrEmpty(selectedImagePath) || string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra và lấy giá trị từ ComboBox
                if (cbbBrand.SelectedValue != null)
                {
                    selectedBrandID = Convert.ToInt32(cbbBrand.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thương hiệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbbCategory.SelectedValue != null)
                {
                    selectedCategoryID = Convert.ToInt32(cbbCategory.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn thể loại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy SupplierID từ lớp tĩnh
                int supplierID = SupplierProductDL.SelectedSupplierID;
                if (supplierID == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị thông báo xác nhận dữ liệu
                MessageBox.Show($"SupplierID đã chọn: {supplierID}\n" +
                                $"Brand đã chọn: {selectedBrandID}\n" +
                                $"Category đã chọn: {selectedCategoryID}\n" +
                                $"Tên sản phẩm: {txtName}\n" +
                                $"Giá sản phẩm: {txtPrice}\n" +
                                $"Số lượng: {txtSL}\n" +
                                $"Tên ảnh: {imageName}",
                                "Thông tin sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Thêm dữ liệu vào DataGridView
                int rowIndex = dgvAdd.Rows.Add();
                dgvAdd.Rows[rowIndex].Cells["ProductName"].Value = txtName;
                dgvAdd.Rows[rowIndex].Cells["Price"].Value = txtPrice;
                dgvAdd.Rows[rowIndex].Cells["Quantity"].Value = txtSL;

                dgvAdd.Rows[rowIndex].Cells["BrandID"].Value = selectedBrandID;
                int BrandID = selectedCategoryID;
                string BrandName = SupplierProductBL.GetInstance.GetBrandNameById(BrandID);
                dgvAdd.Rows[rowIndex].Cells["BrandName"].Value = BrandName;

                dgvAdd.Rows[rowIndex].Cells["SupplierID"].Value = supplierID;
                int SupplierID = selectedCategoryID;
                string SupplierName = SupplierProductBL.GetInstance.GetSupplierNameById(SupplierID);
                dgvAdd.Rows[rowIndex].Cells["SupplierName"].Value = SupplierName;

                dgvAdd.Rows[rowIndex].Cells["CategoryID"].Value = selectedCategoryID;
                int CategoryID = selectedCategoryID;
                string CategoryName = SupplierProductBL.GetInstance.GetCategoryNameById(CategoryID);
                dgvAdd.Rows[rowIndex].Cells["CategoryName"].Value = CategoryName;

                // Thêm hình ảnh vào cột Img
                Image img = Image.FromFile(selectedImagePath);
                dgvAdd.Rows[rowIndex].Cells["Img"].Value = img;

                // Thông báo thành công
                MessageBox.Show("Dữ liệu sản phẩm đã được thêm vào bảng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputFields()
        {
            textBox1.Clear();
            txtSoLuong.Clear();
            textBox2.Clear();
            cbbBrand.SelectedIndex = -1;
            cbbCategory.SelectedIndex = -1;
            pictureBox1.Image = null;
            selectedImagePath = string.Empty;
            imageName = string.Empty;
        }




        private void cbcBrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadComboBoxData()
        {
            cbbBrand.DataSource = BrandBL.GetInstance.GetDanhSachLoaiSanPham();
            cbbBrand.ValueMember = "BrandID";
            cbbBrand.DisplayMember = "BrandName";

            cbbCategory.DataSource = CategoryBL.GetInstance.GetDanhSachLoaiSanPham();
            cbbCategory.ValueMember = "CategoryID";
            cbbCategory.DisplayMember = "CategoryName";
        }

        private void dgvCTPN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string selectedImagePath = string.Empty;
        private string imageName = string.Empty;



        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Hạn chế loại file

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu đường dẫn ảnh vào biến selectedImagePath
                selectedImagePath = openFileDialog.FileName;
                imageName = Path.GetFileName(selectedImagePath);

                // Hiển thị ảnh lên PictureBox
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Đảm bảo ảnh vừa với PictureBox, giữ tỷ lệ
                pictureBox1.Image = Image.FromFile(selectedImagePath);
                MessageBox.Show($"Tên dduongfwf dẫn: {selectedImagePath}");
                MessageBox.Show($"Tên ảnh: {imageName}");
                SupplierProductDL.img = selectedImagePath; // Gán giá trị
                SupplierProductDL.fileImg = imageName; // Gán giá trị
            }
        }
        private void ConfigureDataGridView()
        {
            dgvAdd.Columns.Clear();

            dgvAdd.Columns.Add("ProductName", "Tên sản phẩm");
            dgvAdd.Columns.Add("BrandName", "Tên hãng");
            dgvAdd.Columns.Add("SupplierName", "Tên NCC");
            dgvAdd.Columns.Add("CategoryName", "Thể Loại");
            dgvAdd.Columns.Add("Price", "Giá bán");
            dgvAdd.Columns.Add("Quantity", "Số lượng");


            dgvAdd.Columns.Add("BrandID", "Mã Hãng");
            dgvAdd.Columns["BrandID"].Visible = false;


            dgvAdd.Columns.Add("SupplierID", "Mã NCC");
            dgvAdd.Columns["SupplierID"].Visible = false;

            // Hiển thị tên thể loại
            dgvAdd.Columns.Add("CategoryID", "Mã Thể Loại"); // Chứa mã thể loại
            dgvAdd.Columns["CategoryID"].Visible = false; // Ẩn cột mã thể loại

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            {
                Name = "Img",
                HeaderText = "Hình ảnh",
                ImageLayout = DataGridViewImageCellLayout.Zoom // Cài đặt để ảnh tự động thu/phóng
            };
            dgvAdd.Columns.Add(imgColumn);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (selectedRowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin từ dòng được chọn
            var selectedRow = dgvPhieuNhap.Rows[selectedRowIndex];

            string productName = selectedRow.Cells["ProductName"].Value?.ToString();
            int supplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
            string status = selectedRow.Cells["Status"].Value?.ToString();
            DateTime createdAt = Convert.ToDateTime(selectedRow.Cells["CreatedAt"].Value);
            string imageName = selectedRow.Cells["ImageName"].Value?.ToString(); // Đây là tên file từ CSDL, không phải Bitmap

            int BrandID = Convert.ToInt32(selectedRow.Cells["BrandID"].Value);
            int CategoryID = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);

            // Hiển thị thông tin trước khi lưu
            MessageBox.Show($"tên: {productName}\n giá: {price}\n Số lượng: {quantity}\n ncc:{supplierID} \n trang thai: {status} \n ngay nhap {createdAt} \n file hinh:{imageName}");

            // Gọi hàm AddProduct để thêm sản phẩm vào cơ sở dữ liệu
            // Hiển thị hộp thoại thông báo yêu cầu xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes) // Nếu người dùng chọn "Yes"
            {
                // Gọi hàm thêm sản phẩm và cập nhật trạng thái
                //bool success = SupplierProductBL.GetInstance.AddProduct(productName, supplierID, price, createdAt, quantity, imageName, BrandID, CategoryID);

                // Lấy ID sản phẩm từ DataGridView
                int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                bool successStatus = SupplierProductBL.GetInstance.UpdateProductStatus(productId, 0);

                // Kiểm tra kết quả và thông báo cho người dùng
                if (successStatus)
                {
                    MessageBox.Show("Sản phẩm đã được xóa và trạng thái đã được cập nhật.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    // Reload lại dữ liệu trong DataGridView
                    LoadDataGridView();
                    LoadProductInStock();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm hoặc cập nhật trạng thái.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu người dùng chọn "No", không làm gì
                MessageBox.Show("Hành động bị hủy.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Duyệt qua tất cả các dòng trong DataGridView
                foreach (DataGridViewRow row in dgvAdd.Rows)
                {
                    // Bỏ qua các dòng trống hoặc không hợp lệ
                    if (row.IsNewRow || row.Cells["ProductName"].Value == null)
                        continue;

                    // Lấy dữ liệu từ từng cột
                    int supplierID = Convert.ToInt32(row.Cells["SupplierID"].Value);
                    string productName = row.Cells["ProductName"].Value.ToString();
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    int categoryID = Convert.ToInt32(row.Cells["CategoryID"].Value);
                    int brandID = Convert.ToInt32(row.Cells["BrandID"].Value);
                    string img = SupplierProductDL.fileImg;
                    int status = 1; // Trạng thái mặc định là 1
                    String SaveImg = SupplierProductDL.img;
                    MessageBox.Show($"duong dan: {SaveImg}");
                    // Đường dẫn đích để lưu ảnh
                    string destinationPath = $"D:\\BTL_W\\BTL_W\\BTL\\Images\\{img}";

                    // Copy ảnh vào thư mục lưu trữ (nếu file tồn tại)
                    if (!string.IsNullOrEmpty(img) && File.Exists(SaveImg))
                    {
                        File.Copy(SaveImg, destinationPath, overwrite: true);
                    }

                    // Gọi hàm AddSupplierProduct để lưu vào CSDL
                    bool isAdded = SupplierProductBL.GetInstance.AddSupplierProduct(
                        supplierID, productName, price, status, quantity, img, categoryID, brandID
                    );

                    // Kiểm tra trạng thái lưu
                    if (!isAdded)
                    {
                        MessageBox.Show($"Lưu thất bại cho sản phẩm: {productName}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Lưu thành công tất cả sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductInStock();

                dgvAdd.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có muốn xóa phiếu sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra người dùng chọn Yes
            if (result == DialogResult.Yes)
            {
                // Xóa tất cả các dòng trong DataGridView
                dgvAdd.Rows.Clear();
            }
        }
    }
}