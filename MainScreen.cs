
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;


namespace QL_Phan_Cong_Gaing_Day
{
    public partial class MainScreen : Form
    {
        //for connect to sql and run query
        SqlConnection connection;
        SqlCommand command;
        String str = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=Phan_Cong_GV;Integrated Security=True;TrustServerCertificate=true";
        SqlDataAdapter adapter = new SqlDataAdapter();


        //for load data from sql with query
        bool LoadData()
        {
            try
            {
                // Clear columns in dgvGV
                dgvGV.Columns.Clear();

                dgvGV.AutoGenerateColumns = false;
                // Define and add the columns you want to display
                dgvGV.Columns.Add(CreateTextBoxColumn("Ma_GV", "MãGiảngViên"));
                dgvGV.Columns.Add(CreateTextBoxColumn("HoVaTenGV", "TênGiảngViên"));
                dgvGV.Columns.Add(CreateTextBoxColumn("email", "email"));
                dgvGV.Columns.Add(CreateTextBoxColumn("SDT", "SDT"));

                command = connection.CreateCommand();
                command.CommandText = "SELECT DISTINCT * FROM Giang_Vien";

                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                dgvGV.DataSource = table;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }


        // Load data for gridview dgvGiangDay
        bool LoadDataIntoDataGridViewGVGV()
        {
            try
            {

                //dgvGiangDay.Rows.Clear();
                //dgvGiangDay.Refresh();
                //dgvGiangDay.DataSource = null;
                // Clear columns in dgvGiangDay
                dgvGiangDay.Columns.Clear();

                dgvGiangDay.AutoGenerateColumns = false;
                // Define and add the columns you want to display
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("id_PCGV", "id_PCGV"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("Ma_GV", "MãGV"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("HoVaTenGV", "TênGiảngViên"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("Ten_MH", "TenMH"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("TenLop", "TenLop"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("Ten_Hoc_Ky", "TenHocKy"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("Ten_Bo_Mon", "TenBoMon"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("SoTiet_1Tuan", "SoTiet_1Tuan"));
                dgvGiangDay.Columns.Add(CreateTextBoxColumn("Ma_HK", "Ma_HK"));
                command = connection.CreateCommand();
                command.CommandText = "SELECT  PGV.id_PCGV,Gv.Ma_GV, GV.HoVaTenGV, MH.Ten_MH, LH.TenLop, HK.Ten_Hoc_Ky, BM.Ten_Bo_Mon, PGV.SoTiet_1Tuan, HK.Ma_HK FROM Phan_Cong_Giang_Day  PGV\r\nINNER JOIN Mon_Hoc MH\r\non Mh.Ma_MH = PGV.Ma_MH\r\nINNER JOIN Giang_Vien GV\r\non GV.Ma_GV = PGV.Ma_GV\r\nINNER JOIN Bo_Mon BM\r\non BM.Ma_BM = Mh.Ma_BM\r\nINNER JOIN Hoc_Ky HK\r\non HK.Ma_HK = PGV.Ma_HK\r\nINNER JOIN Lop_Hoc LH\r\non LH.Ma_MH = MH.Ma_MH\r\nORDER BY id_PCGV ASC;";

                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                dgvGiangDay.DataSource = table;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }


        //load for datagridview Lop
        void LoadDataIntoDataForDgvLop()
        {
            try
            {

                //dgvGiangDay.Rows.Clear();
                //dgvGiangDay.Refresh();
                //dgvGiangDay.DataSource = null;
                // Clear columns in dgvGiangDay
                dgvLop.Columns.Clear();

                dgvLop.AutoGenerateColumns = false;
                // Define and add the columns you want to display
                dgvLop.Columns.Add(CreateTextBoxColumn("Ma_Lop", "Ma_Lop"));
                dgvLop.Columns.Add(CreateTextBoxColumn("TenLop", "TenLop"));
                dgvLop.Columns.Add(CreateTextBoxColumn("Ten_MH", "Ten_MH"));
                dgvLop.Columns.Add(CreateTextBoxColumn("Ten_Hoc_Ky", "Ten_Hoc_Ky"));
                command = connection.CreateCommand();
                command.CommandText = "SELECT LP.Ma_Lop, LP.TenLop, MH.Ten_MH, HK.Ten_Hoc_Ky\r\nFROM Lop_Hoc LP\r\nINNER JOIN Mon_Hoc MH ON LP.Ma_MH = MH.Ma_MH\r\nINNER JOIN Hoc_Ky HK ON HK.Ma_HK = LP.Ma_HK\r\nGROUP BY LP.Ma_Lop, LP.TenLop, MH.Ten_MH, HK.Ten_Hoc_Ky;";

                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                dgvLop.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //load for datagridview DgvMonHoc
        void LoadDataIntoDataForDgvMonHoc()
        {
            try
            {
                //dgvGiangDay.Rows.Clear();
                //dgvGiangDay.Refresh();
                //dgvGiangDay.DataSource = null;
                // Clear columns in dgvGiangDay
                dgvMonHoc.Columns.Clear();

                dgvMonHoc.AutoGenerateColumns = false;
                // Define and add the columns you want to display
                dgvMonHoc.Columns.Add(CreateTextBoxColumn("Ma_MH", "Ma_MH"));
                dgvMonHoc.Columns.Add(CreateTextBoxColumn("Ten_MH", "Ten_MH"));
                dgvMonHoc.Columns.Add(CreateTextBoxColumn("Ten_Bo_Mon", "Ten_Bo_Mon"));
                command = connection.CreateCommand();
                command.CommandText = "SELECT MH.Ma_MH, MH.Ten_MH , Bm.Ten_Bo_Mon FROM Mon_Hoc MH\r\nINNER join Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM ;";

                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                dgvMonHoc.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //load for datagridview dgvHocKy
        void LoadDataIntoDataForDgvHocKy()
        {
            try
            {
                //dgvGiangDay.Rows.Clear();
                //dgvGiangDay.Refresh();
                //dgvGiangDay.DataSource = null;
                // Clear columns in dgvGiangDay
                dgvHocKy.Columns.Clear();

                dgvHocKy.AutoGenerateColumns = false;
                // Define and add the columns you want to display
                dgvHocKy.Columns.Add(CreateTextBoxColumn("Ma_HK", "Ma_HK"));
                dgvHocKy.Columns.Add(CreateTextBoxColumn("Ten_Hoc_Ky", "Ten_Hoc_Ky"));

                // Create a DataGridViewTextBoxColumn for the date columns
                DataGridViewTextBoxColumn dateColumn = CreateTextBoxColumn("Ngay_Bat_Dau_HK", "Ngay_Bat_Dau_HK");
                dateColumn.DefaultCellStyle.Format = "yyyy-MM-dd"; // You can specify your desired date format here
                dgvHocKy.Columns.Add(dateColumn);
                dateColumn = CreateTextBoxColumn("Ngay_Ket_Thuc_HK", "Ngay_Ket_Thuc_HK");
                dateColumn.DefaultCellStyle.Format = "yyyy-MM-dd"; // You can specify your desired date format here
                dgvHocKy.Columns.Add(dateColumn);

                command = connection.CreateCommand();
                command.CommandText = "SELECT Ma_HK, Ten_Hoc_Ky, Ngay_Bat_Dau_HK, Ngay_Ket_Thuc_HK FROM Hoc_Ky ";

                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                dgvHocKy.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       

        // Helper method to create DataGridViewTextBoxColumn
        private DataGridViewTextBoxColumn CreateTextBoxColumn(string dataPropertyName, string headerText)
        {
            return new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                HeaderText = headerText
            };
        }

        void loadCamboBoxForGVGD()
        {
            ////for select combobox cbMaGVGD
            FillCombo("SELECT Ma_GV,HoVaTenGV  FROM Giang_Vien", cbMaGVGD, "Ma_GV", "Ma_GV");
            cbMaGVGD.SelectedIndex = -1;

            //for select combobox MonHoc
            FillCombo("SELECT Ma_MH,Ten_MH  FROM Mon_Hoc", cbMonHoc, "Ma_MH", "Ten_MH");
            cbMonHoc.SelectedIndex = -1;
            //for select combobox HocKy
            FillCombo("SELECT Ma_HK,Ten_Hoc_Ky  FROM Hoc_Ky", cbHocKy, "Ma_HK", "Ten_Hoc_Ky");
            cbHocKy.SelectedIndex = -1;
        }

        void loadCamboBoxForLop()
        {
            ////for select combobox CbMonHocLop
            FillCombo("SELECT Ma_MH,Ten_MH  FROM Mon_Hoc", CbMonHocLop, "Ma_MH", "Ma_MH");
            CbMonHocLop.SelectedIndex = -1;
            //for select combobox cbMaHKLop
            FillCombo("SELECT Ma_HK,Ten_Hoc_Ky  FROM Hoc_Ky", cbMaHKLop, "Ma_HK", "Ma_HK");
            cbMaHKLop.SelectedIndex = -1;
        }
        void loadCamboBoxForQLMonHoc()
        {
            ////for select combobox cbMaBMMonHK
            FillCombo("SELECT Ma_BM,Ten_Bo_Mon  FROM Bo_Mon", cbMaBMMonHK, "Ma_BM", "Ma_BM");
            cbMaBMMonHK.SelectedIndex = -1;
        }

        //when run load danh sach GV
        private void MainScreen_Load(object sender, EventArgs e)
        {
            //when run application connection is open
            connection = new SqlConnection(str);
            connection.Open();
            //for loadData danh sach GV
            LoadData();
            //for load on screen quan ly giang day
            LoadDataIntoDataGridViewGVGV();
            //when run load data for comboBox in Giang day
            loadCamboBoxForGVGD();
            //load datagridview Lop when run 
            LoadDataIntoDataForDgvLop();
            LoadDataIntoDataForDgvMonHoc();
            //
            LoadDataIntoDataForDgvHocKy();
            //load for comboxBox
            loadCamboBoxForLop();
            //
            loadCamboBoxForQLMonHoc();

            //when first run app on textbox is null all for Quan ly GV
            clearForGV(); //call method clear
        }
        public MainScreen()
        {
            InitializeComponent();
        }


        //click on items on dgvGv show to txb 
        private void dgvGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvGV.CurrentRow.Index;
            txbMaGV.Text = dgvGV.Rows[i].Cells[0].Value.ToString();
            txbHoTenGV.Text = dgvGV.Rows[i].Cells[1].Value.ToString();
            txbEmailGV.Text = dgvGV.Rows[i].Cells[2].Value.ToString();
            txbSDT.Text = dgvGV.Rows[i].Cells[3].Value.ToString();
            dgvGV.ReadOnly = true;

        }

        //when selectedRow on gridview changed 
        private void dgvGV_SelectionChanged(object sender, EventArgs e)
        {
            ////// Check if any row is selected
            //if (dgvGV.SelectedRows.Count > 0)
            //{

            //    // Get the index of the selected row
            //    int selectedIndex = dgvGV.SelectedRows[0].Index;
            //    // Retrieve data from the selected row and display it in textboxes
            //    txbMaGV.Text = dgvGV.Rows[selectedIndex].Cells[0].Value.ToString();
            //    txbHoTenGV.Text = dgvGV.Rows[selectedIndex].Cells[1].Value.ToString();
            //    txbEmailGV.Text = dgvGV.Rows[selectedIndex].Cells[2].Value.ToString();
            //    txbSDT.Text = dgvGV.Rows[selectedIndex].Cells[3].Value.ToString();

            //}
        }

        //for Insert GV To DB
        private void btnThemGv_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbMaGV.Text == "" || txbHoTenGV.Text == "" || txbSDT.Text == "" || txbEmailGV.Text == "")
                {
                    MessageBox.Show("Xin Nhập Gái trị Vạo ");
                    return;
                }

                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Giang_Vien VALUES('" + txbMaGV.Text + "', N'" + txbHoTenGV.Text + "',N'" + txbEmailGV.Text + "','" + txbSDT.Text + "')";
                //command.ExecuteNonQuery();
                int rowsAffected = command.ExecuteNonQuery(); //run query
                if (rowsAffected > 0) //check run query success 
                {
                    // when insert success show dailog than load data
                    MessageBox.Show("Thêm Thành Công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvGV.ClearSelection();
                    LoadData(); //when insert is already load data from DB again
                    loadCamboBoxForGVGD();
                    clearForGV(); //when inset already clear all textbox
                }
                else
                { // insert fails
                    MessageBox.Show("No Inserted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //for Update or Edit data DB
        private void btnSuaGv_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@MA_GV", txbMaGV.Text);
                command.Parameters.AddWithValue("@HoVaTenGV", txbHoTenGV.Text);
                command.Parameters.AddWithValue("@Email", txbEmailGV.Text);
                command.Parameters.AddWithValue("@SDT", txbSDT.Text);
                // Thiết lập chuỗi lệnh SQL cho command
                command.CommandText = "UPDATE Giang_Vien SET MA_GV=@MA_GV, HoVaTenGV=@HoVaTenGV,Email=@Email, SDT=@SDT WHERE MA_GV = @MA_GV";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload the data if needed
                    loadCamboBoxForGVGD();
                    clearForGV();
                }
                else
                { //if fails show
                    MessageBox.Show("update fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            { //try catch check if error get error than show 
                MessageBox.Show("Error" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //for delete in db
        private void btnXoaGv_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                //de delete from dataGridview;
                command.Parameters.AddWithValue("@Ma_GV", txbMaGV.Text);
                command.CommandText = "DELETE FROM Giang_Vien WHERE Ma_GV = @Ma_GV";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Delete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Reload the data if needed
                    loadCamboBoxForGVGD(); //for load on cambobox on Giảng dạy
                    LoadDataIntoDataGridViewGVGV(); //load again when something on parent child ís delete
                    clearForGV();
                }
                else
                { //if fails show
                    MessageBox.Show("Delete fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //for clearForGV data on textbox
        public void clearForGV()
        {
            txbMaGV.Text = null;
            txbHoTenGV.Text = null;
            txbEmailGV.Text = null;
            txbSDT.Text = null;
        }

        private void BtnLamMoiGv_Click(object sender, EventArgs e)
        {
            clearForGV();
        }

        //for search db
        private void btnTimGV_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txbTimByTenGV.Text;
                if (string.IsNullOrEmpty(txbTimByTenGV.Text))
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu vào tìm!!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //if not input value to find show all run below code show all
                    command = connection.CreateCommand();
                    command.CommandText = "select * from Giang_Vien where HoVaTenGV like '%" + ten + "%'";
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    table.Clear();
                    adapter.Fill(table);
                    dgvGV.DataSource = table; //load what find to gridview
                }
                else
                { //if input value to find run this
                    command = connection.CreateCommand();
                    command.CommandText = "select * from Giang_Vien where HoVaTenGV like '%" + ten + "%'";
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    table.Clear();
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        dgvGV.DataSource = table; //load what find to gridview
                        MessageBox.Show("Đã tìm thấy " + table.Rows.Count + " kết quả.");
                    }
                    else
                    {
                        dgvGV.DataSource = null;
                        MessageBox.Show("Không tìm thấy kết quả.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERror" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //function for run query for combobox
        public string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();

            }
            reader.Close();
            return ma;
        }

        void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {

            SqlDataAdapter dap = new SqlDataAdapter(sql, connection);
            DataTable table1 = new DataTable();
            dap.Fill(table1);
            cbo.DataSource = table1;
            cbo.ValueMember = ma; // Trường giá trị 
            cbo.DisplayMember = ten; // Trường hiển thị
        }


        //Hàm thực hiện câu lệnh SQL
        int RunSQL(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1; // Return a negative value to indicate an error
            }
        }

        //Hàm kiểm tra khoá trùng
        public bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        private void btnThemGvGaingDay_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                // Check if the ID already exists in the database
                sql = "SELECT id_PCGV FROM Phan_Cong_Giang_Day WHERE id_PCGV = N'" + txbIDGiangDay.Text + "'";
                if (!CheckKey(sql))
                {
                    // Check if required fields are filled
                    if (cbMonHoc.Text.Length == 0 || cbHocKy.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MaHocKYGlobal == "" || MaHocKYGlobal == "")
                    {
                        MessageBox.Show("null value");
                        return;
                    }
                    ////check in db is exists   
                    string sql1 = "SELECT\r\n  GV.HoVaTenGV,\r\n  MH.Ten_MH,\r\n  LH.TenLop,\r\n  HK.Ten_Hoc_Ky,\r\n  HK.Ngay_Bat_Dau_HK,\r\n  HK.Ngay_Ket_Thuc_HK,\r\n  BM.Ten_Bo_Mon\r\nFROM\r\n  Phan_Cong_Giang_Day PGV\r\n  INNER JOIN Mon_Hoc MH ON MH.Ma_MH = PGV.Ma_MH\r\n  INNER JOIN Giang_Vien GV ON GV.Ma_GV = PGV.Ma_GV\r\n  INNER JOIN Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM\r\n  INNER JOIN Hoc_Ky HK ON HK.Ma_HK = PGV.Ma_HK\r\n  INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH\r\nWHERE\r\n  MH.Ma_MH = '" + MaMonHocGlobal + "'\r\n  AND \r\n  HK.Ma_HK = '" + MaHocKYGlobal + "'";

                    if (CheckKey(sql1))
                    {
                        MessageBox.Show("A record with the same subject or semester already exists.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        // Insert data into the database
                        //cbMonHoc ||cbTenLop in cb method FillCombo already return with MaID and name
                        sql = "INSERT INTO Phan_Cong_Giang_Day VALUES (N'" + txbIDGiangDay.Text + "',N'" + cbMaGVGD.SelectedValue + "',N'" + cbMonHoc.SelectedValue + "',N'" + cbHocKy.SelectedValue + "'," + txbSoTiet1Tuan.Text + ")";
                        int rowsAffected = RunSQL(sql);

                        if (rowsAffected > 0) //check if this success
                        {
                            MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataIntoDataGridViewGVGV(); //Reload data agian
                                                            // Optionally, clear the input fields or perform other actions upon successful insertion
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("ID đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void dgvGiangDay_SelectionChanged(object sender, EventArgs e)
        {

        }


        //method for when click on combobox MaGV show TenGv on Textbox
        private void cbMaGVGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaGVGD.Text == "")
            {
                txbTenGVGiangDay.Text = "";
            }
            else
            {
                str = "SELECT HoVaTenGV FROM Giang_Vien WHERE Ma_GV =N'" + cbMaGVGD.SelectedValue + "'";
                txbTenGVGiangDay.Text = GetFieldValues(str);

                cbMaGVGD.SelectedValue = cbMaGVGD.SelectedValue.ToString();

            }
        }

        private void btnGVClear_GD_Click(object sender, EventArgs e)
        {
            cbMaGVGD.SelectedValue = "";
            txbIDGiangDay.Text = "";
            txbTenGVGiangDay.Text = "";
            cbMonHoc.SelectedValue = "";
            txbSoTiet1Tuan.Text = "";
            cbHocKy.SelectedValue = "";
        }

        private void btnDelete_GD_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@id_PCGV", txbIDGiangDay.Text);
                command.CommandText = "DELETE FROM Phan_Cong_Giang_Day WHERE id_PCGV = @id_PCGV";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Delete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataIntoDataGridViewGVGV(); // Reload the data if needed

                    clearForGV();
                }
                else
                { //if fails show
                    MessageBox.Show("Delete fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnDetail_Click(object sender, EventArgs e)
        {
            if (TenGVGloble == null || IdPCGiangDayGlobal == null || MaGV_GlobalForDetail == null || MaHocKy_GlobalForDetail == null)
            {
                MessageBox.Show("Selected gridview you want to show detail");
                return;
            }
            else
            {
                Detail_Screen detail_Screen = new Detail_Screen(TenGVGloble, IdPCGiangDayGlobal, MaGV_GlobalForDetail, MaHocKy_GlobalForDetail);
                this.Hide();
                detail_Screen.ShowDialog();
                this.Show();
            }
        }
        String TenGVGloble;
        String IdPCGiangDayGlobal;
        String MaGV_GlobalForDetail;
        String MaHocKy_GlobalForDetail;
        private void dgvGiangDay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Check if any row is selected
            if (dgvGiangDay.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedIndex = dgvGiangDay.SelectedRows[0].Index;
                // Retrieve data from the selected row and display it in textboxes
                txbIDGiangDay.Text = dgvGiangDay.Rows[selectedIndex].Cells[0].Value.ToString();
                IdPCGiangDayGlobal = txbIDGiangDay.Text;
                cbMaGVGD.Text = dgvGiangDay.Rows[selectedIndex].Cells[1].Value.ToString();
                MaGV_GlobalForDetail = cbMaGVGD.Text;
                txbTenGVGiangDay.Text = dgvGiangDay.Rows[selectedIndex].Cells[2].Value.ToString();
                TenGVGloble = txbTenGVGiangDay.Text; //pass value to varible TenGVGlobal
                cbMonHoc.Text = dgvGiangDay.Rows[selectedIndex].Cells[3].Value.ToString();
                // MaHocKy_GlobalForDetail = dgvGiangDay.Rows[selectedIndex].Cells[4].Value.ToString(); //FOR MA
                cbHocKy.Text = dgvGiangDay.Rows[selectedIndex].Cells[5].Value.ToString();
                txbSoTiet1Tuan.Text = dgvGiangDay.Rows[selectedIndex].Cells[7].Value.ToString();
                MaHocKy_GlobalForDetail = dgvGiangDay.Rows[selectedIndex].Cells[8].Value.ToString();
            }
        }

        String MaHocKYGlobal;
        private void cbHocKy_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbHocKy.Text == "")
            {
                cbHocKy.Text = "";
            }
            else
            {
                str = "SELECT Ma_HK FROM Hoc_Ky WHERE Ma_HK =N'" + cbHocKy.SelectedValue + "'";
                MaHocKYGlobal = GetFieldValues(str);
                //MessageBox.Show("cbHocKy " + MaHocKYGlobal);
            }
        }

        String MaMonHocGlobal;
        private void cbMonHoc_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMonHoc.Text == "")
            {
                cbMonHoc.Text = "";
                return;
                //MessageBox.Show("cbHocKy empty");
            }
            else
            {
                // Khi chọn Mã thì tên sẽ tự động hiện ra
                str = "SELECT Ma_MH FROM Mon_Hoc WHERE Ma_MH =N'" + cbMonHoc.SelectedValue + "'";
                //txtbTenNV.Text = GetFieldValues(str);
                MaMonHocGlobal = GetFieldValues(str);
                // MessageBox.Show("cbHocKy " + MaMonHocGlobal);
            }
        }


        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Check if any row is selected
            if (dgvLop.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedIndex = dgvLop.SelectedRows[0].Index;

                txbMaLop.Text = dgvLop.Rows[selectedIndex].Cells[0].Value.ToString();
                txbTenLop.Text = dgvLop.Rows[selectedIndex].Cells[1].Value.ToString();
                string sql = "SELECT MH.Ma_MH\r\nFROM Lop_Hoc LP\r\nINNER JOIN Mon_Hoc MH ON LP.Ma_MH = MH.Ma_MH\r\nINNER JOIN Hoc_Ky HK ON HK.Ma_HK = LP.Ma_HK\r\nWHERE LP.Ma_Lop = '" + txbMaLop.Text + "';";
                CbMonHocLop.Text = GetFieldValues(sql);
                string sql1 = "SELECT Hk.Ma_HK\r\nFROM Lop_Hoc LP\r\nINNER JOIN Mon_Hoc MH ON LP.Ma_MH = MH.Ma_MH\r\nINNER JOIN Hoc_Ky HK ON HK.Ma_HK = LP.Ma_HK\r\nWHERE LP.Ma_Lop = '"+ txbMaLop.Text + "';"; 
                cbMaHKLop.Text = GetFieldValues(sql1);
                //cbMaHKLop.Text = dgvGiangDay.Rows[selectedIndex].Cells[4].Value.ToString();
            }
        }

        private void btnAddLop_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                // Check if the ID already exists in the database
                sql = "SELECT Ma_Lop FROM Lop_Hoc WHERE Ma_Lop = N'"+ txbMaLop.Text + "'";
                if (!CheckKey(sql))
                {
                    // Check if required fields are filled
                    if (CbMonHocLop.Text.Length == 0 || cbMaHKLop.Text.Length == 0)
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ////check in db is exists   
                    //string sql1 = "SELECT\r\n  GV.HoVaTenGV,\r\n  MH.Ten_MH,\r\n  LH.TenLop,\r\n  HK.Ten_Hoc_Ky,\r\n  HK.Ngay_Bat_Dau_HK,\r\n  HK.Ngay_Ket_Thuc_HK,\r\n  BM.Ten_Bo_Mon\r\nFROM\r\n  Phan_Cong_Giang_Day PGV\r\n  INNER JOIN Mon_Hoc MH ON MH.Ma_MH = PGV.Ma_MH\r\n  INNER JOIN Giang_Vien GV ON GV.Ma_GV = PGV.Ma_GV\r\n  INNER JOIN Bo_Mon BM ON BM.Ma_BM = MH.Ma_BM\r\n  INNER JOIN Hoc_Ky HK ON HK.Ma_HK = PGV.Ma_HK\r\n  INNER JOIN Lop_Hoc LH ON LH.Ma_MH = MH.Ma_MH\r\nWHERE\r\n  MH.Ma_MH = '" + MaMonHocGlobal + "'\r\n  AND \r\n  HK.Ma_HK = '" + MaHocKYGlobal + "'";

                    //if (CheckKey(sql1))
                    //{
                    //    MessageBox.Show("A record with the same subject or semester already exists.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}

                    // Insert data into the database
                    //cbMonHoc ||cbTenLop in cb method FillCombo already return with MaID and name
                    sql = "INSERT INTO Lop_Hoc values('"+ txbMaLop.Text+ "','"+ txbTenLop.Text+ "','"+ MaMonHocGlobleLop + "','"+ MaHKGlobalLop + "')";
                    int rowsAffected = RunSQL(sql);

                    if (rowsAffected > 0) //check if this success
                    {
                        MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataIntoDataForDgvLop(); //Reload data agian                              
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("ID đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        string MaMonHocGlobleLop;
        private void CbMonHocLop_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (CbMonHocLop.Text == "")
            {
                txbTenMHLop.Text = "";
                return;
                //MessageBox.Show("cbHocKy empty");
            }
            else
            {
                // Khi chọn Mã thì tên sẽ tự động hiện ra
                str = "SELECT Ten_MH FROM Mon_Hoc WHERE Ma_MH =N'" + CbMonHocLop.SelectedValue + "'";
                //txtbTenNV.Text = GetFieldValues(str);
                txbTenMHLop.Text = GetFieldValues(str);
                MaMonHocGlobleLop = (string)CbMonHocLop.SelectedValue;
                // MessageBox.Show("cbHocKy " + MaMonHocGlobal);
            }
        }

        string MaHKGlobalLop;
        private void cbMaHKLop_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaHKLop.Text == "")
            {
                TenHocKyLop.Text = "";
                return;
                //MessageBox.Show("cbHocKy empty");
            }
            else
            {
                // Khi chọn Mã thì tên sẽ tự động hiện ra
                str = "SELECT Ten_Hoc_Ky FROM Hoc_Ky WHERE Ma_HK =N'" + cbMaHKLop.SelectedValue + "'";
                //txtbTenNV.Text = GetFieldValues(str);
                TenHocKyLop.Text = GetFieldValues(str);
                MaHKGlobalLop =(string)cbMaHKLop.SelectedValue;
                // MessageBox.Show("cbHocKy " + MaMonHocGlobal);
            }
        }

        private void btnEditLop_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@MaLop", txbMaLop.Text);
                command.Parameters.AddWithValue("@TenLop", txbTenLop.Text);
                command.Parameters.AddWithValue("@MaMonHocLop", MaMonHocGlobleLop);
                command.Parameters.AddWithValue("@MaHocKyLop", MaHKGlobalLop);
                // Thiết lập chuỗi lệnh SQL cho command
                command.CommandText = "UPDATE Lop_Hoc \r\nSET\r\n    TenLop = @TenLop,\r\n\tMa_MH = @MaMonHocLop ,\r\n    Ma_HK = @MaHocKyLop\r\nWHERE Ma_Lop = @MaLop ";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataIntoDataForDgvLop(); //Reload data agian 
                }
                else
                { //if fails show
                    MessageBox.Show("update fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            { //try catch check if error get error than show 
                MessageBox.Show("Error" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearLop_Click(object sender, EventArgs e)
        {
            txbMaLop.Text = "";
            txbTenLop.Text = "";
            CbMonHocLop.Text = "";
            cbMaHKLop.Text = "";
        }

        private void btnDeleteLop_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@MaLop", txbMaLop.Text);
                command.CommandText = "DELETE FROM Lop_Hoc WHERE Ma_Lop = @MaLop ";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Delete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataIntoDataForDgvLop(); // Reload the data if needed
                }
                else
                { //if fails show
                    MessageBox.Show("Delete fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMaBMMonHK_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaBMMonHK.Text == "")
            {
                txbTenBMMH.Text = "";
                return;
            }
            else
            {
                // Khi chọn Mã thì tên sẽ tự động hiện ra
                str = "SELECT Ten_Bo_Mon  FROM Bo_Mon WHERE Ma_BM =N'" + cbMaBMMonHK.SelectedValue + "'";
                txbTenBMMH.Text = GetFieldValues(str);
                
                
                //MaHKGlobalLop = (string)cbMaHKLop.SelectedValue;
                // MessageBox.Show("cbHocKy " + MaMonHocGlobal);
            }
        }

        private void btnAddMH_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                // Check if the ID already exists in the database
                sql = "SELECT Ma_MH FROM Mon_Hoc WHERE Ma_MH = '"+ txbMaMonHoc.Text+ "'";
                if (!CheckKey(sql))
                {
                    // Check if required fields are filled
                    if (cbMaBMMonHK.Text.Length == 0 )
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Insert data into the database
                    sql = "INSERT INTO Mon_Hoc VALUES('"+ txbMaMonHoc.Text+ "','"+ txbTenMH.Text+ "','"+ cbMaBMMonHK.Text+ "');";
                    int rowsAffected = RunSQL(sql);

                    if (rowsAffected > 0) //check if this success
                    {
                        MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataIntoDataForDgvMonHoc(); //Reload data agian                              
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ID đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Check if any row is selected
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedIndex = dgvMonHoc.SelectedRows[0].Index;
                txbMaMonHoc.Text = dgvMonHoc.Rows[selectedIndex].Cells[0].Value.ToString();
                txbTenMH.Text = dgvMonHoc.Rows[selectedIndex].Cells[1].Value.ToString();
                //cbMaBMMonHK.Text = dgvMonHoc.Rows[selectedIndex].Cells[2].Value.ToString();

                string sql = "SELECT Ma_BM FROM Mon_Hoc WHERE Ma_MH = '"+ txbMaMonHoc.Text+ "'";
                cbMaBMMonHK.Text = GetFieldValues(sql);

            }
        }

        private void btnClearMH_Click(object sender, EventArgs e)
        {
            txbMaMonHoc.Text = "";
            txbTenMH.Text = "";
            cbMaBMMonHK.Text = "";
        }

        private void BtnDeleteMH_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@Ma_MH", txbMaMonHoc.Text);
                command.CommandText = "DELETE FROM Mon_Hoc WHERE Ma_MH = @Ma_MH ";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Delete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataIntoDataForDgvMonHoc(); //Reload data agian                              
                }
                else
                { //if fails show
                    MessageBox.Show("Delete fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditMH_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@Ma_MH", txbMaMonHoc.Text);
                command.Parameters.AddWithValue("@Ten_MH", txbTenMH.Text);
                command.Parameters.AddWithValue("@Ma_BM", cbMaBMMonHK.Text);
                // Thiết lập chuỗi lệnh SQL cho command
                command.CommandText = "UPDATE Mon_Hoc\r\nSET Ten_MH = @Ten_MH ,Ma_BM = @Ma_BM\r\nWHERE Ma_MH= @Ma_MH";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataIntoDataForDgvMonHoc(); //Reload data agian                              
                }
                else
                { //if fails show
                    MessageBox.Show("update fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            { //try catch check if error get error than show 
                MessageBox.Show("Error" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddHK_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                // Check if the ID already exists in the database
                sql = "SELECT Ma_HK FROM Hoc_Ky WHERE Ma_HK = '" + txbMaHk.Text + "'";
                if (!CheckKey(sql))
                {
                    // Check if required fields are filled
                    if (txbMaHk.Text == "" || txbTenHk.Text == "" || dateTimeNgayBT.Value == DateTime.MinValue)
                    {
                        MessageBox.Show("Vui lòng nhập đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Insert data into the database
                    sql = "INSERT INTO Hoc_Ky VALUES('"+ txbMaHk.Text+ "','"+ txbTenHk.Text+ "','"+ dateTimeNgayBT.Value+ "','"+ dateTimeKT.Value+ "')";
                    int rowsAffected = RunSQL(sql);

                    if (rowsAffected > 0) //check if this success
                    {
                        MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataIntoDataForDgvHocKy(); //Reload data agian                              
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ID đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDeleteHK_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@Ma_HK", txbMaHk.Text);
                command.CommandText = "DELETE FROM Hoc_Ky WHERE Ma_HK = @Ma_HK ";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Delete successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataIntoDataForDgvHocKy(); //Reload data agian                              
                }
                else
                { //if fails show
                    MessageBox.Show("Delete fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditHK_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command = connection.CreateCommand();
                command.Parameters.AddWithValue("@MaHk", txbMaHk.Text);
                command.Parameters.AddWithValue("@TenHk", txbTenHk.Text);
                command.Parameters.AddWithValue("@Ngay_Bat_Dau_HK", dateTimeNgayBT.Value);
                command.Parameters.AddWithValue("@Ngay_Ket_Thuc_HK", dateTimeKT.Text);
                // Thiết lập chuỗi lệnh SQL cho command
                command.CommandText = "UPDATE Hoc_Ky SET Ten_Hoc_Ky = @TenHk, Ngay_Bat_Dau_HK = @Ngay_Bat_Dau_HK ,Ngay_Ket_Thuc_HK = @Ngay_Ket_Thuc_HK WHERE Ma_HK= @MaHk ";
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    //check if command completed success show dailog for user know 
                    MessageBox.Show("Record updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataIntoDataForDgvHocKy(); //Reload data agian                              
                }
                else
                { //if fails show
                    MessageBox.Show("update fails!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            { //try catch check if error get error than show 
                MessageBox.Show("Error" + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHocKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Check if any row is selected
            if (dgvHocKy.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int selectedIndex = dgvHocKy.SelectedRows[0].Index;
                txbMaHk.Text = dgvHocKy.Rows[selectedIndex].Cells[0].Value.ToString();
                txbTenHk.Text = dgvHocKy.Rows[selectedIndex].Cells[1].Value.ToString();
                dateTimeNgayBT.Text = dgvHocKy.Rows[selectedIndex].Cells[2].Value.ToString();
                dateTimeKT.Text = dgvHocKy.Rows[selectedIndex].Cells[3].Value.ToString();

                //string sql = "SELECT Ma_BM FROM Mon_Hoc WHERE Ma_MH = '" + txbMaMonHoc.Text + "'";
                //cbMaBMMonHK.Text = GetFieldValues(sql);

            }
        }
    }
}
