using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    class personne
    {
        public String nom { get; set; }
        public String prenom { get; set; }
        public personne(String nom, String prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }
        public virtual void AfficheDetail()
        {
            Console.WriteLine($"nom:{nom},prenom:{prenom}");

        }
        class Enseignant : personne
        {
            public String matier { get; set; }
            public Enseignant(string nom, string prenom, string matier) : base(nom, prenom)
            {
                matier = matier.ToLower();
            }
            public override void AfficheDetail()
            {
                Console.WriteLine($"nom:{nom},prenom:{prenom}, matier:{matier}");
            }


        }
        class Etudiant : personne
        {
            public string nouveauetu { get; set; }
            public Etudiant(string nom, string prenom, string nouveauetu) : base(nom, prenom)
            {
                this.nouveauetu = nouveauetu;
            }
            public override void AfficheDetail()
            {
                Console.WriteLine($"nom:{nom},prenom:{prenom}, nouveauetu:{nouveauetu}");
            }
        }
        interface IPersonne
        {
            void ajouterPersonne(personne personne);
            void afficherPersonnes();
            void afficherEnseignants();
            void afficherEtudiants();
        }
        public class IpersonneImpl : IPersonne
        {
            private List<personne> personneList = new List<personne>();
            public void ajouterPersonne(personne personne)
            {
                personneList.Add(personne);
                Console.WriteLine("personne bien ajouter");
            }
            public void afficherPersonnes()
            {
                foreach (personne personne in personneList)
                {
                    personne.AfficheDetail();
                    
                }
            }
            public void afficherEnseignants()
            {
                foreach (personne personne in personneList)
                {
                    if (personne is Enseignant enseignant)
                    {
                        enseignant.AfficheDetail();
                    }
                }
            }
            public void afficherEtudiants()
            {
                foreach (personne personne in personneList)
                {
                    if (personne is Etudiant etudiant)
                    {
                        etudiant.AfficheDetail();
                    }
                }
            }

            internal void ajouterPersonne(global::Enseignant enseignant)
            {
                throw new NotImplementedException();
            }

            internal void ajouterPersonne(global::Etudiant etudiant)
            {
                throw new NotImplementedException();
            }
        }

        public class GestionPersonnes 
        { 
              public  static void Menu()
              {
                IpersonneImpl gestion = new IpersonneImpl();
                int choix;
                do
                {
                    Console.WriteLine("*****bienvenue*******");
                    Console.WriteLine("1 : **Ajouter une personne**");
                    Console.WriteLine("2 : **Afficher toutes les personnes**");
                    Console.WriteLine("3 : **Afficher tous les enseignants**");
                    Console.WriteLine("4 : **Afficher tous les étudiants**");
                    Console.WriteLine("5 : **Quitter.**");
                   choix = int.Parse(Console.ReadLine());
                    switch (choix) {
                        
                            case 1:

                                
                            Console.WriteLine("ajouter une  personne");
                            Console.WriteLine("1.**Enseignant**");
                            Console.WriteLine("2.**Etudiant**");
                            


                            int type;
                            bool valide = false;

                            
                            do
                            {
                                string input = Console.ReadLine();

                                
                                if (int.TryParse(input, out type) && (type == 1 || type == 2))
                                {
                                    valide = true; 
                                }
                                else
                                {
                                    
                                    Console.WriteLine("Entrée invalide. Veuillez saisir 1 pour Enseignant ou 2 pour Étudiant.");
                                }
                            } while (!valide);
                            Console.WriteLine("nom");
                            string nom = Console.ReadLine();
                            Console.WriteLine("prenom");
                            String prenom = Console.ReadLine();
                            if (type == 1)
                            {
                                Console.WriteLine("enseignant:");
                                String matier = Console.ReadLine();
                                gestion.ajouterPersonne(new Enseignant(nom, prenom,matier));
                            }else if (type == 2)
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
                    
                   
                } while (choix!=5);
           
            }
            class Program
            {
                static void Main(string[] args)
                {
                   GestionPersonnes.Menu();
                }
            }
        }
    }
    

}

