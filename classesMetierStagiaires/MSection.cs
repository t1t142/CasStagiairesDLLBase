using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;




namespace classesMetierStagiaires
{
    /// <summary>
    /// classe des sections de stagiaires
    /// </summary>
    public class MSection
    {

        /// <summary>
        /// code de la section = sa cl� 
        /// ==> en lecture seule et initialis� dans le constructeur
        /// </summary>
        private String leCodeSection;

        /// <summary>
        /// obtient le code de la section (lecture seule)
        /// </summary>
        public String CodeSection
        {
            get { return leCodeSection; }
        }

        /// <summary>
        /// libell� de la section
        /// (non initialis� dans le constructeur)
        /// </summary>
        private String leNomSection;

        /// <summary>
        /// obtient ou d�finit le libell� de la section
        /// </summary>
        public String NomSection
        {
            get { return leNomSection; }
            set { leNomSection = value; }
        }

        /// <summary>
        /// date de d�but de la formation
        /// </summary>
        private DateTime debutFormation;

        /// <summary>
        /// obtient ou d�finit  la date de d�but de la formation
        /// </summary>
        public DateTime DebutFormation
        {
            get
            {
                return this.debutFormation;
            }
            set
            {
                this.debutFormation = value;
            }
        }

        /// <summary>
        /// date de fin de la formation
        /// </summary>
        private DateTime finFormation;

        /// <summary>
        /// obtient ou d�finit la date de fin de la formation
        /// </summary>
        public DateTime FinFormation
        {
            get
            {
                return this.finFormation;
            }
            set
            {
                this.finFormation = value;
            }
        }

        /// <summary>
        /// collection des stagiaires de cette section 
        /// sous forme de dictionnaire tri�
        /// </summary>
        private SortedDictionary<Int32, MStagiaire> lesStagiaires;


        /// <summary>
        /// datatable des stagiaires pour affichages en datagridview 
        /// et pour exporter/importer en XML
        /// </summary>
        private DataTable dtStagiaires;


        
        /// <summary>
        /// constructeur 
        /// </summary>
        /// <param name="leCode">le code de la section</param>
        /// <param name="leNom">le libell� de la section</param>
        public  MSection(String leCode, String leNom)
        {
            // initialise code et nom de la section
            this.leCodeSection = leCode;
            this.NomSection = leNom;
            // instancie un dictionnaire vide pour les stagiaires de cette section
            lesStagiaires = new SortedDictionary<int,MStagiaire>();
            // datatable : pour y copier les donn�es stagiaires
            // et � fournir aux composants de pr�sentation 
            dtStagiaires = new DataTable();

            // ajout � la datatable de 3 colonnes personnalis�es 
            this.dtStagiaires.Columns.Add(new DataColumn("Num�ro OSIA", typeof(System.Int32)));
            this.dtStagiaires.Columns.Add(new DataColumn("Nom", typeof(System.String)));
            this.dtStagiaires.Columns.Add(new DataColumn("Pr�nom", typeof(System.String)));

        }

        public MSection(String leCode, String leNom, DateTime ddebut, DateTime dfin)
        {
            // initialise code et nom de la section
            this.leCodeSection = leCode;
            this.NomSection = leNom;
            this.debutFormation = ddebut;
            this.finFormation = dfin;

            // instancie un dictionnaire vide pour les stagiaires de cette section
            lesStagiaires = new SortedDictionary<int, MStagiaire>();
            // datatable : pour y copier les donn�es stagiaires
            // et � fournir aux composants de pr�sentation 
            dtStagiaires = new DataTable();

            // ajout � la datatable de 3 colonnes personnalis�es 
            this.dtStagiaires.Columns.Add(new DataColumn("Num�ro OSIA", typeof(System.Int32)));
            this.dtStagiaires.Columns.Add(new DataColumn("Nom", typeof(System.String)));
            this.dtStagiaires.Columns.Add(new DataColumn("Pr�nom", typeof(System.String)));


        }

        /// <summary>
        /// ajouter un stagiaire � la collection
        /// (re�oit la ref au stagiaire et en d�duit la cl� (= numOsia) pour la collection)
        /// </summary>
        /// <param name="unStagiaire">la r�f�rence du stagiaire � ajouter</param>
        public void Ajouter(MStagiaire unStagiaire)
        {
            // TODO : � s�curiser : doublon sur cl� possible
            this.lesStagiaires.Add(unStagiaire.NumOsiaStagiaire, unStagiaire);
           // Stagiaires.insert(unstagiaire);

        }


        /// <summary>
        /// supprimer un stagaire de la collection
        /// (re�oit la ref au stagiaire et en d�duit la cl� (= numOsia) pour la collection)
        /// </summary>
        /// <param name="unStagiaire">la r�f�rence au stagiaire � supprimer</param>
        public void Supprimer(MStagiaire unStagiaire)
        {
            // TODO : � s�curiser...
            this.lesStagiaires.Remove(unStagiaire.NumOsiaStagiaire); 
        }

        /// <summary>
        /// supprimer un stagaire de la collection
        /// (re�oit la cl� du stagiaire (= numOsia) pour la collection
        /// </summary>
        /// <param name="unNumOSIA">la cl� (= numOsia) du stagiaire � supprimer</param>
        /// <exception cref="Exception">Si numOSIA re�u non trouv� en collection</exception>
        public void Supprimer(Int32 unNumOSIA)
        {
            // suppression s�curis�e
            if (this.lesStagiaires.ContainsKey(unNumOSIA))
            {
                this.lesStagiaires.Remove(unNumOSIA);
            }
            else
            {
                throw new Exception("Erreur : num�ro OSIA non trouv� dans la collection");
            }
        }
        /// <summary>
        /// modifier les donn�es d'un stagiaire
        /// tout est modifiable sauf le numOsia (= cl� de la collection)
        /// </summary>
        /// <param name="unStagiaire">la r�f�rence au nouvel objet MStagiaire pour cette cl�</param>
        public void Remplacer(MStagiaire unStagiaire)
        {
            // il suffit de modifier la r�f�rence � l'objet MStagiaire
            // dans la collection pour ce numOsia

            //modifier la r�f�rence de stagiaire stock�e dans la collection            
            this.lesStagiaires[unStagiaire.NumOsiaStagiaire] = unStagiaire;

        }


        /// <summary>
        /// Rechercher un stagiaire dans la liste en connaissant sa cl�
        /// </summary>
        /// <param name="unNumOsia">le num�ro OSIA (=la cl�) du stagiaire � rechercher</param>
        /// <returns>la r�f�rence au stagiaire (ou bien l�ve une erreur)</returns>
        public MStagiaire RestituerStagiaire(Int32 unNumOsia)
        {
            MStagiaire leStagiaire;
            leStagiaire = this.lesStagiaires[unNumOsia] ;
            if (leStagiaire == null)
            {
                throw new Exception("Aucun stagiaire pour le num�ro OSIA " + unNumOsia.ToString());
            }
            else
            {
                return leStagiaire;
            }
        }


        /// <summary>
        /// g�n�rer et retourner une datatable
        /// qui liste les nomOsia, nom et prenom
        /// de tous les stagiaires de la collection
        /// </summary>
        /// <returns>une r�f�rence de datatable � 3 colonne</returns>
        public DataTable ListerStagiaires()
        {
            // vider la datatable pour la r�g�n�rer
            this.dtStagiaires.Clear();
            // boucle de remplissage de la datatable � partir de la collection
            foreach (MStagiaire unStagiaire in this.lesStagiaires.Values)
            {
                // instanciation datarow (=ligne datatable)
                DataRow dr; 
                dr = this.dtStagiaires.NewRow();
                // affectation des 3 colonnes
                dr[0] = unStagiaire.NumOsiaStagiaire;
                dr[1] = unStagiaire.NomStagiaire;
                dr[2] = unStagiaire.PrenomStagiaire;
                // ajouter la ligne � la datatable
                this.dtStagiaires.Rows.Add(dr);
            } // fin de boucle remplissage datatable
            // retourne la r�f�rence � la datatable
            return this.dtStagiaires;
        }

        public void SupprimerStagiaires()
        {
            this.lesStagiaires.Clear();
            
        }

        public override string ToString()
        {
            return "CodeSection : " + this.CodeSection;
        }

        public static void SelectStagiaire(MSection laSection)
        {
            string query = "SELECT * FROM mstagiaire JOIN msections ON mstagiaire.id_section=msections.id_section AND code=@code";
            laSection.SupprimerStagiaires();

            MySqlCommand cmd = DBConnect.GetConnexion().CreateCommand();
            cmd.Parameters.AddWithValue("@code", laSection.CodeSection);
            cmd.CommandText = query;


            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                Boolean afpa = false;
                MStagiaire nouveauStagiaire;
                if (dataReader["type"].ToString() == "DE")
                {
                    // instancier un stagiaire sp�cialis� DE et lui affecter toutes ses propri�t�s
                    if (dataReader["remu_afpa"].ToString() == "1")
                    {
                        afpa = true;
                    }


                    nouveauStagiaire = new MStagiaireDE(
                           int.Parse(dataReader["numosia"].ToString()),
                           dataReader["nom"].ToString(),
                            dataReader["prenom"].ToString(),
                             dataReader["rue"].ToString(),
                             dataReader["ville"].ToString(),
                             dataReader["codepostal"].ToString(),
                            int.Parse(dataReader["nbrenotes"].ToString()),
                            double.Parse(dataReader["pointsnotes"].ToString()),
                             afpa);

                    laSection.Ajouter(nouveauStagiaire);
                    nouveauStagiaire = null;
                }


                if (dataReader["type"].ToString() == "CIF")
                {
                    // instancier un stagiaire sp�cialis� DE et lui affecter toutes ses propri�t�s


                    nouveauStagiaire = new MStagiaireCIF(
                           int.Parse(dataReader["numosia"].ToString()),
                           dataReader["nom"].ToString(),
                            dataReader["prenom"].ToString(),
                             dataReader["rue"].ToString(),
                             dataReader["ville"].ToString(),
                             dataReader["codepostal"].ToString(),
                              int.Parse(dataReader["nbrenotes"].ToString()),
                            double.Parse(dataReader["pointsnotes"].ToString()),
                             dataReader["fongecif"].ToString(),
                              dataReader["typecif"].ToString()

                             );

                    laSection.Ajouter(nouveauStagiaire);
                    nouveauStagiaire = null;
                }

            }


            //close Data Reader
            dataReader.Close();

        }

       public static void InsertStagiaireCif(MStagiaireCIF st, MSection sect)
        {
            String type;
            String typecif;
            String fongecif;

            string query = "INSERT INTO mstagiaire(`id`, `id_section`, `nom`, `prenom`, `numosia`, `rue`, `codepostal`, `ville`," +
                "`pointsnotes`, `nbrenotes`, `type`, `typecif`, `fongecif`, `remu_afpa`)" +
                "VALUES(Null,@section, @Nom, @Prenom, @NumOsia, @Rue, @CodePostal, @Ville, @PointsNotes, @NbreNotes, @Type, @TypeCif, @FongeCif, Null)";

            type = "CIF";
            typecif = st.TypeCifStagiaire;
            fongecif = st.FongecifStagiaire;



            MySqlCommand cmd = DBConnect.GetConnexion().CreateCommand();
            cmd.CommandText = query;
            //Execute command
            cmd.Parameters.AddWithValue("@Nom", st.NomStagiaire);
            cmd.Parameters.AddWithValue("@Prenom", st.PrenomStagiaire);
            cmd.Parameters.AddWithValue("@NumOsia", st.NumOsiaStagiaire);
            cmd.Parameters.AddWithValue("@Rue", st.RueStagiaire);
            cmd.Parameters.AddWithValue("@CodePostal", st.CodePostalStagiaire);
            cmd.Parameters.AddWithValue("@Ville", st.VilleStagiaire);
            cmd.Parameters.AddWithValue("@PointsNotes", st.PointsNotes);
            cmd.Parameters.AddWithValue("@NbreNotes", st.NbreNotes);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@TypeCif", typecif);
            cmd.Parameters.AddWithValue("@FongeCif", fongecif);
            cmd.Parameters.AddWithValue("@section", sect.CodeSection);
            cmd.ExecuteNonQuery();

            //close connection

        }
        public static void InsertStagiaireDE(MStagiaireDE st, MSection sect)
        {
            String type;
            Boolean remuafpa;

            string query = "INSERT INTO mstagiaire (`id`, `id_section`, `nom`, `prenom`, `numosia`, `rue`, `codepostal`, `ville`," +
                "`pointsnotes`, `nbrenotes`, `type`, `typecif`, `fongecif`, `remu_afpa`)" +
                "VALUES(Null,@section, @Nom, @Prenom, @NumOsia, @Rue, @CodePostal, @Ville, @PointsNotes, @NbreNotes, @Type, Null, Null, @RemuAfpa)";

            type = "DE";
            remuafpa = st.RemuAfpaStagiaire;



            try
            {

                //create command and assign the query and connection from the constructor
                // MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlCommand cmd = DBConnect.GetConnexion().CreateCommand();
                cmd.CommandText = query;
                //Execute command
                //Execute command
                cmd.Parameters.AddWithValue("@Nom", st.NomStagiaire);
                cmd.Parameters.AddWithValue("@Prenom", st.PrenomStagiaire);
                cmd.Parameters.AddWithValue("@NumOsia", st.NumOsiaStagiaire);
                cmd.Parameters.AddWithValue("@Rue", st.RueStagiaire);
                cmd.Parameters.AddWithValue("@CodePostal", st.CodePostalStagiaire);
                cmd.Parameters.AddWithValue("@Ville", st.VilleStagiaire);
                cmd.Parameters.AddWithValue("@PointsNotes", st.PointsNotes);
                cmd.Parameters.AddWithValue("@NbreNotes", st.NbreNotes);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Remuafpa", remuafpa);
                cmd.Parameters.AddWithValue("@section", sect.CodeSection);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //   MessageBox.Show(ex.Message);

            }
            //close connection



        }


        //Update statement
        public static void UpdateStagiaire(MStagiaire st)
        {
            string query = "UPDATE mstagiaire SET nom=@Nom, prenom=@Prenom,rue= @Rue,codepostal= @CodePostal,ville= @Ville," +
                "pointsnotes=@pointnotes,nbrenotes=@nombrenotes WHERE numosia= @NumOsia";



            //create mysql command
            MySqlCommand cmd = DBConnect.GetConnexion().CreateCommand();
            cmd.CommandText = cmd.CommandText = query;


            cmd.Parameters.AddWithValue("@Nom", st.NomStagiaire);
            cmd.Parameters.AddWithValue("@Prenom", st.PrenomStagiaire);
            cmd.Parameters.AddWithValue("@NumOsia", st.NumOsiaStagiaire);
            cmd.Parameters.AddWithValue("@Rue", st.RueStagiaire);
            cmd.Parameters.AddWithValue("@CodePostal", st.CodePostalStagiaire);
            cmd.Parameters.AddWithValue("@Ville", st.VilleStagiaire);
            cmd.Parameters.AddWithValue("@pointnotes", st.PointsNotes);
            cmd.Parameters.AddWithValue("@nombrenotes", st.NbreNotes);
            //Assign the connection using Connection


            //Execute query
            cmd.ExecuteNonQuery();



        }

        //Delete statement
        public static void DeleteStagiaire(int id)
        {
            string query = "DELETE FROM mstagiaire WHERE numosia=@Numosia";


            MySqlCommand cmd = DBConnect.GetConnexion().CreateCommand();
            cmd.CommandText = query;

            cmd.Parameters.AddWithValue("@Numosia", id);
            cmd.ExecuteNonQuery();


        }


    }
}
