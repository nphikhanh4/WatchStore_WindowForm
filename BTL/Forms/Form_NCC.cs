using BLL;
using DAL;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
                dgvNCC.Columns.Clear();

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
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dgvNCC.Rows[e.RowIndex];
                    txtTen.Text = selectedRow.Cells["ContactName"].Value.ToString();
                    txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                    txtDiaChi.Text = selectedRow.Cells["Address"].Value.ToString();
                    txtSDT.Text = selectedRow.Cells["Phone"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
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
                if (dgvNCC.SelectedRows.Count > 0)
                {
                    int supplierID = Convert.ToInt32(dgvNCC.SelectedRows[0].Cells["SupplierID"].Value);

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
                        bool isRemoved = SupplierProductBL.GetInstance.UpdateSupplierRemove(supplierID, 0); 

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
                if (dgvNCC.SelectedRows.Count > 0)
                {
                    int supplierID = Convert.ToInt32(dgvNCC.SelectedRows[0].Cells["SupplierID"].Value);

                    if (supplierID > 0)
                    {
                        string contactName = txtTen.Text.Trim();
                        string phone = txtSDT.Text.Trim();
                        string email = txtEmail.Text.Trim();
                        string address = txtDiaChi.Text.Trim();

                        if (string.IsNullOrEmpty(contactName) || string.IsNullOrEmpty(phone) ||
                            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; 
                        }
                        if (!email.EndsWith("@gmail.com"))
                        {
                            MessageBox.Show("Email phải có đuôi @gmail.com!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (phone.Length != 10 || !phone.All(char.IsDigit))
                        {
                            MessageBox.Show("Số điện thoại phải có đúng 10 chữ số và chỉ chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string message = $"Thông tin nhà cung cấp:\n" +
                                         $"ID NCC: {supplierID}\n" +
                                         $"Tên: {contactName}\n" +
                                         $"SĐT: {phone}\n" +
                                         $"Email: {email}\n" +
                                         $"Địa chỉ: {address}\n\n" +
                                         "Bạn có chắc chắn muốn cập nhật nhà cung cấp này?";

                        DialogResult result = MessageBox.Show(message, "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            bool isUpdated = SupplierProductBL.GetInstance.UpdateSupplier(
                                supplierID,
                                contactName,
                                phone,
                                email,
                                address
                            );

                            if (isUpdated)
                            {
                                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDataGridView(); 
                                ClearTxt();  
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhà cung cấp chưa tồn tại hoặc ID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một nhà cung cấp để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiện thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string contactName = txtTen.Text.Trim();
            string phone = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtDiaChi.Text.Trim();

            if (string.IsNullOrEmpty(contactName) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!email.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email phải có đuôi @gmail.com!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số và chỉ chứa số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isAdded = SupplierProductBL.GetInstance.AddSupplier(contactName, phone, email, address);

            if (isAdded)
            {
                MessageBox.Show("Nhà cung cấp đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                ClearTxt();
                 Form_ChonNCC chon = new Form_ChonNCC();
                chon.LoadComboBoxData();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại! - Nhà cung cấp đã tồn tại ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
    }
}
