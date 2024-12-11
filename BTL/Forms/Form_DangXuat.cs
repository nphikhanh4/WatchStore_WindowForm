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
    public partial class Form_DangXuat : Form
    {
        public Form_DangXuat()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Duyệt qua tất cả các form đang mở
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                // Kiểm tra nếu form không phải là form đăng nhập
                if (form.Name != "Form_DangNhap")
                {
                    form.Close();  // Đóng form
                }
            }
            SignupDL.GetInstance.GetDanhSachAdmin();
            // Mở lại form đăng nhập
            Form_DangNhap loginForm = new Form_DangNhap();
            loginForm.Show();

            // Đóng form hiện tại (ví dụ form Dashboard)
            this.Close();
        }
    }
}
