using System;
using System.Collections.Generic;
using System.Text;
using System.Data; // ajouté manuellement
using MySql.Data.MySqlClient;
using System.Globalization;

namespace classesMetierStagiaires
{
    public class MSections
    {
        /// <summary>
        /// collection des objets MSection
        /// </summary>
        private SortedDictionary<String , MSection> lesSections;

        /// <summary>
        /// DataTable à 2 colonnes pour restituer la liste des sections
        /// </summary>
        private DataTable dtSections;

        /// <summary>
        /// constructeur par défaut
        /// (initialise la collection et le datatable)
        /// </summary>
        public MSections()
        {
            // instancier la collection 
            lesSections = new SortedDictionary<string, MSection>();
            
            // prépare la DataTable pour restituer la liste des sections
            dtSections = new DataTable();

            // ajouter à la datatable 2 colonnes personnalisées 
            this.dtSections.Columns.Add(new DataColumn("Code Section", typeof(System.String)));
            this.dtSections.Columns.Add(new DataColumn("Nom Section", typeof(System.String)));
            this.dtSections.Columns.Add(new DataColumn("Date debut Section", typeof(DateTime)));
            this.dtSections.Columns.Add(new DataColumn("Date fin Section", typeof(DateTime)));
        }
        /// <summary>
        /// ajouter une Section à la collection
        /// (reçoit la ref à la section et en déduit la clé (= codesection) pour la collection)
        /// </summary>
        /// <param name="uneSection">la référence de la section à ajouter</param>
        public void Ajouter(MSection uneSection)
        {
            this.lesSections.Add(uneSection.CodeSection, uneSection); // TODO : à sécuriser...
        }


        /// <summary>
        /// supprimer une section de la collection
        /// (reçoit la ref à la section et en déduit la clé (= codesection) pour la collection)
        /// </summary>
        /// <param name="uneSection">la référence de la section à supprimer</param>
        public void Supprimer(MSection uneSection)
        {
            this.lesSections.Remove(uneSection.CodeSection); // TODO : à sécuriser...
        }

        /// <summary>
        /// supprimer une section de la collection
        /// (reçoit la clé de la section (= codesection) pour la collection)
        /// </summary>
        /// <param name="unCodeSection">la clé (= code section) de la section à supprimer</param>
        /// <exception cref="Exception">Si code section reçu non trouvé en collection</exception>
        public void Supprimer(String unCodeSection)
        {
            // suppression sécurisée
            if (this.lesSections.ContainsKey(unCodeSection))
            {
                this.lesSections.Remove(unCodeSection);
            }
            else
            {
                throw new Exception("Erreur : code Section non trouvé dans la collection");
            }
        }
        /// <summary>
        /// modifier les données d'une section
        /// tout est modifiable sauf le code section (= clé de la collection)
        /// </summary>
        /// <param name="uneSection">la référence au nouvel objet MSection pour cette clé</param>
        public void Remplacer(MSection uneSection)
        {
            // il suffit de modifier la référence à l'objet MSection
            // dans la collection pour ce code Section
            
            //modifier la référence de section stockée dans la collection            
            this.lesSections[uneSection.CodeSection] = uneSection; // TODO : à sécuriser...

        }


        /// <summary>
        /// Rechercher une section dans la liste en connaissant sa clé
        /// </summary>
        /// <param name="unCodeSection">le code section (=la clé) de la section à rechercher</param>
        /// <exception cref="Exception">Si code section reçu non trouvé en collection</exception>
        /// <returns>la référence à la section</returns>
        public MSection RestituerSection(String unCodeSection)
        {
            MSection laSection;
            laSection = this.lesSections[unCodeSection] as MSection;
            if (laSection == null)
            {
                throw new Exception("Aucune section trouvée pour le code Section " + unCodeSection);
            }
            else
            {
                return laSection;
            }
        }


        /// <summary>
        /// générer et retourner une datatable
        /// qui liste les codeSection et nomSection
        /// de toutes les sections de la collection
        /// </summary>
        /// <returns>une référence de datatable à 2 colonnes</returns>
        public DataTable ListerSections()
        {
            DataRow dr;   // ligne de la datatable
            // vider la datatable pour la régénérer
            this.dtSections.Clear();
            // boucle de remplissage de la datatable à partir de la collection
            foreach (MSection uneSection in this.lesSections.Values)
            {
                // instanciation datarow (=ligne)
                dr = this.dtSections.NewRow();
                // affectation des 2 colonnes
                // récupérer le valeur de clé
                dr[0] = uneSection.CodeSection;
                // affecter l'autre colonne des valeurs de prop. de l'objet MSection
                dr[1] = uneSection.NomSection;
                dr[2] = uneSection.DebutFormation;
                dr[3] = uneSection.FinFormation;

                // ajouter la ligne à la datatable
                this.dtSections.Rows.Add(dr);
            } // fin boucle remplissage datatable
            // retourne la référence à la datatable
            return this.dtSections;
        }


        //-------------------Test ajout nouvelles classes
        public static void SelectSection(MSections sections)
        {
            string query = "SELECT * FROM msections";
            sections.SupprimerSections();

            MySqlCommand cmd = DBConnect.GetConnexion().CreateCommand();
            cmd.CommandText = query;


            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                Boolean afpa = false;
                //MStagiaire nouveauStagiaire;
                Console.WriteLine(dataReader["debut_formation"].ToString());
                Console.Read();

                if (dataReader["debut_formation"].ToString() != "")
                {

                    MSection nvlsection = new MSection(
                    dataReader["code"].ToString(),
                    dataReader["nom"].ToString(),
                    DateTime.ParseExact(dataReader["debut_formation"].ToString(), "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture),
                    DateTime.ParseExact(dataReader["date_fin"].ToString(), "dd/MM/yyyy hh:mm:ss", CultureInfo.InvariantCulture),
                    int.Parse(dataReader["id_section"].ToString()));

                    // ajout de la nouvelle à la liste des sections

                    sections.Ajouter(nvlsection);
                    nvlsection = null;
                }
                else
                {
                    MSection nvlsection = new MSection(
                    dataReader["code"].ToString(),
                    dataReader["nom"].ToString(),
                    int.Parse(dataReader["id_section"].ToString()));
                    // ajout de la nouvelle à la liste des sections

                    sections.Ajouter(nvlsection);
                    nvlsection = null;
                }
            }

            //close Data Reader
            dataReader.Close();

        }
        /*
        public static void InsertStagiaireCif(MStagiaireCIF st)
        {
            String type;
            String typecif;
            String fongecif;

            string query = "INSERT INTO mstagiaire(`id`, `id_section`, `nom`, `prenom`, `numosia`, `rue`, `codepostal`,
			`ville`, `pointsnotes`, `nbrenotes`, `type`, `typecif`, `fongecif`, `remu_afpa`)  VALUES(Null, @section,
            @Nom, @Prenom, @NumOsia, @Rue, @CodePostal, @Ville, @PointsNotes, @NbreNotes, @Type, @TypeCif, @FongeCif, Null)";
    
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
            cmd.Parameters.AddWithValue("@section", 1);
            cmd.ExecuteNonQuery();

            //close connection

        }
        public static void InsertStagiaireDE(MStagiaireDE st)
        {
            String type;
            Boolean remuafpa;

            string query = "INSERT INTO mstagiaire (`id`, `id_section`, `nom`, `prenom`, `numosia`,
			`rue`, `codepostal`, `ville`, `pointsnotes`, `nbrenotes`, `type`, `typecif`, `fongecif`,
			`remu_afpa`) VALUES(Null, @section, @Nom, @Prenom, @NumOsia, @Rue, @CodePostal, @Ville, @PointsNotes,
            @NbreNotes, @Type, Null, Null, @RemuAfpa)";
    
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
                cmd.Parameters.AddWithValue("@section", 1);
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
            string query = "UPDATE mstagiaire SET nom=@Nom, prenom=@Prenom,rue= @Rue,
    
            codepostal = @CodePostal,ville = @Ville,pointsnotes = @pointnotes,nbrenotes = @nombrenotes WHERE numosia = @NumOsia";
    


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
        */

        /// <summary>
        /// supprime toutes les sections
        /// </summary>
        public void SupprimerSections()
        {
            lesSections.Clear();
        }
        


    }
    
}


