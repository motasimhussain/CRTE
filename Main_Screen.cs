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
    public partial class Main_Screen : Form
    {
        NewPass np;
        SellItems si;
        DBConnect db = new DBConnect();

        public Main_Screen()
        {
            InitializeComponent();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            np = new NewPass();
            np.Owner = this;
            np.ShowDialog();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            si = new SellItems();
            si.Owner = this;
            si.ShowDialog();
            this.Hide();
        }

        private void Main_Screen_Load(object sender, EventArgs e)
        {
            db.Bind(dataGridView1,"printer");
            db.Bind(dataGridView2, "scanner");
            db.Bind(dataGridView3, "photostate");
            db.Bind(dataGridView4, "misc");
            db.Bind(dataGridView5, "cartridge");
            db.Bind(dataGridView6, "toner");
            db.Bind(dataGridView7, "repair");



        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db.Save();
        }

        private void Main_Screen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                MessageBox.Show("right on!!");

                //db.Save();
            }
        }
    }
}
