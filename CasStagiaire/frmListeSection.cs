using classesMetierStagiaires;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasStagiaire
{
    public partial class frmListeSection : Form
    {
        public frmListeSection()
        {
            
                InitializeComponent();
                // initialisation de la collection de sections
                Donnees.Sections = new MSections();

                // TODO : initialisation du jeu d'essai ==> récupérer depuis BDD
                this.init();

                // afficher la liste des stagiaires de la section
                this.afficheSections(Donnees.Sections);
            }

        /// <summary>
        /// initialisation du jeu d'essai 
        /// </summary>
        private void init()
        {

            MSections.SelectSection(Donnees.Sections);
        }

                private void btnouvrir_Click(object sender, EventArgs e)
        {

        }

        private void frmListeSection_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmListeSection_Load_1(object sender, EventArgs e)
        {



        }
        private void afficheSections(MSections sections)
        {
            MSections.SelectSection(sections);

            // déterminer l'origine des données à afficher : 
            // appel de la méthode de la classe MSection 
            // qui alimente et retourne copie de sa 
            // collection de stagiaires sous forme de datatable
            this.grdSection.DataSource = sections.ListerSections();
            // refraîchir l'affichage
            this.grdSection.Refresh();

        }

        private void frmListeSection_Load_1(object sender, EventArgs e)
        {

        }
    }
}
