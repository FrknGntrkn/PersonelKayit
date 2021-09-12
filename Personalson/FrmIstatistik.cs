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

namespace Personalson
{
    public partial class lbl : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LRC7UJQ;Initial Catalog=personal;Integrated Security=True");
        public lbl()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //TOPLAM PERSONEL SAYISI
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select Count(*) From Table_1", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblToplamPer.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //EVLİ PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select Count(*) From Table_1 where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPer.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //BEKAR PERSONEL SAYISI

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select Count(*) From Table_1 where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPer.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //FARKLI ŞEHİR SAYISI

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(PerSehir)) From Table_1", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //TOPLAM MAAŞ

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) From Table_1", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //ORTALAMA MAAŞ

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select Avg(PerMaas) From Table_1", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();


        }
    }
}
