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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=CAN;Initial Catalog=ogrenciKayitOTO;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();


            SqlCommand komut = new SqlCommand("select *from kullaniciGiris where kullaniciAdi='" + textBox1.Text.ToString() + "' AND sifre='" + textBox2.Text.ToString() + "'", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                    Form2 frm2 = new Form2();
                    frm2.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!!");
            }
             this.Hide();
             baglan.Close();

            
        }
    }
}
