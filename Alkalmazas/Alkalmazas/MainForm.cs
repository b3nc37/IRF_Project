using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Alkalmazas
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            timer.Start();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.FileName.EndsWith(".xml"))
                    {
                        XmlDocument xmlDocument = XmlParser.LoadXml(dialog.FileName);
                        var proba = XmlParser.GetHeadersForCsv(xmlDocument);
                        var proba2 = XmlParser.GetRawValues(xmlDocument);
                        CsvWriter csvWriter = new CsvWriter(null);
                        csvWriter.WriteRow(proba + "\n");
                        foreach (var item in proba2)
                        {
                            csvWriter.WriteRow(item + "\n");
                        }

                    }
                    else
                    {
                        MessageBox.Show($"Ismeretlen hiba történt.");
                    }

                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("A megadott fájl nem található!");
            }

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
    }
}
