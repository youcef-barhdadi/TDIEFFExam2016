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
    public partial class Q4 : Form
    {
        public Q4()
        {
            InitializeComponent();
        }
        ADO ado = new ADO();
        private void Q4_Load(object sender, EventArgs e)
        {
            string req = $@"select C. nomCamp , C.dateCretion , C.montantCamp , (select count(*) from Participant where idP = P.idP ) as 'ss' from Campagne  C
left join Participation  P
on  C.idCamp =P.idCamp 
where (SELECT SUM(montant) from  Participation where idPart = P.idPart)  > = C.montantCamp and YEAR(C.dateCretion) = 2015 

";

            ado.remplirDG(req, dataGridView1);


        }
    }
}
