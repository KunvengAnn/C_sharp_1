using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Game_Millionaire_with_sql.Properties;
using System.Reflection.Emit;

namespace Game_Millionaire_with_sql
{
    public partial class QUIZ : Form
    {
        bool fityfity = false;
        int second = 0;
        int[] x = new int[17];
        int p = 0;
        string ansformdb, anselect;
        returnClass rc = new returnClass();
        public static string Score ;
        //int qid = 1;
        int qid;
        private static string connstring = ConfigurationManager.ConnectionStrings[name: "Question"].ConnectionString;
        SqlConnection connection = new SqlConnection(connstring);
        public QUIZ()
        {
            InitializeComponent();
           
        }

        StartGame sg = new StartGame(); // obj of form Start Game
        private void QUIZ_Load(object sender, EventArgs e)
        {
            if(fityfity == true)
            {
                pictureb.Enabled = false;

            }
            timer1.Interval = 1000;
            // Reset the timer
            second = 0;
            timer1.Start();

            lbl_Name.Text = sg.getname(); //load name from form StartGame with name or sign in with name to show on name quiz
            Random r = new Random();
            qid = r.Next(1, 17);
            x[p] = qid;
            //MessageBox.Show(qid.ToString());

            disPlayQuestion(qid);


            /*
            //string ConnectionString = "Data Source=DESKTOP-KO9KLMV\\SQLEXPRESS;Initial Catalog=Question;Integrated Security=True;TrustServerCertificate=true";
            String sql = "SELECT q_question,q_questionA,q_questionB,q_questionC,q_questionD FROM Question Where q_id="+qid;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label_Question.Text = reader.GetValue(0).ToString(); //Question
                    label_A.Text = reader.GetValue(1).ToString(); // option A
                    label_B.Text = reader.GetValue(2).ToString(); // option B
                    label_C.Text = reader.GetValue(3).ToString(); // option C
                    label_D.Text = reader.GetValue(4).ToString(); // option D
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex.Message);
            }
            */
        }

        private void label_A_Click(object sender, EventArgs e)
        {
            second = 0;
            univercode(label_A.Text);
            diplayLabels();

            //ansformdb = rc.scalarReturn(" SELECT Q_CORRECTOPTION FROM Question WHERE q_id ="+qid);
            //anselect = label_A.Text;
            //if (anselect.Equals(ansformdb))  // if answer select on label_A.text 
            //{                               // ansformdb is correct option select from database sql;
            //    MessageBox.Show("Correct answer!!");
            //    qid++;
            //    disPlayQuestion(qid);
            //l1:
            //    Random r = new Random();
            //    int s = r.Next(1, 17);

            //    bool c = search(x, s);
            //    if(c==true)
            //    {
            //        goto l1;
            //    }
            //    else
            //    {
            //        p++;
            //        qid = s;
            //        x[p] = qid;
            //        disPlayQuestion(qid);
            //        //prize1.BackColor = Color.Red;
            //        LabelColorChanged(qid);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Game Over!!");
            //}

        }

        private void label_B_Click(object sender, EventArgs e)
        {
            second = 0;
            univercode(label_B.Text);
            diplayLabels();

            //anselect = label_B.Text;
            //if (anselect.Equals(ansformdb))  // if answer select on label_A.text 
            //{                               // ansformdb is correct option select from database sql;
            //    MessageBox.Show("Correct answer!!");
            //    qid++;
            //    disPlayQuestion(qid);
            //l1:
            //    Random r = new Random();
            //    int s = r.Next(1, 17);

            //    bool c = search(x, s);
            //    if (c == true)
            //    {
            //        goto l1;
            //    }
            //    else
            //    {
            //        p++;
            //        qid = s;
            //        x[p] = qid;
            //        disPlayQuestion(qid);
            //        LabelColorChanged(qid);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Game Over!!");
            //}
        }

        private void label_C_Click(object sender, EventArgs e)
        {
            second = 0;

            //easy because declare one method univercode to do all
            univercode(label_C.Text);
            diplayLabels();

            //anselect = label_C.Text;
            //if (anselect.Equals(ansformdb))  // if answer select on label_A.text 
            //{                               // ansformdb is correct option select from database sql;
            //    MessageBox.Show("Correct answer!!");
            //    qid++;
            //    disPlayQuestion(qid);
            //l1:
            //    Random r = new Random();
            //    int s = r.Next(1, 17);

            //    bool c = search(x, s);
            //    if (c == true)
            //    {
            //        goto l1;
            //    }
            //    else
            //    {
            //        p++;
            //        qid = s;
            //        x[p] = qid;
            //        disPlayQuestion(qid);
            //        LabelColorChanged(qid);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Game Over!!");
            //}
        }

        private void label_D_Click(object sender, EventArgs e)
        {
            second = 0;

            //anselect = label_D.Text;
            univercode(label_D.Text);
            diplayLabels();
        }


        public void LabelColorChanged(int P)
        { // have two ways to do change color run on price quiz

            Button[] prizes = { prize1, prize2, prize3, prize4, prize5, prize6, prize7, prize8, prize9, prize10, prize11, prize12, prize13, prize14, prize15 };
            for (int i = 0; i < prizes.Length; i++)
            {
                if (i == p - 1)
                {
                    prizes[i].BackColor = Color.Orange;
                    prizes[i].ForeColor = Color.Purple;
                    label1.Text ="\r" + prizes[i].Text;
                    Score = prizes[i].Text; // Gán giá trị của giải thưởng từ button vào biến Score
                }
                else if (i < p - 1)
                {
                    prizes[i].BackColor = Color.Transparent;
                    prizes[i].ForeColor = Color.Gold;
                }

                //else if (i == prizes.Length - 1) // Kiểm tra nếu là giải thưởng cuối cùng
                //{
                //    //this.Hide();
                //    MessageBox.Show("Congrated 😍😘🥰");
                //}
            }

            if (p == prizes.Length) // Kiểm tra nếu là giải thưởng cuối cùng
            {
                
                MessageBox.Show("Congrated 😍😘🥰");
                LastForm lf = new LastForm();
                lf.Show();
                this.Hide();
            }
            //if(p == 1)
            //{
            //    prize1.BackColor = Color.Orange;
            //    prize1.ForeColor = Color.Purple;
            //}
            //if (p == 2)
            //{
            //    prize2.BackColor = Color.Orange;
            //    prize2.ForeColor = Color.Purple;
            //    prize1.BackColor = Color.Transparent;
            //    prize1.ForeColor = Color.Gold;
            //}
            //if (p == 3)
            //{
            //    prize3.BackColor = Color.Orange;
            //    prize3.ForeColor = Color.Purple;
            //    prize2.BackColor = Color.Transparent;
            //    prize2.ForeColor = Color.Gold;
            //}
            //if (p == 4)
            //{
            //    prize4.BackColor = Color.Orange;
            //    prize4.ForeColor = Color.Purple;
            //    prize3.BackColor = Color.Transparent;
            //    prize3.ForeColor = Color.Gold;
            //}

        }
        public static bool search(int[] x, int s)
        {
            bool c = false ;
            for(int i = 0; i < x.Length; i++ )
            {
                if(s == x[i])
                {
                    c = true;
                    break;
                }
            }
            return c;
        } //function of searching.........



        public void univercode(string anselect)
        {
            //anselect = label_D.Text; can lable A ,B C and lable D to easy declare one 
            // parameter to use with lable A ,B,C or D;
            if (anselect.Equals(ansformdb))  // if answer select on label_A.text 
            {                               // ansformdb is correct option select from database sql;
                MessageBox.Show("Correct answer!!");
                qid++;
                disPlayQuestion(qid);
            l1:
                Random r = new Random();
                int s = r.Next(1, 17);

                bool c = search(x, s);
                if (c == true)
                {
                    goto l1;
                }
                else
                {
                    p++;
                    qid = s;
                    x[p] = qid;
                    disPlayQuestion(qid);
                    LabelColorChanged(qid);
                }
            }
            else
            {
                MessageBox.Show("Game Over!!");
                GameOver gover = new GameOver();
                gover.Show();
                this.Close();
            }
        }// method to show on select option A,B,C and D correct and incorrect ;........

        private void timer1_Tick(object sender, EventArgs e)
        {
            //second = second + 1;
            //if(second <= 9)
            //{
            //    LabelTime.Text = "0" + second.ToString();
            //}
            //else
            //{
                //LabelTime.Text = second.ToString();
            
            

            //if(second >= 30)
            //{
            //     timer1.Stop();

            //    this.Hide();
            //    GameOver gOver = new GameOver();
            //    gOver.Show();
            //}



            second = second + 1;

            LabelTime.Text = second.ToString().PadLeft(2, '0');

            if (second >= 30)
            {
                timer1.Stop();

                
                GameOver gOver = new GameOver();
                gOver.Show();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (fityfity == true)
            {
                return;
            }
            else
            {
                fityfity = true;
                pictureb.BackgroundImage = Properties.Resources._5050Disabled; // Sử dụng tài nguyên hình ảnh từ Properties để tránh đường dẫn tuyệt đối
                pictureb.Enabled = false;
                returnClass rc = new returnClass();
                string correctOption = rc.scalarReturn("SELECT Q_CORRECTOPTION FROM Question WHERE q_id=" + qid);

                // Ẩn hai lựa chọn không chính xác
                if (label_A.Text.Equals(correctOption))
                {
                    label_B.Visible = false;
                    label_C.Visible = false;
                }
                else if (label_B.Text.Equals(correctOption))
                {
                    label_A.Visible = false;
                    label_C.Visible = false;
                }
                else if (label_C.Text.Equals(correctOption))
                {
                    label_A.Visible = false;
                    label_B.Visible = false;
                }
                else if (label_D.Text.Equals(correctOption))
                {
                    label_A.Visible = false;
                    label_B.Visible = false;
                }
            }
        }

        public void diplayLabels()
        {
            label_A.Visible = true;
            label_B.Visible = true;
            label_C.Visible = true;
            label_D.Visible = true;
        }

        private void lbl_Name_Click(object sender, EventArgs e)
        {

        }

        private void disPlayQuestion(int q_id)
        {
            String sql = "SELECT q_question,q_questionA,q_questionB,q_questionC,q_questionD,Q_CORRECTOPTION FROM Question Where q_id=" + q_id; //in method q_id is parameter;
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label_Question.Text = reader.GetValue(0).ToString(); //Question
                    label_A.Text = reader.GetValue(1).ToString(); // option A
                    label_B.Text = reader.GetValue(2).ToString(); // option B
                    label_C.Text = reader.GetValue(3).ToString(); // option C
                    label_D.Text = reader.GetValue(4).ToString(); // option D
                    ansformdb = reader.GetValue(5).ToString(); // correct option
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }//method ends..........




    }
}
