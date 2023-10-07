using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace QL_Phan_Cong_Gaing_Day
{
    public partial class splash_screen : Form
    {
        public splash_screen()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                sum = sum + i;
                //Calling ReportProgress() method raises ProgressChanged event
                //To this method pass the percentage of processing that is complete;
                backgroundWorker1.ReportProgress(i);
                if (i == 100)
                {
                    e.Cancel = true;
                    // Reset progress percentage to Zero and return
                    backgroundWorker1.ReportProgress(100);
                    return;
                }
                //Check if the Cancellation is requested
                if (backgroundWorker1.CancellationPending)
                {
                    //Set Cancel property of DoWorkEventArgs object to true
                    e.Cancel = true;
                    backgroundWorker1.ReportProgress(0);
                    return;
                }

            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label_Show_Splash_percen.Text = e.ProgressPercentage.ToString() + "%";
        }

        MainScreen MainScreen = new MainScreen();
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label_Show_Splash_percen.Text = "100%";
                this.Hide();
                MainScreen.ShowDialog();
                //this.Close();
            }
            else if (e.Error != null)
            {
                label_Show_Splash_percen.Text = e.Error.Message;
            }
            else
            {
                label_Show_Splash_percen.Text = e.Result.ToString();
            }
        }

        private void splash_screen_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                //This method will Start the execution asynchronously in the background
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
