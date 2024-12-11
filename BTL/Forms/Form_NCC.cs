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

namespace DONGHO.Forms
{
    public partial class Form_NCC : Form
    {
        public Form_NCC()
        {
            InitializeComponent();
            LoadDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadDataGridView()
        {
            try
            {
                DataTable dt = SupplierDL.GetInstance.GetDanhSachNhaCungCap();
                DataRow[] filteredRows = dt.Select("check_Remove = 1");
                // Xóa cột cũ trước khi thêm dữ liệu
                dgvNCC.Columns.Clear();

                // Tạo cột hiển thị dữ liệu
                dgvNCC.Columns.Add("SupplierID", "Mã NCC");
                dgvNCC.Columns.Add("ContactName", "Tên NCC");
                dgvNCC.Columns.Add("Phone", "SĐT");
                dgvNCC.Columns.Add("Email", "Email");
                dgvNCC.Columns.Add("Address", "Địa chỉ");
                dgvNCC.Columns.Add("CreatedAt", "Ngày hợp tác");

                foreach (DataRow row in filteredRows)
                {
                    int rowIndex = dgvNCC.Rows.Add();

                    dgvNCC.Rows[rowIndex].Cells["SupplierID"].Value = row["SupplierID"];
                    dgvNCC.Rows[rowIndex].Cells["ContactName"].Value = row["ContactName"];
                    dgvNCC.Rows[rowIndex].Cells["Phone"].Value = row["Phone"];
                    dgvNCC.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                    dgvNCC.Rows[rowIndex].Cells["Address"].Value = row["Address"];
                    dgvNCC.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }




        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng click vào một dòng (có thể không phải là header hoặc ngoài vùng dữ liệu)
                if (e.RowIndex >= 0)
                {
                    // Lấy dòng dữ liệu đã chọn
                    DataGridViewRow selectedRow = dgvNCC.Rows[e.RowIndex];

                    // Gán dữ liệu từ các cột vào các TextBox tương ứng
                    txtTen.Text = selectedRow.Cells["ContactName"].Value.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                    txtDiaChi.Text = selectedRow.Cells["Address"].Value.ToString();
                    txtSDT.Text = selectedRow.Cells["Phone"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
            }
        }
        private void ClearTxt()
        {
            txtTen.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu một dòng được chọn trong DataGridView
                if (dgvNCC.SelectedRows.Count > 0)
                {
                    // Lấy SupplierID từ dòng được chọn
                    int supplierID = Convert.ToInt32(dgvNCC.SelectedRows[0].Cells["SupplierID"].Value);

                    // Lấy thông tin nhà cung cấp từ các ô của dòng được chọn
                    string contactName = dgvNCC.SelectedRows[0].Cells["ContactName"].Value.ToString();
                    string phone = dgvNCC.SelectedRows[0].Cells["Phone"].Value.ToString();
                    string email = dgvNCC.SelectedRows[0].Cells["Email"].Value.ToString();
                    string address = dgvNCC.SelectedRows[0].Cells["Address"].Value.ToString();

                    string message = $"Thông tin nhà cung cấp:\n" +
                                     $"ID NCC: {supplierID}\n" +
                                     $"Tên: {contactName}\n" +
                                     $"SĐT: {phone}\n" +
                                     $"Email: {email}\n" +
                                     $"Địa chỉ: {address}\n\n" +
                                     "Bạn có chắc chắn muốn xóa nhà cung cấp này?";

                    DialogResult result = MessageBox.Show(message, "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        bool isRemoved = SupplierProductBL.GetInstance.UpdateSupplierRemove(supplierID, 0); // 1 có thể là trạng thái xóa, ví dụ

                        if (isRemoved)
                        {
                            MessageBox.Show("Nhà cung cấp đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataGridView();
                            ClearTxt();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thao tác: " + ex.Message);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có dòng được chọn trong DataGridView
                if (dgvNCC.SelectedRows.Count > 0)
                {
                    // Lấy SupplierID từ dòng được chọn
                    int supplierID = Convert.ToInt32(dgvNCC.SelectedRows[0].Cells["SupplierID"].Value);

                    // Kiểm tra nếu SupplierID hợp lệ
                    if (supplierID > 0)
                    {
                        // Lấy thông tin từ các ô TextBox
                        string contactName = txtTen.Text.Trim();
                        string phone = txtSDT.Text.Trim();
                        string email = txtEmail.Text.Trim();
                        string address = txtDiaChi.Text.Trim();

                        // Kiểm tra nếu có trường nào bị rỗng
                        if (string.IsNullOrEmpty(contactName) || string.IsNullOrEmpty(phone) ||
                            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Dừng việc cập nhật nếu có trường bị bỏ trống
                        }

                        // Tạo thông báo xác nhận trước khi cập nhật
                        string message = $"Thông tin nhà cung cấp:\n" +
                                         $"ID NCC: {supplierID}\n" +
                                         $"Tên: {contactName}\n" +
                                         $"SĐT: {phone}\n" +
                                         $"Email: {email}\n" +
                                         $"Địa chỉ: {address}\n\n" +
                                         "Bạn có chắc chắn muốn cập nhật nhà cung cấp này?";

                        // Hiển thị hộp thoại xác nhận
                        DialogResult result = MessageBox.Show(message, "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // Nếu người dùng chọn Yes (OK)
                        if (result == DialogResult.Yes)
                        {
                            // Gọi phương thức UpdateSupplier để thực hiện cập nhật
                            bool isUpdated = SupplierProductBL.GetInstance.UpdateSupplier(
                                supplierID,
                                contactName,
                                phone,
                                email,
                                address
                            );

                            // Kiểm tra kết quả cập nhật
                            if (isUpdated)
                            {
                                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataGridView();  // Tải lại dữ liệu trong DataGridView
                                ClearTxt();  // Xóa giá trị các TextBox
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        // Nếu SupplierID không hợp lệ (0 hoặc không tồn tại)
                        MessageBox.Show("Nhà cung cấp chưa tồn tại hoặc ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Nếu không có dòng nào được chọn
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ và hiển thị thông báo lỗi cho người dùng
                MessageBox.Show("Lỗi khi thực hiện thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            // Lấy thông tin từ các ô TextBox
            string contactName = txtTen.Text.Trim();
            string phone = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtDiaChi.Text.Trim();

            // Kiểm tra các trường hợp thông tin trống
            if (string.IsNullOrEmpty(contactName) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi phương thức trong lớp BL để thêm nhà cung cấp
            bool isAdded = SupplierProductBL.GetInstance.AddSupplier(contactName, phone, email, address);

            if (isAdded)
            {
                MessageBox.Show("Nhà cung cấp đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Load lại dữ liệu hoặc thực hiện hành động khác
                LoadDataGridView();
                ClearTxt();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại! - Nhà cung cấp đã tồn tại ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}