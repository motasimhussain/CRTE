using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CRTE
{
    public partial class Form1 : Form
    {

        Main_Screen ms;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("breakPoint.rtv"))
            {
                if (textBox2.Text == readWrite.readPass())
                {
                    ms = new Main_Screen();

                    this.Hide();

                    ms.ShowDialog();

                    this.Show();

                }
                else
                {
                    MessageBox.Show("Wrong Pass!!");
                }
            }

            else 
            {
                readWrite.writePass("Masood");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.PerformClick();
            }
        }



    }
}
