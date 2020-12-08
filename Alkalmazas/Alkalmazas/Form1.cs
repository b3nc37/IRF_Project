using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alkalmazas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileMegnyito fileMegnyito = new FileMegnyito();
            fileMegnyito.Megnynitas();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Konverter konverter = new Konverter();
            konverter.Konvertalas();
        }
    }
}
