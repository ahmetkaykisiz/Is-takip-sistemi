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
    public partial class StoryEkle : Form
    {
        public StoryEkle()
        {
            InitializeComponent();
        }
       OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database2.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            OleDbCommand kaydet = new OleDbCommand("insert into [Story] (StorySpace,StoryName) values('" + textBox2.Text + "','" + textBox1.Text + "')", baglanti);
            kaydet.ExecuteNonQuery();
           
            baglanti.Close();

        }
    }
}
