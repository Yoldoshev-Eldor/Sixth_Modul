using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SchoolSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-40PGLKA;User ID=sa;Password=1;Initial Catalog=schooldb;TrustServerCertificate=True"); 
            con.Open();
            string username=textBox1.Text;
            string password=textBox2.Text;
            SqlCommand cnn = new SqlCommand("select UserName,Password from logintab where UserName='" + textBox1.Text + "'and Password='" + textBox2.Text + "'",con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0 )
            {
                Main main = new Main();
                main.Show();

            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            con.Close();
        }
    }
}
