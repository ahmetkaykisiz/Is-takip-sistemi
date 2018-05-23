using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace eminhocav3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database2.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand listele = new OleDbCommand("Select * From [user] where userName='" + textBox1.Text + "' and userPassword='" + textBox2.Text + "'", baglanti);

            OleDbDataReader oku = listele.ExecuteReader();

            if (oku.Read())
            {
                Form2 form1 = new Form2();
                form1.Show();
                this.Hide();
            }
            else { label3.Text = "Kullanıcı Adı Veya Şifre Hatalı..."; }
            baglanti.Close();
        }
    }
}
