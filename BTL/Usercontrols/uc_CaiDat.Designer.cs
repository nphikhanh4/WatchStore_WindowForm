namespace DONGHO.Usercontrols
{
    partial class uc_CaiDat
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_CaiDat));
            tableLayoutPanel3 = new TableLayoutPanel();
            pnlThongTinKhachHang = new Panel();
            btnDangXuat = new Button();
            btnXacNhan = new Button();
            txtNhapLai = new TextBox();
            label5 = new Label();
            txtMatKhauMoi = new TextBox();
            txtMatKhauHienTai = new TextBox();
            label12 = new Label();
            lblMatKhauHienTai = new Label();
            lblNhapLai = new Label();
            label10 = new Label();
            panel8 = new Panel();
            label3 = new Label();
            tableLayoutPanel3.SuspendLayout();
            pnlThongTinKhachHang.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Silver;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(pnlThongTinKhachHang, 0, 1);
            tableLayoutPanel3.Controls.Add(panel8, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 6.389776F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 93.61022F));
            tableLayoutPanel3.Size = new Size(1643, 963);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // pnlThongTinKhachHang
            // 
            pnlThongTinKhachHang.BackColor = Color.White;
            pnlThongTinKhachHang.Controls.Add(btnDangXuat);
            pnlThongTinKhachHang.Controls.Add(btnXacNhan);
            pnlThongTinKhachHang.Controls.Add(txtNhapLai);
            pnlThongTinKhachHang.Controls.Add(label5);
            pnlThongTinKhachHang.Controls.Add(txtMatKhauMoi);
            pnlThongTinKhachHang.Controls.Add(txtMatKhauHienTai);
            pnlThongTinKhachHang.Controls.Add(label12);
            pnlThongTinKhachHang.Controls.Add(lblMatKhauHienTai);
            pnlThongTinKhachHang.Controls.Add(lblNhapLai);
            pnlThongTinKhachHang.Controls.Add(label10);
            pnlThongTinKhachHang.Dock = DockStyle.Fill;
            pnlThongTinKhachHang.ForeColor = Color.Black;
            pnlThongTinKhachHang.Location = new Point(4, 66);
            pnlThongTinKhachHang.Margin = new Padding(4, 5, 4, 5);
            pnlThongTinKhachHang.Name = "pnlThongTinKhachHang";
            pnlThongTinKhachHang.Size = new Size(1635, 892);
            pnlThongTinKhachHang.TabIndex = 55;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.FromArgb(17, 145, 249);
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Image = (Image)resources.GetObject("btnDangXuat.Image");
            btnDangXuat.ImageAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.Location = new Point(812, 349);
            btnDangXuat.Margin = new Padding(4, 5, 4, 5);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(163, 57);
            btnDangXuat.TabIndex = 78;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.TextAlign = ContentAlignment.MiddleRight;
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += BtnDangXuat_Click;
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.FromArgb(17, 145, 249);
            btnXacNhan.FlatAppearance.BorderSize = 0;
            btnXacNhan.FlatStyle = FlatStyle.Flat;
            btnXacNhan.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.ForeColor = Color.White;
            btnXacNhan.Image = Properties.Resources.Synchronize1;
            btnXacNhan.ImageAlign = ContentAlignment.MiddleLeft;
            btnXacNhan.Location = new Point(588, 349);
            btnXacNhan.Margin = new Padding(4, 5, 4, 5);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(163, 57);
            btnXacNhan.TabIndex = 3;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.TextAlign = ContentAlignment.MiddleRight;
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // txtNhapLai
            // 
            txtNhapLai.BackColor = Color.White;
            txtNhapLai.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNhapLai.ForeColor = Color.Black;
            txtNhapLai.Location = new Point(588, 295);
            txtNhapLai.Margin = new Padding(4, 5, 4, 5);
            txtNhapLai.Name = "txtNhapLai";
            txtNhapLai.PasswordChar = '●';
            txtNhapLai.Size = new Size(451, 34);
            txtNhapLai.TabIndex = 2;
            txtNhapLai.TextChanged += txtNhapLai_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(367, 302);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(204, 25);
            label5.TabIndex = 76;
            label5.Text = "Nhập lại mật khẩu mới";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.BackColor = Color.White;
            txtMatKhauMoi.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhauMoi.ForeColor = Color.Black;
            txtMatKhauMoi.Location = new Point(588, 240);
            txtMatKhauMoi.Margin = new Padding(4, 5, 4, 5);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '●';
            txtMatKhauMoi.Size = new Size(451, 34);
            txtMatKhauMoi.TabIndex = 1;
            txtMatKhauMoi.TextChanged += txtMatKhauMoi_TextChanged;
            // 
            // txtMatKhauHienTai
            // 
            txtMatKhauHienTai.BackColor = Color.White;
            txtMatKhauHienTai.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhauHienTai.ForeColor = Color.Black;
            txtMatKhauHienTai.Location = new Point(588, 185);
            txtMatKhauHienTai.Margin = new Padding(4, 5, 4, 5);
            txtMatKhauHienTai.Name = "txtMatKhauHienTai";
            txtMatKhauHienTai.PasswordChar = '●';
            txtMatKhauHienTai.Size = new Size(451, 34);
            txtMatKhauHienTai.TabIndex = 0;
            txtMatKhauHienTai.TextChanged += txtMatKhauHienTai_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(367, 248);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(129, 25);
            label12.TabIndex = 74;
            label12.Text = "Mật khẩu mới";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMatKhauHienTai
            // 
            lblMatKhauHienTai.AutoSize = true;
            lblMatKhauHienTai.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMatKhauHienTai.ForeColor = Color.Red;
            lblMatKhauHienTai.Location = new Point(1048, 194);
            lblMatKhauHienTai.Margin = new Padding(4, 0, 4, 0);
            lblMatKhauHienTai.Name = "lblMatKhauHienTai";
            lblMatKhauHienTai.Size = new Size(226, 20);
            lblMatKhauHienTai.TabIndex = 77;
            lblMatKhauHienTai.Text = "Mật khẩu hiện tại không đúng";
            lblMatKhauHienTai.TextAlign = ContentAlignment.MiddleCenter;
            lblMatKhauHienTai.Visible = false;
            // 
            // lblNhapLai
            // 
            lblNhapLai.AutoSize = true;
            lblNhapLai.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNhapLai.ForeColor = Color.Red;
            lblNhapLai.Location = new Point(1048, 305);
            lblNhapLai.Margin = new Padding(4, 0, 4, 0);
            lblNhapLai.Name = "lblNhapLai";
            lblNhapLai.Size = new Size(237, 20);
            lblNhapLai.TabIndex = 77;
            lblNhapLai.Text = "Nhập lại mật khẩu không giống";
            lblNhapLai.TextAlign = ContentAlignment.MiddleCenter;
            lblNhapLai.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(367, 194);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(160, 25);
            label10.TabIndex = 77;
            label10.Text = "Mật khẩu hiện tại";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(label3);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(4, 5);
            panel8.Margin = new Padding(4, 5, 4, 5);
            panel8.Name = "panel8";
            panel8.Size = new Size(1635, 51);
            panel8.TabIndex = 0;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(8, 133, 204);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(1635, 51);
            label3.TabIndex = 56;
            label3.Text = "Thiết Lập";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uc_CaiDat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Margin = new Padding(4, 5, 4, 5);
            Name = "uc_CaiDat";
            Size = new Size(1643, 963);
            tableLayoutPanel3.ResumeLayout(false);
            pnlThongTinKhachHang.ResumeLayout(false);
            pnlThongTinKhachHang.PerformLayout();
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pnlThongTinKhachHang;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtNhapLai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauHienTai;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNhapLai;
        private System.Windows.Forms.Label lblMatKhauHienTai;
        private Button btnDangXuat;
    }
}
