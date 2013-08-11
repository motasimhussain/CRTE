using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            this.Hide();
            si.ShowDialog();
            reBind();
            this.Show();
        }

        private void Main_Screen_Load(object sender, EventArgs e)
        {
            db.Bind(dataGridView1, "printer");

            dataGridView1.Columns[0].Visible = false;

            
            //db.Bind(dataGridView3, "photostate");
            //db.Bind(dataGridView4, "misc");
            //db.Bind(dataGridView5, "cartridge");
            //db.Bind(dataGridView6, "toner");
            //db.Bind(dataGridView7, "repair");
        }



       

        private void Main_Screen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                button2.PerformClick();
            }
        }

        private void TabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                db.Bind(dataGridView1, "printer");
                dataGridView1.Columns[0].Visible = false;
            }
            else if(tabControl1.SelectedIndex == 1)
            {
               db.Bind(dataGridView2, "scanner");
               dataGridView2.Columns[0].Visible = false;
            }

            else if (tabControl1.SelectedIndex == 2)
            {
                db.Bind(dataGridView3, "photostate");
                dataGridView3.Columns[0].Visible = false;
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                db.Bind(dataGridView4, "misc");
                dataGridView4.Columns[0].Visible = false;
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                db.Bind(dataGridView5, "cartridge");
                dataGridView5.Columns[0].Visible = false;
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                db.Bind(dataGridView6, "toner");
                dataGridView6.Columns[0].Visible = false;
            }

            else if (tabControl1.SelectedIndex == 6)
            {
                db.Bind(dataGridView7, "repair");
                dataGridView7.Columns[0].Visible = false;
            }
            else if (tabControl1.SelectedIndex == 7)
            {
                db.Bind(dataGridView8, "sales");
                dataGridView8.Columns[0].Visible = false;
            }
            



        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[0].ReadOnly = true;
            
        }
        

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {   
            db.saveSql(dataGridView1);
        }

        private void dataGridView2_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            db.saveSql(dataGridView2);
        }

        private void dataGridView3_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            db.saveSql(dataGridView3);
        }

       

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Columns[0].ReadOnly = true;
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Columns[0].ReadOnly = true;
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4.Columns[0].ReadOnly = true;
        }
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView5.Columns[0].ReadOnly = true;
        }
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView6.Columns[0].ReadOnly = true;
        }
        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView7.Columns[0].ReadOnly = true;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            reBind();
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Columns[0].ReadOnly = true;
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView3.Columns[0].ReadOnly = true;
        }

        private void dataGridView4_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView4.Columns[0].ReadOnly = true;
        }

        private void dataGridView5_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView5.Columns[0].ReadOnly = true;
        }

        private void dataGridView6_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView6.Columns[0].ReadOnly = true;
        }

        private void dataGridView7_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView7.Columns[0].ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {

                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView1);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
                    {
                        dataGridView2.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView2);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
                    {
                        dataGridView3.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView3);
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView4.SelectedRows)
                    {
                        dataGridView4.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView4);
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView5.SelectedRows)
                    {
                        dataGridView5.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView5);
            }
            else if (tabControl1.SelectedTab == tabPage6)
            {
                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView6.SelectedRows)
                    {
                        dataGridView6.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView6);
            }
            else if (tabControl1.SelectedTab == tabPage7)
            {
                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView7.SelectedRows)
                    {
                        dataGridView7.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView7);
            }
            else if (tabControl1.SelectedTab == tabPage8)
            {
                var result = MessageBox.Show("Do you really want to delete this entry?\n This will remove the entire row! \n This is an irrecoverable process!", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dataGridView8.SelectedRows)
                    {
                        dataGridView8.Rows.RemoveAt(item.Index);
                    }
                }

                db.saveSql(dataGridView8);
            }
        }

        private void dataGridView4_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            db.saveSql(dataGridView4);
        }

        private void dataGridView5_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            db.saveSql(dataGridView5);
        }

        private void dataGridView6_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            db.saveSql(dataGridView6);
        }

        private void dataGridView7_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            db.saveSql(dataGridView7);
        }

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView8.Columns[0].ReadOnly = true;
        }

        private void dataGridView8_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            db.saveSql(dataGridView8);
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void saveCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
            MessageBox.Show("Saved");
        }

        public void reBind()
        {
            db.Bind(dataGridView1, "printer");
            db.Bind(dataGridView2, "scanner");
            db.Bind(dataGridView3, "photostate");
            db.Bind(dataGridView4, "misc");
            db.Bind(dataGridView5, "cartridge");
            db.Bind(dataGridView6, "toner");
            db.Bind(dataGridView7, "repair");
        }

    }
}
