using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using Npgsql;
using System.Linq;
using System.Windows.Forms;


namespace Eureca
{
    public partial class Form1 : Form
    {
       
        private string id;
        private NpgsqlConnection con = new NpgsqlConnection("Server=172.28.2.117;Username=postgres;Password=postgres;Database=eureca");
        private NpgsqlCommand cmd = new NpgsqlCommand();
        public Form1()
        {
            InitializeComponent();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from eureca.view limit 5000;";

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(rdr);

                advancedDataGridView2.DataSource = dt;
                rdr.Close();    
            }
            var date = new NpgsqlCommand("select dateofupdate from eureca.item limit 1;", con);
            var read = date.ExecuteReader();
            read.Read();
            textBox1.Text = read.GetString(0);
            cmd.Dispose();

            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sql;
            

            if (Char.IsControl (e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                con.Open();

                if (txtSearch.Text.Length == 1)
                {
                    sql = "select * from eureca.view limit 500;";
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(rdr);
                        advancedDataGridView2.DataSource = dt;

                    }
                }

                
                

                if (e.KeyChar == (char)Keys.Enter)
                {
                    sql = String.Format("select * from eureca.view Where partnumber ilike '%{0}%' limit 500;", txtSearch.Text);
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    NpgsqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(rdr);
                        advancedDataGridView2.DataSource = dt;

                    }
                    cmd.Dispose();
                }
                con.Close();
            }
            else
            {
                con.Open();
                string box = "";
                for (int i = 0; i < txtSearch.Text.Length - 1; i++) box += txtSearch.Text[i];
                if (e.KeyChar == (char)Keys.Back)
                {
                    sql = String.Format("select * from eureca.view Where partnumber ilike '%{0}%' limit 500;", box);
                }
                else sql = String.Format("select * from eureca.view Where partnumber ilike '%{0}%' limit 500;", txtSearch.Text + e.KeyChar.ToString());

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    advancedDataGridView2.DataSource = dt;

                }
                con.Close();

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

     
       
    }
}