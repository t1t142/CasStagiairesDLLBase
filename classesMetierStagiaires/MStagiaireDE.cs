using System;
using System.Collections.Generic;
using System.Text;

namespace classesMetierStagiaires
{
    /// <summary>
    /// stagiaire sp�cialis� statut Demandeur d'emploi
    /// </summary>
    public class MStagiaireDE : MStagiaire
    {

        /// <summary>
        /// constructeur d'initialisation
        /// (appelle le constructeur d'initialisation de la classe de base)
        /// </summary>
        /// <param name="unNumosia">num�ro OSIA</param>
        /// <param name="unNom">Nom</param>
        /// <param name="unPrenom">Pr�nom</param>
        /// <param name="uneRue">Adresse</param>
        /// <param name="uneVille">Ville</param>
        /// <param name="UnCodePostal">Code Postal</param>
        /// <param name="unRemuAfpa">R�munaration par l'Afpa</param>
        public MStagiaireDE(Int32 unNumosia, String unNom, String unPrenom, String uneRue, String uneVille, String UnCodePostal,
            Boolean unRemuAfpa)
            : base( unNumosia,  unNom,  unPrenom,  uneRue,  uneVille,  UnCodePostal)
        {
            this.RemuAfpaStagiaire = unRemuAfpa;
        }

        /// <summary>
        /// R�muneration par l'Afpa
        /// </summary>
        private Boolean remuAfpaStagiaire;

        /// <summary>
        /// obtient ou d�finit R�mun�ration par l'Afpa
        /// </summary>
        public Boolean RemuAfpaStagiaire
        {
            get
            {
                return this.remuAfpaStagiaire;
            }
            set
            {
                this.remuAfpaStagiaire = value;
            }
        }

    }
}
