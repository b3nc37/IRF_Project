using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                XmlDocument xmlDocument = XmlParser.LoadXml(@"Input/schema.xml");
                var proba = XmlParser.GetHeadersForCsv(xmlDocument);
                var proba2 = XmlParser.GetRawValues(xmlDocument);
                foreach (var item in proba2)
                {
                    Console.WriteLine(item);
                }
                


            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("A megadott fájl nem található!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ismeretlen hiba történt. {ex.Message}");
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
