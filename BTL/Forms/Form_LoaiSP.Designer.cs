namespace DONGHO.Forms
{
    partial class Form_LoaiSP
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            picThanhCong = new PictureBox();
            btnXoa = new Button();
            btnCapNhat = new Button();
            btnThem = new Button();
            txtTen = new TextBox();
            label12 = new Label();
            dgvLoaiSanPham = new DataGridView();
            label4 = new Label();
            timer = new System.Windows.Forms.Timer(components);
            button9 = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThanhCong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiSanPham).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Silver;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 387F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvLoaiSanPham, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 48);
            tableLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 378F));
            tableLayoutPanel1.Size = new Size(1087, 378);
            tableLayoutPanel1.TabIndex = 63;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGray;
            panel3.Controls.Add(picThanhCong);
            panel3.Controls.Add(btnXoa);
            panel3.Controls.Add(btnCapNhat);
            panel3.Controls.Add(btnThem);
            panel3.Controls.Add(txtTen);
            panel3.Controls.Add(label12);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(4, 5);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(692, 368);
            panel3.TabIndex = 0;
            // 
            // picThanhCong
            // 
            picThanhCong.Location = new Point(73, 120);
            picThanhCong.Margin = new Padding(4, 5, 4, 5);
            picThanhCong.Name = "picThanhCong";
            picThanhCong.Size = new Size(78, 73);
            picThanhCong.SizeMode = PictureBoxSizeMode.StretchImage;
            picThanhCong.TabIndex = 65;
            picThanhCong.TabStop = false;
            picThanhCong.Visible = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(17, 145, 249);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.White;
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(203, 152);
            btnXoa.Margin = new Padding(4, 5, 4, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(219, 41);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Ngừng kinh doanh";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoaSP_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.FromArgb(17, 145, 249);
            btnCapNhat.FlatAppearance.BorderSize = 0;
            btnCapNhat.FlatStyle = FlatStyle.Flat;
            btnCapNhat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.ImageAlign = ContentAlignment.MiddleLeft;
            btnCapNhat.Location = new Point(448, 152);
            btnCapNhat.Margin = new Padding(4, 5, 4, 5);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(114, 41);
            btnCapNhat.TabIndex = 2;
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
            btnThem.Location = new Point(587, 152);
            btnThem.Margin = new Padding(4, 5, 4, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(86, 41);
            btnThem.TabIndex = 3;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThemSP_Click;
            // 
            // txtTen
            // 
            txtTen.BackColor = Color.White;
            txtTen.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTen.ForeColor = Color.Black;
            txtTen.Location = new Point(192, 64);
            txtTen.Margin = new Padding(4, 5, 4, 5);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(481, 34);
            txtTen.TabIndex = 0;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(11, 73);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(173, 25);
            label12.TabIndex = 58;
            label12.Text = "Tên loại sản phẩm";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvLoaiSanPham
            // 
            dgvLoaiSanPham.AllowUserToAddRows = false;
            dgvLoaiSanPham.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgvLoaiSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvLoaiSanPham.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLoaiSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLoaiSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLoaiSanPham.Dock = DockStyle.Fill;
            dgvLoaiSanPham.Location = new Point(704, 5);
            dgvLoaiSanPham.Margin = new Padding(4, 5, 4, 5);
            dgvLoaiSanPham.MultiSelect = false;
            dgvLoaiSanPham.Name = "dgvLoaiSanPham";
            dgvLoaiSanPham.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvLoaiSanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvLoaiSanPham.RowHeadersVisible = false;
            dgvLoaiSanPham.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(17, 145, 249);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dgvLoaiSanPham.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvLoaiSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiSanPham.Size = new Size(379, 368);
            dgvLoaiSanPham.TabIndex = 1;
            dgvLoaiSanPham.Click += dgvLoaiSanPham_Click;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(8, 133, 204);
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(1087, 48);
            label4.TabIndex = 64;
            label4.Text = "Loại Sản Phẩm";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Tick += timer_Tick;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(8, 133, 204);
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatAppearance.MouseOverBackColor = Color.Red;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Location = new Point(1043, 0);
            button9.Margin = new Padding(4, 5, 4, 5);
            button9.Name = "button9";
            button9.Size = new Size(44, 48);
            button9.TabIndex = 4;
            button9.TextImageRelation = TextImageRelation.ImageBeforeText;
            button9.UseVisualStyleBackColor = false;
            button9.Click += Button9_Click;
            // 
            // Form_LoaiSP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(1087, 426);
            Controls.Add(button9);
            Controls.Add(label4);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form_LoaiSP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLoaiSanPham";
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picThanhCong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiSanPham).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvLoaiSanPham;
        private System.Windows.Forms.PictureBox picThanhCong;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button9;
    }
}