namespace DONGHO.Usercontrols
{
    partial class UC_NhanVien
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            dgvNhanVien = new DataGridView();
            panel3 = new Panel();
            label4 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            panelBoLoc = new Panel();
            panel7 = new Panel();
            pictureBox2 = new PictureBox();
            txtTenNV = new TextBox();
            btnLamMoi = new Button();
            label7 = new Label();
            btnApDung = new Button();
            cboLocLoaiNhanVien = new ComboBox();
            panel5 = new Panel();
            label2 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            pnlThongTinNhanVien = new Panel();
            button3 = new Button();
            btnLamMoiThongTin = new Button();
            btnSaThai = new Button();
            btnCapNhat = new Button();
            btnThem = new Button();
            dateNgaySinh = new DateTimePicker();
            cboLoai = new ComboBox();
            cboGioiTinh = new ComboBox();
            label16 = new Label();
            picHinhAnh = new PictureBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            label21 = new Label();
            label14 = new Label();
            label18 = new Label();
            txtTen = new TextBox();
            label13 = new Label();
            txtFullName = new TextBox();
            txtPass = new TextBox();
            label12 = new Label();
            label22 = new Label();
            label10 = new Label();
            label9 = new Label();
            panel8 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panelBoLoc.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            pnlThongTinNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(tableLayoutPanel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1348, 725);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightGray;
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Controls.Add(tableLayoutPanel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(589, 0);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(759, 725);
            panel2.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Controls.Add(dgvNhanVien);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 239);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(4, 0, 4, 0);
            panel4.Size = new Size(759, 476);
            panel4.TabIndex = 4;
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvNhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvNhanVien.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(4, 0);
            dgvNhanVien.Margin = new Padding(4, 3, 4, 3);
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNhanVien.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvNhanVien.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvNhanVien.RowTemplate.Height = 30;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(751, 476);
            dgvNhanVien.TabIndex = 0;
            dgvNhanVien.CellContentClick += dgvNhanVien_CellContentClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(label4);
            panel3.Location = new Point(0, 186);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(4, 0, 4, 0);
            panel3.Size = new Size(759, 57);
            panel3.TabIndex = 3;
            // 
            // label4
            // 
            label4.BackColor = Color.DodgerBlue;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(4, 0);
            label4.Name = "label4";
            label4.Size = new Size(751, 57);
            label4.TabIndex = 0;
            label4.Text = "DANH SÁCH NHÂN VIÊN";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Silver;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(panelBoLoc, 0, 1);
            tableLayoutPanel2.Controls.Add(panel5, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel2.Size = new Size(759, 185);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // panelBoLoc
            // 
            panelBoLoc.BackColor = Color.White;
            panelBoLoc.Controls.Add(panel7);
            panelBoLoc.Controls.Add(btnLamMoi);
            panelBoLoc.Controls.Add(label7);
            panelBoLoc.Controls.Add(btnApDung);
            panelBoLoc.Controls.Add(cboLocLoaiNhanVien);
            panelBoLoc.Dock = DockStyle.Fill;
            panelBoLoc.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panelBoLoc.Location = new Point(4, 49);
            panelBoLoc.Margin = new Padding(4, 3, 4, 3);
            panelBoLoc.Name = "panelBoLoc";
            panelBoLoc.Size = new Size(751, 133);
            panelBoLoc.TabIndex = 55;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(pictureBox2);
            panel7.Controls.Add(txtTenNV);
            panel7.Location = new Point(181, 31);
            panel7.Margin = new Padding(4, 3, 4, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(280, 37);
            panel7.TabIndex = 59;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icons8_search_24px;
            pictureBox2.Location = new Point(243, 3);
            pictureBox2.Margin = new Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(31, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 61;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click_1;
            // 
            // txtTenNV
            // 
            txtTenNV.BackColor = Color.White;
            txtTenNV.BorderStyle = BorderStyle.None;
            txtTenNV.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenNV.ForeColor = Color.Black;
            txtTenNV.Location = new Point(46, 3);
            txtTenNV.Margin = new Padding(4, 3, 4, 3);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(189, 27);
            txtTenNV.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.MediumSeaGreen;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.ImageAlign = ContentAlignment.MiddleRight;
            btnLamMoi.Location = new Point(366, 86);
            btnLamMoi.Margin = new Padding(4, 3, 4, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(133, 39);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(34, 32);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(122, 37);
            label7.TabIndex = 55;
            label7.Text = "Tìm kiếm";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnApDung
            // 
            btnApDung.BackColor = Color.FromArgb(17, 145, 249);
            btnApDung.FlatAppearance.BorderSize = 0;
            btnApDung.FlatStyle = FlatStyle.Flat;
            btnApDung.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApDung.ForeColor = Color.White;
            btnApDung.Location = new Point(217, 84);
            btnApDung.Name = "btnApDung";
            btnApDung.Size = new Size(119, 42);
            btnApDung.TabIndex = 4;
            btnApDung.Text = "Áp dụng";
            btnApDung.UseVisualStyleBackColor = false;
            btnApDung.Click += btnApDung_Click_1;
            // 
            // cboLocLoaiNhanVien
            // 
            cboLocLoaiNhanVien.BackColor = Color.White;
            cboLocLoaiNhanVien.Font = new Font("Microsoft Sans Serif", 14.25F);
            cboLocLoaiNhanVien.ForeColor = Color.Black;
            cboLocLoaiNhanVien.FormattingEnabled = true;
            cboLocLoaiNhanVien.Location = new Point(470, 32);
            cboLocLoaiNhanVien.Name = "cboLocLoaiNhanVien";
            cboLocLoaiNhanVien.Size = new Size(190, 37);
            cboLocLoaiNhanVien.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(4, 3);
            panel5.Margin = new Padding(4, 3, 4, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(751, 40);
            panel5.TabIndex = 0;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(8, 133, 204);
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(751, 40);
            label2.TabIndex = 56;
            label2.Text = "Bộ lọc";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.Silver;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tableLayoutPanel4.Dock = DockStyle.Bottom;
            tableLayoutPanel4.Location = new Point(0, 715);
            tableLayoutPanel4.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 1.34453785F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 98.6554642F));
            tableLayoutPanel4.Size = new Size(759, 10);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Silver;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(pnlThongTinNhanVien, 0, 1);
            tableLayoutPanel3.Controls.Add(panel8, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Left;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 6.389776F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 93.61022F));
            tableLayoutPanel3.Size = new Size(589, 725);
            tableLayoutPanel3.TabIndex = 5;
            // 
            // pnlThongTinNhanVien
            // 
            pnlThongTinNhanVien.BackColor = Color.White;
            pnlThongTinNhanVien.Controls.Add(button3);
            pnlThongTinNhanVien.Controls.Add(btnLamMoiThongTin);
            pnlThongTinNhanVien.Controls.Add(btnSaThai);
            pnlThongTinNhanVien.Controls.Add(btnCapNhat);
            pnlThongTinNhanVien.Controls.Add(btnThem);
            pnlThongTinNhanVien.Controls.Add(dateNgaySinh);
            pnlThongTinNhanVien.Controls.Add(cboLoai);
            pnlThongTinNhanVien.Controls.Add(cboGioiTinh);
            pnlThongTinNhanVien.Controls.Add(label16);
            pnlThongTinNhanVien.Controls.Add(picHinhAnh);
            pnlThongTinNhanVien.Controls.Add(txtSoDienThoai);
            pnlThongTinNhanVien.Controls.Add(txtEmail);
            pnlThongTinNhanVien.Controls.Add(label21);
            pnlThongTinNhanVien.Controls.Add(label14);
            pnlThongTinNhanVien.Controls.Add(label18);
            pnlThongTinNhanVien.Controls.Add(txtTen);
            pnlThongTinNhanVien.Controls.Add(label13);
            pnlThongTinNhanVien.Controls.Add(txtFullName);
            pnlThongTinNhanVien.Controls.Add(txtPass);
            pnlThongTinNhanVien.Controls.Add(label12);
            pnlThongTinNhanVien.Controls.Add(label22);
            pnlThongTinNhanVien.Controls.Add(label10);
            pnlThongTinNhanVien.Controls.Add(label9);
            pnlThongTinNhanVien.Dock = DockStyle.Fill;
            pnlThongTinNhanVien.ForeColor = Color.Black;
            pnlThongTinNhanVien.Location = new Point(4, 49);
            pnlThongTinNhanVien.Margin = new Padding(4, 3, 4, 3);
            pnlThongTinNhanVien.Name = "pnlThongTinNhanVien";
            pnlThongTinNhanVien.Size = new Size(581, 673);
            pnlThongTinNhanVien.TabIndex = 55;
            // 
            // button3
            // 
            button3.BackColor = Color.Cyan;
            button3.Cursor = Cursors.UpArrow;
            button3.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(431, 235);
            button3.Name = "button3";
            button3.Size = new Size(88, 36);
            button3.TabIndex = 80;
            button3.Text = "Chọn ảnh";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btnLamMoiThongTin
            // 
            btnLamMoiThongTin.BackColor = Color.FromArgb(17, 145, 249);
            btnLamMoiThongTin.FlatAppearance.BorderSize = 0;
            btnLamMoiThongTin.FlatStyle = FlatStyle.Flat;
            btnLamMoiThongTin.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoiThongTin.ForeColor = Color.White;
            btnLamMoiThongTin.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoiThongTin.Location = new Point(52, 409);
            btnLamMoiThongTin.Margin = new Padding(4, 3, 4, 3);
            btnLamMoiThongTin.Name = "btnLamMoiThongTin";
            btnLamMoiThongTin.Size = new Size(102, 43);
            btnLamMoiThongTin.TabIndex = 17;
            btnLamMoiThongTin.Text = "Làm mới";
            btnLamMoiThongTin.UseVisualStyleBackColor = false;
            btnLamMoiThongTin.Click += btnLamMoiThongTin_Click;
            // 
            // btnSaThai
            // 
            btnSaThai.BackColor = Color.FromArgb(17, 145, 249);
            btnSaThai.FlatAppearance.BorderSize = 0;
            btnSaThai.FlatStyle = FlatStyle.Flat;
            btnSaThai.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaThai.ForeColor = Color.White;
            btnSaThai.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaThai.Location = new Point(174, 409);
            btnSaThai.Margin = new Padding(4, 3, 4, 3);
            btnSaThai.Name = "btnSaThai";
            btnSaThai.Size = new Size(97, 43);
            btnSaThai.TabIndex = 18;
            btnSaThai.Text = "Sa thải";
            btnSaThai.UseVisualStyleBackColor = false;
            btnSaThai.Click += btnSaThai_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.FromArgb(17, 145, 249);
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnCapNhat.FlatStyle = FlatStyle.Flat;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.ImageAlign = ContentAlignment.MiddleLeft;
            btnCapNhat.Location = new Point(291, 409);
            btnCapNhat.Margin = new Padding(4, 3, 4, 3);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(108, 43);
            btnCapNhat.TabIndex = 19;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(17, 145, 249);
            btnThem.BackgroundImageLayout = ImageLayout.None;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(418, 409);
            btnThem.Margin = new Padding(4, 3, 4, 3);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(101, 43);
            btnThem.TabIndex = 20;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // dateNgaySinh
            // 
            dateNgaySinh.CalendarMonthBackground = Color.FromArgb(51, 51, 51);
            dateNgaySinh.CalendarTitleBackColor = Color.FromArgb(17, 145, 249);
            dateNgaySinh.CalendarTitleForeColor = Color.White;
            dateNgaySinh.CalendarTrailingForeColor = Color.White;
            dateNgaySinh.Font = new Font("Microsoft Sans Serif", 14.25F);
            dateNgaySinh.Format = DateTimePickerFormat.Short;
            dateNgaySinh.Location = new Point(139, 245);
            dateNgaySinh.Margin = new Padding(4, 3, 4, 3);
            dateNgaySinh.Name = "dateNgaySinh";
            dateNgaySinh.Size = new Size(220, 34);
            dateNgaySinh.TabIndex = 11;
            // 
            // cboLoai
            // 
            cboLoai.BackColor = Color.White;
            cboLoai.Font = new Font("Microsoft Sans Serif", 14.25F);
            cboLoai.ForeColor = Color.Black;
            cboLoai.FormattingEnabled = true;
            cboLoai.Items.AddRange(new object[] { "Quản trị viên", "Quản lý" });
            cboLoai.Location = new Point(139, 157);
            cboLoai.Margin = new Padding(4, 3, 4, 3);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(220, 37);
            cboLoai.TabIndex = 8;
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.BackColor = Color.White;
            cboGioiTinh.Font = new Font("Microsoft Sans Serif", 14.25F);
            cboGioiTinh.ForeColor = Color.Black;
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGioiTinh.Location = new Point(139, 201);
            cboGioiTinh.Margin = new Padding(4, 3, 4, 3);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(220, 37);
            cboGioiTinh.TabIndex = 10;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(29, 249);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(99, 25);
            label16.TabIndex = 55;
            label16.Text = "Ngày sinh";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.Cursor = Cursors.Hand;
            picHinhAnh.Location = new Point(385, 41);
            picHinhAnh.Margin = new Padding(4, 3, 4, 3);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(166, 166);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.TabIndex = 6;
            picHinhAnh.TabStop = false;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.BackColor = Color.White;
            txtSoDienThoai.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoDienThoai.ForeColor = Color.Black;
            txtSoDienThoai.Location = new Point(139, 117);
            txtSoDienThoai.Margin = new Padding(4, 3, 4, 3);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(219, 34);
            txtSoDienThoai.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.Black;
            txtEmail.Location = new Point(139, 76);
            txtEmail.Margin = new Padding(4, 3, 4, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 34);
            txtEmail.TabIndex = 1;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(78, 83);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(60, 25);
            label21.TabIndex = 55;
            label21.Text = "Email";
            label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(42, 208);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(82, 25);
            label14.TabIndex = 55;
            label14.Text = "Giới tính";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(16, 123);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(126, 25);
            label18.TabIndex = 55;
            label18.Text = "Số điện thoại";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtTen
            // 
            txtTen.BackColor = Color.White;
            txtTen.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTen.ForeColor = Color.Black;
            txtTen.Location = new Point(139, 36);
            txtTen.Margin = new Padding(4, 3, 4, 3);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(220, 34);
            txtTen.TabIndex = 0;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(5, 165);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(139, 25);
            label13.TabIndex = 55;
            label13.Text = "Loại nhân viên";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = Color.White;
            txtFullName.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFullName.ForeColor = Color.Black;
            txtFullName.Location = new Point(139, 290);
            txtFullName.Margin = new Padding(4, 3, 4, 3);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(219, 34);
            txtFullName.TabIndex = 8;
            // 
            // txtPass
            // 
            txtPass.BackColor = Color.White;
            txtPass.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPass.ForeColor = Color.Black;
            txtPass.Location = new Point(139, 330);
            txtPass.Margin = new Padding(4, 3, 4, 3);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(219, 34);
            txtPass.TabIndex = 7;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(1, 43);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(137, 25);
            label12.TabIndex = 55;
            label12.Text = "Tên nhân viên";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.White;
            label22.Location = new Point(601, 355);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(23, 25);
            label22.TabIndex = 55;
            label22.Text = "₫";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(34, 290);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(95, 25);
            label10.TabIndex = 55;
            label10.Text = "FullName";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(34, 330);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(104, 25);
            label9.TabIndex = 55;
            label9.Text = "PassWord";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(label3);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(4, 3);
            panel8.Margin = new Padding(4, 3, 4, 3);
            panel8.Name = "panel8";
            panel8.Size = new Size(581, 40);
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
            label3.Size = new Size(581, 40);
            label3.TabIndex = 56;
            label3.Text = "Thông Tin Nhân Viên";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_NhanVien
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UC_NhanVien";
            Size = new Size(1348, 725);
            Load += UC_NhanVien_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            panel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panelBoLoc.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            pnlThongTinNhanVien.ResumeLayout(false);
            pnlThongTinNhanVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelBoLoc;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cboLocLoaiNhanVien;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pnlThongTinNhanVien;
        private System.Windows.Forms.Button btnLamMoiThongTin;
        private System.Windows.Forms.Button btnSaThai;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dateNgaySinh;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApDung;
        private Button btnLamMoi;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel4;
        private DataGridView dgvNhanVien;
        private Panel panel3;
        private Label label4;
    }
}
