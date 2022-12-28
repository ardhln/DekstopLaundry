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
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;

namespace LaundryChan
{
    public partial class Home : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=AR762\ARIDHLN;Initial Catalog=Login1;Integrated Security=True");
        public Home()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Laundry2] (Nama, Berat, Tipe, Harga, Uang, Kembalian, Tgl_selesai) values ('"+ textBox1.Text +"', '"+ textBox2.Text +"', '"+ comboBox1.Text +"', '"+ textBox3.Text +"', '"+ textBox4.Text +"', '"+ textBox5.Text +"', '"+ dateTimePicker1.Text +"')";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            display_data();
            MessageBox.Show("Berhasil diinput");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Double A, B;

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Tipe belum diisi");
            }
            else if(comboBox1.SelectedIndex == 0)
            {
                A = Double.Parse(textBox2.Text);
                B = A * 7000;
                textBox3.Text = B.ToString();
                
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                A = Double.Parse(textBox2.Text);
                B = A * 10000;
                textBox3.Text = B.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Double C, D, E;
            C = Double.Parse(textBox3.Text);
            D = Double.Parse(textBox4.Text);
            E = D - C;
            textBox5.Text = E.ToString();
        }
        public void display_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Laundry2]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            koneksi.Close();
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            display_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Laundry2] where Nama = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            display_data();
            MessageBox.Show("Item Dihapus");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Laundry2] set Nama='" + this.textBox1.Text + "', Berat='" + this.textBox2.Text + "', Tipe='" + this.comboBox1.Text + "', Harga='" + this.textBox3.Text + "', Uang='" + this.textBox4.Text + "', Kembalian='" + this.textBox5.Text + "', Tgl_selesai='" + dateTimePicker1.Text + "' where Nama= '"+ this.textBox1.Text +"'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value = DateTime.Now;   
            display_data();
            MessageBox.Show("Berhasil diupdate");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Laundry2] where Nama = '"+textBox6.Text+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            koneksi.Close();
            textBox6.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Value= DateTime.Now;
        }
    }
}
