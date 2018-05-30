using System;
using System.Collections.Generic;
using System.Text;
using System.Data; // ajout� manuellement
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
        /// DataTable � 2 colonnes pour restituer la liste des sections
        /// </summary>
        private DataTable dtSections;

        /// <summary>
        /// constructeur par d�faut
        /// (initialise la collection et le datatable)
        /// </summary>
        public MSections()
        {
            // instancier la collection 
            lesSections = new SortedDictionary<string, MSection>();
            
            // pr�pare la DataTable pour restituer la liste des sections
            dtSections = new DataTable();

            // ajouter � la datatable 2 colonnes personnalis�es 
            this.dtSections.Columns.Add(new DataColumn("Code Section", typeof(System.String)));
            this.dtSections.Columns.Add(new DataColumn("Nom Section", typeof(System.String)));
            this.dtSections.Columns.Add(new DataColumn("Date debut Section", typeof(DateTime)));
            this.dtSections.Columns.Add(new DataColumn("Date fin Section", typeof(DateTime)));
        }
        /// <summary>
        /// ajouter une Section � la collection
        /// (re�oit la ref � la section et en d�duit la cl� (= codesection) pour la collection)
        /// </summary>
        /// <param name="uneSection">la r�f�rence de la section � ajouter</param>
        public void Ajouter(MSection uneSection)
        {
            this.lesSections.Add(uneSection.CodeSection, uneSection); // TODO : � s�curiser...
        }


        /// <summary>
        /// supprimer une section de la collection
        /// (re�oit la ref � la section et en d�duit la cl� (= codesection) pour la collection)
        /// </summary>
        /// <param name="uneSection">la r�f�rence de la section � supprimer</param>
        public void Supprimer(MSection uneSection)
        {
            this.lesSections.Remove(uneSection.CodeSection); // TODO : � s�curiser...
        }

        /// <summary>
        /// supprimer une section de la collection
        /// (re�oit la cl� de la section (= codesection) pour la collection)
        /// </summary>
        /// <param name="unCodeSection">la cl� (= code section) de la section � supprimer</param>
        /// <exception cref="Exception">Si code section re�u non trouv� en collection</exception>
        public void Supprimer(String unCodeSection)
        {
            // suppression s�curis�e
            if (this.lesSections.ContainsKey(unCodeSection))
            {
                this.lesSections.Remove(unCodeSection);
            }
            else
            {
                throw new Exception("Erreur : code Section non trouv� dans la collection");
            }
        }
        /// <summary>
        /// modifier les donn�es d'une section
        /// tout est modifiable sauf le code section (= cl� de la collection)
        /// </summary>
        /// <param name="uneSection">la r�f�rence au nouvel objet MSection pour cette cl�</param>
        public void Remplacer(MSection uneSection)
        {
            // il suffit de modifier la r�f�rence � l'objet MSection
            // dans la collection pour ce code Section
            
            //modifier la r�f�rence de section stock�e dans la collection            
            this.lesSections[uneSection.CodeSection] = uneSection; // TODO : � s�curiser...

        }


        /// <summary>
        /// Rechercher une section dans la liste en connaissant sa cl�
        /// </summary>
        /// <param name="unCodeSection">le code section (=la cl�) de la section � rechercher</param>
        /// <exception cref="Exception">Si code section re�u non trouv� en collection</exception>
        /// <returns>la r�f�rence � la section</returns>
        public MSection RestituerSection(String unCodeSection)
        {
            MSection laSection;
            laSection = this.lesSections[unCodeSection] as MSection;
            if (laSection == null)
            {
                throw new Exception("Aucune section trouv�e pour le code Section " + unCodeSection);
            }
            else
            {
                return laSection;
            }
        }


        /// <summary>
        /// g�n�rer et retourner une datatable
        /// qui liste les codeSection et nomSection
        /// de toutes les sections de la collection
        /// </summary>
        /// <returns>une r�f�rence de datatable � 2 colonnes</returns>
        public DataTable ListerSections()
        {
            DataRow dr;   // ligne de la datatable
            // vider la datatable pour la r�g�n�rer
            this.dtSections.Clear();
            // boucle de remplissage de la datatable � partir de la collection
            foreach (MSection uneSection in this.lesSections.Values)
            {
                // instanciation datarow (=ligne)
                dr = this.dtSections.NewRow();
                // affectation des 2 colonnes
                // r�cup�rer le valeur de cl�
                dr[0] = uneSection.CodeSection;
                // affecter l'autre colonne des valeurs de prop. de l'objet MSection
                dr[1] = uneSection.NomSection;
                dr[2] = uneSection.DebutFormation;
                dr[3] = uneSection.FinFormation;

                // ajouter la ligne � la datatable
                this.dtSections.Rows.Add(dr);
            } // fin boucle remplissage datatable
            // retourne la r�f�rence � la datatable
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

                    // ajout de la nouvelle � la liste des sections

                    sections.Ajouter(nvlsection);
                    nvlsection = null;
                }
                else
                {
                    MSection nvlsection = new MSection(
                    dataReader["code"].ToString(),
                    dataReader["nom"].ToString(),
                    int.Parse(dataReader["id_section"].ToString()));
                    // ajout de la nouvelle � la liste des sections

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


