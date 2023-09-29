using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Millionaire_with_sql
{
    public partial class StartGame : Form
    {
        public StartGame()
        {
            InitializeComponent();
        }
        public static string name;
        public string getname()
        {
            return name;
        }
        private void btn_Play_Now_Click(object sender, EventArgs e)
        {
            name = TXT_Name.Text;
            QUIZ q = new QUIZ();
            q.Show();
            this.Close();
        }
    }
}
