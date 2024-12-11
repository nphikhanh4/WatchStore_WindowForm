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
using Book;
using DAL;
using Microsoft.VisualBasic.ApplicationServices;
namespace DONGHO.Forms
{

    public partial class Form_DangNhap : Form
    {
        public static string role;
        public static string name;
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        public static int Quyen;
        public static string TenDangNhap;

        private void Login_close_Click(object sender, EventArgs e)
        {
            this.Close();



        }

        private void Login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showPass.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            XuLyDangNhap();
       
        }

        public void Alert(string msg, Form_Notification.enmType type)
        {
            Form_Notification frm = new Form_Notification();
            frm.TopMost = true;
            frm.showAlert(msg, type);
        }
    
        private int failedLoginAttempts = 0;
        private const int MaxLoginAttempts = 3;
        private void XuLyDangNhap()
        {
            Cursor = Cursors.AppStarting;

            try
            {
                string username = txtTenDangNhap.Text.Trim();
                string password = txtMatKhau.Text;

                // Kiểm tra thông tin đầu vào
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Giới hạn số lần đăng nhập sai
                if (failedLoginAttempts >= MaxLoginAttempts)
                {
                    MessageBox.Show("Bạn đã nhập sai quá nhiều lần. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gọi tầng BLL để kiểm tra đăng nhập
                if (SignupBL.GetInstance.CheckLogin(username, password))
                {
                    role = SignupBL.GetInstance.GetRole(username);
                    name = SignupBL.GetInstance.GetName(username);
                    TenDangNhap = username;

                  //  MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset thông tin nhập
                    ResetLoginFields();

                    // Chuyển đến dashboard

                    Form_DashBoard dashboard = new Form_DashBoard();
                    dashboard.ReceivedData_Role = role;
                    dashboard.ReceivedData_Name = name;
                    dashboard.Show();
                    this.Hide();
                    
                }
                else
                {
                    failedLoginAttempts++;
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                MessageBox.Show("Đã xảy ra lỗi trong quá trình đăng nhập. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void ResetLoginFields()
        {
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
        }

        private void LogError(Exception ex)
        {
            // Ghi log lỗi ra file hoặc database (tùy bạn implement)
            Console.WriteLine(ex.Message);
        }
       
        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                XuLyDangNhap();
            }
        }
        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                btnDangNhap.BackColor = Color.DimGray;
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" && txtMatKhau.Text != "")
            {
                btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            }
            else
            {
                btnDangNhap.BackColor = Color.DimGray;
            }
        }
       
    }
}
