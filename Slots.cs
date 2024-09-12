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

namespace SlotBooking
{
    public partial class Slots : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        public Slots()
        {
            InitializeComponent();
            conn.ConnectionString = @"server=.\sqlexpress;initial catalog=adodemo;user id=sa;password=Pass@123;";
            cmd.Connection = conn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "insert into slots values(@slotName,@slotPrice,@slotDate)";
            cmd.Parameters.AddWithValue("@slotName", slotName.Text);
            cmd.Parameters.AddWithValue("@slotPrice", slotPrice.Text);
            cmd.Parameters.AddWithValue("@slotDate", textDate.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            slotName.Text = "";
            slotPrice.Text = "";
            textDate.Text = "";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "select * from slots";
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                slotName.Text = reader[0].ToString();
                slotPrice.Text = reader[1].ToString();
                textDate.Text = reader[2].ToString();
            }
            else
            {
                conn.Close();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            if (reader.Read())
            {
                slotName.Text = reader[0].ToString();
                slotPrice.Text = reader[1].ToString();
                textDate.Text = reader[2].ToString();
            }
            
        }

        private void textDate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
