using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using CasStagiaire;



namespace classesMetierStagiaires
{
    /// <summary>
    /// form de d�marrage : datagridview des stagiaires (de la section CDI pour commencer)
    /// </summary>
    public partial class frmExo9 : Form
    {

        /// <summary>
        /// la section de stagiaires g�r�e par ce form
        /// </summary>
        private MSection laSection;
        private String code;
        
        /// <summary>
        /// Constructeur 
        /// (initialise la collection de sections et ins�re en dur la section CDI)
        /// </summary>
        public frmExo9(MSection section)
        {
            laSection = section;

            InitializeComponent();
            // initialisation de la collection de sections
            // Donnees.Sections = new MSections();

            // TODO : initialisation du jeu d'essai ==> r�cup�rer depuis BDD
            this.init();
           
            // afficher la liste des stagiaires de la section
            this.afficheStagiaires();
        }

        /// <summary>
        /// initialisation du jeu d'essai 
        /// </summary>
        private void init()
        {
           
            // ajoute le stagiaire instanci� � la collection de la section CDI1
           // this.laSection.Ajouter(unStagiaire);
            MSection.SelectStagiaire(laSection);

        }

        /// <summary>
        /// r�tablit la source de donn�es de la dataGridView
        /// et rafra�chit son affichage
        /// </summary>
        private void afficheStagiaires()
        {
            MSection.SelectStagiaire(laSection);

            // d�terminer l'origine des donn�es � afficher : 
            // appel de la m�thode de la classe MSection 
            // qui alimente et retourne copie de sa 
            // collection de stagiaires sous forme de datatable
            this.grdStagiaires.DataSource = laSection.ListerStagiaires(); 
            // refra�chir l'affichage
            this.grdStagiaires.Refresh();
            
        }

        /// <summary>
        /// Bouton  ajouter : instancie un form de saisie stagiaire
        /// et lui passe la r�f�rence � la section en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // instancier un form de saisie de stagiaire et l'afficher en modal
            // il faut pr�ciser la r�f�rence � la section que l'on traite
            frmAjoutStagiaire frmAjout = new frmAjoutStagiaire(this.laSection);
            // si on sort de la saisie par OK
            if (frmAjout.ShowDialog() == DialogResult.OK)
            {
                // r�g�n�rer l'affichage du dataGridView 
                afficheStagiaires();
            }
        }

        /// <summary>
        /// Double-clic sur le datagridview :
        /// ouvrir la feuille d�tail en y affichant
        /// le stagiaire correspondant � la ligne double-cliqu�e
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdStagiaires_DoubleClick(object sender, EventArgs e)
        {
            // ouvrir la feuille d�tail en y affichant 
            // le stagiaire correspondant � la ligne double-cliqu�e
            MStagiaire leStagiaire;
            Int32 laCle; // cl� (=numOSIA) du stagiaire dans la collection

            // r�cup�rer cl� du stagiaire cliqu� en DataGridView
            laCle = (Int32)this.grdStagiaires.CurrentRow.Cells[0].Value;
            // instancier un objet stagiaire pointant vers 
            // le stagiaire d'origine dans la collection
            leStagiaire = this.laSection.RestituerStagiaire(laCle);
            // instancier un form d�tail pour ce stagiaire
            frmVisuStagiaire frmVisu = new frmVisuStagiaire(leStagiaire);
            // personnaliser le titre du form
            frmVisu.Text = leStagiaire.ToString();
            // afficher le form d�tail en modal
            frmVisu.ShowDialog();

            // en sortie du form d�tail, refraichir la datagridview
            this.afficheStagiaires();

        }

        /// <summary>
        /// bouton fermer : fermer le form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// bouton supprimer : g�rer la suppression du stagiaire point� dans la datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        
       private void btnSupprimer_Click(object sender, EventArgs e)
        {
                // si un stagiaire est point� dans la datagridview
                if (this.grdStagiaires.CurrentRow != null)
                {
                    // r�cup�rer la cl� du stagiaire point�
                    Int32 cleStagiaire;
                    cleStagiaire = (Int32)this.grdStagiaires.CurrentRow.Cells[0].Value;
                    // demander confirmation de la suppression
                    // NB: messagebox retourne une valeur exploitable !
                    if (MessageBox.Show("Voulez-vous supprimer le stagiaire num�ro :" + cleStagiaire.ToString(), "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    {
                        /*
                        // supprimer et compacter la collection
                        this.laSection.Supprimer(cleStagiaire);

                        // *** ajouter l'impact en BDD **
                        // ----------------------------------------
                        */
                        //modification effectuer par moussa
                        MSection.DeleteStagiaire(cleStagiaire);

                        // r�afficher la datagridview
                        afficheStagiaires();
                    }
                }
            }

        /// <summary>
        /// gestion bouton supprimer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdStagiaires_SelectionChanged(object sender, EventArgs e)
        {
            // admirer la syntaxe optimis�e...
            this.btnSupprimer.Enabled = (this.grdStagiaires.CurrentRow == null ? false : true);

        }

        private void frmExo9_Load(object sender, EventArgs e)
        {

        }
    }
    
}