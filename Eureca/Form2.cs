using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace Eureca
{ 
    public partial class Form2 : Form
    {   public int closed = 0;
        private NpgsqlCommand cmd = new NpgsqlCommand();
        private NpgsqlConnection con = new NpgsqlConnection("Server=172.28.2.117;Username=postgres;Password=postgres;Database=eureca");

        public Form2()
        {
            InitializeComponent();
            con.Open();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sql = String.Format("select * from eureca.view Where partnumber like '{0}%' limit 500;", box);
            var command = new NpgsqlCommand(String.Format("select * from eureca.auth where login='{0}' and pass='{1}'",textBox1.Text,textBox2.Text), con);

            try 
            {
                command.ExecuteScalar().ToString();
                MessageBox.Show("Вы успешно авторизовались");
                this.Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            //this.Close();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {   EventArgs ar = new EventArgs();
                button1_Click(sender,ar);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            closed = 1;
        }
    }
}
