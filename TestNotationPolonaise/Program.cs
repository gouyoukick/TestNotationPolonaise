/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Procédure de décalage des éléments d'un tableau de 2 cases vers la gauche.
        /// </summary>
        /// <param name="tab">tableau à décaler</param>
        /// <param name="position">position de début de décalage</param>
        static void Decalage(string[] tab, int position )
        {
            for (int l = position; l < (tab.Length - 3); l++)
            {
                tab[l + 1] = tab[l + 3];
            }
            tab[tab.Length - 5] = "";
            tab[tab.Length - 4] = "";
        }
        
        /// <summary>
        /// Calcul avec formulation Polonaise pour les opérations +, -, / et *
        /// </summary>
        /// <param name="formule">la formule Polonaise à calculer</param>
        /// <returns></returns>
        static string Polonaise(String formule)
        {
            //detection erreur de saisie
            try
            {
                //découpage de la formule et remplissage du tableau
                string[] tab = (formule + "   ").Split(' ');
                //Lecture du tableau en partant de la fin
                for (int k = (tab.Length - 4); k > -1; k--)
                {
                    switch (tab[k])
                    {
                        //addition
                        case "+":
                            tab[k] = (float.Parse(tab[k + 1]) + float.Parse(tab[k + 2])).ToString();
                            Decalage(tab, k);
                            break;
                        //soustraction
                        case "-":
                            tab[k] = (float.Parse(tab[k + 1]) - float.Parse(tab[k + 2])).ToString();
                            Decalage(tab, k);
                            break;
                        //Multiplication
                        case "*":
                            tab[k] = (float.Parse(tab[k + 1]) * float.Parse(tab[k + 2])).ToString();
                            Decalage(tab, k);
                            break;
                        //Division
                        case "/":
                            if(float.Parse(tab[k + 2]) != 0)
                            {
                                tab[k] = (float.Parse(tab[k + 1]) / float.Parse(tab[k + 2])).ToString();
                                Decalage(tab, k);
                            }
                            //Arret si Division par O
                            else
                            {
                                return "NaN";
                            }
                            break;
                    }
                }
                //Arret si tous les chiffres ne sont pas consommés
                if (tab[1] != "")
                {
                    return "NaN";
                }
                else
                {
                    return tab[0];
                }
            }
            catch
            {
                return "NaN";
            }

        }
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
