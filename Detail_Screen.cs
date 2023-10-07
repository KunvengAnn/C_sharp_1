using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel; //library Export to Excel

namespace QL_Phan_Cong_Gaing_Day
{
    public partial class Detail_Screen : Form
    {
        //for connect to sql and run query
        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=Phan_Cong_GV;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();


        // Helper method to create DataGridViewTextBoxColumn
        private DataGridViewTextBoxColumn CreateTextBoxColumn(string dataPropertyName, string headerText)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText
            };
        }
        bool LoadDataIntodgvDetailGVD()
        {
            try
            {
                dgvDetailGVD.Rows.Clear();
                dgvDetailGVD.Refresh();
                dgvDetailGVD.DataSource = null;
                // Clear columns in dgvGiangDay
                dgvDetailGVD.Columns.Clear();
                dgvDetailGVD.AutoGenerateColumns = false;

                // Define and add the columns you want to display
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("HoVaTenGV", "HoVaTenGV"));
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("Ten_MH", "Ten_MH"));
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("TenLop", "TenLop"));
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("Ten_Hoc_Ky", "Ten_Hoc_Ky"));
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("Ngay_Bat_Dau_HK", "Ngay_Bat_Dau_HK"));
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("Ngay_Ket_Thuc_HK", "Ngay_Ket_Thuc_HK"));
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("Ten_Bo_Mon", "Ten_Bo_Mon"));
                dgvDetailGVD.Columns.Add(CreateTextBoxColumn("Total_HoursGD1KY", "TotalHours1Ky"));

                //_idPCGiangDay get throught constructor
                command = connection.CreateCommand();
                command.CommandText = "SELECT\r\n  GV.HoVaTenGV,\r\n   MH.Ten_MH,\r\n  LH.TenLop,\r\n  HK.Ten_Hoc_Ky,\r\n  HK.Ngay_Bat_Dau_HK,\r\n  HK.Ngay_Ket_Thuc_HK,\r\n  BM.Ten_Bo_Mon,\r\n  SUM(PGV.SoTiet_1Tuan*10) AS Total_HoursGD1KY\r\nFROM\r\n  Phan_Cong_Giang_Day PGV\r\n  INNER JOIN Mon_Hoc MH ON MH.Ma_MH = PGV.Ma_MH\r\n  INNER JOIN Giang_Vien GV ON GV.Ma_GV = PGV.Ma_GV\r\n  INNER JOIN Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM\r\n  INNER JOIN Hoc_Ky HK ON HK.Ma_HK = PGV.Ma_HK\r\n  INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH\r\nWHERE\r\n  GV.Ma_GV = '" + _MaGV + "' AND HK.Ma_HK = '" + _MaHocKY + "'\r\nGROUP BY\r\n  GV.HoVaTenGV,\r\n  HK.Ten_Hoc_Ky,\r\n   MH.Ten_MH,\r\n  LH.TenLop,\r\n  HK.Ngay_Bat_Dau_HK,\r\n  HK.Ngay_Ket_Thuc_HK,\r\n  BM.Ten_Bo_Mon;";

                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                dgvDetailGVD.DataSource = table;

                // Now, add the "STT" column and populate it
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "STT";
                sttColumn.HeaderText = "STT";
                dgvDetailGVD.Columns.Insert(0, sttColumn); // Insert as the first column

                for (int i = 0; i < dgvDetailGVD.Rows.Count; i++)
                {
                    dgvDetailGVD.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private String _idPCGiangDay;
        private String _MaGV;
        private String _MaHocKY;
        public Detail_Screen(string textTenGVDetail, String idPCGiangDaySelectedGgv, string maGV, string maHocKY)
        {
            InitializeComponent();
            labelTenGV.Text = textTenGVDetail; //pass name Through constructor
            _idPCGiangDay = idPCGiangDaySelectedGgv;
            _MaGV = maGV;
            _MaHocKY = maHocKY;
        }
        public DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            dap.SelectCommand = new SqlCommand();
            dap.SelectCommand.Connection = connection; //Kết nối cơ sở dữ liệu
            dap.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        private void btnExportToExcelFile_Click(object sender, EventArgs e)
        {
            try
            {
                // Display "Please wait" message
                MessageBox.Show("Opening now, please wait...", "Please Wait", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Khởi động chương trình Excel
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                DataTable tblInformationDetail;
                DataTable onlYNameGV;
                exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
                exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
                //// Định dạng chung
                exRange = (COMExcel.Range)exSheet.Cells[1, 1];
                exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font style
                exRange.Range["A1:B3"].Font.Size = 10;
                exRange.Range["A1:B3"].Font.Bold = true;
                exRange.Range["A1:B3"].Font.ColorIndex = 1; //set Color 1 black 5 blue  
                exRange.Range["A1:A1"].ColumnWidth = 7;
                exRange.Range["B1:B1"].ColumnWidth = 15;
                exRange.Range["A1:D1"].MergeCells = true;
                exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:D1"].Value = "Trường Đại Học Kỹ thuật Công Nghiệp ";
                exRange.Range["A2:D2"].MergeCells = true;
                exRange.Range["A2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A2:D2"].Value = "Khoa(Quản Lý Chuyên môn)";

                //CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM
                exRange.Range["J1:P1"].MergeCells = true;
                exRange.Range["J1:P1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["J1:P1"].Value = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
                //Độc lập - Tự do - Hành phúc
                exRange.Range["J2:P2"].MergeCells = true;
                exRange.Range["J2:P2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["J2:P2"].Value = "Độc lập - Tự do - Hành phúc";


                exRange.Range["C3:K3"].Font.Size = 16;
                exRange.Range["C3:K3"].Font.Bold = true;
                exRange.Range["C3:K3"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["C3:K3"].MergeCells = true;
                exRange.Range["C3:K3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C3:K3"].Value = "Bảng Thống kế Tổng Hợp Lao Dộng Cá Nhân";
                //Năm học
                exRange.Range["F4:I4"].MergeCells = true;
                exRange.Range["F4:I4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["F4:I4"].Value = "Năm học";
                //Hệ Chính quy
                exRange.Range["F5:I5"].MergeCells = true;
                exRange.Range["F5:I5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["F5:I5"].Value = "Hệ Chính quy";
                //I. Thông Tin
                exRange.Range["A10:B10"].MergeCells = true;
                exRange.Range["A10:B10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["A10:B10"].Value = "I. Thông Tin";
                //Họ Tên Giảng Viên:
                exRange.Range["A11:B11"].MergeCells = true;
                exRange.Range["A11:B11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["A11:B11"].Value = "Họ Tên Giảng Viên:";
                sql = "Select HoVaTenGV From Giang_Vien WHERE Ma_GV = '" + _MaGV + "'";
                onlYNameGV = GetDataToTable(sql);
                //TenGv
                exRange.Range["C11:D11"].MergeCells = true;
                exRange.Range["C11:D11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["C11:D11"].Value = onlYNameGV.Rows[0]["HoVaTenGV"].ToString();

                //Chức vụ Chính quyên:
                exRange.Range["A12:B12"].MergeCells = true;
                exRange.Range["A12:B12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["A12:B12"].Value = "Chức vụ Chính quyên:";
                //Chưc vụ kiêm nhiêm:
                exRange.Range["A13:B13"].MergeCells = true;
                exRange.Range["A13:B13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["A13:B13"].Value = "Chưc vụ kiêm nhiêm:";
                //Mã Ngạch:
                exRange.Range["J11:K11"].MergeCells = true;
                exRange.Range["J11:K11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["J11:K11"].Value = "Mã Ngạch:";
                //Ngạch viên chức :
                exRange.Range["J12:K12"].MergeCells = true;
                exRange.Range["J12:K12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["J12:K12"].Value = "Ngạch viên chức :";
                //Giảng Viên
                exRange.Range["L12:M12"].MergeCells = true;
                exRange.Range["L12:M12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["L12:M12"].Value = "Giảng Viên";
                //Học hàm vị:
                exRange.Range["J13:K13"].MergeCells = true;
                exRange.Range["J13:K13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["J13:K13"].Value = "Học hàm vị:";
                //Tiến Sỹ
                exRange.Range["L13:M13"].MergeCells = true;
                exRange.Range["L13:M13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["L13:M13"].Value = "Tiến Sỹ";
                //II. Tổng Kết loa động cá nhân
                exRange.Range["A15:D15"].MergeCells = true;
                exRange.Range["A15:D15"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
                exRange.Range["A15:D15"].Value = "II. Tổng Kết loa động cá nhân";



                //exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();  // Biểu diễn thông tin chung của hóa đơn bán//SELECT A.MA_DATHANG, A.NGAYLAP,A.TongTien,B.TEN_KH,B.DIACHI_KH,B.DIACHI_KH,C.TEN_NV FROM DATHANG A, KHACHHANG B, NHANVIEN C WHERE A.MA_DATHANG='MD01' AND A.MA_KH=B.MA_KH AND A.MA_NV=C.MA_NV ;
                //sql = "SELECT A.MA_DATHANG, A.NGAYLAP,A.TongTien,B.TEN_KH,B.DIACHI_KH,B.DIACHI_KH,C.TEN_NV FROM DATHANG A, KHACHHANG B, " +
                //      "NHANVIEN C WHERE A.MA_DATHANG = N'" + txbMaDH.Text + "' AND A.MA_KH=B.MA_KH AND A.MA_NV=C.MA_NV";
                //tblThongtinHD = GetDataToTable(sql);
                //exRange.Range["B6:C9"].Font.Size = 12;
                //exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
                //exRange.Range["C6:E6"].MergeCells = true;
                //exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
                //exRange.Range["B7:B7"].Value = "Khách hàng:";
                //exRange.Range["C7:E7"].MergeCells = true;
                //exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
                //exRange.Range["B8:B8"].Value = "Địa chỉ:";
                //exRange.Range["C8:E8"].MergeCells = true;
                //exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
                //exRange.Range["B9:B9"].Value = "Điện thoại:";
                //exRange.Range["C9:E9"].MergeCells = true;
                //exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();

                //Lấy thông tin 
                sql = "SELECT\r\n  GV.HoVaTenGV,\r\n   MH.Ten_MH,\r\n  LH.TenLop,\r\n  HK.Ten_Hoc_Ky,\r\n  HK.Ngay_Bat_Dau_HK,\r\n  HK.Ngay_Ket_Thuc_HK,\r\n  BM.Ten_Bo_Mon,\r\n  SUM(PGV.SoTiet_1Tuan*10) AS Total_HoursGD1KY\r\nFROM\r\n  Phan_Cong_Giang_Day PGV\r\n  INNER JOIN Mon_Hoc MH ON MH.Ma_MH = PGV.Ma_MH\r\n  INNER JOIN Giang_Vien GV ON GV.Ma_GV = PGV.Ma_GV\r\n  INNER JOIN Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM\r\n  INNER JOIN Hoc_Ky HK ON HK.Ma_HK = PGV.Ma_HK\r\n  INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH\r\nWHERE\r\n  GV.Ma_GV = '" + _MaGV + "' AND HK.Ma_HK = '" + _MaHocKY + "'\r\nGROUP BY\r\n  GV.HoVaTenGV,\r\n  HK.Ten_Hoc_Ky,\r\n   MH.Ten_MH,\r\n  LH.TenLop,\r\n  HK.Ngay_Bat_Dau_HK,\r\n  HK.Ngay_Ket_Thuc_HK,\r\n  BM.Ten_Bo_Mon; ";
                tblInformationDetail = GetDataToTable(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A17:I17"].Font.Bold = true;
                exRange.Range["A17:I17"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C17:I17"].ColumnWidth = 12;
                exRange.Range["A17:A17"].Value = "STT";
                exRange.Range["B17:B17"].Value = "HoTenGV";
                exRange.Range["C17:C17"].Value = "TenMH";
                exRange.Range["D17:D17"].Value = "TenLop";
                exRange.Range["E17:E17"].Value = "HocKy";
                exRange.Range["F17:F17"].Value = "HK_Bất Đấu";
                exRange.Range["G17:G17"].Value = "HK_Kết_Thức";
                exRange.Range["H17:H17"].Value = "Ten_BM";
                exRange.Range["I17:I17"].Value = "Tổng1Ky";

                // Populate data starting from cell A17 (below the headers)
                var dataStartCell = exRange.Range["A17"];
                int stt = 1; // Initialize STT counter
                foreach (DataRow roww in tblInformationDetail.Rows)
                {
                    dataStartCell.Offset[stt, 0].Value = stt; // STT
                    dataStartCell.Offset[stt, 1].Value = roww["HoVaTenGV"].ToString(); // HoTenGV
                    dataStartCell.Offset[stt, 2].Value = roww["Ten_MH"].ToString(); // TenMH
                    dataStartCell.Offset[stt, 3].Value = roww["TenLop"].ToString(); // TenLop
                    dataStartCell.Offset[stt, 4].Value = roww["Ten_Hoc_Ky"].ToString(); // HocKy
                                                                                        // Convert database date to Excel date format for Ngay_Bat_Dau_HK and Ngay_Ket_Thuc_HK
                    dataStartCell.Offset[stt, 5].Value = Convert.ToDateTime(roww["Ngay_Bat_Dau_HK"]).ToString("dd/MM/yyyy");
                    dataStartCell.Offset[stt, 6].Value = Convert.ToDateTime(roww["Ngay_Ket_Thuc_HK"]).ToString("dd/MM/yyyy");
                    dataStartCell.Offset[stt, 7].Value = roww["Ten_Bo_Mon"].ToString(); // Ten_BM
                    dataStartCell.Offset[stt, 8].Value = roww["Total_HoursGD1KY"].ToString(); // Tổng1Ky
                    stt++;
                }
                exSheet.Name = "Quan Ly Giang Vien"; //for set name sheet exel
                exApp.Visible = true; //to show Excel pop up

                // Once export is done, close the message
                MessageBox.Show("Export completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dgvDetailGVD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Detail_Screen_Load(object sender, EventArgs e)
        {
            //when run application connection is open
            connection = new SqlConnection(str);
            connection.Open();
            LoadDataIntodgvDetailGVD();
            Console.Write("Hello World! ");
            Console.WriteLine(_MaGV);
            Console.WriteLine(_MaHocKY);
            Console.Write(_idPCGiangDay.ToString());
        }
    }
}
