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

namespace StajOgrenciKayitOtomasyonu
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=CAN;Initial Catalog=ogrenciKayitOTO;Integrated Security=True");

        private void listele()
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("select * from kullaniciGiris", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kullaniciAdi"].ToString());
              

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into kullaniciGiris(kullaniciAdi,sifre) values (@p1,@p2)", baglan);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", textBox2.Text);
         
            komut.ExecuteNonQuery();
            baglan.Close();
            listele();
            temizle();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            temizle();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();

            String secili = listView1.SelectedItems[0].SubItems[0].Text;

            SqlCommand komut = new SqlCommand("update kullaniciGiris set kullaniciAdi='" + textBox1.Text.ToString() + "', sifre='"+textBox2.Text.ToString()+"' where id='" + secili + "' ", baglan);
            komut.ExecuteNonQuery();

            baglan.Close();

            listView1.Items.Clear();
            temizle();
            listele();
            secili = " ";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();


            String secili = listView1.SelectedItems[0].SubItems[0].Text;

            SqlCommand delete = new SqlCommand("delete from kullaniciGiris where id='" + secili + "'", baglan);
            delete.ExecuteNonQuery();

            baglan.Close();

            secili = " ";
            listView1.Items.Clear();
            temizle();
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            this.Hide();
            //DialogResult = DialogResult.Cancel;
        }
    }
}
