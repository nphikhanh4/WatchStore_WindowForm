namespace DONGHO.Forms
{
    partial class Form_DangXuat
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
            label4 = new Label();
            lblThongBao = new Label();
            btnOK = new Button();
            button1 = new Button();
            SuspendLayout();
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
            label4.Size = new Size(675, 48);
            label4.TabIndex = 56;
            label4.Text = "Thông Báo";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThongBao
            // 
            lblThongBao.BackColor = Color.LightGray;
            lblThongBao.Dock = DockStyle.Fill;
            lblThongBao.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongBao.ForeColor = Color.Black;
            lblThongBao.Location = new Point(0, 48);
            lblThongBao.Margin = new Padding(4, 0, 4, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(675, 292);
            lblThongBao.TabIndex = 57;
            lblThongBao.Text = "Bạn có chắc muốn đăng xuất không ?";
            lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.FromArgb(17, 145, 249);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(425, 246);
            btnOK.Margin = new Padding(4, 5, 4, 5);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(127, 52);
            btnOK.TabIndex = 59;
            btnOK.Text = "KHÔNG";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(17, 145, 249);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(134, 246);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(127, 52);
            button1.TabIndex = 60;
            button1.Text = "CÓ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // Form_DangXuat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 26);
            ClientSize = new Size(675, 340);
            Controls.Add(button1);
            Controls.Add(btnOK);
            Controls.Add(lblThongBao);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form_DangXuat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmThongBao";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Button btnOK;
        private Button button1;
    }
}