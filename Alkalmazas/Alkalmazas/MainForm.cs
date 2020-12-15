using System;
using System.Windows.Forms;

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
                EnableConverter();
            }
        }

        private void choosexmlButton_Click(object sender, EventArgs e)
        {
            DialogOpen dialogOpen = new DialogOpen();
            string path = dialogOpen.OpenFile();
            if (!string.IsNullOrEmpty(path))
            {
                xmlPath = path;
                EnableConverter();
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            try
            {
                var document = XmlParser.LoadXml(xmlPath);
                var header = XmlParser.GetHeadersForCsv(document);
                var innertext = XmlParser.GetRawValues(document);

                CsvWriter csvWriter = new CsvWriter(csvPath);
                csvWriter.WriteRow(header + "\n");
                foreach (var item in innertext)
                {
                    csvWriter.WriteRow(item + "\n");
                }
                convertButton.Enabled = false;
                MessageBox.Show("A konvertálás sikeresen megtörtént");
            }
            catch (Exception)
            {

                MessageBox.Show("Ismeretlen hiba");
            }
        }

        private void EnableConverter()
        {
            if (!string.IsNullOrEmpty(csvPath) && !string.IsNullOrEmpty(xmlPath))
            {
                convertButton.Enabled = true;
            }
        }
    }
}
