namespace DONGHO.Forms
{
    partial class Form_DangNhap
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            login_close = new Label();
            login_showPass = new CheckBox();
            btnDangNhap = new Button();
            txtMatKhau = new TextBox();
            label3 = new Label();
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(login_close);
            panel1.Controls.Add(login_showPass);
            panel1.Controls.Add(btnDangNhap);
            panel1.Controls.Add(txtMatKhau);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtTenDangNhap);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-1, -2);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(848, 634);
            panel1.TabIndex = 0;
            // 
            // login_close
            // 
            login_close.AutoSize = true;
            login_close.Cursor = Cursors.Hand;
            login_close.FlatStyle = FlatStyle.Flat;
            login_close.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_close.Location = new Point(812, 15);
            login_close.Margin = new Padding(4, 0, 4, 0);
            login_close.Name = "login_close";
            login_close.Size = new Size(24, 24);
            login_close.TabIndex = 10;
            login_close.Text = "X";
            login_close.Click += Login_close_Click;
            // 
            // login_showPass
            // 
            login_showPass.BackColor = Color.Transparent;
            login_showPass.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_showPass.ForeColor = Color.Gray;
            login_showPass.Location = new Point(642, 351);
            login_showPass.Margin = new Padding(4, 5, 4, 5);
            login_showPass.Name = "login_showPass";
            login_showPass.Size = new Size(151, 24);
            login_showPass.TabIndex = 7;
            login_showPass.Text = "Show Password";
            login_showPass.UseVisualStyleBackColor = false;
            login_showPass.CheckedChanged += Login_showPass_CheckedChanged;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.DodgerBlue;
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(399, 390);
            btnDangNhap.Margin = new Padding(4, 5, 4, 5);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(133, 54);
            btnDangNhap.TabIndex = 6;
            btnDangNhap.Text = "LOGIN";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += Login_btn_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(399, 296);
            txtMatKhau.Margin = new Padding(4, 5, 4, 5);
            txtMatKhau.Multiline = true;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(405, 44);
            txtMatKhau.TabIndex = 5;
            txtMatKhau.TextChanged += txtMatKhau_TextChanged;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(395, 267);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenDangNhap.Location = new Point(399, 200);
            txtTenDangNhap.Margin = new Padding(4, 5, 4, 5);
            txtTenDangNhap.Multiline = true;
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(405, 44);
            txtTenDangNhap.TabIndex = 3;
            txtTenDangNhap.TextChanged += txtTenDangNhap_TextChanged;
            txtTenDangNhap.KeyDown += txtTenDangNhap_KeyDown;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(395, 171);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Username:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(395, 93);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(170, 24);
            label1.TabIndex = 1;
            label1.Text = "Welcome back!";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DodgerBlue;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(379, 634);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_blue;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(71, 161);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(214, 201);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(37, 390);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(266, 29);
            label6.TabIndex = 0;
            label6.Text = "CỬA HÀNG ĐỒNG HỒ";
            // 
            // Form_DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 632);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form_DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox login_showPass;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label login_close;
    }
}

