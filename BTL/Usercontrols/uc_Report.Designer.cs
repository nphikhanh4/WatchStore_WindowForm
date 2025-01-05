namespace DONGHO.Usercontrols
{
    partial class uc_Report
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            cbbNam = new ComboBox();
            panel1 = new Panel();
            btnEmail = new Button();
            button1 = new Button();
            panelCheckBox = new Panel();
            groupBox = new GroupBox();
            checkBoxOrient = new CheckBox();
            checkBoxTissot = new CheckBox();
            checkBoxSeiko = new CheckBox();
            checkBoxCitizen = new CheckBox();
            checkBoxOlymPianus = new CheckBox();
            checkBoxBentley = new CheckBox();
            checkBoxGShock = new CheckBox();
            checkBoxCasio = new CheckBox();
            chartBrandAll = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartBrand = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel2 = new Panel();
            label4 = new Label();
            PDFMinProduct = new Button();
            dtgvMinProduct = new DataGridView();
            panelTopProduct = new Panel();
            label3 = new Label();
            PDFTopProduct = new Button();
            dtgvTopProduct = new DataGridView();
            label2 = new Label();
            cbbTrungBinhHoaDon = new ComboBox();
            chartTrungBinhHoaDon = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            panelCheckBox.SuspendLayout();
            groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartBrandAll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartBrand).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvMinProduct).BeginInit();
            panelTopProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvTopProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartTrungBinhHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 11);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(204, 40);
            label1.TabIndex = 1;
            label1.Text = "Doanh thu trung bình";
            // 
            // cbbNam
            // 
            cbbNam.FormattingEnabled = true;
            cbbNam.Items.AddRange(new object[] { "Năm 2023", "Năm 2024" });
            cbbNam.Location = new Point(208, 11);
            cbbNam.Margin = new Padding(2);
            cbbNam.Name = "cbbNam";
            cbbNam.Size = new Size(150, 28);
            cbbNam.TabIndex = 2;
            cbbNam.SelectedIndexChanged += cbbNam_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(btnEmail);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panelCheckBox);
            panel1.Controls.Add(chartBrandAll);
            panel1.Controls.Add(chartBrand);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panelTopProduct);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbbTrungBinhHoaDon);
            panel1.Controls.Add(chartTrungBinhHoaDon);
            panel1.Controls.Add(chartDoanhThu);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbbNam);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1348, 725);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // btnEmail
            // 
            btnEmail.Location = new Point(1137, 7);
            btnEmail.Margin = new Padding(2);
            btnEmail.Name = "btnEmail";
            btnEmail.Size = new Size(131, 29);
            btnEmail.TabIndex = 18;
            btnEmail.Text = "Xuất báo cáo";
            btnEmail.UseVisualStyleBackColor = true;
            btnEmail.Click += btnEmail_Click;
            // 
            // button1
            // 
            button1.Location = new Point(310, 1002);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(92, 29);
            button1.TabIndex = 17;
            button1.Text = "So sánh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panelCheckBox
            // 
            panelCheckBox.Controls.Add(groupBox);
            panelCheckBox.Location = new Point(33, 992);
            panelCheckBox.Margin = new Padding(2);
            panelCheckBox.Name = "panelCheckBox";
            panelCheckBox.Size = new Size(273, 162);
            panelCheckBox.TabIndex = 16;
            // 
            // groupBox
            // 
            groupBox.Controls.Add(checkBoxOrient);
            groupBox.Controls.Add(checkBoxTissot);
            groupBox.Controls.Add(checkBoxSeiko);
            groupBox.Controls.Add(checkBoxCitizen);
            groupBox.Controls.Add(checkBoxOlymPianus);
            groupBox.Controls.Add(checkBoxBentley);
            groupBox.Controls.Add(checkBoxGShock);
            groupBox.Controls.Add(checkBoxCasio);
            groupBox.Location = new Point(10, 2);
            groupBox.Margin = new Padding(2);
            groupBox.Name = "groupBox";
            groupBox.Padding = new Padding(2);
            groupBox.Size = new Size(251, 155);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "BrandName";
            groupBox.Enter += groupBox_Enter;
            // 
            // checkBoxOrient
            // 
            checkBoxOrient.AutoSize = true;
            checkBoxOrient.Location = new Point(103, 86);
            checkBoxOrient.Margin = new Padding(2);
            checkBoxOrient.Name = "checkBoxOrient";
            checkBoxOrient.Size = new Size(72, 24);
            checkBoxOrient.TabIndex = 18;
            checkBoxOrient.Text = "Orient";
            checkBoxOrient.UseVisualStyleBackColor = true;
            checkBoxOrient.CheckedChanged += checkBox8_CheckedChanged;
            // 
            // checkBoxTissot
            // 
            checkBoxTissot.AutoSize = true;
            checkBoxTissot.Location = new Point(103, 112);
            checkBoxTissot.Margin = new Padding(2);
            checkBoxTissot.Name = "checkBoxTissot";
            checkBoxTissot.Size = new Size(69, 24);
            checkBoxTissot.TabIndex = 4;
            checkBoxTissot.Text = "Tissot";
            checkBoxTissot.UseVisualStyleBackColor = true;
            // 
            // checkBoxSeiko
            // 
            checkBoxSeiko.AutoSize = true;
            checkBoxSeiko.Location = new Point(23, 111);
            checkBoxSeiko.Margin = new Padding(2);
            checkBoxSeiko.Name = "checkBoxSeiko";
            checkBoxSeiko.Size = new Size(67, 24);
            checkBoxSeiko.TabIndex = 3;
            checkBoxSeiko.Text = "Seiko";
            checkBoxSeiko.UseVisualStyleBackColor = true;
            // 
            // checkBoxCitizen
            // 
            checkBoxCitizen.AutoSize = true;
            checkBoxCitizen.Location = new Point(23, 85);
            checkBoxCitizen.Margin = new Padding(2);
            checkBoxCitizen.Name = "checkBoxCitizen";
            checkBoxCitizen.Size = new Size(76, 24);
            checkBoxCitizen.TabIndex = 2;
            checkBoxCitizen.Text = "Citizen";
            checkBoxCitizen.UseVisualStyleBackColor = true;
            // 
            // checkBoxOlymPianus
            // 
            checkBoxOlymPianus.AutoSize = true;
            checkBoxOlymPianus.Location = new Point(104, 60);
            checkBoxOlymPianus.Margin = new Padding(2);
            checkBoxOlymPianus.Name = "checkBoxOlymPianus";
            checkBoxOlymPianus.Size = new Size(112, 24);
            checkBoxOlymPianus.TabIndex = 17;
            checkBoxOlymPianus.Text = "Olym Pianus";
            checkBoxOlymPianus.UseVisualStyleBackColor = true;
            // 
            // checkBoxBentley
            // 
            checkBoxBentley.AutoSize = true;
            checkBoxBentley.Location = new Point(23, 60);
            checkBoxBentley.Margin = new Padding(2);
            checkBoxBentley.Name = "checkBoxBentley";
            checkBoxBentley.Size = new Size(80, 24);
            checkBoxBentley.TabIndex = 1;
            checkBoxBentley.Text = "Bentley";
            checkBoxBentley.UseVisualStyleBackColor = true;
            // 
            // checkBoxGShock
            // 
            checkBoxGShock.AutoSize = true;
            checkBoxGShock.Location = new Point(103, 32);
            checkBoxGShock.Margin = new Padding(2);
            checkBoxGShock.Name = "checkBoxGShock";
            checkBoxGShock.Size = new Size(86, 24);
            checkBoxGShock.TabIndex = 5;
            checkBoxGShock.Text = "G-Shock";
            checkBoxGShock.UseVisualStyleBackColor = true;
            checkBoxGShock.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // checkBoxCasio
            // 
            checkBoxCasio.AutoSize = true;
            checkBoxCasio.Location = new Point(23, 32);
            checkBoxCasio.Margin = new Padding(2);
            checkBoxCasio.Name = "checkBoxCasio";
            checkBoxCasio.Size = new Size(67, 24);
            checkBoxCasio.TabIndex = 0;
            checkBoxCasio.Text = "Casio";
            checkBoxCasio.UseVisualStyleBackColor = true;
            // 
            // chartBrandAll
            // 
            chartArea5.Name = "ChartArea1";
            chartBrandAll.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            chartBrandAll.Legends.Add(legend5);
            chartBrandAll.Location = new Point(675, 1173);
            chartBrandAll.Margin = new Padding(2);
            chartBrandAll.Name = "chartBrandAll";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            chartBrandAll.Series.Add(series5);
            chartBrandAll.Size = new Size(650, 279);
            chartBrandAll.TabIndex = 15;
            chartBrandAll.Text = "chart1";
            // 
            // chartBrand
            // 
            chartArea6.Name = "ChartArea1";
            chartBrand.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            chartBrand.Legends.Add(legend6);
            chartBrand.Location = new Point(6, 1173);
            chartBrand.Margin = new Padding(2);
            chartBrand.Name = "chartBrand";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            chartBrand.Series.Add(series6);
            chartBrand.Size = new Size(638, 275);
            chartBrand.TabIndex = 9;
            chartBrand.Text = "chart2";
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(PDFMinProduct);
            panel2.Controls.Add(dtgvMinProduct);
            panel2.Location = new Point(781, 505);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(520, 478);
            panel2.TabIndex = 7;
            // 
            // label4
            // 
            label4.Location = new Point(20, 0);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(324, 40);
            label4.TabIndex = 8;
            label4.Text = "Sản phẩm có doanh thu ít nhất";
            // 
            // PDFMinProduct
            // 
            PDFMinProduct.Location = new Point(356, 2);
            PDFMinProduct.Margin = new Padding(2);
            PDFMinProduct.Name = "PDFMinProduct";
            PDFMinProduct.Size = new Size(92, 29);
            PDFMinProduct.TabIndex = 7;
            PDFMinProduct.Text = "In PDF";
            PDFMinProduct.UseVisualStyleBackColor = true;
            PDFMinProduct.Click += PDFMinProduct_Click;
            // 
            // dtgvMinProduct
            // 
            dtgvMinProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgvMinProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvMinProduct.Location = new Point(2, 42);
            dtgvMinProduct.Margin = new Padding(2);
            dtgvMinProduct.Name = "dtgvMinProduct";
            dtgvMinProduct.RowHeadersWidth = 82;
            dtgvMinProduct.Size = new Size(516, 434);
            dtgvMinProduct.TabIndex = 0;
            // 
            // panelTopProduct
            // 
            panelTopProduct.Controls.Add(label3);
            panelTopProduct.Controls.Add(PDFTopProduct);
            panelTopProduct.Controls.Add(dtgvTopProduct);
            panelTopProduct.Location = new Point(781, 40);
            panelTopProduct.Margin = new Padding(2);
            panelTopProduct.Name = "panelTopProduct";
            panelTopProduct.Size = new Size(520, 431);
            panelTopProduct.TabIndex = 6;
            // 
            // label3
            // 
            label3.Location = new Point(22, 0);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(296, 40);
            label3.TabIndex = 8;
            label3.Text = "Sản phẩm bán ra nhiều nhất";
            label3.Click += label3_Click;
            // 
            // PDFTopProduct
            // 
            PDFTopProduct.Location = new Point(356, 2);
            PDFTopProduct.Margin = new Padding(2);
            PDFTopProduct.Name = "PDFTopProduct";
            PDFTopProduct.Size = new Size(92, 29);
            PDFTopProduct.TabIndex = 7;
            PDFTopProduct.Text = "In PDF";
            PDFTopProduct.UseVisualStyleBackColor = true;
            PDFTopProduct.Click += PDFTopProduct_Click;
            // 
            // dtgvTopProduct
            // 
            dtgvTopProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgvTopProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvTopProduct.Location = new Point(2, 42);
            dtgvTopProduct.Margin = new Padding(2);
            dtgvTopProduct.Name = "dtgvTopProduct";
            dtgvTopProduct.RowHeadersWidth = 82;
            dtgvTopProduct.Size = new Size(516, 388);
            dtgvTopProduct.TabIndex = 0;
            // 
            // label2
            // 
            label2.Location = new Point(6, 511);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(199, 40);
            label2.TabIndex = 4;
            label2.Text = "Thống kê doanh thu";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // cbbTrungBinhHoaDon
            // 
            cbbTrungBinhHoaDon.FormattingEnabled = true;
            cbbTrungBinhHoaDon.Items.AddRange(new object[] { "Năm 2023", "Năm 2024" });
            cbbTrungBinhHoaDon.Location = new Point(233, 509);
            cbbTrungBinhHoaDon.Margin = new Padding(2);
            cbbTrungBinhHoaDon.Name = "cbbTrungBinhHoaDon";
            cbbTrungBinhHoaDon.Size = new Size(150, 28);
            cbbTrungBinhHoaDon.TabIndex = 5;
            cbbTrungBinhHoaDon.SelectedIndexChanged += cbbTrungBinhHoaDon_SelectedIndexChanged;
            // 
            // chartTrungBinhHoaDon
            // 
            chartArea7.Name = "ChartArea1";
            chartTrungBinhHoaDon.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            chartTrungBinhHoaDon.Legends.Add(legend7);
            chartTrungBinhHoaDon.Location = new Point(15, 553);
            chartTrungBinhHoaDon.Margin = new Padding(2);
            chartTrungBinhHoaDon.Name = "chartTrungBinhHoaDon";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            chartTrungBinhHoaDon.Series.Add(series7);
            chartTrungBinhHoaDon.Size = new Size(690, 430);
            chartTrungBinhHoaDon.TabIndex = 3;
            chartTrungBinhHoaDon.Text = "chart1";
            // 
            // chartDoanhThu
            // 
            chartArea8.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend8);
            chartDoanhThu.Location = new Point(15, 83);
            chartDoanhThu.Margin = new Padding(2);
            chartDoanhThu.Name = "chartDoanhThu";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            chartDoanhThu.Series.Add(series8);
            chartDoanhThu.Size = new Size(690, 388);
            chartDoanhThu.TabIndex = 1;
            chartDoanhThu.Text = "chart1";
            // 
            // uc_Report
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "uc_Report";
            Size = new Size(1348, 725);
            Load += uc_Report_Load;
            panel1.ResumeLayout(false);
            panelCheckBox.ResumeLayout(false);
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartBrandAll).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartBrand).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvMinProduct).EndInit();
            panelTopProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgvTopProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartTrungBinhHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private ComboBox cbbNam;
        private Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrungBinhHoaDon;
        private Label label2;
        private ComboBox cbbTrungBinhHoaDon;
        private Panel panelTopProduct;
        private DataGridView dtgvTopProduct;
        private Button PDFTopProduct;
        private Label label3;
        private Panel panel2;
        private Label label4;
        private Button PDFMinProduct;
        private DataGridView dtgvMinProduct;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBrandAll;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBrand;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelCheckBox;
        private GroupBox groupBox;
        private CheckBox checkBoxCitizen;
        private CheckBox checkBoxBentley;
        private CheckBox checkBoxCasio;
        private CheckBox checkBoxGShock;
        private CheckBox checkBoxSeiko;
        private CheckBox checkBoxTissot;
        private CheckBox checkBoxOrient;
        private CheckBox checkBoxOlymPianus;
        private Button button1;
        private Button btnEmail;
    }
}
