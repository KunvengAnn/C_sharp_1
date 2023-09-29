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
    public partial class LastForm : Form
    {
        public LastForm()
        {
            InitializeComponent();
        }

        private void btnExitLat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Do you leave now?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnHomeLast_Click(object sender, EventArgs e)
        {
            sg.Show();
            this.Close();
        }

        StartGame sg = new StartGame(); //declare obj from form start GAme;
        private void LastForm_Load(object sender, EventArgs e)
        {
            txtNameLastForm.Text = sg.getname(); //getname from form start Game;

            //declare obj from Quiz next you can use varrible Score on form Quiz
            QUIZ q = new QUIZ();
            txtScoreLastForm.Text = QUIZ.Score;
        }
    }
}
