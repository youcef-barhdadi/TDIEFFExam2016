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

namespace Dossier2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection("");
            cnx.Open();
            SqlCommand cmd = new SqlCommand("Q3", cnx);


            SqlParameter p = new SqlParameter("idC", textBox1.Text);
            cmd.Parameters.Add(p);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());


            dataGridView1.DataSource = dt;

            cnx.Close();
        }
    }
}
