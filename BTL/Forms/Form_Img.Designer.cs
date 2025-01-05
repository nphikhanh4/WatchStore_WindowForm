namespace DONGHO.Forms
{
    partial class Form_Img
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
            groupBox1 = new GroupBox();
            btnChon = new Button();
            groupBox2 = new GroupBox();
            btnLoad = new Button();
            lblThongBao = new Label();
            label10 = new Label();
            txtURL = new TextBox();
            button9 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            label4.Size = new Size(805, 48);
            label4.TabIndex = 57;
            label4.Text = "Load Hình Ảnh";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnChon);
            groupBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Black;
            groupBox1.Location = new Point(5, 52);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(800, 91);
            groupBox1.TabIndex = 58;
            groupBox1.TabStop = false;
            groupBox1.Text = "Load hình từ máy tính";
            // 
            // btnChon
            // 
            btnChon.BackColor = Color.FromArgb(17, 145, 249);
            btnChon.FlatAppearance.BorderSize = 0;
            btnChon.FlatStyle = FlatStyle.Flat;
            btnChon.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChon.ForeColor = Color.White;
            btnChon.Location = new Point(345, 33);
            btnChon.Margin = new Padding(4, 5, 4, 5);
            btnChon.Name = "btnChon";
            btnChon.Size = new Size(91, 46);
            btnChon.TabIndex = 5;
            btnChon.Text = "Chọn";
            btnChon.UseVisualStyleBackColor = false;
            btnChon.Click += btnChon_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnLoad);
            groupBox2.Controls.Add(lblThongBao);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtURL);
            groupBox2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(6, 153);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(799, 148);
            groupBox2.TabIndex = 58;
            groupBox2.TabStop = false;
            groupBox2.Text = "Load hình từ URL";
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(17, 145, 249);
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(688, 88);
            btnLoad.Margin = new Padding(4, 5, 4, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(91, 46);
            btnLoad.TabIndex = 5;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // lblThongBao
            // 
            lblThongBao.AutoSize = true;
            lblThongBao.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblThongBao.ForeColor = Color.OrangeRed;
            lblThongBao.Location = new Point(322, 89);
            lblThongBao.Margin = new Padding(4, 0, 4, 0);
            lblThongBao.Name = "lblThongBao";
            lblThongBao.Size = new Size(138, 20);
            lblThongBao.TabIndex = 56;
            lblThongBao.Text = "URL không đúng!";
            lblThongBao.TextAlign = ContentAlignment.MiddleCenter;
            lblThongBao.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(0, 49);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(48, 20);
            label10.TabIndex = 56;
            label10.Text = "URL:";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtURL
            // 
            txtURL.BackColor = Color.White;
            txtURL.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtURL.ForeColor = Color.Black;
            txtURL.Location = new Point(52, 39);
            txtURL.Margin = new Padding(4, 5, 4, 5);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(725, 30);
            txtURL.TabIndex = 7;
            txtURL.TextChanged += txtURL_TextChanged;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(8, 133, 204);
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatAppearance.MouseOverBackColor = Color.Red;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Location = new Point(760, 0);
            button9.Margin = new Padding(4, 5, 4, 5);
            button9.Name = "button9";
            button9.Size = new Size(44, 48);
            button9.TabIndex = 59;
            button9.TextImageRelation = TextImageRelation.ImageBeforeText;
            button9.UseVisualStyleBackColor = false;
            button9.Click += Button9_Click;
            // 
            // Form_Img
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(805, 330);
            Controls.Add(button9);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form_Img";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLoadImage";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label lblThongBao;
    }
}