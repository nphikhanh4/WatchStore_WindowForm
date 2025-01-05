using BLL;
using DTO;
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
    public partial class Form_LoaiSP : Form
    {
        public Form_LoaiSP()
        {
            InitializeComponent();
            LoadDataGridView();
        }

       
        private void Button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadDataGridView()
        {
            dgvLoaiSanPham.DataSource = CategoryBL.GetInstance.GetDanhSachLoaiSanPham();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        public bool b = false;
        int maloaisp = 0;
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtTen.Text == "")
            {
                txtTen.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (k == 1)
            {
                Form_ThongBao frm = new Form_ThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin loại sản phẩm";
                frm.ShowDialog();
                return;
            }
            CategoryDTO lspDTO = new CategoryDTO();
            lspDTO.CategoryName = txtTen.Text;
            if (CategoryBL.GetInstance.ThemLoaiSanPham(lspDTO))
            {
                picThanhCong.Visible = true;
                timer.Start();
                LoadDataGridView();
                txtTen.Text = "";
                b = true;
            }

        }


        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (CategoryBL.GetInstance.NgungKinhDoanh(maloaisp.ToString()))
            {
                picThanhCong.Visible = true;
                txtTen.Text = "";
                LoadDataGridView();
                timer.Start();
                b = true;
            }

        }


        private void txtTen_Click(object sender, EventArgs e)
        {
            if (txtTen.BackColor == Color.OrangeRed)
            {
                txtTen.BackColor = Color.FromArgb(26, 26, 26);
            }
        }
        int i = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 20)
            {
                picThanhCong.Visible = false;
                timer.Stop();
                i = 0;
            }
        }

        private void dgvLoaiSanPham_Click(object sender, EventArgs e)
        {
            if (dgvLoaiSanPham.SelectedRows.Count == 1)
            {
                if (txtTen.BackColor == Color.OrangeRed)
                {
                    txtTen.BackColor = Color.FromArgb(51, 51, 51);
                }
                DataGridViewRow dr = dgvLoaiSanPham.SelectedRows[0];
                maloaisp = int.Parse(dr.Cells["CategoryID"].Value.ToString().Trim());
                txtTen.Text = dr.Cells["CategoryName"].Value.ToString().Trim();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int k = 0;
            if (txtTen.Text == "")
            {
                txtTen.BackColor = Color.OrangeRed;
                k = 1;
            }
            if (k == 1)
            {
                Form_ThongBao frm = new Form_ThongBao();
                frm.lblThongBao.Text = "Bạn chưa nhập đủ thông tin loại sản phẩm";
                frm.ShowDialog();
                return;
            }
            CategoryDTO lspDTO = new CategoryDTO();
            lspDTO.CategoryID = maloaisp;
            lspDTO.CategoryName = txtTen.Text;
            if (CategoryBL.GetInstance.CapNhatLoaiSanPham(lspDTO))
            {
                picThanhCong.Visible = true;
                timer.Start();
                LoadDataGridView();
                txtTen.Text = "";
                b = true;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
