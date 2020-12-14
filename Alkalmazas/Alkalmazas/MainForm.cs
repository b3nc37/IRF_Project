using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Alkalmazas
{
    public partial class MainForm : Form
    {
        private string xmlPath;
        private string csvPath;

        public MainForm()
        {
            InitializeComponent();
            timer.Start();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            clockLabel.Text = DateTime.Now.ToLongTimeString();
            dateLabel.Text = DateTime.Now.ToLongDateString();
        }

        private void choosecsvButton_Click(object sender, EventArgs e)
        {
            DialogOpen dialogOpen = new DialogOpen();
            string path = dialogOpen.SaveFile();
            if (!string.IsNullOrEmpty(path))
            {
                csvPath = path;
            }
        }

        private void choosexmlButton_Click(object sender, EventArgs e)
        {
            DialogOpen dialogOpen = new DialogOpen();
            string path = dialogOpen.OpenFile();
            if (!string.IsNullOrEmpty(path))
            {
                xmlPath = path;
            }
        }
    }
}
