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
    public partial class Q3 : Form
    {
        public Q3()
        {
            InitializeComponent();
        }
        ADO ado = new ADO();
        private void Q3_Load(object sender, EventArgs e)
        {

            ado.RemplirCompo("select idCategorie , nomCategorie from Categorie",comboBox1);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string req = $@"select nomCamp , SUM(P.montant) , DATEDIFF(DAY,dateCretion,dateFin) from Campagne  C
left join Participation  P
on  C.idCamp =P.idCamp 


where  idCamp = '{comboBox1.SelectedValue}'";


            ado.remplirDG(req, dataGridView1);
        }
    }
}
