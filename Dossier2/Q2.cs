using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dossier2
{
    public partial class Q2 : Form
    {


        DataTable dt;
        public Q2()
        {
            InitializeComponent();

            dt = ado.getDataTable("select * from Organisatuer");
        }
        ADO ado = new ADO();

        
        private void button1_Click(object sender, EventArgs e)
        {

            if(passtextBox5.Text.Length < 6)
            {
                MessageBox.Show(" 6 caracters password");
                return;
            }


            string req = $"insert into Organisatuer values ('{idtextBox1.Text}','{nomtextBox2.Text}','{prenomtextBox3.Text}','{emailtextBox4.Text}','{passtextBox5.Text}')";


            int num =  ado.Execute(req);


            

            if(num< 0)
            {
                MessageBox.Show("Ajouter avec success");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (passtextBox5.Text.Length < 6)
            {
                MessageBox.Show(" 6 caracters password");
                return;
            }

            string req = $"update Organisatuer set nomOrg = '{nomtextBox2.Text}' , prenomOrg = '{prenomtextBox3.Text}',emailOrg = '{emailtextBox4.Text}' , passOrg = '{passtextBox5.Text}' where  idOrg ='{idtextBox1.Text}' ";


            int num = ado.Execute(req);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("confime", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string req = $"delete from  Organisatuer where  idOrg ={idtextBox1}  ";
                int num = ado.Execute(req);

                MessageBox.Show($"{num} deleete");
            }


        }

        int index = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            index = 0;
            Navigate(index);
        }


        public void Navigate(int postion)
        {
            idtextBox1.Text = dt.Rows[postion][0].ToString();
            nomtextBox2.Text = dt.Rows[postion][1].ToString();
            prenomtextBox3.Text = dt.Rows[postion][2].ToString();
            emailtextBox4.Text = dt.Rows[postion][3].ToString();
            passtextBox5.Text = dt.Rows[postion][4].ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            index = dt.Rows.Count - 1;

            Navigate(index);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(index != dt.Rows.Count - 1)
            {
                index++;
                Navigate(index);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (index != 0)
            {
                index--;
                Navigate(index);
            }
        }
    }
}
