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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
       
        SqlConnection baglan = new SqlConnection("Data Source=CAN;Initial Catalog=ogrenciKayitOTO;Integrated Security=True");
       
        private void listele()
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("select * from ogrenciBilgii",baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tcNo"].ToString();
                ekle.SubItems.Add(oku["adSoyad"].ToString());
                ekle.SubItems.Add(oku["okul"].ToString());
                ekle.SubItems.Add(oku["bolum"].ToString());
                ekle.SubItems.Add(oku["sinif"].ToString());
                ekle.SubItems.Add(oku["baslangicT"].ToString());
                ekle.SubItems.Add(oku["bitisT"].ToString());
                ekle.SubItems.Add(oku["fotograf"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
        private void pictureBoxTemizle()
        {
            pictureBox1.Image = null;
            pictureBox1.Refresh();
        }

            private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
            file.ShowDialog();
            String dosyaYolu = file.FileName;
            textBox5.Text = file.FileName;
            pictureBox1.ImageLocation = dosyaYolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("insert into ogrenciBilgii(tcNo,adSoyad,okul,bolum,sinif,baslangicT,bitisT,fotograf) values ('"+textBox1.Text.ToString()+ "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + comboBox1.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglan);
                
            komut.ExecuteNonQuery();
            baglan.Close();

            listView1.Items.Clear();
            listele();
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            baglan.Open();

            String secili = listView1.SelectedItems[0].SubItems[0].Text;

            SqlCommand komut = new SqlCommand("update ogrenciBilgii set tcNo='"+textBox1.Text.ToString()+"', adSoyad='"+textBox2.Text.ToString()+"', okul='"+textBox3.Text.ToString()+"', bolum='"+textBox4.Text.ToString()+"', sinif='"+comboBox1.Text.ToString()+"', baslangicT='"+textBox6.Text.ToString()+"', bitisT='"+textBox7.Text.ToString()+"' where tcNo='"+secili+"' ", baglan);
            komut.ExecuteNonQuery();

            baglan.Close();

            listView1.Items.Clear();
            temizle();
            listele();
            secili = " ";   
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            temizle();
            listele();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();


            String secili = listView1.SelectedItems[0].SubItems[0].Text;

            SqlCommand delete = new SqlCommand("delete from ogrenciBilgii where tcNo='"+secili+"'", baglan);
            delete.ExecuteNonQuery();

            baglan.Close();

            secili = " ";
            listView1.Items.Clear();
            temizle();
            listele();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pictureBoxTemizle();
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[7].Text;

            String adres = textBox5.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand arama = new SqlCommand("select *from ogrenciBilgii where adSoyad='" + textBox8.Text.ToString() + "' ", baglan);
            SqlDataReader oku = arama.ExecuteReader();

            while(oku.Read())
            {
                listView1.Items.Clear();
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["tcNo"].ToString();
                ekle.SubItems.Add(oku["adSoyad"].ToString());
                ekle.SubItems.Add(oku["okul"].ToString());
                ekle.SubItems.Add(oku["bolum"].ToString());
                ekle.SubItems.Add(oku["sinif"].ToString());
                ekle.SubItems.Add(oku["baslangicT"].ToString());
                ekle.SubItems.Add(oku["bitisT"].ToString());
                ekle.SubItems.Add(oku["fotograf"].ToString());

                listView1.Items.Add(ekle);

            }
            baglan.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            foreach (Control item in Controls)
            {
                if(item is TextBox)
                {
                    if(item.Text=="")
                    {
                        listView1.Items.Clear();
                        listele();
                    }
                }
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
