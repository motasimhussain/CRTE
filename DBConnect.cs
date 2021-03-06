﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;                               //Adding MySQL Library
using System.Windows.Forms;
using System.Data;


namespace CRTE
{
    class DBConnect
    {
        public MySqlConnection con;
        protected string server;
        protected string database;
        protected string uid;
        protected string password;

        protected MySqlDataAdapter mySqlDataAdapter;
        protected MySqlCommandBuilder mySqlCommandBuilder;
        protected DataTable dataTable;
        protected BindingSource bindingSource;


        public DBConnect()
        {
            initialize();
        }

        protected virtual void initialize()
        {
            server = "localhost";
            database = "crte";
            uid = "root";
            password = "root";
            string connectionString;

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            con = new MySqlConnection(connectionString);
        }

        //open connection to database
        protected virtual bool OpenConnection()
        {
            try
            {
                con.Open();
                return true;
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //Close connection
        protected virtual bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO login (u_id,pass,user_type) VALUES ('admin','admin','')";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        public void Insert(string cName,string pName,string pSno,string warr,string date,float price,float profit,float balance)
        {
            string query = "INSERT INTO sales (Client_Name,Product_Name,Product_SerialNo,Warranty,Date,Price,Profit,Balance) VALUES ('"+cName+"','"+pName+"','"+pSno+"','"+warr+"','"+date+"','"+price+"','"+profit+"','"+balance+"')";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        //Update statement
        public virtual void UpdateStock(string table,string field , int data, string sField,int sData)
        {
            string qurey = "UPDATE "+table+" SET "+field+" ='"+data+"' Where "+sField+" = '"+sData+"'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = qurey;
                cmd.Connection = con;

                cmd.ExecuteNonQuery();

                this.CloseConnection();

            }
        }

        //Delete statement
        public virtual void Delete(string table, string column, string value)
        {

            string query = "DELETE FROM " + table + " WHERE " + column + "='" + value + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();

                this.CloseConnection();

            }

        }

        //Select statement
        public virtual List<string>[] Select()
        {
            string query = "SELECT * FROM login";

            List<string>[] list = new List<string>[8];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();
            list[7] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, con);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["u_id"] + "");
                    list[2].Add(dataReader["pass"] + "");
                    list[3].Add(dataReader["user_type"] + "");
                    list[4].Add(dataReader["name"] + "");
                    list[5].Add(dataReader["last_name"] + "");
                    list[6].Add(dataReader["nic"] + "");
                    list[7].Add(dataReader["sales"] + "");

                }

                dataReader.Close();

                this.CloseConnection();

                return list;
            }

            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM login";

            int Count = -1;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, con);

                Count = int.Parse(cmd.ExecuteScalar() + "");

                this.CloseConnection();
                return Count;
            }

            else
            {
                return Count;
            }
        }

        public virtual void Bind(DataGridView dataGridView, string tableName)
        {
            // please note that the following code is vulnerable
            string query = "SELECT * FROM " + tableName;

            mySqlDataAdapter = new MySqlDataAdapter(query, con);
            mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

            mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
            mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
            mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();

            //dataTable = new DataTable();
            //mySqlDataAdapter.Fill(dataTable);

            //bindingSource = new BindingSource();
            //bindingSource.DataSource = dataTable;

            //dataGridView.DataSource = bindingSource;


            DataSet DS = new DataSet();
            mySqlDataAdapter.Fill(DS);
            DS.Tables[0].TableName = tableName;
            dataGridView.DataSource = DS.Tables[0];
        }



        public virtual void saveSql(DataGridView dgv)
        {
            DataTable changes = ((DataTable)dgv.DataSource).GetChanges();


            if (changes != null)
            {
                try
                {
                    MySqlCommandBuilder mcb = new MySqlCommandBuilder(mySqlDataAdapter);
                    mySqlDataAdapter.UpdateCommand = mcb.GetUpdateCommand();
                    mySqlDataAdapter.Update(changes);
                    ((DataTable)dgv.DataSource).AcceptChanges();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Oops something went wrong =( ");
                }
            }
        }




        public void Save()
        {
            mySqlDataAdapter.Update(dataTable);
        }


        public void FillComboBox(ComboBox cb,string tableName, string col)
        {
            string query = "SELECT "+ col +" FROM " + tableName;
            MySqlCommand cmdSel = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);
            cb.DataSource = dt;
            cb.DisplayMember = col;//column name to display
        }



       

        //Backup
        public void Backup()
        {
            //not yet implemented
        }

        //Restore
        public void Restore()
        {
        }
        //not yet implemented
    }
}
