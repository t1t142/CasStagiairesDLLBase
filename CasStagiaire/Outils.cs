using System;
using System.Collections.Generic;
using System.Text;

namespace classesMetierStagiaires
{
    /// <summary>
    /// classe outils pour contr�les de saisie
    /// </summary>
    public class Outils
    {

        /// <summary>
        /// fonction g�n�rique de contr�le qu'une chaine re�ue pourra se convertir en Int32
        /// </summary>
        /// <param name="s">une String � convertir</param>
        /// <returns>Bool�en (vrai = OK, false = erreur)</returns>
        public static Boolean EstEntier(String s)
        {
            /* v�rifier que la chaine re�ue repr�sente bien un entier valide :
             * - uniquement des chiffres
             * - pas vide
             * - pas plus de 9 chiffres (capacit� maxi du type Int32)
             */
            Int32 i;            // indice de parcours de cha�ne
            Char c;             // caract�re courant
            Boolean code = true;   // code retour; OK a priori

            // test longueur cha�ne re�ue
            if (s.Length < 10 && s.Length > 0)
            {
                // v�rifier 1 � 1 que tous les caract�res sont des chiffres
                for (i = 0; i < s.Length; i++)
                {
                    c = s[i]; // extrait le i� car
                    if (!(Char.IsDigit(c))) // si ce n'est pas un chiffre
                    {
                        code = false; // erreur d�tect�e
                    }
                } // fin de boucle for
            }
            else // erreur de longueur de chaine
            {
                code = false; // erreur d�tect�e
            }
            return code;
        }
    }
}
