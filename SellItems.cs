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
    public partial class SellItems : Form
    {
        DBConnect db = new DBConnect();
        search se;
        string selecteditem;
        int stock;
 
        public SellItems()
        {
            InitializeComponent();
        }

        private void SellItems_Load(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            se = new search();
            if(comboBox1.SelectedIndex == 0)
            {
                selecteditem = "printer";
                db.FillComboBox(comboBox2, "printer", "Product_Name");
                se.Bind(comboBox3, "Stock", "printer", "Product_Name", comboBox2.Text);
                
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                selecteditem = "scanner";
                db.FillComboBox(comboBox2, "scanner", "Product_Name");
                se.Bind(comboBox3, "Stock", "scanner", "Product_Name", comboBox2.Text);
                
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                selecteditem = "photostate";
                db.FillComboBox(comboBox2, "photostate", "Product_Name");
                
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                selecteditem = "misc";
                db.FillComboBox(comboBox2, "misc", "Product_Name");
                
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                selecteditem = "cartridge";
                db.FillComboBox(comboBox2, "cartridge", "Product_Name");
                
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                selecteditem = "toner";
                db.FillComboBox(comboBox2, "toner", "Product_Name");
                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selecteditem != "misc")
            {
                se = new search();
                se.Bind(comboBox3,"Stock", selecteditem, "Product_Name", comboBox2.Text);

                //se.BindText(textBox8, "Stock", selecteditem, "Product_Name", comboBox2.Text);
            }

            if (comboBox2.Text != "")
            {
                se = new search();
                button1.Enabled = true;
                se.Bind(comboBox4, "Price", comboBox1.Text.ToLower(), "Product_Name", comboBox2.Text);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            comboBox4.Visible = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            comboBox4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c_name.Text != "" && price.Text != "" && balance.Text != "")
            {
                panel1.Visible = true;

                textBox1.Text = c_name.Text;
                textBox2.Text = comboBox2.Text;
                textBox3.Text = s_no.Text;
                textBox4.Text = warranty.Text;
                textBox5.Text = dateTimePicker1.Text;
                textBox6.Text = price.Text;
                textBox7.Text = balance.Text;

            }
            else 
            {
                MessageBox.Show("Enter valid Data!!!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            float profit = float.Parse(price.Text) - float.Parse(comboBox4.Text);

            db.Insert(c_name.Text,comboBox2.Text,s_no.Text,warranty.Text,dateTimePicker1.Text,float.Parse(price.Text),profit,float.Parse(balance.Text));

            //se.Bind(comboBox5, "S_No", selecteditem, "Product_Name", comboBox2.Text);
            se = new search();

            int serial = se.Bind("S_No", selecteditem, "Product_Name", comboBox2.Text);


            

            if(selecteditem != "misc")
            {
                db.UpdateStock(selecteditem, "Stock", int.Parse(comboBox3.Text) - 1, "S_No", serial);
            }

            this.Close();
        }

        private void SellItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }





    }
}
