using DONGHO.Usercontrols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book
{
    public partial class Form_DashBoard : Form
    {
        public string ReceivedData_Name { get; set; }
        public string ReceivedData_Role { get; set; }

        int PanelWidth;
        bool isCollapsed;
        public Form_DashBoard()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 70)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }

        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void BtnSaleBooks_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSaleBooks);

            UC_Sales ucS = new UC_Sales();
            AddControlsToPanel(ucS);
        }

        private void BtnPurchase_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPurchase);
            uc_SanPham ucP = new uc_SanPham();
            AddControlsToPanel(ucP);
        }

        //private void BtnExpense_Click(object sender, EventArgs e)
        //{
        //    moveSidePanel(btnExpense);
        //    UC_MuaHang ucE = new UC_MuaHang();
        //    AddControlsToPanel(ucE);
        //}

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUsers);
            UC_KhachHang ucK = new UC_KhachHang();
            AddControlsToPanel(ucK);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSettings);
            uc_CaiDat ucC = new uc_CaiDat();
            AddControlsToPanel(ucC);

        }

        private void PanelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelControls_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnWareHouse_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnWareHouse);
            UC_WareHouse ucW = new UC_WareHouse();
            AddControlsToPanel(ucW);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnNhanVien);
            UC_NhanVien ucW = new UC_NhanVien();
            AddControlsToPanel(ucW);
        }
    }
}
