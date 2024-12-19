using System;
using static projet1.personne;

internal static class GestionPersonnesHelpers
{
    public static void Menu()
    {
        IpersonneImpl gestion = new IpersonneImpl();
        int choix;
        do
        {
            Console.WriteLine("bienvenue");
            Console.WriteLine("1 : Ajouter une personne");
            Console.WriteLine("2 : Afficher toutes les personnes.");
            Console.WriteLine("3 : Afficher tous les enseignants");
            Console.WriteLine("4 : Afficher tous les étudiants.");
            Console.WriteLine("5 : Quitter.");
            choix = int.Parse(Console.ReadLine());
            switch (choix)
            {
                case 1:
                    Console.WriteLine("ajouter le personne");
                    Console.WriteLine("1.Enseignant");
                    Console.WriteLine("2.etudiant");
                    int type = int.Parse((string)Console.ReadLine());
                    Console.WriteLine("nom");
                    string nom = Console.ReadLine();
                    Console.WriteLine("prenom");
                    String prenom = Console.ReadLine();
                    if (type == 1)
                    {
                        Console.WriteLine("enseignant:");
                        String matier = Console.ReadLine();
                        gestion.ajouterPersonne(new Enseignant(nom, prenom, matier));
                    }
                    else if (type == 2)
                    {
                        String nouveauetu = Console.ReadLine();
                        gestion.ajouterPersonne(new Etudiant(nom, prenom, nouveauetu));
                    }
                    break;
                case 2:
                    Console.WriteLine("afficher les personne");
                    gestion.afficherPersonnes();
                    break;
                case 3:
                    Console.WriteLine("afficher les enseignant");
                    gestion.afficherEnseignants();
                    break;
                case 4:
                    Console.WriteLine(" etudiant");
                    gestion.afficherEtudiants();
                    break;
                case 5:
                    Console.WriteLine("quitter");
                    break;
                default:
                    Console.WriteLine("pas de choix");
                    break;

            }


        } while (choix != 5);

    }
}