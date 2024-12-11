using BusinessLogicLayer;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DONGHO.Usercontrols
{
    public partial class UC_Home : System.Windows.Forms.UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }
        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            LoadData();
            cboDoanhThu.SelectedIndex = 0;
            cboTopSanPham1.SelectedIndex = 0;
            cboTopSanPham2.SelectedIndex = 0;
        }
        private string Convert(double gia)
        {
            string giaban = gia.ToString();
            string result = "";
            int d = 0;
            for (int i = giaban.Length - 1; i >= 0; i--)
            {
                d++;
                result += giaban[i];
                if (d == 3 && i != 0)
                {
                    result += '.';
                    d = 0;
                }
            }
            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void LoadData()
        {
            Cursor = Cursors.AppStarting;
            lbSanPhanDaBan.Text = TrangChuBL.GetInstance.GetTongSanPhamDaBan().ToString();
            lbTongDoanhThu.Text = Convert(TrangChuBL.GetInstance.GetTongDoanhThu()) + " ₫";
            lbTongKhachHang.Text = TrangChuBL.GetInstance.GetTongKhachHang().ToString();
            Cursor = Cursors.Default;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        List<DoanhThuDTO> lstdt = new List<DoanhThuDTO>();
        DoanhThuDTO dtDTO;
        private void cboDoanhThu_SelectedValueChanged(object sender, EventArgs e)
        {
            lblDoanhThu.Text = "Biểu Đồ Doanh Thu " + cboDoanhThu.SelectedItem.ToString();
            chartDoanhThu.Series.Clear();

            var series = chartDoanhThu.Series.Add("Doanh Thu");
            series.ChartType = SeriesChartType.Bar;
            series.Font = new Font("UTM Avo", 10, FontStyle.Bold);
            series.BorderColor = Color.Orange;
            series.BorderWidth = 2;
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1; // Đảm bảo mỗi điểm hiển thị cách đều
            chartDoanhThu.ChartAreas[0].AxisX.IsMarginVisible = true; // Hiển thị khoảng cách giữa các cột
            chartDoanhThu.Series["Doanh Thu"].IsXValueIndexed = true; // Sắp xếp giá trị X theo thứ tự

            List<DoanhThuDTO> revenueData = new List<DoanhThuDTO>();
            switch (cboDoanhThu.SelectedItem.ToString())
            {

                case "Hôm nay":
                    double todayRevenue = TrangChuBL.GetInstance.GetDoanhThuHomNay();
                    revenueData.Add(new DoanhThuDTO { ngay = DateTime.Now, doanhthu = todayRevenue });
                    break;
                case "Hôm qua":
                    var yesterday = TrangChuBL.GetInstance.GetDoanhThuHomQua();
                    revenueData.Add(yesterday ?? new DoanhThuDTO { ngay = DateTime.Now.AddDays(-1), doanhthu = 0 });
                    break;
                case "7 ngày qua":
                    lstdt = TrangChuBL.GetInstance.GetDoanhThu7NgayQua();

                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.doanhthu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.doanhthu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;

                case "Tháng này":
                    lstdt = TrangChuBL.GetInstance.GetDoanhThuThangNay();
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.doanhthu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.doanhthu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                case "Tháng trước":
                    lstdt = TrangChuBL.GetInstance.GetDoanhThuThangTruoc();
                    
                    if (lstdt.Count > 0)
                    {
                        int n = 0;
                        for (int l = lstdt.Count - 1; l >= 0; l--)
                        {
                            dtDTO = lstdt[l];
                            chartDoanhThu.Series["Doanh Thu"].Points.Add(dtDTO.doanhthu);
                            chartDoanhThu.Series["Doanh Thu"].Points[n].AxisLabel = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LegendText = dtDTO.ngay.ToShortDateString();
                            chartDoanhThu.Series["Doanh Thu"].Points[n].LabelForeColor = Color.OrangeRed;
                            chartDoanhThu.Series["Doanh Thu"].Points[n].Label = Convert(dtDTO.doanhthu).ToString() + " ₫";
                            n++;
                        }
                    }
                    else
                    {
                        chartDoanhThu.Series["Doanh Thu"].Points.Add(0);
                        chartDoanhThu.Series["Doanh Thu"].Points[0].LabelForeColor = Color.OrangeRed;
                        chartDoanhThu.Series["Doanh Thu"].Points[0].Label = "0 ₫";
                    }
                    break;
                default:
                    break;
            }

            for (int i = 0; i < revenueData.Count; i++)
            {
                var point = series.Points.Add(revenueData[i].doanhthu);
                series.Points[i].AxisLabel = revenueData[i].ngay.ToShortDateString();
                series.Points[i].LabelForeColor = Color.OrangeRed;
                series.Points[i].Label = $"{revenueData[i].doanhthu:N0} ₫";
            }
        }

        private void cboTopSanPham1_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (cboTopSanPham2.SelectedItem != null)
            {
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuong7NgayQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangTruoc();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThu7NgayQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangTruoc();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void lblTopSP_Click(object sender, EventArgs e)
        {

        }

        private void cboTopSanPham2_SelectedValueChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (cboTopSanPham2.SelectedItem != null)
            {
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongHomQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuong7NgayQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo số lượng" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoSoLuongThangTruoc();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.quantity);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = pdDTO.quantity + "";
                        i++;
                    }
                }
                if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm nay")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Hôm qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuHomQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "7 ngày qua")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThu7NgayQua();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng này")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangNay();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
                else if (cboTopSanPham2.SelectedItem.ToString() == "Theo doanh thu" && cboTopSanPham1.SelectedItem.ToString() == "Tháng trước")
                {
                    chartTopSP.Series.Clear();
                    chartTopSP.Series.Add("Top 10 Sản Phẩm");
                    chartTopSP.Series["Top 10 Sản Phẩm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    chartTopSP.Series["Top 10 Sản Phẩm"].Font = new Font("UTM Avo", 12, FontStyle.Bold);
                    chartTopSP.Series["Top 10 Sản Phẩm"].LabelForeColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderColor = Color.White;
                    chartTopSP.Series["Top 10 Sản Phẩm"].BorderWidth = 2;

                    List<ProductDTO> lstSP = TrangChuBL.GetInstance.GetTop10SPTheoDoanhThuThangTruoc();
                    int i = 0;
                    foreach (ProductDTO pdDTO in lstSP)
                    {
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points.Add(pdDTO.tongdoanhthu);
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].AxisLabel = pdDTO.productid.ToString();
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].LegendText = pdDTO.productname;
                        chartTopSP.Series["Top 10 Sản Phẩm"].Points[i].Label = Convert(pdDTO.tongdoanhthu).ToString() + " ₫";
                        i++;
                    }
                }
            }
            Cursor = Cursors.Default;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboDoanhThu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
