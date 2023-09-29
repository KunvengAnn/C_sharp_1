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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        StartGame sg = new StartGame(); //declare one obj from form startGame;
        private void GameOver_Load(object sender, EventArgs e)
        {
            txtNameGameOver.Text = sg.getname(); //name from form start GAme;

            label2.Text = QUIZ.Score;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            StartGame sga = new StartGame();
            sga.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Do you to leave now??", "Question ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rs == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        
        private void txtNameGameOver_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
