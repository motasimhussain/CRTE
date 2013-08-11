using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;


namespace CRTE
{
    class search:DBConnect
    {
        //public void Bind(ComboBox cbox,string reqfield ,string tableName,string field , string data)  //search data from a field and return data to datagridview
        //{
        //    try
        //    {

        //        string query = "select "+reqfield+" from "+tableName+" where "+field+" = '"+data+"'";

        //        mySqlDataAdapter = new MySqlDataAdapter(query, con);
        //        mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);

        //        //mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
        //       // mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
        //       // mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();

        //        dataTable = new DataTable();
        //        mySqlDataAdapter.Fill(dataTable);

        //        bindingSource = new BindingSource();
        //        bindingSource.DataSource = dataTable;

        //        cbox.DataSource = bindingSource;

        //    }

        //    catch (MySqlException exception)
        //    {
        //        MessageBox.Show(exception.ToString());
        //    }
        //}

        public void Bind(ComboBox cb, string reqfield, string tableName, string field, string data)
        {
            string query = "select "+reqfield+" from "+tableName+" where "+field+" = '"+data+"'";
            MySqlCommand cmdSel = new MySqlCommand(query, con);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);
            cb.DataSource = dt;
            cb.DisplayMember = reqfield;//column name to display
        }

        public int Bind(string reqfield, string tableName, string field, string data)
        {
            string query = "select " + reqfield + " from " + tableName + " where " + field + " = '" + data + "'";
            con.Open();
            MySqlCommand cmdSel = new MySqlCommand(query, con);
            //DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);

            int myInt = (int)cmdSel.ExecuteScalar();
            con.Close();
            return myInt;
            //da.Fill(dt);
            //cb.DataSource = dt;
            //cb.DisplayMember = reqfield;//column name to display
        }


        public void BindText(TextBox tb, string reqfield, string tableName, string field, string data)
        {
            string query = "select " + reqfield + " from " + tableName + " where " + field + " = '" + data + "'";
            con.Open();
            MySqlCommand cmdSel = new MySqlCommand(query, con);
            //DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);

            tb.Text = cmdSel.ExecuteScalar().ToString();
            con.Close();
            //da.Fill(dt);
            //cb.DataSource = dt;
            //cb.DisplayMember = reqfield;//column name to display
        }

    }
}
