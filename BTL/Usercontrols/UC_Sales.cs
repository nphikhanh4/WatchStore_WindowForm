
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
using SystemImage = System.Drawing.Image;
using SystemFont = System.Drawing.Font;

using iTextSharp.text.pdf;
using iTextSharp.text;


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

        private SystemImage ResizeImage(string imagePath, int width, int height)
        {
            try
            {
                SystemImage img = SystemImage.FromFile(imagePath);
                Bitmap resizedImage = new Bitmap(img, new Size(width, height));
                img.Dispose();
                return resizedImage;
            }
            catch (Exception)
            {
                SystemImage img = SystemImage.FromFile("D:\\BTL_Web\\Khanh\\Web\\WebApplication1\\Content\\img\\G-Shock\\G-Shock Dimesion\\G-Shock Dimesion.jpg");
                Bitmap resizedImage = new Bitmap(img, new Size(width, height));
                return resizedImage;
            }
        }

        private async Task<SystemImage> LoadImageAsync(string imagePath)
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
            int stockQuantity = 0;
            int currentItemQuantity = 0;

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
                    }
                }
                string getOrderItemQuantity = "SELECT Quantity FROM OrderItem as oi join [Order] as o on o.OrderID = oi.OrderID WHERE ProductID = @ProductID and OrderStatus = 0";
                using (SqlCommand getStockCommand = new SqlCommand(getOrderItemQuantity, connection))
                {
                    getStockCommand.Parameters.AddWithValue("@ProductID", productId);

                    object result = getStockCommand.ExecuteScalar();
                    if (result != null)
                    {
                        currentItemQuantity = Convert.ToInt32(result);
                    }
                }

                string getStockQuery = "SELECT StockQuantity FROM Product WHERE ProductID = @ProductID";
                using (SqlCommand getStockCommand = new SqlCommand(getStockQuery, connection))
                {
                    getStockCommand.Parameters.AddWithValue("@ProductID", productId);

                    object result = getStockCommand.ExecuteScalar();
                    if (result != null)
                    {
                        stockQuantity = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Product not found.");
                        return;
                    }
                }
            }

            if (customerId != 0)
            {
                if (stockQuantity > 0)
                {
                    if (currentItemQuantity == stockQuantity)
                    {
                        MessageBox.Show("Không đủ.");
                    }

                    else
                    {
                        addOrderItem(customerId, int.Parse(productId), price);
                    }
                }
                else
                {
                    MessageBox.Show("Hết hàng ròi.");
                }
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
                    string checkOrderQuery = @" SELECT OrderID FROM [Order] WHERE CustomerID = @CustomerID AND (OrderStatus = 0 OR OrderStatus IS NULL);";
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

                                bool productExists = false;
                                foreach (DataGridViewRow row in dgvCTHD.Rows)
                                {
                                    if (row.Cells["TenSP"].Value.ToString() == productName)
                                    {
                                        productExists = true;
                                        // Nếu sản phẩm đã có trong giỏ, cập nhật số lượng và tổng tiền
                                        int currentQuantity = (int)row.Cells["SoLuong"].Value;
                                        row.Cells["SoLuong"].Value = quantity;
                                        row.Cells["TongTien"].Value = ((quantity * unitPrice) * (100 - discount) / 100).ToString("N0");
                                        break;
                                    }
                                }
                                if (!productExists)
                                {
                                    dgvCTHD.Rows.Add(productName, unitPrice.ToString("N0"), discount, quantity, totalPrice.ToString("N0"), "-", "+");
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

            // Column 5: Decrease quantity
            if (e.ColumnIndex == 5)
            {
                if(e.RowIndex == -1)
                {
                    return;
                }
                string productName = dgvCTHD.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                int orderId = getOrderId(customerId);
                int productId = getProductIdByName(productName);
                int currentQuantity = (int)dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value;
                if (currentQuantity > 1)
                {
                    UpdateQuantity(orderId, productId, currentQuantity - 1);
                    dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value = currentQuantity - 1;

                    decimal unitPrice = decimal.Parse(dgvCTHD.Rows[e.RowIndex].Cells["DonGia"].Value.ToString())
                        * (100 - (int)dgvCTHD.Rows[e.RowIndex].Cells["KM"].Value) / 100;
                    decimal newTotalPrice = unitPrice * (currentQuantity - 1);
                    dgvCTHD.Rows[e.RowIndex].Cells["TongTien"].Value = newTotalPrice.ToString("N0");
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
                if (e.RowIndex == -1)
                {
                    return;
                }
                string productName = dgvCTHD.Rows[e.RowIndex].Cells["TenSP"].Value.ToString();
                int orderId = getOrderId(customerId);
                int productId = getProductIdByName(productName);
                int currentQuantity = (int)dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value;
                if (getQuantityByProductId(productId) == currentQuantity)
                {
                    MessageBox.Show("Không đủ số lượng.");
                }
                else
                {
                    UpdateQuantity(orderId, productId, currentQuantity + 1);
                    dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value = currentQuantity + 1;

                    decimal unitPrice = decimal.Parse(dgvCTHD.Rows[e.RowIndex].Cells["DonGia"].Value.ToString())
                            * (100 - (int)dgvCTHD.Rows[e.RowIndex].Cells["KM"].Value) / 100;
                    decimal newTotalPrice = unitPrice * (currentQuantity + 1);
                    dgvCTHD.Rows[e.RowIndex].Cells["TongTien"].Value = newTotalPrice.ToString("N0");

                    updateUnitPrice(orderId, unitPrice, productId);
                }
            }
            CalculateTotalPrice();
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

        private int getQuantityByProductId(int productId)
        {
            int stockQuantity = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getStockQuery = "SELECT StockQuantity FROM Product WHERE ProductID = @ProductID";
                using (SqlCommand command = new SqlCommand(getStockQuery, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);
                    object result = command.ExecuteScalar();

                    stockQuantity = Convert.ToInt32(result);

                }
            }
            return stockQuantity;
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
                        AND (OrderStatus = 0 OR OrderStatus = 2 OR OrderStatus IS NULL);";

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
                            SET OrderStatus = @orderStatus,
                            OrderDate = GETDATE()
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

        private void updateStockQuantity(int customerId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string fetchOrderItemsQuery = @"
                SELECT 
                    oi.ProductID, 
                    oi.Quantity 
                FROM OrderItem oi
                INNER JOIN [Order] o ON oi.OrderID = o.OrderID
                WHERE o.CustomerID = @CustomerID AND o.OrderStatus = 0";

                    using (SqlCommand fetchCommand = new SqlCommand(fetchOrderItemsQuery, connection))
                    {
                        fetchCommand.Parameters.AddWithValue("@CustomerID", customerId);
                        using (SqlDataReader reader = fetchCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = (int)reader["ProductID"];
                                int quantity = (int)reader["Quantity"];

                                updateProductStock(productId, quantity);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void updateProductStock(int productId, int quantity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateStockQuery = @"
                        UPDATE Product
                        SET StockQuantity = StockQuantity - @Quantity
                        WHERE ProductID = @ProductID";

                    using (SqlCommand updateCommand = new SqlCommand(updateStockQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Quantity", quantity);
                        updateCommand.Parameters.AddWithValue("@ProductID", productId);

                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product stock: " + ex.Message);
            }
        }



        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int customerId = getCustomerId();
            try
            {
                decimal paidAmount = decimal.Parse(txtTienKHTra.Text.Replace(" đ", "").Replace(",", ""));
                string totalPriceText = lblTongTien.Text.Replace(" đ", "").Replace(",", "").Trim();
                decimal totalPrice = decimal.Parse(totalPriceText);

                txtTienThua.Text = CalculateRemainingBalance(paidAmount, totalPrice).ToString("N0");
                updateTotalPrice(customerId, totalPrice);
                updateStockQuantity(customerId);
                updateOrderStatus(customerId, 2);
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
            inHoaDon();
        }

        private void txtTienKHTra_TextChanged(object sender, EventArgs e)
        {
            string input = txtTienKHTra.Text.Replace(",", "").Trim();

            if (string.IsNullOrWhiteSpace(txtTienKHTra.Text))
            {
                label11.Visible = false;
            }
            else
            {
                label11.Visible = true;
            }

            if (decimal.TryParse(input, out decimal paidAmount))
            {
                txtTienKHTra.Text = paidAmount.ToString("N0");
                txtTienKHTra.SelectionStart = txtTienKHTra.Text.Length;

                string totalPriceText = lblTongTien.Text.Replace(" đ", "").Replace(",", "");
                decimal totalPrice = decimal.Parse(totalPriceText);

                bool successful = (paidAmount >= totalPrice);

                if (successful)
                {
                    txtTienThua.Text = CalculateRemainingBalance(paidAmount, totalPrice).ToString("N0");
                    label13.Visible = true;
                    btnThanhToan.Enabled = true;
                    btnThanhToan.BackColor = Color.Blue;
                }
                else
                {
                    btnThanhToan.Enabled = false;
                    btnThanhToan.BackColor = Color.Gray;
                    txtTienThua.Text = CalculateRemainingBalance(paidAmount, totalPrice).ToString("N0");
                    label13.Visible = true;
                }
            }
            else
            {
                txtTienThua.Text = "";
                label13.Visible = false;
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
                    BackColor = Color.LightGray,
                    Margin = new Padding(5),
                };

                decimal price = row["DonGiaBan"] != DBNull.Value ? Convert.ToDecimal(row["DonGiaBan"]) : 0m;
                string brandName = row["BrandName"].ToString();
                string productId = row["MãSP"].ToString();
                string stockQuantity = row["SoLuong"].ToString();
                string productName = row["TênSP"].ToString();
                string discount = row["KhuyenMai"].ToString();
                string imageProduct = row["LinkHinhAnh"].ToString();
                string imagePath = Path.Combine(@"D:\BTL_W\BTL_W\BTL\Images", imageProduct);
                decimal reducedPrice = price * (100 - int.Parse(discount)) / 100;

                PictureBox pictureBox = new PictureBox()
                {
                    Width = 185,
                    Height = 145,
                    Padding = new Padding(35, 3, 0, 0),
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (productName == "Casio Edifice")
                {
                    pictureBox.Image = ResizeImage(@"D:\BTL_Web\Khanh\Web\WebApplication1\Content\img\Casio\Casio Sheen\Casio Sheen.jpg", 185, 145);
                }
                else
                {
                    pictureBox.Image = ResizeImage(imagePath, 185, 145);
                }

                Label lblName = new Label
                {
                    Text = row["TênSP"].ToString(),
                    AutoSize = true,
                    Font = new SystemFont("Arial", 9, FontStyle.Bold),
                    Location = new Point(13, 155)
                };

                Label lblPrice = new Label
                {
                    Text = "Price: $" + reducedPrice.ToString("N0"),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(255, 218, 165, 32),
                    Font = new SystemFont("Arial", 13, FontStyle.Regular),
                    Location = new Point(10, 175),
                };

                Label lblRealPrice = new Label
                {
                    Text = price.ToString("N0"),
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Font = new SystemFont("Arial", 12, FontStyle.Regular),
                    Location = new Point(20, 200),
                };

                lblRealPrice.Paint += (sender, e) =>
                {
                    Label label = sender as Label;
                    if (label != null)
                    {
                        Size textSize = TextRenderer.MeasureText(label.Text, label.Font);
                        int lineY = textSize.Height / 2 + label.Padding.Top;

                        e.Graphics.DrawLine(new Pen(Color.Gray), 0, lineY, textSize.Width, lineY);
                    }
                };

                Label lblDiscount = null;

                if (discount != "0")
                {
                    lblDiscount = new Label
                    {
                        Text = "-" + discount + "%",
                        Width = 40,
                        Height = 25,
                        Location = new Point(180, 0),
                        BackColor = Color.Red,
                        Font = new SystemFont("Arial", 8, FontStyle.Regular),
                        TextAlign = ContentAlignment.MiddleCenter
                    };
                }

                string stockQuantityText = "Còn : " + stockQuantity;
                if (int.Parse(stockQuantity) <= 0)
                    stockQuantityText = "Hết Hàng!";

                Label StockQuantity = new Label
                {
                    Text = stockQuantityText,
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Font = new SystemFont("Arial", 7, FontStyle.Regular),
                    Location = new Point(160, 205),
                };



                panel.Controls.Add(pictureBox);
                panel.Controls.Add(lblName);
                panel.Controls.Add(lblPrice);
                panel.Controls.Add(StockQuantity);

                if (lblDiscount != null) // Kiểm tra nếu lblDiscount được khởi tạo
                {
                    panel.Controls.Add(lblDiscount);
                    lblDiscount.BringToFront();
                    panel.Controls.Add(lblRealPrice);

                }

                AddClickEventToPanelControls(panel, customerId, productId, reducedPrice);
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
        private void inHoaDon()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f);
            iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream("D:/HoaDon.pdf", FileMode.Create));
            document.Open();
            string fontPath = @"C:\Windows\Fonts\tahoma.ttf";
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(baseFont, 12);


            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 20, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph("HÓA ĐƠN BÁN HÀNG", headerFont);
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            iTextSharp.text.Paragraph dashedLine = new iTextSharp.text.Paragraph("-------------------------------------------", vietnameseFont);
            dashedLine.Alignment = Element.ALIGN_CENTER;
            document.Add(dashedLine);


            iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph($"Ngày lập: {DateTime.Now:dd/MM/yyyy HH:mm}", vietnameseFont);
            date.Alignment = Element.ALIGN_RIGHT;
            document.Add(date);
            document.Add(new iTextSharp.text.Paragraph("\n"));

            document.Add(new iTextSharp.text.Paragraph("Cửa hàng: Watch Store", vietnameseFont));
            document.Add(new iTextSharp.text.Paragraph("Địa chỉ: 450-451 Lê Văn Việt, Phường Tăng Nhơn Phú A, Hồ Chí Minh, Việt Nam", vietnameseFont));
            document.Add(new iTextSharp.text.Paragraph("Nhân viên: Nguyễn Văn A", vietnameseFont));

            document.Add(dashedLine);

            DataTable dt = KhachHangBL.GetInstance.GetCustomerById(getCustomerId());
            string printName = "Khách hàng: ";
            string printPhone = "Số điện thoại: ";
            string printAddress = "Địa chỉ: ";
            int cusID = 0;
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                printName += row["FullName"].ToString();
                printPhone += row["Phone"].ToString();
                printAddress += row["Address"].ToString();
                cusID = int.Parse(row["CustomerID"].ToString());
            }
            else Console.WriteLine("Ko tìm thấy customer.");

            document.Add(new iTextSharp.text.Paragraph(printName, vietnameseFont));
            document.Add(new iTextSharp.text.Paragraph(printPhone, vietnameseFont));
            document.Add(new iTextSharp.text.Paragraph(printAddress, vietnameseFont));

            document.Add(new iTextSharp.text.Paragraph("\n"));

            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(4);
            table.WidthPercentage = 100;

            table.AddCell(new iTextSharp.text.Phrase("STT", vietnameseFont));
            table.AddCell(new iTextSharp.text.Phrase("Tên sản phẩm", vietnameseFont));
            table.AddCell(new iTextSharp.text.Phrase("Số lượng", vietnameseFont));
            table.AddCell(new iTextSharp.text.Phrase("Giá (VND)", vietnameseFont));

            DataTable pd = ProductBL.GetInstance.GetProductToPrint(getCustomerId());
            int i = 1;
            decimal total = pd.AsEnumerable()
                  .Sum(row => row.Field<decimal?>("SubPrice") ?? 0);

            foreach (DataRow row in pd.Rows)
            {
                table.AddCell(new iTextSharp.text.Phrase(i.ToString(), vietnameseFont));
                table.AddCell(new iTextSharp.text.Phrase(row["ProductName"].ToString(), vietnameseFont));
                table.AddCell(new iTextSharp.text.Phrase(Convert.ToInt32(row["Quantity"]).ToString(), vietnameseFont));
                table.AddCell(new iTextSharp.text.Phrase(Convert.ToDecimal(row["SubPrice"]).ToString("N0"), vietnameseFont));
                i++;
            }

            iTextSharp.text.pdf.PdfPCell totalCell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Tổng cộng", vietnameseFont));
            totalCell.Colspan = 3;
            totalCell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(totalCell);
            table.AddCell(new iTextSharp.text.Phrase(total.ToString("N0"), vietnameseFont));

            document.Add(table);
            document.Add(new iTextSharp.text.Paragraph("\n"));
            document.Add(new iTextSharp.text.Paragraph("\n"));

            document.Add(dashedLine);

            iTextSharp.text.Font thankFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Paragraph thank = new iTextSharp.text.Paragraph($"Cảm ơn quý khách đã mua hàng ở Watch Store\nChúc quý khách một ngày tốt lành!", thankFont);
            thank.Alignment = Element.ALIGN_CENTER;
            document.Add(thank);
            document.Close();

            MessageBox.Show("Hóa đơn PDF đã được tạo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            updateOrderStatus(cusID, 1);
            checkOrder();

            try
            {
                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "D:/HoaDon.pdf", // File path
                    UseShellExecute = true      // Required to open with default application
                };
                System.Diagnostics.Process.Start(processInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở file PDF. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                btnThanhToan_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnHuy_Click(sender, e);
            }
        }

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCTHD_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}