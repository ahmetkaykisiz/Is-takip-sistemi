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
    public partial class GorevEkle : Form
    {
        public GorevEkle()
        {
            InitializeComponent();
        }
    
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database2.accdb");
        private void Form4_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand listele2 = new OleDbCommand("Select * From [Story] ", baglanti);

            OleDbDataReader oku2 = listele2.ExecuteReader();

            while (oku2.Read())
            {
                comboBox1.Items.Add(oku2["StoryName"]);
                
            }
           

            
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand listele = new OleDbCommand("Select * From Story where StoryName='" + comboBox1.Text + "'", baglanti);
            OleDbDataReader oku = listele.ExecuteReader();
            if (oku.Read())
            {
                label5.Text = oku["Id"].ToString();
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand kaydet = new OleDbCommand("insert into [Task] (StoryId,TaskSpace,TaskLiable,TaskLocation) values('" +label5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + label2.Text + "')", baglanti);
            kaydet.ExecuteNonQuery();

            baglanti.Close();
        }

        private void görevleriDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void görevDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoryEkle form3 = new StoryEkle();
            form3.Show();
            this.Hide();
        }

        private void görevEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form1 = new Form2();
            form1.Show();
            this.Hide();
        }
    }
}
