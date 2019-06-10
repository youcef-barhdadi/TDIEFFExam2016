using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Dossier2
{
    public class ADO
    {
        SqlConnection cnx = new SqlConnection("");



        public void OpenCon()
        {
            if(cnx.State != ConnectionState.Open)
            {
                cnx.Open();
            }
        }

        public void CloseCnx()
        {
            if(cnx.State != ConnectionState.Closed)
            {
                cnx.Close();
            }
        }


        public DataTable getDataTable(string req)
        {
            SqlCommand cmd = new SqlCommand(req, cnx);
            OpenCon();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            CloseCnx();


            return dt;

        }


        public int Execute(string req)
        {
            SqlCommand cmd = new SqlCommand(req, cnx);
            OpenCon();


            int num = cmd.ExecuteNonQuery();

            CloseCnx();

            return num;
        }



        public void RemplirCompo(string req,ComboBox c)
        {
            DataTable dt = getDataTable(req);

            c.ValueMember = dt.Columns[0].ColumnName;
            c.DisplayMember = dt.Columns[1].ColumnName;

            c.DataSource = dt;


        }


        public void remplirDG(string req,DataGridView d)
        {

            d.DataSource = getDataTable(req);
        }




        public void ExcuteProc(string name, List<SqlParameter> list)
        {



            OpenCon();




            CloseCnx();
        }
    }

}
