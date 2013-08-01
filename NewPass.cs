using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRTE
{
    public partial class NewPass : Form
    {
        public NewPass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == readWrite.readPass() && textBox2.Text != "")
            {
                readWrite.writePass(textBox2.Text);
                MessageBox.Show("Password Changed!!");
                this.Close();
            }

            else
            {
                MessageBox.Show("Wrong Password!!");
            }
        }
    }
}
