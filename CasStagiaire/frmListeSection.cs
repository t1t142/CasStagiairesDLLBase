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
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

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

        

        private void frmListeSection_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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


        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> handler = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }

        private void btnouvrir_Click(object sender, EventArgs e)
        {
            
            MSection laSection;
            String leCode;

         
            leCode = (String)this.grdSection.CurrentRow.Cells[0].Value;
        
            laSection = Donnees.Sections.RestituerSection(leCode);
        
            //MessageBox.Show("ok");
            OnRaiseCustomEvent(new CustomEventArgs(laSection));
        
        }

       
    }

}

 