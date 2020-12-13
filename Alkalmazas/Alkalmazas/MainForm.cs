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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Súgó");
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xmlDocument = XmlParser.LoadXml(@"Input/schema.xml");
                var asd = XmlParser.GetHeadersForCsv(xmlDocument); 
                

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
    }
}
