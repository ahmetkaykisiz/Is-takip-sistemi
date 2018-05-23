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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database2.accdb");
        private void görevEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StoryEkle form = new StoryEkle();
            form.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand listele = new OleDbCommand("Select * From Task", baglanti);
            OleDbDataReader oku = listele.ExecuteReader();
            while (oku.Read())
            {
                string a = oku["TaskLocation"].ToString();
                if(a == "1")//Başlangıc kısmı
                {
                    listBox2.Items.Add(oku["TaskSpace"]);
                    listBox5.Items.Add(oku["TaskLiable"]);
                   listBox1.Items.Add(oku["StoryId"]);
                    label6.Text = oku["StoryId"].ToString();
                    //OleDbCommand listele2 = new OleDbCommand("Select * From [Story] where Id='" + label6.Text + "' ", baglanti);
                    //OleDbDataReader oku2 = listele2.ExecuteReader();
                  // if (oku2.Read())
                  //  {
                   //    listBox1.Items.Add(oku2["StroyName"]);
                  // }
                   // listBox3.Items.Add("-");
                  //  listBox4.Items.Add("-");
                }
               
               
                if(a=="2")
                {
                    listBox3.Items.Add(oku["TaskSpace"]);
                    listBox5.Items.Add(oku["TaskLiable"]);
                    listBox1.Items.Add(oku["StoryId"]);
                    listBox2.Items.Add("-");
                    listBox4.Items.Add("-");
                    // Programlanıyor Kısmı
                }
                if(a=="3")
                {
                    listBox4.Items.Add(oku["TaskSpace"]);
                    listBox5.Items.Add(oku["TaskLiable"]);
                    listBox1.Items.Add(oku["StoryId"]);
                    listBox3.Items.Add("-");
                    listBox2.Items.Add("-");
                    //Tamamlandı Kısmı
                }
               
            }
            baglanti.Close();
        }

        private void görevleriDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GorevEkle form4 = new GorevEkle();
            form4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)// in progress yapma
        {
            baglanti.Open();
            label6.Text = listBox2.SelectedItem.ToString();
             OleDbCommand guncel = new OleDbCommand("update [Task] set TaskLocation ='" + 2 + "' where TaskSpace='" + label6.Text + "' ", baglanti);
            guncel.ExecuteNonQuery();
            baglanti.Close();
          
        }

        private void button2_Click(object sender, EventArgs e)//Bitti
        {
            baglanti.Open();
            label6.Text = listBox3.SelectedItem.ToString();
            OleDbCommand guncel = new OleDbCommand("update [Task] set TaskLocation ='" + 3 + "' where TaskSpace='" + label6.Text + "' ", baglanti);
            guncel.ExecuteNonQuery();
            baglanti.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void userSenaryoİlerletToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
