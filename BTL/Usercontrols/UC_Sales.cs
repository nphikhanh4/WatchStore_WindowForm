
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Diagnostics;


namespace DONGHO.Usercontrols
{
    public partial class UC_Sales : UserControl
    {
        private string connectionString = "Server=LAPTOP-4TC8L8F1;Database=WatchStore;Trusted_Connection=True;TrustServerCertificate=true;";
        private int currentPage = 1;
        private int itemsPerPage = 6;
        private FlowLayoutPanel flowLayout;
        int sumpage = 0;
        public UC_Sales()
        {
            InitializeComponent();
            InitializeFlowLayout();
            LoadCboLocNCC();
            LoadCboLocLoaiSP();
            refreshFilter();
            LoadDanhSachSanPhamTheoBoLoc(currentPage);
        }


        private void LoadCboLocLoaiSP()
        {
            DataTable dt = CategoryBL.GetInstance.GetDanhSachLoaiSanPham();
            if (dt == null)
            {
                MessageBox.Show("Không thể tải danh sách loại sản phẩm.");
                return;
            }

            if (!dt.Columns.Contains("CategoryID") || !dt.Columns.Contains("CategoryName"))
            {
                MessageBox.Show("Dữ liệu loại sản phẩm không đúng định dạng.");
                return;
            }

            DataRow dr = dt.NewRow();
            dr["CategoryID"] = "-1";
            dr["CategoryName"] = "Tất cả";
            dt.Rows.Add(dr);

            dt.DefaultView.Sort = "CategoryID ASC";
            dt = dt.DefaultView.ToTable();

            cboLocLoaiSP.DataSource = dt;
            cboLocLoaiSP.DisplayMember = "CategoryName";
            cboLocLoaiSP.ValueMember = "CategoryID";

            if (cboLocLoaiSP.Items.Count > 0)
                cboLocLoaiSP.SelectedIndex = cboLocLoaiSP.Items.Count - 1;
        }

        private void LoadCboLocNCC()
        {
            DataTable dt = SupplierBL.GetInstance.GetDanhSachNCC();
            if (dt == null)
            {
                MessageBox.Show("Không thể tải danh sách nhà cung cấp.");
                return;
            }

            if (!dt.Columns.Contains("SupplierId") || !dt.Columns.Contains("SupplierName"))
            {
                MessageBox.Show("Dữ liệu nhà cung cấp không đúng định dạng.");
                return;
            }

            DataRow dr = dt.NewRow();
            dr["SupplierId"] = "-1";
            dr["SupplierName"] = "Tất cả";
            dt.Rows.Add(dr);

            dt.DefaultView.Sort = "SupplierId ASC";
            dt = dt.DefaultView.ToTable();

            cboLocNCC.DataSource = dt;
            cboLocNCC.DisplayMember = "SupplierName";
            cboLocNCC.ValueMember = "SupplierId";

            if (cboLocNCC.Items.Count > 0)
                cboLocNCC.SelectedIndex = cboLocNCC.Items.Count - 1;
        }

        private void InitializeFlowLayout()
        {
            flowLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            panel9.Controls.Add(flowLayout);
            tableLayoutPanel4.Controls.Add(panel9);
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
                return null;
            }
        }

        private async Task<Image> LoadImageAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return ResizeImage(imagePath, 100, 80); // Resize image when loading
                }
                catch
                {
                    return null;
                }
            });
        }

        private async void LoadItemList(int page)
        {
            try
            {
                flowLayout.Controls.Clear();

                int customerId = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string countQuery = @"
                        SELECT COUNT(*) 
                        FROM Product
                        JOIN Brand ON Brand.BrandID = Product.BrandID";

                    SqlCommand countCommand = new SqlCommand(countQuery, connection);

                    int totalItems = (int)await countCommand.ExecuteScalarAsync();
                    int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                    btnPre.Enabled = currentPage > 1;
                    btnNext.Enabled = currentPage < totalPages;
                    lblPageNumber.Text = $"{currentPage}/{totalPages}";

                    string query = $@"
                        SELECT 
                            Product.ProductID, 
                            Product.ProductName, 
                            Product.Price, 
                            Brand.BrandName
                        FROM Product
                        JOIN Brand ON Brand.BrandID = Product.BrandID
                        ORDER BY Product.ProductId
                        OFFSET {(page - 1) * itemsPerPage} ROWS
                        FETCH NEXT {itemsPerPage} ROWS ONLY";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Panel panel = new Panel
                        {
                            Width = 222,
                            Height = 255,
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(5),
                        };

                        decimal price = (decimal)row["Price"];
                        string brandName = row["BrandName"].ToString();
                        string productId = row["ProductID"].ToString();
                        string productName = row["ProductName"].ToString();
                        string imagePath = Path.Combine(@"D:\LapTrinhTrucQuan\BTL_Store\Content\img\", brandName, productName, productName + @" Default\1.jpg");

                        PictureBox pictureBox = new PictureBox()
                        {
                            Width = 205,
                            Height = 185,
                            Padding = new Padding(15, 15, 0, 0),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        pictureBox.Image = await LoadImageAsync(imagePath);

                        Label lblName = new Label
                        {
                            Text = row["ProductName"].ToString(),
                            AutoSize = true,
                            Font = new Font("Arial", 9, FontStyle.Bold),
                            Location = new Point(13, 190)
                        };

                        Label lblPrice = new Label
                        {
                            Text = "Price: $" + row["Price"].ToString(),
                            AutoSize = true,
                            ForeColor = Color.FromArgb(255, 218, 165, 32),
                            Font = new Font("Arial", 14, FontStyle.Regular),
                            Location = new Point(10, 210),
                        };

                        panel.Controls.Add(pictureBox);
                        panel.Controls.Add(lblName);
                        panel.Controls.Add(lblPrice);

                        AddClickEventToPanelControls(panel, customerId, productId, price);

                        flowLayout.Controls.Add(panel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void AddClickEventToPanelControls(Panel panel, int customerId, string productId, decimal price)
        {
            foreach (Control control in panel.Controls)
            {
                control.Click += (sender, e) => PanelControl_Click(sender, e, customerId, productId, price);
            }
            panel.Click += (sender, e) => PanelControl_Click(sender, e, customerId, productId, price);
        }

        private void PanelControl_Click(object sender, EventArgs e, int customerId, string productId, decimal price)
        {
            string sdt = txtSDT.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkPhoneNumberQuery = "SELECT CustomerID FROM Customer WHERE Phone = @PhoneNumber";
                using (SqlCommand checkPhoneCommand = new SqlCommand(checkPhoneNumberQuery, connection))
                {
                    checkPhoneCommand.Parameters.AddWithValue("@PhoneNumber", sdt);
                    using (SqlDataReader reader = checkPhoneCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerId = (int)reader["CustomerID"];
                        }
                        else
                        {
                            MessageBox.Show("Phone number not found.");
                        }
                    }
                }
            }
            if (customerId != 0)
            {
                addOrderItem(customerId, int.Parse(productId), price);
            }
            else
            {
                MessageBox.Show("Customer not found. Please check the phone number.");
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDanhSachSanPhamTheoBoLoc(currentPage);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadDanhSachSanPhamTheoBoLoc(currentPage);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                checkOrder();
            }
        }

        private void checkOrder()
        {
            string sdt = txtSDT.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkPhoneNumberQuery = "SELECT CustomerID, FullName FROM Customer WHERE Phone = @PhoneNumber";
                    using (SqlCommand checkPhoneCommand = new SqlCommand(checkPhoneNumberQuery, connection))
                    {
                        checkPhoneCommand.Parameters.AddWithValue("@PhoneNumber", sdt);
                        using (SqlDataReader reader = checkPhoneCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int customerId = (int)reader["CustomerID"];
                                string fullName = reader["FullName"].ToString();

                                txtTenKH.Text = fullName;
                                checkOrderExists(customerId);
                                foundSDT.Visible = true;
                            }
                            else
                            {
                                foundSDT.Visible = false;
                                txtTenKH.Text = "";
                                MessageBox.Show("Phone number not found. Please register the customer.");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void checkOrderExists(int customerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to check if an existing order exists for the customer
                    string checkOrderQuery = @"
                        SELECT COUNT(*) 
                        FROM [Order] 
                        WHERE CustomerID = @CustomerID 
                        AND (OrderStatus = 0 OR OrderStatus IS NULL);"; // Check if order exists or is in cart (OrderStatus = 0)

                    using (SqlCommand checkOrderCommand = new SqlCommand(checkOrderQuery, connection))
                    {
                        checkOrderCommand.Parameters.AddWithValue("@CustomerID", customerId);

                        int orderCount = (int)checkOrderCommand.ExecuteScalar();

                        if (orderCount == 0)
                        {
                            createNewOrder(customerId);
                        }
                        else
                        {
                            Console.WriteLine("An order already exists for this customer.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void createNewOrder(int customerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to insert a new order
                    string insertOrderQuery = @"
                 INSERT INTO [Order] (CustomerID, OrderStatus, TotalPrice)
                VALUES (@CustomerID, 0, 0);";  // Default values for the new order

                    using (SqlCommand insertOrderCommand = new SqlCommand(insertOrderQuery, connection))
                    {
                        insertOrderCommand.Parameters.AddWithValue("@CustomerID", customerId);

                        insertOrderCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("New order created successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void addOrderItem(int customerId, int productID, decimal unitPrice)
        {
            try
            {
                int orderId = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkOrderQuery = @"
                        SELECT OrderID 
                        FROM [Order] 
                        WHERE CustomerID = @CustomerID 
                        AND (OrderStatus = 0 OR OrderStatus IS NULL);";

                    using (SqlCommand checkOrderCommand = new SqlCommand(checkOrderQuery, connection))
                    {
                        checkOrderCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        object result = checkOrderCommand.ExecuteScalar();

                        if (result != null)
                        {
                            orderId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi addOrderItem");
                            return;
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkOrderItemQuery = @"
                        SELECT Quantity 
                        FROM OrderItem 
                        WHERE OrderID = @OrderID 
                        AND ProductID = @ProductID;";

                    using (SqlCommand checkOrderItemCommand = new SqlCommand(checkOrderItemQuery, connection))
                    {
                        checkOrderItemCommand.Parameters.AddWithValue("@OrderID", orderId);
                        checkOrderItemCommand.Parameters.AddWithValue("@ProductID", productID);

                        object quantityResult = checkOrderItemCommand.ExecuteScalar();

                        if (quantityResult != null)
                        {
                            int currentQuantity = Convert.ToInt32(quantityResult);

                            string updateQuantityQuery = @"
                                UPDATE OrderItem 
                                SET Quantity = @NewQuantity 
                                WHERE OrderID = @OrderID 
                                AND ProductID = @ProductID;";

                            using (SqlCommand updateCommand = new SqlCommand(updateQuantityQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@NewQuantity", currentQuantity + 1);
                                updateCommand.Parameters.AddWithValue("@OrderID", orderId);
                                updateCommand.Parameters.AddWithValue("@ProductID", productID);

                                updateCommand.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertOrderItemQuery = @"
                        INSERT INTO OrderItem (OrderID, ProductID, Quantity, UnitPrice)
                        VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice)";

                            using (SqlCommand insertCommand = new SqlCommand(insertOrderItemQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@OrderID", orderId);
                                insertCommand.Parameters.AddWithValue("@ProductID", productID);
                                insertCommand.Parameters.AddWithValue("@Quantity", 1);
                                insertCommand.Parameters.AddWithValue("@UnitPrice", unitPrice);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                addProductToGrid(orderId, productID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void addProductToGrid(int orderId, int productID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        Product.ProductName AS TenSanPham, 
                        Product.Price AS DonGia, 
                        Product.Discount as KM,
                        OrderItem.Quantity AS SoLuong,
                        OrderItem.UnitPrice as TongTien
                    FROM OrderItem
                    JOIN Product ON Product.ProductID = OrderItem.ProductID                   
                    WHERE OrderItem.OrderID = @OrderID
                    AND Product.ProductID = @ProductID"; // Lấy thông tin cho sản phẩm vừa thêm

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderId);
                        command.Parameters.AddWithValue("@ProductID", productID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string productName = reader["TenSanPham"].ToString();
                                decimal unitPrice = (decimal)reader["DonGia"];
                                int quantity = (int)reader["SoLuong"];
                                int discount = (int)reader["KM"];
                                decimal totalPrice = (decimal)reader["TongTien"];

                                // Kiểm tra xem sản phẩm đã có trong DataGridView chưa
                                bool productExists = false;
                                foreach (DataGridViewRow row in dgvCTHD.Rows)
                                {
                                    if (row.Cells["TenSP"].Value.ToString() == productName)
                                    {
                                        productExists = true;
                                        // Nếu sản phẩm đã có trong giỏ, cập nhật số lượng và tổng tiền
                                        int currentQuantity = (int)row.Cells["SoLuong"].Value;
                                        row.Cells["SoLuong"].Value = quantity;
                                        row.Cells["TongTien"].Value = quantity * unitPrice;
                                        break;
                                    }
                                }

                                // Nếu sản phẩm chưa có, thêm dòng mới
                                if (!productExists)
                                {
                                    dgvCTHD.Rows.Add(productName, unitPrice, discount, quantity, totalPrice);
                                }
                            }
                        }
                    }
                }
                CalculateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product to grid: " + ex.Message);
            }
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int customerId = getCustomerId();
            string productName = dgvCTHD.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();

            if (e.RowIndex >= 0)
            {
                int orderId = getOrderId(customerId);
                int productId = getProductIdByName(productName);
                int currentQuantity = (int)dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value;

                // Column 5: Decrease quantity
                if (e.ColumnIndex == 5)
                {
                    if (currentQuantity > 1)
                    {
                        UpdateQuantity(orderId, productId, currentQuantity - 1);
                        dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value = currentQuantity - 1;

                        decimal unitPrice = (decimal)dgvCTHD.Rows[e.RowIndex].Cells["DonGia"].Value;
                        decimal newTotalPrice = unitPrice * (currentQuantity - 1);
                        dgvCTHD.Rows[e.RowIndex].Cells["TongTien"].Value = newTotalPrice;
                    }
                    else
                    {
                        DeleteOrderItem(orderId, productId);
                        dgvCTHD.Rows.RemoveAt(e.RowIndex);
                    }
                }
                // Column 6: Increase quantity
                else if (e.ColumnIndex == 6)
                {
                    UpdateQuantity(orderId, productId, currentQuantity + 1);
                    dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value = currentQuantity + 1;

                    decimal unitPrice = (decimal)dgvCTHD.Rows[e.RowIndex].Cells["DonGia"].Value;
                    decimal newTotalPrice = unitPrice * (currentQuantity + 1);
                    dgvCTHD.Rows[e.RowIndex].Cells["TongTien"].Value = newTotalPrice;

                    updateUnitPrice(orderId, unitPrice, productId);
                }
                CalculateTotalPrice();
            }
        }

        private void DeleteOrderItem(int orderId, int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = @"
                DELETE FROM OrderItem 
                WHERE OrderID = @OrderID 
                AND ProductID = @ProductID";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@OrderID", orderId);
                        deleteCommand.Parameters.AddWithValue("@ProductID", productId);

                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting OrderItem: " + ex.Message);
            }
        }

        private void UpdateQuantity(int orderId, int productId, int newQuantity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE OrderItem 
                        SET Quantity = @NewQuantity 
                        WHERE OrderID = @OrderID 
                        AND ProductID = @ProductID";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@OrderID", orderId);
                        updateCommand.Parameters.AddWithValue("@ProductID", productId);
                        updateCommand.Parameters.AddWithValue("@NewQuantity", newQuantity);

                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating quantity: " + ex.Message);
            }
        }

        private int getOrderId(int customerId)
        {
            int orderId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkOrderQuery = @"
                        SELECT OrderID 
                        FROM [Order] 
                        WHERE CustomerID = @CustomerID 
                        AND (OrderStatus = 0 OR OrderStatus IS NULL);";

                using (SqlCommand checkOrderCommand = new SqlCommand(checkOrderQuery, connection))
                {
                    checkOrderCommand.Parameters.AddWithValue("@CustomerID", customerId);
                    object result = checkOrderCommand.ExecuteScalar();

                    if (result != null)
                    {
                        orderId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show(customerId.ToString());
                        MessageBox.Show("Không tìm thấy OrderId");
                        return orderId;
                    }
                }
            }
            return orderId;
        }

        private int getCustomerId()
        {
            int customerId = 0;
            string sdt = txtSDT.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkPhoneNumberQuery = "SELECT CustomerID FROM Customer WHERE Phone = @PhoneNumber";
                using (SqlCommand checkPhoneCommand = new SqlCommand(checkPhoneNumberQuery, connection))
                {
                    checkPhoneCommand.Parameters.AddWithValue("@PhoneNumber", sdt);
                    using (SqlDataReader reader = checkPhoneCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerId = (int)reader["CustomerID"];
                        }
                        else
                        {
                            MessageBox.Show("tìm ko thấy customerId");
                        }
                    }
                }
            }
            return customerId;
        }

        private int getProductIdByName(string productName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int productId = 0;
                connection.Open();

                string checkOrderQuery = @"
                        SELECT ProductId
                        FROM [Product] 
                        WHERE ProductName = @productName;";

                using (SqlCommand checkOrderCommand = new SqlCommand(checkOrderQuery, connection))
                {
                    checkOrderCommand.Parameters.AddWithValue("@productName", productName);
                    object result = checkOrderCommand.ExecuteScalar();

                    if (result != null)
                    {
                        productId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("ko tìm thấy ProductId by ProductName.");
                        return 0;
                    }
                }
                return productId;
            }
        }

        private void updateUnitPrice(int orderId, decimal newUnitPrice, int productId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE OrderItem 
                        SET UnitPrice = @newUnitPrice 
                        WHERE OrderID = @OrderID 
                        AND ProductID = @ProductID";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@OrderID", orderId);
                        updateCommand.Parameters.AddWithValue("@ProductID", productId);
                        updateCommand.Parameters.AddWithValue("@newUnitPrice", newUnitPrice);

                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating UnitPrice: " + ex.Message);
            }
        }

        private void CalculateTotalPrice()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvCTHD.Rows)
            {
                if (row.Cells["TongTien"].Value != DBNull.Value)
                {
                    total += Convert.ToDecimal(row.Cells["TongTien"].Value);
                }
            }
            lblTongTien.Text = total.ToString("N0") + " đ";
        }

        private decimal CalculateRemainingBalance(decimal paidAmount, decimal totalOrderCost)
        {
            return paidAmount - totalOrderCost;
        }

        private void updateOrderStatus(int customerId, int orderStatus)
        {
            int orderId = getOrderId(customerId);
            if (orderId != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string updateQuery = @"
                            UPDATE [Order] 
                            SET OrderStatus = @orderStatus 
                            WHERE OrderID = @OrderID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@OrderID", orderId);
                            updateCommand.Parameters.AddWithValue("@orderStatus", orderStatus);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Order status updated successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to update order status.");
                            }
                        }
                    }
                    dgvCTHD.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order status: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No order found for this customer.");
            }
        }

        private void updateTotalPrice(int customerId, decimal totalprice)
        {
            int orderId = getOrderId(customerId);
            if (orderId != 0)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string updateQuery = @"
                            UPDATE [Order] 
                            SET TotalPrice = @totalprice 
                            WHERE OrderID = @OrderID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@OrderID", orderId);
                            updateCommand.Parameters.AddWithValue("@Totalprice", totalprice);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("TotalPrice updated.");
                            }
                            else
                            {
                                MessageBox.Show("Failed to update TotalPrice.");
                            }
                        }
                    }
                    dgvCTHD.Rows.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order status: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No order found for this customer.");
            }
        }

        private void btnApDung_Click(object sender, EventArgs e)
        {
            LoadDanhSachSanPhamTheoBoLoc(1);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int customerId = getCustomerId();

            try
            {
                decimal paidAmount = decimal.Parse(txtTienKHTra.Text.Replace(" đ", "").Replace(",", ""));
                string totalPriceText = lblTongTien.Text.Replace(" đ", "").Replace(",", "").Trim();
                decimal totalPrice = decimal.Parse(totalPriceText);

                txtTienThua.Text = CalculateRemainingBalance(paidAmount, totalPrice).ToString("N0") + " đ";
                updateTotalPrice(customerId, totalPrice);
                updateOrderStatus(customerId, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            btnThanhToan.Enabled = false;
            btnThanhToan.BackColor = Color.Gray;
            txtTienThua.Text = "";
            txtTienKHTra.Text = "";
            lblTongTien.Text = "0";
            checkOrder();

        }

        private void txtTienKHTra_TextChanged(object sender, EventArgs e)
        {
            string input = txtTienKHTra.Text.Replace(",", "").Trim();

            if (decimal.TryParse(input, out decimal paidAmount))
            {
                txtTienKHTra.Text = paidAmount.ToString("N0");
                txtTienKHTra.SelectionStart = txtTienKHTra.Text.Length;

                string totalPriceText = lblTongTien.Text.Replace(" đ", "").Replace(",", "");
                decimal totalPrice = decimal.Parse(totalPriceText);

                bool successful = (paidAmount >= totalPrice);

                if (successful)
                {
                    txtTienThua.Text = CalculateRemainingBalance(paidAmount, totalPrice).ToString("N0") + " đ";
                    btnThanhToan.Enabled = true;
                    btnThanhToan.BackColor = Color.Blue;
                }
                else
                {
                    btnThanhToan.Enabled = false;
                    btnThanhToan.BackColor = Color.Gray;
                    txtTienThua.Text = CalculateRemainingBalance(paidAmount, totalPrice).ToString("N0") + " đ";
                }
            }
            else
            {
                txtTienThua.Text = "";
                btnThanhToan.Enabled = false;
                btnThanhToan.BackColor = Color.Gray;
            }
        }

        private void LoadDanhSachSanPhamTheoBoLoc(int numpage)
        {
            if (panel9.Width >= 800)
                itemsPerPage = 8;
            else itemsPerPage = 6;
            Debug.WriteLine($"panel9.Width: {panel9.Width}, itemsPerPage: {itemsPerPage}");


            currentPage = numpage;
            int customerId = 0;
            flowLayout.Controls.Clear();

            DataTable dt = ProductBL.GetInstance.GetDanhSachSanPhamTheoBoLoc(
                txtTenSP.Text,
                cboLocLoaiSP.SelectedValue.ToString(),
                cboLocNCC.SelectedValue.ToString().Trim()
            );

            int totalItems = dt.Rows.Count;

            int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            btnPre.Enabled = currentPage > 1;
            btnPre.BackColor = btnPre.Enabled ? Color.DeepSkyBlue : Color.LightGray;

            btnNext.Enabled = currentPage < totalPages;
            btnNext.BackColor = btnNext.Enabled ? Color.DeepSkyBlue : Color.LightGray;


            lblPageNumber.Text = $"{currentPage}/{totalPages}";

            int startRow = (currentPage - 1) * itemsPerPage;
            int endRow = Math.Min(startRow + itemsPerPage, totalItems);

            for (int i = startRow; i < endRow; i++)
            {
                DataRow row = dt.Rows[i];

                Panel panel = new Panel
                {
                    Width = 220,
                    Height = 225,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Pink,
                    Margin = new Padding(5),
                };

                decimal price = row["DonGiaBan"] != DBNull.Value ? Convert.ToDecimal(row["DonGiaBan"]) : 0m;
                string brandName = row["BrandName"].ToString();
                string productId = row["MãSP"].ToString();
                string productName = row["TênSP"].ToString();
                string imagePath = Path.Combine(@"D:\LapTrinhTrucQuan\BTL_Store\Content\img\", brandName, productName, productName + @" Default\1.jpg");

                PictureBox pictureBox = new PictureBox()
                {
                    Width = 205,
                    Height = 160,
                    Padding = new Padding(20, 3, 0, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                pictureBox.Image = ResizeImage(imagePath, 205, 185);

                Label lblName = new Label
                {
                    Text = row["TênSP"].ToString(),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(13, 170)
                };

                Label lblPrice = new Label
                {
                    Text = "Price: $" + price.ToString(), // Hiển thị giá với 2 chữ số thập phân
                    AutoSize = true,
                    ForeColor = Color.FromArgb(255, 218, 165, 32),
                    Font = new Font("Arial", 14, FontStyle.Regular),
                    Location = new Point(10, 190),
                };

                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);

                AddClickEventToPanelControls(panel, customerId, productId, price);

                flowLayout.Controls.Add(panel);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            refreshFilter();
        }
        private void refreshFilter()
        {
            txtTenSP.Text = "";
            cboLocLoaiSP.SelectedIndex = 0;
            cboLocNCC.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lblTongTien.Text = "0";
            int customerId = getCustomerId();
            updateOrderStatus(customerId, -1);
            checkOrder();
        }
    }
}