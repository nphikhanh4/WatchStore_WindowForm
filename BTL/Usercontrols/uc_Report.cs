using BLL;
using DAL;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Mail;
using System.Net;

using SystemImage = System.Drawing.Image;
using SystemFont = System.Drawing.Font;


namespace DONGHO.Usercontrols
{
    public partial class uc_Report : UserControl
    {

        public uc_Report()
        {
            InitializeComponent();

        }
        private void uc_Report_Load(object sender, EventArgs e)
        {
            cbbNam.SelectedIndex = 0;
            cbbNam_SelectedIndexChanged(sender, e);
            cbbTrungBinhHoaDon.SelectedIndex = 0;
            cbbTrungBinhHoaDon_SelectedIndexChanged(sender, e);
            LoadTopProducts();
            LoadMinProducts();
            DrawBrandChartAll();
            DrawBrandChartDefault();
            CheckBoxEvents();
        }
        private int selectedCount = 0;

        private SystemImage ResizeImage(string imagePath, int width, int height)
        {
            try
            {
                SystemImage img = SystemImage.FromFile(imagePath);
                Bitmap resizedImage = new Bitmap(img, new Size(width, height));
                img.Dispose();
                return resizedImage;
            }
            catch (Exception)
            {
                SystemImage img = SystemImage.FromFile("D:\\BTL_Web\\Khanh\\Web\\WebApplication1\\Content\\img\\G-Shock\\G-Shock Dimesion\\G-Shock Dimesion.jpg");
                Bitmap resizedImage = new Bitmap(img, new Size(width, height));
                return resizedImage;
            }
        }

        private void ChartDoanhThu(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {

                chartDoanhThu.Series.Clear();
                chartDoanhThu.ChartAreas.Clear();
                ChartArea chartArea = new ChartArea();
                chartDoanhThu.ChartAreas.Add(chartArea);
                Series series = new Series("Doanh thu")
                {
                    ChartType = SeriesChartType.Column,
                    Color = System.Drawing.Color.SteelBlue,
                    BorderWidth = 1,
                };

                foreach (DataRow row in dt.Rows)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(row["Month"], row["TotalRevenue"]);
                    point.ToolTip = $"Tháng: {row["Month"]}, Doanh thu: {row["TotalRevenue"]:C0}";
                    series.Points.Add(point);
                }
                chartDoanhThu.Series.Add(series);
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";

                chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
                chartDoanhThu.Series[0].IsValueShownAsLabel = false;
                chartDoanhThu.Series[0].ToolTip = "Tháng: #VALX, Doanh thu: #VALY VND";
                chartDoanhThu.Titles.Clear();
                Title chartTitle = new Title()
                {
                    Text = "Biểu đồ trung bình hóa đơn",
                    Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold),
                    Docking = Docking.Top,
                    Alignment = ContentAlignment.MiddleCenter
                };
                chartDoanhThu.Titles.Add(chartTitle);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ.");
            }
        }
        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = null;

            if (cbbNam.SelectedIndex == -1)
            {
                dt = ReportBL.GetInstance.GetHoaDon2023();
            }
            else if (cbbNam.SelectedIndex == 0)
            {
                dt = ReportBL.GetInstance.GetHoaDon2023();
            }
            else if (cbbNam.SelectedIndex == 1)
            {
                dt = ReportBL.GetInstance.GetHoaDon2024();
            }
            if (dt != null)
            {
                ChartDoanhThu(dt);
            }
        }

        private void ChartTrungBinhHoaDon(DataTable dt)
        {
            try
            {
                chartTrungBinhHoaDon.Series.Clear();
                chartTrungBinhHoaDon.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea("ChartArea1");
                chartArea.AxisX.Title = "Tháng";
                chartArea.AxisY.Title = "Tổng doanh thu (VND)";
                chartArea.AxisY2.Title = "Số hóa đơn";
                chartArea.AxisX.Interval = 1;

                chartArea.AxisY2.Enabled = AxisEnabled.True;
                chartTrungBinhHoaDon.ChartAreas.Add(chartArea);

                Series columnSeries = new Series("Số hóa đơn")
                {
                    ChartType = SeriesChartType.Column,
                    BorderWidth = 1,
                    Color = Color.Orange,
                    YAxisType = AxisType.Secondary
                };

                Series areaSeries = new Series("Tổng doanh thu")
                {
                    ChartType = SeriesChartType.Area,
                    BorderWidth = 2,
                    Color = Color.FromArgb(100, Color.Blue),
                    YAxisType = AxisType.Primary
                };

                Dictionary<int, (int year, decimal totalRevenue, int totalOrders)> dataDictionary = new Dictionary<int, (int, decimal, int)>();

                foreach (DataRow row in dt.Rows)
                {
                    int year = Convert.ToInt32(row["Year"]);
                    int month = Convert.ToInt32(row["Month"]);
                    decimal totalRevenue = Convert.ToDecimal(row["Tổng tiền"]);
                    int totalOrders = Convert.ToInt32(row["Tổng hóa đơn"]);

                    dataDictionary[month] = (year, totalRevenue, totalOrders);
                }

                for (int month = 1; month <= 12; month++)
                {
                    if (dataDictionary.ContainsKey(month))
                    {
                        var data = dataDictionary[month];

                        areaSeries.Points.AddXY(month, data.totalRevenue);

                        columnSeries.Points.AddXY(month, data.totalOrders);

                        areaSeries.Points[month - 1].ToolTip = $"Tháng {month}/{data.year}: Tổng doanh thu = {data.totalRevenue:C0} VND";
                        columnSeries.Points[month - 1].ToolTip = $"Tháng {month}/{data.year}: Số hóa đơn = {data.totalOrders}";
                    }
                    else
                    {
                        areaSeries.Points.AddXY(month, 0);
                        columnSeries.Points.AddXY(month, 0);
                    }
                }

                chartTrungBinhHoaDon.Series.Add(areaSeries);
                chartTrungBinhHoaDon.Series.Add(columnSeries);

                chartTrungBinhHoaDon.Legends.Clear();
                chartTrungBinhHoaDon.Legends.Add(new Legend("Legend1")
                {
                    Docking = Docking.Top,
                    Alignment = StringAlignment.Center
                });

                areaSeries.LegendText = "Tổng doanh thu";
                columnSeries.LegendText = "Số hóa đơn";

                chartTrungBinhHoaDon.Titles.Clear();
                Title chartTitle = new Title()
                {
                    Text = "Biểu đồ doanh thu",
                    Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold),
                    Docking = Docking.Top,
                    Alignment = ContentAlignment.MiddleCenter
                };
                chartTrungBinhHoaDon.Titles.Add(chartTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu biểu đồ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbTrungBinhHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = null;

            if (cbbTrungBinhHoaDon.SelectedIndex == -1)
            {
                dt = ReportBL.GetInstance.GetDoanhThu2023();
            }
            else if (cbbTrungBinhHoaDon.SelectedIndex == 0)
            {
                dt = ReportBL.GetInstance.GetDoanhThu2023();
            }
            else if (cbbTrungBinhHoaDon.SelectedIndex == 1)
            {
                dt = ReportBL.GetInstance.GetDoanhThu2024();
            }

            if (dt != null)
            {
                ChartTrungBinhHoaDon(dt);
            }
        }


        private void LoadTopProducts()
        {
            try
            {
                DataTable dt = ReportDL.GetInstance.GetTopProduct();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dtgvTopProduct.Columns.Clear();

                    dtgvTopProduct.Columns.Add("ProductName", "Tên sản phẩm");
                    dtgvTopProduct.Columns.Add("TotalSold", "Tổng số lượng bán");

                    dtgvTopProduct.Columns["TotalSold"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                    {
                        Name = "ProductImage",
                        HeaderText = "Ảnh sản phẩm",
                        ImageLayout = DataGridViewImageCellLayout.Zoom
                    };
                    dtgvTopProduct.Columns.Add(imageColumn);
                    int totalWidth = dtgvTopProduct.Width; 

                    dtgvTopProduct.Columns["ProductName"].Width = (int)(totalWidth * 0.4); 
                    dtgvTopProduct.Columns["TotalSold"].Width = (int)(totalWidth * 0.26);  
                    dtgvTopProduct.Columns["ProductImage"].Width = (int)(totalWidth * 0.2);
                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = dtgvTopProduct.Rows.Add();

                        dtgvTopProduct.Rows[rowIndex].Cells["ProductName"].Value = row["ProductName"];
                        dtgvTopProduct.Rows[rowIndex].Cells["TotalSold"].Value = row["TotalSold"];

                        if (row["ImageUrl"] != DBNull.Value)
                        {
                            string imageName = row["ImageUrl"].ToString();
                        
                            string imagePath = Path.Combine("D:\\BTL_W\\BTL_W\\BTL\\Images", imageName);

                            if (File.Exists(imagePath))
                            {
                                System.Drawing.Image img = ResizeImage(imagePath, 40, 40);
                                dtgvTopProduct.Rows[rowIndex].Cells["ProductImage"].Value = img;
                            }
                            else
                            {
                                dtgvTopProduct.Rows[rowIndex].Cells["ProductImage"].Value = null;
                            }
                        }
                        else
                        {
                            dtgvTopProduct.Rows[rowIndex].Cells["ProductImage"].Value = null;
                        }
                    }

                    //dtgvTopProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dtgvTopProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtgvTopProduct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dtgvTopProduct.AllowUserToAddRows = false;
                    dtgvTopProduct.AllowUserToResizeRows = false;
                    dtgvTopProduct.AllowUserToResizeColumns = false;
                    dtgvTopProduct.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportTopProductPDF()
        {
            try
            {
                if (dtgvTopProduct.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    FileName = "TopProducts.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    string fontPath = @"C:\Windows\Fonts\tahoma.ttf";
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(baseFont, 12);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Báo cáo: Top 7 Sản Phẩm Bán Chạy", headerFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    document.Add(title);

                    document.Add(new iTextSharp.text.Paragraph("\n"));

                    PdfPTable table = new PdfPTable(dtgvTopProduct.Columns.Count)
                    {
                        WidthPercentage = 100
                    };

                    foreach (DataGridViewColumn column in dtgvTopProduct.Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new iTextSharp.text.Phrase(column.HeaderText, vietnameseFont))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                        };
                        table.AddCell(headerCell);
                    }

                    foreach (DataGridViewRow row in dtgvTopProduct.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell is DataGridViewImageCell imageCell && imageCell.Value != null)
                            {
                                System.Drawing.Image img = (System.Drawing.Image)imageCell.Value;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                    pdfImage.ScaleAbsolute(50f, 50f);
                                    PdfPCell imagePdfCell = new PdfPCell(pdfImage)
                                    {
                                        HorizontalAlignment = Element.ALIGN_CENTER,
                                        Padding = 5
                                    };
                                    table.AddCell(imagePdfCell);
                                }
                            }
                            else
                            {
                                PdfPCell dataCell = new PdfPCell(new iTextSharp.text.Phrase(cell.Value?.ToString() ?? "", vietnameseFont))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER
                                };
                                table.AddCell(dataCell);
                            }
                        }
                    }

                    document.Add(table);

                    document.Close();

                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PDFTopProduct_Click(object sender, EventArgs e)
        {
            ExportTopProductPDF();

        }



        private void LoadMinProducts()
        {
            try
            {
                DataTable dt = ReportDL.GetInstance.GetMinProduct();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dtgvMinProduct.Columns.Clear();


                    dtgvMinProduct.Columns.Add("ProductName", "Tên sản phẩm");
                    dtgvMinProduct.Columns.Add("TotalRevenue", "Doanh thu");
                    dtgvMinProduct.Columns["TotalRevenue"].DefaultCellStyle.Format = "C0";
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
                    {
                        Name = "ProductImage",
                        HeaderText = "Hình ảnh",
                        ImageLayout = DataGridViewImageCellLayout.Zoom,

                    };
                    dtgvMinProduct.Columns.Add(imageColumn);
                    int totalWidth = dtgvMinProduct.Width;

                    dtgvMinProduct.Columns["ProductName"].Width = (int)(totalWidth * 0.4); 
                    dtgvMinProduct.Columns["TotalRevenue"].Width = (int)(totalWidth * 0.26); 
                    dtgvMinProduct.Columns["ProductImage"].Width = (int)(totalWidth * 0.2);

                    foreach (DataRow row in dt.Rows)
                    {
                        int rowIndex = dtgvMinProduct.Rows.Add();

                        dtgvMinProduct.Rows[rowIndex].Cells["ProductName"].Value = row["ProductName"];
                        dtgvMinProduct.Rows[rowIndex].Cells["TotalRevenue"].Value = row["TotalRevenue"];

                        if (row["ImageUrl"] != DBNull.Value)
                        {
                            string imageName = row["ImageUrl"].ToString();
                            string imagePath = Path.Combine("D:\\BTL_W\\BTL_W\\BTL\\Images", imageName);
                            if (File.Exists(imagePath))
                            {
                                System.Drawing.Image img = img = ResizeImage(imagePath, 40, 40);
                                dtgvMinProduct.Rows[rowIndex].Cells["ProductImage"].Value = img;
                            }
                            else
                            {
                                dtgvMinProduct.Rows[rowIndex].Cells["ProductImage"].Value = null;
                            }
                        }
                        else
                        {
                            dtgvMinProduct.Rows[rowIndex].Cells["ProductImage"].Value = null;
                        }
                    }


                    dtgvMinProduct.RowTemplate.Height = 10;
                    dtgvMinProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtgvMinProduct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dtgvMinProduct.AllowUserToAddRows = false;
                    dtgvMinProduct.AllowUserToResizeRows = false;
                    dtgvMinProduct.AllowUserToResizeColumns = false;
                    dtgvMinProduct.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ExportMinProductPDF()
        {
            try
            {
                if (dtgvMinProduct.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất PDF!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    FileName = "MinSaleProducts.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    string fontPath = @"C:\Windows\Fonts\tahoma.ttf";
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font vietnameseFont = new iTextSharp.text.Font(baseFont, 12);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Báo cáo: Top 10 Sản Phẩm Có Doanh Thu Ít Nhất", headerFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    document.Add(title);
                    document.Add(new iTextSharp.text.Paragraph("\n"));

                    PdfPTable table = new PdfPTable(dtgvMinProduct.Columns.Count)
                    {
                        WidthPercentage = 100
                    };

                    foreach (DataGridViewColumn column in dtgvMinProduct.Columns)
                    {
                        PdfPCell headerCell = new PdfPCell(new iTextSharp.text.Phrase(column.HeaderText, vietnameseFont))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY
                        };
                        table.AddCell(headerCell);
                    }

                    foreach (DataGridViewRow row in dtgvMinProduct.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell is DataGridViewImageCell imageCell && imageCell.Value != null)
                            {
                                System.Drawing.Image img = (System.Drawing.Image)imageCell.Value;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                    pdfImage.ScaleAbsolute(50f, 50f);
                                    PdfPCell imagePdfCell = new PdfPCell(pdfImage)
                                    {
                                        HorizontalAlignment = Element.ALIGN_CENTER,
                                        Padding = 5
                                    };
                                    table.AddCell(imagePdfCell);
                                }
                            }
                            else if (dtgvMinProduct.Columns[cell.ColumnIndex].Name == "TotalRevenue")
                            {
                                string formattedValue = string.Format("{0:C0}", Convert.ToDecimal(cell.Value));
                                PdfPCell dataCell = new PdfPCell(new iTextSharp.text.Phrase(formattedValue, vietnameseFont))
                                {
                                    HorizontalAlignment = Element.ALIGN_RIGHT
                                };
                                table.AddCell(dataCell);
                            }
                            else
                            {
                                PdfPCell dataCell = new PdfPCell(new iTextSharp.text.Phrase(cell.Value?.ToString() ?? "", vietnameseFont))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER
                                };
                                table.AddCell(dataCell);
                            }

                        }
                    }

                    document.Add(table);

                    document.Close();

                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PDFMinProduct_Click(object sender, EventArgs e)
        {
            ExportMinProductPDF();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DrawBrandChart()
        {
            DataTable dt = ReportDL.GetInstance.GetBrand();
            if (dt != null && dt.Rows.Count > 0)
            {
                chartBrand.Series.Clear();
                chartBrand.ChartAreas.Clear();
                chartBrand.Titles.Clear();

                ChartArea chartArea = new ChartArea();
                chartBrand.ChartAreas.Add(chartArea);

                List<string> selectedBrands = new List<string>();

                if (checkBoxCasio.Checked) selectedBrands.Add("Casio");
                if (checkBoxSeiko.Checked) selectedBrands.Add("Seiko");
                if (checkBoxOrient.Checked) selectedBrands.Add("Orient");
                if (checkBoxBentley.Checked) selectedBrands.Add("Bentley");
                if (checkBoxTissot.Checked) selectedBrands.Add("Tissot");
                if (checkBoxOlymPianus.Checked) selectedBrands.Add("Olym Pianus");
                if (checkBoxCitizen.Checked) selectedBrands.Add("Citizen");
                if (checkBoxGShock.Checked) selectedBrands.Add("G-Shock");


                if (selectedBrands.Count <= 3)
                {
                    foreach (var brandName in selectedBrands)
                    {
                        Series series = new Series(brandName)
                        {
                            ChartType = SeriesChartType.StackedColumn,  // Biểu đồ cột chồng
                            BorderWidth = 1,
                            BorderColor = Color.Transparent,
                            ShadowOffset = 0,
                            IsValueShownAsLabel = false,
                        };

                        if (brandName == "Casio")
                        {
                            series.Color = Color.Blue;
                        }
                        else if (brandName == "Seiko")
                        {
                            series.Color = Color.Green;
                        }
                        else if (brandName == "Orient")
                        {
                            series.Color = Color.Red;
                        }
                        else if (brandName == "Bentley")
                        {
                            series.Color = Color.Aqua;
                        }

                        else if (brandName == "Tissot")
                        {
                            series.Color = Color.Violet;
                        }
                        else if (brandName == "Citizen")
                        {
                            series.Color = Color.Thistle;
                        }
                        else if (brandName == "Olym Pianus")
                        {
                            series.Color = Color.Transparent;
                        }
                        else series.Color = Color.Yellow;

                        chartBrand.Series.Add(series);
                    }

                    var months = dt.AsEnumerable().Select(r => r.Field<int>("Month")).Distinct().OrderBy(m => m).ToList();

                    foreach (int month in months)
                    {
                        foreach (var brandName in selectedBrands)
                        {
                            var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("Month") == month && r.Field<string>("BrandName") == brandName);

                            int quantity = row != null ? row.Field<int>("TotalQuantitySold") : 0;

                            var series = chartBrand.Series[brandName];
                            series.Points.AddXY(month, quantity);
                        }
                    }

                    chartBrand.ChartAreas[0].AxisX.Title = "Tháng";
                    chartBrand.ChartAreas[0].AxisY.Title = "Tổng số lượng bán";
                    chartBrand.ChartAreas[0].AxisX.Interval = 1;
                    chartBrand.ChartAreas[0].AxisY.LabelStyle.Format = "0";
                    chartBrand.Titles.Clear();
                    Title chartTitle = new Title()
                    {
                        Text = "Biểu đồ doanh thu theo thương hiệu",
                        Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold),
                        Docking = Docking.Top,
                        Alignment = ContentAlignment.MiddleCenter
                    };
                    chartBrand.Titles.Add(chartTitle);
                }
                else
                {
                    MessageBox.Show("Bạn chỉ có thể chọn tối đa 3 thương hiệu để vẽ biểu đồ.");
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ.");
            }
        }

        private void DrawBrandChartDefault()
        {
            DataTable dt = ReportDL.GetInstance.GetBrand();
            if (dt != null && dt.Rows.Count > 0)
            {
                chartBrand.Series.Clear();
                chartBrand.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();
                chartBrand.ChartAreas.Add(chartArea);

                var brandNames = dt.AsEnumerable()
                                   .Select(r => r.Field<string>("BrandName"))
                                   .Distinct()
                                   .Take(3)
                                   .ToList();

                foreach (var brandName in brandNames)
                {
                    Series series = new Series(brandName)
                    {
                        ChartType = SeriesChartType.StackedColumn,
                        BorderWidth = 1,
                        BorderColor = Color.Transparent,
                        ShadowOffset = 0,
                        IsValueShownAsLabel = false,

                    };
                    if (brandName == "Casio")
                    {
                        series.Color = Color.Blue;
                    }
                    else if (brandName == "Seiko")
                    {
                        series.Color = Color.Green;
                    }
                    else if (brandName == "Orient")
                    {
                        series.Color = Color.Red;
                    }

                    chartBrand.Series.Add(series);
                }

                var months = dt.AsEnumerable().Select(r => r.Field<int>("Month")).Distinct().OrderBy(m => m).ToList();

                foreach (int month in months)
                {
                    foreach (var brandName in brandNames)
                    {
                        var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("Month") == month && r.Field<string>("BrandName") == brandName);
                        int quantity = row != null ? row.Field<int>("TotalQuantitySold") : 0;
                        var series = chartBrand.Series[brandName];
                        series.Points.AddXY(month, quantity);
                    }
                }

                chartBrand.ChartAreas[0].AxisX.Title = "Tháng";
                chartBrand.ChartAreas[0].AxisY.Title = "Tổng số lượng bán";
                chartBrand.ChartAreas[0].AxisX.Interval = 1;
                chartBrand.ChartAreas[0].AxisY.LabelStyle.Format = "0";

                Title chartTitle = new Title()
                {
                    Text = "Biểu đồ doanh thu theo thương hiệu",
                    Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold),
                    Docking = Docking.Top,
                    Alignment = ContentAlignment.MiddleCenter
                };
                chartBrand.Titles.Add(chartTitle);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ.");
            }
        }

        private void DrawBrandChartAll()
        {
            DataTable dt = ReportDL.GetInstance.GetBrandAll();
            if (dt != null && dt.Rows.Count > 0)
            {
                chartBrandAll.Series.Clear();
                chartBrandAll.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea
                {
                    AxisX =
            {
                Title = "Tổng số lượng bán",
                LabelStyle = { Format = "0" },
                IsReversed = false,
                MajorGrid = { LineColor = Color.LightGray },
                Interval = 1
            },
                    AxisY =
            {
                Title = "Thương hiệu",
                LabelAutoFitStyle = LabelAutoFitStyles.None,
                IsReversed = false,
                MajorGrid = { LineColor = Color.LightGray }
            },
                    Area3DStyle = { Inclination = 45, Rotation = 0, IsClustered = true }
                };
                chartBrandAll.ChartAreas.Add(chartArea);

                Series series = new Series("BrandSales")
                {
                    ChartType = SeriesChartType.Bar,
                    BorderWidth = 1,
                    BorderColor = Color.Transparent,
                    ShadowOffset = 0,
                    IsValueShownAsLabel = true,
                    BackGradientStyle = GradientStyle.TopBottom,
                    IsXValueIndexed = true
                };

                foreach (DataRow row in dt.Rows)
                {
                    string brandName = row["Hang"].ToString();
                    int totalQuantitySold = Convert.ToInt32(row["TotalQuantitySold"]);

                    series.Points.AddXY(brandName, totalQuantitySold);
                    series.Points[series.Points.Count - 1].ToolTip = $"{brandName}: {totalQuantitySold} sản phẩm đã bán";
                }

                chartBrandAll.Series.Add(series);

                chartBrandAll.ChartAreas[0].AxisX.Title = "Tổng số lượng bán";
                chartBrandAll.ChartAreas[0].AxisY.Title = "Thương hiệu";

                Title chartTitle = new Title()
                {
                    Text = "Biểu đồ doanh thu theo thương hiệu",
                    Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold),
                    Docking = Docking.Top,
                    Alignment = ContentAlignment.MiddleCenter
                };
                chartBrandAll.Titles.Add(chartTitle);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ.");
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void CheckBoxEvents()
        {
            checkBoxCasio.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            checkBoxSeiko.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            checkBoxOrient.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            checkBoxBentley.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            checkBoxCitizen.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            checkBoxGShock.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            checkBoxOlymPianus.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            checkBoxTissot.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);

        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox != null)
            {
                CheckBox[] checkBoxes = { checkBoxCasio, checkBoxSeiko, checkBoxOrient, checkBoxBentley, checkBoxTissot, checkBoxOlymPianus, checkBoxCitizen, checkBoxGShock };

                int checkedCount = checkBoxes.Count(c => c.Checked);

                if (checkedCount > 3)
                {
                    checkBox.Checked = false;
                    MessageBox.Show("Bạn chỉ có thể chọn tối đa 3 thương hiệu.");
                }
                else
                {
                    if (checkBox.Checked)
                    {
                        MessageBox.Show($"{checkBox.Text} đã được chọn.");
                    }
                    else
                    {
                        MessageBox.Show($"{checkBox.Text} đã bị bỏ chọn.");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawBrandChart();
        }      

        private void btnEmail_Click(object sender, EventArgs e)
        {
            Form emailInputForm = new Form();
            emailInputForm.Text = "Nhập email nhận báo cáo";
            emailInputForm.Size = new Size(500, 250);
            emailInputForm.StartPosition = FormStartPosition.CenterScreen;


            Label emailLabel = new Label();
            emailLabel.Text = "Vui lòng nhập địa chỉ email:";
            emailLabel.Location = new Point(20, 20);
            emailLabel.AutoSize = true;
            emailInputForm.Controls.Add(emailLabel);

            TextBox emailTextBox = new TextBox();
            emailTextBox.Location = new Point(20, 60);
            emailTextBox.Width = 350;
            emailInputForm.Controls.Add(emailTextBox);

            Button submitButton = new Button();
            submitButton.Text = "Gửi";
            submitButton.Location = new Point(150, 120);
            submitButton.AutoSize = true;
            submitButton.Click += (s, args) =>
            {
                string userEmail = emailTextBox.Text.Trim();

                if (string.IsNullOrEmpty(userEmail) || !IsValidEmail(userEmail))
                {
                    MessageBox.Show("Vui lòng nhập email hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ExportChartsToPDF(userEmail, chartBrand, chartBrandAll, chartDoanhThu, chartTrungBinhHoaDon);
                }

                emailInputForm.Close();
            };
            emailInputForm.Controls.Add(submitButton);

            emailInputForm.ShowDialog();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void ExportChartsToPDF(string userEmail, params Chart[] charts)
        {
            try
            {
                using (MemoryStream pdfStream = new MemoryStream())
                {
                    iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(document, pdfStream);
                    document.Open();

                    string fontPath = @"C:\Windows\Fonts\tahoma.ttf";
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                   
                    document.Add(new iTextSharp.text.Paragraph("\n"));

                    foreach (var bieudo in charts)
                    {
                        using (MemoryStream chartImageStream = new MemoryStream())
                        {
                            bieudo.SaveImage(chartImageStream, ChartImageFormat.Png);
                            chartImageStream.Position = 0;

                            iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(chartImageStream.ToArray());
                            chartImage.Alignment = Element.ALIGN_CENTER;
                            chartImage.ScaleToFit(PageSize.A4.Width - 20, PageSize.A4.Height - 100);
                            document.Add(chartImage);

                            document.Add(new iTextSharp.text.Paragraph("\n"));
                        }
                    }

                    document.Close();

                    SendPasswordEmail(userEmail, "Biểu đồ doanh thu WatchStore", pdfStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SendPasswordEmail(string userEmail, string subject, byte[] pdfFile)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("watchstore4conga@gmail.com", "wfxx gjdt ucie kzdk"),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("watchstore4conga@gmail.com"),
                    Subject = subject,
                    Body = "Xin chào, đây là báo cáo PDF của cửa hàng WatchStore.",
                    IsBodyHtml = true
                };
                mailMessage.To.Add(userEmail);

                using (MemoryStream ms = new MemoryStream(pdfFile))
                {
                    mailMessage.Attachments.Add(new Attachment(ms, "Biểu Đồ WatchStore.pdf", "application/pdf"));
                    smtpClient.Send(mailMessage);
                }

                MessageBox.Show("Email đã được gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
