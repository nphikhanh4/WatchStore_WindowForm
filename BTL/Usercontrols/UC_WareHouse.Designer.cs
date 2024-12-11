namespace DONGHO.Usercontrols
{
    partial class UC_WareHouse
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            tableLayoutPanel3 = new TableLayoutPanel();
            pnlThongTinSanPham = new Panel();
            button5 = new Button();
            label1 = new Label();
            dgvAdd = new DataGridView();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            cbbCategory = new ComboBox();
            cbbBrand = new ComboBox();
            button3 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            txtSoLuong = new TextBox();
            label2 = new Label();
            label9 = new Label();
            lblDaTaoPhieuNhap = new Label();
            label6 = new Label();
            btnTaoPhieu = new Button();
            panel8 = new Panel();
            label3 = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel9 = new Panel();
            dgvSanPham = new DataGridView();
            panel10 = new Panel();
            label4 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            dgvPhieuNhap = new DataGridView();
            panel2 = new Panel();
            label5 = new Label();
            button1 = new Button();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGiaNhap = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            MaNV = new DataGridViewTextBoxColumn();
            MaNhap = new DataGridViewTextBoxColumn();
            MaSP = new DataGridViewTextBoxColumn();
            button6 = new Button();
            tableLayoutPanel3.SuspendLayout();
            pnlThongTinSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel8.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            panel10.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.Silver;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(pnlThongTinSanPham, 0, 1);
            tableLayoutPanel3.Controls.Add(panel8, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Left;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 8F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 92F));
            tableLayoutPanel3.Size = new Size(502, 695);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // pnlThongTinSanPham
            // 
            pnlThongTinSanPham.BackColor = Color.White;
            pnlThongTinSanPham.Controls.Add(button5);
            pnlThongTinSanPham.Controls.Add(label1);
            pnlThongTinSanPham.Controls.Add(dgvAdd);
            pnlThongTinSanPham.Controls.Add(pictureBox1);
            pnlThongTinSanPham.Controls.Add(button4);
            pnlThongTinSanPham.Controls.Add(cbbCategory);
            pnlThongTinSanPham.Controls.Add(cbbBrand);
            pnlThongTinSanPham.Controls.Add(button3);
            pnlThongTinSanPham.Controls.Add(button2);
            pnlThongTinSanPham.Controls.Add(textBox2);
            pnlThongTinSanPham.Controls.Add(textBox1);
            pnlThongTinSanPham.Controls.Add(txtSoLuong);
            pnlThongTinSanPham.Controls.Add(label2);
            pnlThongTinSanPham.Controls.Add(label9);
            pnlThongTinSanPham.Controls.Add(lblDaTaoPhieuNhap);
            pnlThongTinSanPham.Controls.Add(label6);
            pnlThongTinSanPham.Controls.Add(btnTaoPhieu);
            pnlThongTinSanPham.Dock = DockStyle.Fill;
            pnlThongTinSanPham.Location = new Point(4, 60);
            pnlThongTinSanPham.Margin = new Padding(4, 5, 4, 5);
            pnlThongTinSanPham.Name = "pnlThongTinSanPham";
            pnlThongTinSanPham.Size = new Size(494, 630);
            pnlThongTinSanPham.TabIndex = 55;
            // 
            // button5
            // 
            button5.Location = new Point(391, 592);
            button5.Margin = new Padding(2);
            button5.Name = "button5";
            button5.Size = new Size(92, 29);
            button5.TabIndex = 74;
            button5.Text = "Hủy";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(18, 230);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(135, 25);
            label1.TabIndex = 73;
            label1.Text = "Hãng/Thể loại";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvAdd
            // 
            dgvAdd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdd.Location = new Point(11, 352);
            dgvAdd.Margin = new Padding(2);
            dgvAdd.Name = "dgvAdd";
            dgvAdd.RowHeadersWidth = 82;
            dgvAdd.Size = new Size(481, 199);
            dgvAdd.TabIndex = 72;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(156, 267);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 62);
            pictureBox1.TabIndex = 71;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Location = new Point(18, 289);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(130, 29);
            button4.TabIndex = 70;
            button4.Text = "Chọn ảnh";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // cbbCategory
            // 
            cbbCategory.FormattingEnabled = true;
            cbbCategory.Location = new Point(328, 228);
            cbbCategory.Margin = new Padding(2);
            cbbCategory.Name = "cbbCategory";
            cbbCategory.Size = new Size(136, 28);
            cbbCategory.TabIndex = 69;
            // 
            // cbbBrand
            // 
            cbbBrand.FormattingEnabled = true;
            cbbBrand.Location = new Point(157, 228);
            cbbBrand.Margin = new Padding(2);
            cbbBrand.Name = "cbbBrand";
            cbbBrand.Size = new Size(136, 28);
            cbbBrand.TabIndex = 67;
            // 
            // button3
            // 
            button3.Location = new Point(274, 592);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(92, 29);
            button3.TabIndex = 65;
            button3.Text = "Lưu";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(327, 301);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(143, 29);
            button2.TabIndex = 64;
            button2.Text = "Thêm phiếu nhập";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(157, 122);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(307, 27);
            textBox2.TabIndex = 63;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 66);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(307, 27);
            textBox1.TabIndex = 62;
            // 
            // txtSoLuong
            // 
            txtSoLuong.BackColor = Color.White;
            txtSoLuong.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSoLuong.ForeColor = Color.Black;
            txtSoLuong.Location = new Point(157, 169);
            txtSoLuong.Margin = new Padding(4, 5, 4, 5);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(307, 34);
            txtSoLuong.TabIndex = 60;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(54, 178);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 61;
            label2.Text = "Số Lượng";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(11, 124);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(135, 25);
            label9.TabIndex = 61;
            label9.Text = "Đơn Giá Nhập";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDaTaoPhieuNhap
            // 
            lblDaTaoPhieuNhap.AutoSize = true;
            lblDaTaoPhieuNhap.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDaTaoPhieuNhap.ForeColor = Color.ForestGreen;
            lblDaTaoPhieuNhap.Location = new Point(327, 15);
            lblDaTaoPhieuNhap.Margin = new Padding(4, 0, 4, 0);
            lblDaTaoPhieuNhap.Name = "lblDaTaoPhieuNhap";
            lblDaTaoPhieuNhap.Size = new Size(149, 20);
            lblDaTaoPhieuNhap.TabIndex = 61;
            lblDaTaoPhieuNhap.Text = "Đã tạo phiếu nhập!";
            lblDaTaoPhieuNhap.TextAlign = ContentAlignment.MiddleCenter;
            lblDaTaoPhieuNhap.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(54, 68);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(79, 25);
            label6.TabIndex = 61;
            label6.Text = "Tên SP";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.BackColor = Color.FromArgb(17, 145, 249);
            btnTaoPhieu.FlatAppearance.BorderSize = 0;
            btnTaoPhieu.FlatStyle = FlatStyle.Flat;
            btnTaoPhieu.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTaoPhieu.ForeColor = Color.White;
            btnTaoPhieu.ImageAlign = ContentAlignment.MiddleLeft;
            btnTaoPhieu.Location = new Point(156, 15);
            btnTaoPhieu.Margin = new Padding(4, 5, 4, 5);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.Size = new Size(164, 33);
            btnTaoPhieu.TabIndex = 58;
            btnTaoPhieu.Text = "Tạo Phiếu";
            btnTaoPhieu.TextAlign = ContentAlignment.MiddleRight;
            btnTaoPhieu.UseVisualStyleBackColor = false;
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(label3);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(4, 5);
            panel8.Margin = new Padding(4, 5, 4, 5);
            panel8.Name = "panel8";
            panel8.Size = new Size(494, 45);
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
            label3.Size = new Size(494, 45);
            label3.TabIndex = 57;
            label3.Text = "Thông Tin Nhập Sản Phẩm";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.Silver;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(panel9, 0, 1);
            tableLayoutPanel4.Controls.Add(panel10, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Top;
            tableLayoutPanel4.Location = new Point(502, 0);
            tableLayoutPanel4.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 17.48252F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 82.51748F));
            tableLayoutPanel4.Size = new Size(811, 336);
            tableLayoutPanel4.TabIndex = 3;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(dgvSanPham);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(4, 63);
            panel9.Margin = new Padding(4, 5, 4, 5);
            panel9.Name = "panel9";
            panel9.Size = new Size(803, 268);
            panel9.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSanPham.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.Location = new Point(0, 0);
            dgvSanPham.Margin = new Padding(4, 5, 4, 5);
            dgvSanPham.MultiSelect = false;
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 82;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvSanPham.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvSanPham.RowTemplate.Height = 30;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(803, 268);
            dgvSanPham.TabIndex = 1;
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.Controls.Add(label4);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(4, 5);
            panel10.Margin = new Padding(4, 5, 4, 5);
            panel10.Name = "panel10";
            panel10.Size = new Size(803, 48);
            panel10.TabIndex = 0;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(8, 133, 204);
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(803, 48);
            label4.TabIndex = 56;
            label4.Text = "Danh Sach Sản Phẩm Trong Cửa Hàng";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Silver;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(502, 336);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.48252F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 82.51748F));
            tableLayoutPanel1.Size = new Size(811, 299);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dgvPhieuNhap);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(4, 57);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 237);
            panel1.TabIndex = 1;
            // 
            // dgvPhieuNhap
            // 
            dgvPhieuNhap.AllowUserToAddRows = false;
            dgvPhieuNhap.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dgvPhieuNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvPhieuNhap.BackgroundColor = Color.White;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuNhap.Dock = DockStyle.Fill;
            dgvPhieuNhap.Location = new Point(0, 0);
            dgvPhieuNhap.Margin = new Padding(4, 5, 4, 5);
            dgvPhieuNhap.MultiSelect = false;
            dgvPhieuNhap.Name = "dgvPhieuNhap";
            dgvPhieuNhap.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.White;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvPhieuNhap.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvPhieuNhap.RowHeadersVisible = false;
            dgvPhieuNhap.RowHeadersWidth = 82;
            dataGridViewCellStyle8.BackColor = Color.White;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle8.SelectionForeColor = Color.White;
            dgvPhieuNhap.RowsDefaultCellStyle = dataGridViewCellStyle8;
            dgvPhieuNhap.RowTemplate.Height = 30;
            dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuNhap.Size = new Size(803, 237);
            dgvPhieuNhap.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(4, 5);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(803, 42);
            panel2.TabIndex = 0;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(8, 133, 204);
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(803, 42);
            label5.TabIndex = 56;
            label5.Text = "Danh Sách Sản Phẩm Trong Kho";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(528, 651);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(188, 39);
            button1.TabIndex = 59;
            button1.Text = "nhập về cửa hàng";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SoLuong
            // 
            SoLuong.HeaderText = "SL";
            SoLuong.MinimumWidth = 10;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            SoLuong.Width = 40;
            // 
            // DonGiaNhap
            // 
            DonGiaNhap.HeaderText = "Đơn Giá Nhập";
            DonGiaNhap.MinimumWidth = 10;
            DonGiaNhap.Name = "DonGiaNhap";
            DonGiaNhap.ReadOnly = true;
            DonGiaNhap.Width = 130;
            // 
            // TenSP
            // 
            TenSP.HeaderText = "Tên SP";
            TenSP.MinimumWidth = 10;
            TenSP.Name = "TenSP";
            TenSP.ReadOnly = true;
            TenSP.Width = 200;
            // 
            // MaNV
            // 
            MaNV.HeaderText = "MaNV";
            MaNV.MinimumWidth = 10;
            MaNV.Name = "MaNV";
            MaNV.ReadOnly = true;
            MaNV.Visible = false;
            MaNV.Width = 200;
            // 
            // MaNhap
            // 
            MaNhap.HeaderText = "MaNhap";
            MaNhap.MinimumWidth = 10;
            MaNhap.Name = "MaNhap";
            MaNhap.ReadOnly = true;
            MaNhap.Visible = false;
            MaNhap.Width = 200;
            // 
            // MaSP
            // 
            MaSP.HeaderText = "MaSP";
            MaSP.MinimumWidth = 10;
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            MaSP.Visible = false;
            MaSP.Width = 200;
            // 
            // button6
            // 
            button6.Location = new Point(758, 652);
            button6.Margin = new Padding(2);
            button6.Name = "button6";
            button6.Size = new Size(92, 38);
            button6.TabIndex = 75;
            button6.Text = "Xóa";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // UC_Sales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button6);
            Controls.Add(button1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel4);
            Controls.Add(tableLayoutPanel3);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UC_Sales";
            Size = new Size(1313, 695);
            tableLayoutPanel3.ResumeLayout(false);
            pnlThongTinSanPham.ResumeLayout(false);
            pnlThongTinSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel8.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            panel10.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel pnlThongTinSanPham;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDaTaoPhieuNhap;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox cbbCategory;
        private ComboBox cbbBrand;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn MaNhap;
        private DataGridViewTextBoxColumn MaNV;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn DonGiaNhap;
        private DataGridViewTextBoxColumn SoLuong;
        private PictureBox pictureBox1;
        private Button button4;
        private DataGridView dgvAdd;
        private Button button5;
        private Label label1;
        private Button button6;
    }
}