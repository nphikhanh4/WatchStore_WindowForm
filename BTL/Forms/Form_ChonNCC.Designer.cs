namespace DONGHO.Forms
{
    partial class Form_ChonNCC
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
            button9 = new Button();
            btnChon = new Button();
            button1 = new Button();
            cboNCC = new ComboBox();
            label24 = new Label();
            SuspendLayout();
            // 
            // button9
            // 
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatAppearance.MouseOverBackColor = Color.Red;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Location = new Point(594, 1);
            button9.Margin = new Padding(4);
            button9.Name = "button9";
            button9.Size = new Size(42, 51);
            button9.TabIndex = 20;
            button9.Text = "X";
            button9.TextImageRelation = TextImageRelation.ImageBeforeText;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // btnChon
            // 
            btnChon.BackColor = Color.FromArgb(17, 145, 249);
            btnChon.BackgroundImageLayout = ImageLayout.None;
            btnChon.FlatAppearance.BorderSize = 0;
            btnChon.FlatStyle = FlatStyle.Flat;
            btnChon.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChon.ForeColor = Color.White;
            btnChon.ImageAlign = ContentAlignment.MiddleLeft;
            btnChon.Location = new Point(496, 169);
            btnChon.Margin = new Padding(4);
            btnChon.Name = "btnChon";
            btnChon.Size = new Size(128, 57);
            btnChon.TabIndex = 17;
            btnChon.Text = "Chọn";
            btnChon.TextAlign = ContentAlignment.MiddleRight;
            btnChon.UseVisualStyleBackColor = false;
            btnChon.Click += btnChon_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.WhiteSmoke;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.icons8_add_32px;
            button1.Location = new Point(428, 68);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(46, 31);
            button1.TabIndex = 57;
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // cboNCC
            // 
            cboNCC.BackColor = Color.White;
            cboNCC.Font = new Font("Microsoft Sans Serif", 14.25F);
            cboNCC.ForeColor = Color.Black;
            cboNCC.FormattingEnabled = true;
            cboNCC.Location = new Point(225, 66);
            cboNCC.Margin = new Padding(4);
            cboNCC.Name = "cboNCC";
            cboNCC.Size = new Size(196, 37);
            cboNCC.TabIndex = 56;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.Black;
            label24.Location = new Point(80, 71);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(133, 25);
            label24.TabIndex = 58;
            label24.Text = "Nhà cung cấp";
            label24.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form_ChonNCC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(640, 244);
            Controls.Add(button1);
            Controls.Add(cboNCC);
            Controls.Add(label24);
            Controls.Add(button9);
            Controls.Add(btnChon);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Form_ChonNCC";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmChonNCC";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.Label label24;
    }
}