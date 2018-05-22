using System;
using System.Collections.Generic;
using System.Text;
using System.Data; // ajout� manuellement

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
                // ajouter la ligne � la datatable
                this.dtSections.Rows.Add(dr);
            } // fin boucle remplissage datatable
            // retourne la r�f�rence � la datatable
            return this.dtSections;
        }

    }
}
