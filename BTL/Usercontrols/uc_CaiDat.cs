
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
using BLL;
using DAL;
namespace DONGHO.Usercontrols
{
    public partial class uc_CaiDat : UserControl
    {
        public uc_CaiDat()
        {
            InitializeComponent();
        }


        bool b = false;
        private void txtNhapLai_TextChanged(object sender, EventArgs e)
        {
            if (txtNhapLai.Text == "")
            {
                lblNhapLai.Visible = false;
                b = true;
                return;
            }
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                lblNhapLai.Visible = true;
            }
            if (txtMatKhauMoi.Text == txtNhapLai.Text)
            {
                lblNhapLai.Visible = false;
                b = true;
            }
        }

        //Load lai du lieu


        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Ensure the button click logic is only executed when 'b' is true
            if (!b)
                return;

            // Validate new password length
            string newPassword = txtMatKhauMoi.Text;
            if (newPassword.Length < 8 || newPassword.Length > 20)
            {
                ShowNotification("Mật khẩu phải từ 8 đến 20 ký tự!");
                return;
            }

            // Check current password
            string currentUsername = Form_DangNhap.TenDangNhap.ToString();
            string currentPassword = txtMatKhauHienTai.Text;

            if (SignupBL.GetInstance.CheckLogin(currentUsername, currentPassword))
            {
                // Proceed to change the password
                SignupBL.GetInstance.DoiMatKhau(currentUsername, newPassword);

                // Show success alert
                this.Alert("Đã đổi mật khẩu thành công!", Form_Notification.enmType.Success);

                // Clear input fields and hide labels
                txtNhapLai.Clear();
                txtMatKhauMoi.Clear();
                txtMatKhauHienTai.Clear();
                lblNhapLai.Visible = false;


            }
            else
            {
                // Show error for incorrect current password
                lblMatKhauHienTai.Visible = true;
                txtNhapLai.Clear();
                txtMatKhauMoi.Clear();
                lblNhapLai.Visible = false;

                // Reset 'b' if necessary
                b = false;
            }
        }

        // Helper method to show a notification in a modal dialog
        private void ShowNotification(string message)
        {
            Form_ThongBao frm = new Form_ThongBao();
            frm.lblThongBao.Text = message;
            frm.ShowDialog();
        }

        public void Alert(string msg, Form_Notification.enmType type)
        {
            Form_Notification frm = new Form_Notification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }

        private void txtMatKhauHienTai_TextChanged(object sender, EventArgs e)
        {
            lblMatKhauHienTai.Visible = false;
        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {
            if (txtNhapLai.Text == "")
            {
                return;
            }
            if (txtMatKhauMoi.Text != txtNhapLai.Text)
            {
                lblNhapLai.Visible = true;
            }
            if (txtMatKhauMoi.Text == txtNhapLai.Text)
            {
                lblNhapLai.Visible = false;
                b = true;
            }
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            Form_DangXuat form_DangXuat = new Form_DangXuat();
            form_DangXuat.Show();
        }
    }
}
