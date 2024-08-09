using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueNha
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            btnQLNha.Click += new EventHandler(OpenForm1_Click);
            btnQLHD.Click += new EventHandler(OpenForm2_Click);
        }

        private void OpenForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void OpenForm1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
