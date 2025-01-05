
using BLL;
using DAL;
using DONGHO.Forms;
using System.Data;




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
            LoadProductInStock();
            LoadComboBoxData();
            ConfigureDataGridView();
        }


        private Image ResizeImage(string imagePath, int width, int height)
        {
            try
            {
                Image img = Image.FromFile(imagePath);
                Bitmap resizedImage = new Bitmap(img, new Size(width, height));
                img.Dispose();
                return resizedImage;
            }
            catch (Exception)
            {
                Image img = Image.FromFile("D:\\BTL_Web\\Khanh\\Web\\WebApplication1\\Content\\img\\G-Shock\\G-Shock Dimesion\\G-Shock Dimesion.jpg");
                Bitmap resizedImage = new Bitmap(img, new Size(width, height));
                return resizedImage;
            }
        }
        private void LoadProductInStock()
        {
            try
            {
                DataTable dt = SupplierProductBL.GetInstance.GetProductInStock();
                DataRow[] filteredRows = dt.Select("Status = 1");
                dgvPhieuNhap.Columns.Clear();
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
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                imageColumn.Name = "Img";
                imageColumn.HeaderText = "Hình ảnh";
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvPhieuNhap.Columns.Add(imageColumn);
                dgvPhieuNhap.Columns.Add("ImageName", "Tên hình ảnh");
                foreach (DataRow row in filteredRows)
                {
                    int rowIndex = dgvPhieuNhap.Rows.Add();
                    dgvPhieuNhap.Rows[rowIndex].Cells["ProductID"].Value = row["ProductID"];
                    int SupplierID = Convert.ToInt32(row["SupplierID"]);
                    string SupplierName = SupplierProductBL.GetInstance.GetSupplierNameById(SupplierID);
                    dgvPhieuNhap.Rows[rowIndex].Cells["SupplierName"].Value = SupplierName;
                    dgvPhieuNhap.Rows[rowIndex].Cells["SupplierID"].Value = SupplierID;
                    dgvPhieuNhap.Rows[rowIndex].Cells["ProductName"].Value = row["ProductName"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["Price"].Value = row["Price"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["Quantity"].Value = row["Quantity"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["Status"].Value = row["Status"];
                    dgvPhieuNhap.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                    int brandID = Convert.ToInt32(row["BrandID"]);
                    string brandName = SupplierProductBL.GetInstance.GetBrandNameById(brandID);
                    dgvPhieuNhap.Rows[rowIndex].Cells["brandName"].Value = brandName;
                    dgvPhieuNhap.Rows[rowIndex].Cells["BrandID"].Value = brandID;
                    int CategoryID = Convert.ToInt32(row["CategoryID"]);
                    string CategoryName = SupplierProductBL.GetInstance.GetCategoryNameById(CategoryID);
                    dgvPhieuNhap.Rows[rowIndex].Cells["CategoryName"].Value = CategoryName;
                    dgvPhieuNhap.Rows[rowIndex].Cells["CategoryID"].Value = CategoryID;

                    if (row["Img"] != DBNull.Value)
                    {
                        string imageName = row["Img"].ToString();  
                        string imagePath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Images", imageName);

                        if (File.Exists(imagePath))
                        {
                            Image img = ResizeImage(imagePath, 32, 32);
                            dgvPhieuNhap.Rows[rowIndex].Cells["Img"].Value = img; 
                            dgvPhieuNhap.Rows[rowIndex].Cells["ImageName"].Value = imageName;  
                        }
                        else
                        {
                            dgvPhieuNhap.Rows[rowIndex].Cells["Img"].Value = null;  
                            dgvPhieuNhap.Rows[rowIndex].Cells["ImageName"].Value = null;  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu View: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }

        }


        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = SupplierProductBL.GetInstance.GetProduct();

                dgvSanPham.Columns.Clear();

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

                DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
                {
                    Name = "ImageColumn",
                    HeaderText = "Image",
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                dgvSanPham.Columns.Add(imgColumn);

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

                    string imagePath = Path.Combine(Application.StartupPath, @"D:\BTL_W\BTL_W\BTL\Images", row["ImageUrl"].ToString());
                    if (File.Exists(imagePath))
                    {

                        dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = ResizeImage(imagePath, 32, 32);
                    }
                    else
                    {
                        dgvSanPham.Rows[rowIndex].Cells["ImageColumn"].Value = null; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {

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
                selectedRowIndex = e.RowIndex; 
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

            var selectedRow = dgvPhieuNhap.Rows[selectedRowIndex];

            string productName = selectedRow.Cells["ProductName"].Value?.ToString();
            int supplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
            string status = selectedRow.Cells["Status"].Value?.ToString();
            DateTime createdAt = Convert.ToDateTime(selectedRow.Cells["CreatedAt"].Value);
            string imageName = selectedRow.Cells["ImageName"].Value?.ToString();

            int BrandID = Convert.ToInt32(selectedRow.Cells["BrandID"].Value);
            int CategoryID = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);

            MessageBox.Show($"tên: {productName}\n giá: {price}\n Số lượng: {quantity}\n ncc:{supplierID} \n trang thai: {status} \n ngay nhap {createdAt} \n file hinh:{imageName}");

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {
                bool success = SupplierProductBL.GetInstance.AddProduct(productName, supplierID, price, createdAt, quantity, imageName, BrandID, CategoryID);

                int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                bool successStatus = SupplierProductBL.GetInstance.UpdateProductStatus(productId, 0);

                if (success && successStatus)
                {
                    MessageBox.Show("Sản phẩm đã được thêm vào hệ thống và trạng thái đã được cập nhật.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

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
                string txtName = textBox1.Text.Trim();      
                string txtSL = txtSoLuong.Text.Trim();      
                string txtPrice = textBox2.Text.Trim();    

                if (string.IsNullOrEmpty(txtName) || string.IsNullOrEmpty(txtSL) || string.IsNullOrEmpty(txtPrice))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(selectedImagePath) || string.IsNullOrEmpty(imageName))
                {
                    MessageBox.Show("Vui lòng chọn hình ảnh cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                int supplierID = SupplierProductDL.SelectedSupplierID;
                if (supplierID == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"SupplierID đã chọn: {supplierID}\n" +
                                $"Brand đã chọn: {selectedBrandID}\n" +
                                $"Category đã chọn: {selectedCategoryID}\n" +
                                $"Tên sản phẩm: {txtName}\n" +
                                $"Giá sản phẩm: {txtPrice}\n" +
                                $"Số lượng: {txtSL}\n" +
                                $"Tên ảnh: {imageName}",
                                "Thông tin sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                Image img = Image.FromFile(selectedImagePath);
                dgvAdd.Rows[rowIndex].Cells["Img"].Value = img;

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
        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                imageName = Path.GetFileName(selectedImagePath);

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; 
                pictureBox1.Image = Image.FromFile(selectedImagePath);
                MessageBox.Show($"Tên dduongfwf dẫn: {selectedImagePath}");
                MessageBox.Show($"Tên ảnh: {imageName}");
                SupplierProductDL.img = selectedImagePath; 
                SupplierProductDL.fileImg = imageName; 
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
            dgvAdd.Columns.Add("CategoryID", "Mã Thể Loại");
            dgvAdd.Columns["CategoryID"].Visible = false; 





            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            {
                Name = "Img",
                HeaderText = "Hình ảnh",
                ImageLayout = DataGridViewImageCellLayout.Zoom 
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

            var selectedRow = dgvPhieuNhap.Rows[selectedRowIndex];

            string productName = selectedRow.Cells["ProductName"].Value?.ToString();
            int supplierID = Convert.ToInt32(selectedRow.Cells["SupplierID"].Value);
            decimal price = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);
            string status = selectedRow.Cells["Status"].Value?.ToString();
            DateTime createdAt = Convert.ToDateTime(selectedRow.Cells["CreatedAt"].Value);
            string imageName = selectedRow.Cells["ImageName"].Value?.ToString();

            int BrandID = Convert.ToInt32(selectedRow.Cells["BrandID"].Value);
            int CategoryID = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);

            MessageBox.Show($"tên: {productName}\n giá: {price}\n Số lượng: {quantity}\n ncc:{supplierID} \n trang thai: {status} \n ngay nhap {createdAt} \n file hinh:{imageName}");

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                                                  "Xác nhận",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes) 
            {

                int productId = Convert.ToInt32(selectedRow.Cells["ProductID"].Value);
                bool successStatus = SupplierProductBL.GetInstance.UpdateProductStatus(productId, 0);

                if (successStatus)
                {
                    MessageBox.Show("Sản phẩm đã được xóa và trạng thái đã được cập nhật.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

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
                foreach (DataGridViewRow row in dgvAdd.Rows)
                {
                    if (row.IsNewRow || row.Cells["ProductName"].Value == null)
                        continue;

                    int supplierID = Convert.ToInt32(row.Cells["SupplierID"].Value);
                    string productName = row.Cells["ProductName"].Value.ToString();
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    int categoryID = Convert.ToInt32(row.Cells["CategoryID"].Value);
                    int brandID = Convert.ToInt32(row.Cells["BrandID"].Value);
                    string img = SupplierProductDL.fileImg;
                    int status = 1; 
                    String SaveImg = SupplierProductDL.img;
                    MessageBox.Show($"duong dan: {SaveImg}");
                    string destinationPath = $"D:\\BTL_W\\BTL_W\\BTL\\Images\\{img}";

                    if (!string.IsNullOrEmpty(img) && File.Exists(SaveImg))
                    {
                        File.Copy(SaveImg, destinationPath, overwrite: true);
                    }

                    bool isAdded = SupplierProductBL.GetInstance.AddSupplierProduct(
                        supplierID, productName, price, status, quantity, img, categoryID, brandID
                    );

                    if (!isAdded)
                    {
                        MessageBox.Show($"Lưu thất bại cho sản phẩm: {productName}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                //MessageBox.Show("Lưu thành công tất cả sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = MessageBox.Show("Bạn có muốn xóa phiếu sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dgvAdd.Rows.Clear();
            }
        }

        private void dgvAdd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnHoaDon_Click(object sender, EventArgs e)
        {
       
        }
    }
}
