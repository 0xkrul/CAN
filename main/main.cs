using System;
using System.IO;
using System.Collections.Generic;

class SAE11
{
    struct Reservation
    {
        public string nom;
        public int idLiaison;
        public string date;
        public string heure;
        public string horodatage;

        public Reservation(string nm, int idls, string dt, string hr, string hrdtg)
        {
            nom = nm;
            idLiaison = idls;
            date = dt;
            heure = hr;
            horodatage = hrdtg;
        }
    }

    struct Passager
    {
        public string nom;
        public string prenom;
        public string codeCategorie;

        public Passager(string nm, string pn, string cdCat)
        {
            nom = nm;
            prenom = pn;
            codeCategorie = cdCat;
        }
    }

    
    struct Vehicule
    {
        public string codeCategorie;
        public int quantité;

        public Vehicule(string cdCat, int qte)
        {

            codeCategorie = cdCat;
            quantité = qte;
        }
    }
    
    static void Main()
    {
        int choix, id = 0; string liaison;
        int jours;
        string horaire = "";
        Dictionary<int, List<string>> horaireLorientGroix, horaireGroixLorient, horaireQuiberonLePalais, horaireLePalaisQuiberon;
        string nomReservation;
        string horodatage;
        string date = " ";;
        List<Reservation> listeReservations = new List<Reservation>();
        Reservation reserv;
        Dictionary<string, string> categVehicule;
        categVehicule = new Dictionary<string, string>
            {
                { "Trottinette électrique", "trot" },
                { "Vélo ou remorque à vélo", "velo" },
                { "Vélo électrique", "velelec" },
                { "Vélo cargo ou tandem", "cartand" },
                { "Deux-roues <= 125 cm3", "mobil" },
                { "Deux-roues > 125 cm3", "moto" },
                { "Voiture moins de 4 m", "cat1" },
                { "Voiture de 4 m à 4.39 m", "cat2" },
                { "Voiture de 4.40 m à 4.79 m", "cat3" },
                { "Voiture 4.80 m et plus", "cat4" },
                { "Camping-car - véhicule plus de 2.10 m de haut", "camp" }
            };
        

        horaireLorientGroix = new Dictionary<int, List<string>>
        {
            { 1, new() { "09:45", "12:15", "17:00", "19:30" } },
            { 2, new() { "09:45", "12:15", "17:00", "19:30" } },
            { 3, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 4, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 5, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 6, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 7, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 8, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 9, new() { "09:45", "12:15", "17:00", "19:30" } },
            { 10, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 11, new() { "09:45", "12:15", "17:00", "19:30" } },
            { 12, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 13, new() { "08:05", "11:00", "13:45", "18:45" } }, 
            { 14, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 15, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 16, new() { "09:45", "12:15", "17:00", "19:30" } },
            { 17, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 18, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 19, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 20, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 21, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 22, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 23, new() { "09:45", "12:15", "17:00", "19:30" } },
            { 24, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 25, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 26, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 27, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 28, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 29, new() { "08:05", "11:00", "13:45", "16:15", "18:45" } },
            { 30, new() { "09:45", "12:15", "17:00", "19:30" } }
        };

        horaireGroixLorient = new Dictionary<int, List<string>>
        {
            { 1, new List<string>() { "08:30", "11:00", "15:45", "18:15" } },
            { 2, new List<string>() { "08:30", "11:00", "15:45", "18:15" } },
            { 3, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 4, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 5, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 6, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 7, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 8, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 9, new List<string>() { "08:30", "11:00", "15:45", "18:15" } },
            { 10, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 11, new List<string>() { "08:30", "11:00", "15:45", "18:15" } },
            { 12, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 13, new List<string>() { "06:50", "12:30", "15:00", "17:30" } },
            { 14, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 15, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 16, new List<string>() { "08:30", "11:00", "15:45", "18:15" } },
            { 17, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 18, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 19, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 20, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 21, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 22, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 23, new List<string>() { "08:30", "11:00", "15:45", "18:15" } },
            { 24, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 25, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 26, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 27, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 28, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 29, new List<string>() { "06:50", "09:30", "12:30", "15:00", "17:30" } },
            { 30, new List<string>() { "08:30", "11:00", "15:45", "18:15" } }
        };

        horaireQuiberonLePalais = new Dictionary<int, List<string>>
        {
            { 1, new List<string>() { "08:15", "09:30", "11:15", "12:45", "14:45", "17:15", "19:00", "20:00" } },
            { 2, new List<string>() { "08:00", "09:30", "11:15", "12:30", "14:15", "15:45", "17:15", "19:00" } },
            { 3, new List<string>() { "08:00", "09:30", "11:15", "14:30", "17:30", "19:30" } },
            { 4, new List<string>() { "07:30", "09:30", "10:30", "13:30", "18:15", "19:30" } },
            { 5, new List<string>() { "08:00", "10:30", "12:00", "17:15", "19:00", "20:00" } },
            { 6, new List<string>() { "07:30", "08:30", "11:45", "14:45", "18:15", "20:45" } },
            { 7, new List<string>() { "08:00", "09:30", "12:30", "15:30", "18:15", "20:00" } },
            { 8, new List<string>() { "08:15", "09:45", "11:00", "14:15", "17:15", "19:30" } },
            { 9, new List<string>() { "08:30", "11:15", "14:15", "16:15", "17:30", "19:30" } },
            { 10, new List<string>() { "08:00", "09:30", "11:15", "14:15", "17:30", "19:30" } },
            { 11, new List<string>() { "08:15", "11:15", "14:15", "16:15", "17:30", "19:30" } },
            { 12, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 13, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 14, new List<string>() { "08:00", "09:30", "11:15", "14:15", "17:15", "19:15", "20:15" } },
            { 15, new List<string>() { "08:00", "09:30", "11:15", "14:15", "17:30", "19:30" } },
            { 16, new List<string>() { "08:15", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 17, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 18, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 19, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 20, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:15" } },
            { 21, new List<string>() { "08:00", "09:30", "11:15", "14:15", "17:15", "19:15", "20:15" } },
            { 22, new List<string>() { "08:00", "09:30", "11:15", "14:15", "17:30", "19:30" } },
            { 23, new List<string>() { "08:15", "11:15", "14:15", "16:15", "17:15", "19:30" } },
            { 24, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 25, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 26, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 27, new List<string>() { "08:00", "09:30", "11:15", "14:15", "16:15", "17:15", "20:00" } },
            { 28, new List<string>() { "08:00", "09:30", "11:15", "14:15", "17:15", "19:15", "20:15" } },
            { 29, new List<string>() { "08:00", "09:30", "11:15", "14:15", "17:30", "19:30" } },
            { 30, new List<string>() { "08:15", "11:15", "14:15", "16:15", "17:30", "19:30" } }
        };

        horaireLePalaisQuiberon = new Dictionary<int, List<string>>
        {
            { 1, new List<string>() { "06:45", "07:45", "09:45", "11:00", "12:45", "14:45", "17:30", "18:45" } },
            { 2, new List<string>() { "06:30", "07:45", "09:45", "11:00", "12:45", "14:15", "15:45", "17:15", "18:40" } },
            { 3, new List<string>() { "06:30", "07:45", "09:45", "12:45", "16:00", "18:00" } },
            { 4, new List<string>() { "06:00", "07:45", "09:00", "12:00", "16:45", "18:00" } },
            { 5, new List<string>() { "06:30", "07:45", "10:30", "13:30", "17:30", "18:30" } },
            { 6, new List<string>() { "06:00", "07:00", "09:00", "13:15", "16:15", "18:30" } },
            { 7, new List<string>() { "06:30", "07:45", "09:45", "14:00", "16:45", "18:45" } },
            { 8, new List<string>() { "07:00", "08:00", "09:45", "12:45", "15:45", "17:45" } },
            { 9, new List<string>() { "07:15", "09:45", "12:45", "14:45", "15:45", "18:00" } },
            { 10, new List<string>() { "06:30", "07:45", "09:45", "12:45", "15:45", "18:00" } },
            { 11, new List<string>() { "07:00", "09:45", "12:45", "14:45", "15:45", "18:00" } },
            { 12, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 13, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 14, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "17:45", "18:45" } },
            { 15, new List<string>() { "06:30", "07:45", "09:45", "12:45", "15:45", "18:00" } },
            { 16, new List<string>() { "07:00", "09:45", "12:45", "14:45", "15:45", "18:00" } },
            { 17, new List<string>() { "06:30", "07:45", "09:45", "12:45", "15:45", "18:30" } },
            { 18, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 19, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 20, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 21, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:45" } },
            { 22, new List<string>() { "06:30", "07:45", "09:45", "12:45", "15:45", "18:00" } },
            { 23, new List<string>() { "07:00", "09:45", "12:45", "14:45", "15:45", "18:00" } },
            { 24, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 25, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 26, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 27, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:30" } },
            { 28, new List<string>() { "06:30", "07:45", "09:45", "12:45", "15:45", "18:45" } },
            { 29, new List<string>() { "06:30", "07:45", "09:45", "12:45", "14:45", "15:45", "18:00" } },
            { 30, new List<string>() { "07:00", "09:45", "12:45", "14:45", "15:45", "18:00" } }
        };

        //DEMANDE SI ALLER-RETOUR
        Console.WriteLine("Souhaitez-vous réserver un aller-retour ?");
        Console.WriteLine("1 - Aller simple");
        Console.WriteLine("2 - Aller-retour");
        int typeReservation;
        do
        {
            Console.Write("Votre choix : ");
            typeReservation = int.Parse(Console.ReadLine());
            if (typeReservation < 1 || typeReservation > 2)
            {
                Console.WriteLine("Choix invalide, veuillez réessayer.");
            }
        } while (typeReservation < 1 || typeReservation > 2);

        int nombreTraversees = (typeReservation == 2) ? 2 : 1;

        //BOUCLE POUR ALLER ET/OU RETOUR
        for(int traversee = 0; traversee < nombreTraversees; traversee++)
        {
            if(traversee == 0)
            {
                Console.WriteLine("\n=== RÉSERVATION ALLER ===");
            }
            else
            {
                Console.WriteLine("\n=== RÉSERVATION RETOUR ===");
            }

        //AFFICHAGE DES ITINÉRAIRES
        Console.WriteLine("\n=== Choisissez un itinéraire ===");
        Console.WriteLine("1 - Lorient → Groix");
        Console.WriteLine("2 - Groix → Lorient");
        Console.WriteLine("3 - Quiberon → Le Palais");
        Console.WriteLine("4 - Le Palais → Quiberon");
        Console.WriteLine();
        
        //choix du code de l'itinéraire (1 à 4)
        do
        {
            Console.Write("Choisissez le numéro de votre itinéraire : ");
            choix = int.Parse(Console.ReadLine());
            if (choix < 1 || choix > 4)
            {
                Console.WriteLine("Choix invalide, veuillez réessayer.");
            }
        } while (choix < 1 || choix > 4);

        //Selectionner l'heure et la date en fonction du choix
        switch(choix)
        {
            case 1:
            
                Console.WriteLine("Vous avez choisi : Lorient → Groix");
                liaison = "Lorient-Groix";
                id = 1;
                foreach(int jour in horaireLorientGroix.Keys)
                {
                    Console.WriteLine();
                    Console.WriteLine("novembre " +jour + "  ");
                    Console.Write("Horaires : ");
                    foreach(string heure in horaireLorientGroix[jour])
                    {
                        Console.Write(heure + " ");
                    }
                    Console.WriteLine();
                    
                }
                Console.Write("Choisissez un jour(1-30)  : ");
                jours = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Choisissez un horaire (HH:mm) : ");
                horaire = Console.ReadLine();

                //si la date et l'heure ne sont pas dans le dictionnaire
                while(!horaireLorientGroix.ContainsKey(jours) || !horaireLorientGroix[jours].Contains(horaire))
                {
                    Console.WriteLine("Horaire ou date invalide, veuillez réessayer.");
                    Console.Write("Choisissez un jour : ");
                    jours = int.Parse(Console.ReadLine());
                    Console.Write("Choisissez un horaire : ");
                    horaire = Console.ReadLine();
                }
                //mettre la date au format AAAA-MM-JJ
                date = "2025-11-" + jours.ToString();
                break;

            case 2:
                Console.WriteLine("Vous avez choisi : Groix → Lorient");
                liaison = "Groix-Lorient";
                id = 2;
                foreach(int jour in horaireGroixLorient.Keys)
                {
                    Console.WriteLine();
                    Console.WriteLine("novembre " +jour + "  ");
                    Console.Write("Horaires : ");
                    foreach(string heure in horaireGroixLorient[jour])
                    {
                        Console.Write(heure + " ");
                    }
                    Console.WriteLine();
                    
                }
                Console.Write("Choisissez un jour (1-30) : ");
                jours = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Choisissez un horaire (HH:mm) : ");
                horaire = Console.ReadLine();

                //si la date et l'heure ne sont pas dans le dictionnaire
                while(!horaireGroixLorient.ContainsKey(jours) || !horaireGroixLorient[jours].Contains(horaire))
                {
                    Console.WriteLine("Horaire ou date invalide, veuillez réessayer.");
                    Console.Write("Choisissez un jour (1-30) : ");
                    jours = int.Parse(Console.ReadLine());
                    Console.Write("Choisissez un horaire (HH:mm) : ");
                    horaire = Console.ReadLine();
                }
                date = "2025-11-" + jours.ToString();

                break;

            case 3:
                Console.WriteLine("Vous avez choisi : Quiberon → Le Palais");
                liaison = "Quiberon-Le Palais";
                id = 3;
                foreach(int jour in horaireQuiberonLePalais.Keys)
                {
                    Console.WriteLine();
                    Console.WriteLine("novembre " +jour + "  ");
                    Console.Write("Horaires : ");
                    foreach(string heure in horaireQuiberonLePalais[jour])
                    {
                        Console.Write(heure + " ");
                    }
                    Console.WriteLine();
                    
                }
                Console.Write("Choisissez un jour (1-30): ");
                jours = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Choisissez un horaire (HH:mm): ");
                horaire = Console.ReadLine();

                //si la date et l'heure ne sont pas dans le dictionnaire
                while(!horaireQuiberonLePalais.ContainsKey(jours) || !horaireQuiberonLePalais[jours].Contains(horaire))
                {
                    Console.WriteLine("Horaire ou date invalide, veuillez réessayer.");
                    Console.Write("Choisissez un jour (1-30): ");
                    jours = int.Parse(Console.ReadLine());
                    Console.Write("Choisissez un horaire (HH:mm): ");
                    horaire = Console.ReadLine();
                }
                date = "2025-11-" + jours.ToString();

                break;

            case 4:
                Console.WriteLine("Vous avez choisi : Le Palais → Quiberon");
                liaison = "Le Palais-Quiberon";
                id = 4;
                foreach(int jour in horaireLePalaisQuiberon.Keys)
                {
                    Console.WriteLine();
                    Console.WriteLine("novembre " +jour + "  ");
                    Console.Write("Horaires : ");
                    foreach(string heure in horaireLePalaisQuiberon[jour])
                    {
                        Console.Write(heure + " ");
                    }
                    Console.WriteLine();
                    
                }
                Console.Write("Choisissez un jour (1-30): ");
                jours = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Choisissez un horaire (HH:mm): ");
                horaire = Console.ReadLine();

                //si la date et l'heure ne sont pas dans le dictionnaire continuer à demander une saisie valide
                while(!horaireLePalaisQuiberon.ContainsKey(jours) || !horaireLePalaisQuiberon[jours].Contains(horaire))
                {
                    Console.WriteLine("Horaire ou date invalide, veuillez réessayer.");
                    Console.Write("Choisissez un jour (1-30): ");
                    jours = int.Parse(Console.ReadLine());
                    Console.Write("Choisissez un horaire (HH:mm): ");
                    horaire = Console.ReadLine();
                }
                date = "2025-11-" + jours.ToString();
                break;
            default:
                Console.WriteLine("Choix invalide !");
                break;
        }

        //Création de l'objet Reservation pour cette traversée
        horodatage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        reserv = new Reservation("",id,date,horaire,horodatage);
        listeReservations.Add(reserv);

        } // FIN DE LA BOUCLE POUR ALLER ET/OU RETOUR

        //COLLECTE DES PASSAGERS ET VÉHICULES (UNE SEULE FOIS POUR ALLER-RETOUR)
        List<Passager> listePassagers = new List<Passager>();
        List<Vehicule> listeVehicules = new List<Vehicule>();

        Console.WriteLine("\n=== INFORMATIONS PASSAGERS ET VÉHICULES ===");
        Console.WriteLine("Combien de Passagers souhaitez-vous transporter (vous inclus) ?");
        int nombrePassagers = int.Parse(Console.ReadLine());
        

        //SI LE NOMBRE DE PASSAGERS EST SUPÉRIEUR À 0 SINON PASSER CETTE ÉTAPE
        string codePassager = "";

        if(nombrePassagers > 0)
        {
            for(int i = 0; i<nombrePassagers; i++)
            {
                Console.WriteLine("Passager n°" + (i+1) + " : ");
                Console.Write("Nom : ");
                string nomPassager = Console.ReadLine();
                Console.Write("Prénom : ");
                string prenomPassager = Console.ReadLine();
                Console.Write("Âge : ");
                int agePassager = int.Parse(Console.ReadLine());
                
                //Chercher le code du passager en fonction de son âge
                
                if(agePassager < 4)
                {
                    codePassager = "bebe";
                }
                else if(agePassager<=17)
                {
                    codePassager = "enf417";
                }
                else if(agePassager<=25)
                {
                    codePassager = "jeu1825";
                }
                else if(agePassager>=26)
                {
                    codePassager = "adu26p";
                }
                

                //Création de l'objet Passager
                Passager passager = new Passager(nomPassager, prenomPassager, codePassager);
                listePassagers.Add(passager);
            }
            Console.WriteLine(nombrePassagers + " passagers seront ajoutés à votre réservation.");
        }
        else 
        {
            Console.WriteLine("Aucun passager réservé.");
        }

        //Verification si il y a des animaux de compagnie
        Console.WriteLine("Combien d'animaux de compagnie souhaitez-vous transporter ?");
        int nombreAnimaux = int.Parse(Console.ReadLine());
        for(int i = 0; i<nombreAnimaux; i++)
        {
            Console.WriteLine("Animal n°" + (i+1) + " : ");
        
            
            Console.Write("Nom de l'animal : ");
            string nomAnimal = Console.ReadLine();
            codePassager = "ancomp";
            //Création de l'objet Passager pour l'animal
            Passager animal = new Passager(nomAnimal, "", codePassager);
            listePassagers.Add(animal);
        }
        Console.WriteLine(nombreAnimaux + " animaux de compagnie seront ajoutés à votre réservation.");


        //Saisie du nombre de véhicules et de leur catégorie
        
        string catVehicule = "";

        Console.WriteLine("Combien de véhicules souhaitez-vous transporter ?");
        int nombreVehicules = int.Parse(Console.ReadLine());
        

        //SI LE NOMBRE DE VÉHICULES EST SUPÉRIEUR À 0 SINON PASSER CETTE ÉTAPE
        if(nombreVehicules > 0)
        {
            foreach(string vehic in categVehicule.Keys)
            {
                Console.WriteLine(vehic.PadRight(45) + " correspond à : "+ categVehicule[vehic]);
            }
            Console.WriteLine("Saisissez les catégories de vos véhicules : ");
            Console.WriteLine();
            for(int i = 0; i<nombreVehicules; i++)
            {
                bool existe = false;
                do //Vérification de la validité de la catégorie de véhicule
                {
                    Console.Write("Véhicule n°" + (i+1) + " : ");
                    catVehicule = Console.ReadLine();
                    if(!categVehicule.ContainsValue(catVehicule))
                    {
                        Console.WriteLine("Catégorie de véhicule invalide, veuillez réessayer.");
                    }
                }while(!categVehicule.ContainsValue(catVehicule));
                
                //Vérification si la catégorie de véhicule existe déjà dans la liste si oui, incrémenter la quantité
                for(int j=0; j<listeVehicules.Count; j++)
                {
                    if(listeVehicules[j].codeCategorie == catVehicule) 
                    {
                        Vehicule v = listeVehicules[j];
                        v.quantité++;
                        listeVehicules[j] = v;
                        existe = true;
                    }
                }
                //Si la catégorie n'existe pas, l'ajouter à la liste
                if(!existe)
                {
                    listeVehicules.Add(new Vehicule(catVehicule, 1));
                }
            }
            
        }
        else 
        {
            Console.WriteLine("Aucun véhicule réservé.");
        }

        //MISE À JOUR DU NOM DANS TOUTES LES RÉSERVATIONS
        Console.WriteLine("\nÀ quel nom souhaitez-vous faire la réservation ?");
        nomReservation = Console.ReadLine();
        string nomFichier = "reservation-" + nomReservation + ".json";
        
        //Mettre à jour le nom dans toutes les réservations
        for(int i = 0; i < listeReservations.Count; i++)
        {
            Reservation r = listeReservations[i];
            r.nom = nomReservation;
            listeReservations[i] = r;
        }
    
        
        //Création du fichier JSON


        if(File.Exists(nomFichier))
        {
            Console.WriteLine("Une réservation existe déjà sous ce nom.");
        }
        else 
        {
            FileStream fs = new FileStream(nomFichier, FileMode.Create, FileAccess.Write);    //si la reservation n'existe pas, création du fichier au format "reservation-nom.json"
            StreamWriter fichierReservation = new StreamWriter(fs);

            fichierReservation.WriteLine("[");

            //BOUCLE POUR ÉCRIRE CHAQUE RÉSERVATION (ALLER ET/OU RETOUR)
            for(int resIndex = 0; resIndex < listeReservations.Count; resIndex++)
            {
                reserv = listeReservations[resIndex];

                //ecriture de l'onglet reservation dans le fichier JSON
                fichierReservation.WriteLine("  {\n"
                + "     \"reservation\": {\n" 
                + "       \"nom\": \""  + reserv.nom + "\",\n"
                + "       \"idLiaison\": " + reserv.idLiaison + ",\n"
                + "       \"date\": \"" + reserv.date + "\",\n"
                + "       \"heure\": \"" + reserv.heure + "\",\n"
                + "       \"horodatage\": \"" + reserv.horodatage + "\"\n"
                + "     },\n"
                );

                //ecriture de l'onglet passagers
                fichierReservation.WriteLine("\n"
                + "     \"passagers\": [");
                for(int i=0; i<listePassagers.Count;i++)
                {
                    fichierReservation.Write(   "     {\n"
                    + "       \"nom\" : \"" + listePassagers[i].nom + "\",\n"
                    + "       \"prenom\" : \"" + listePassagers[i].prenom + "\",\n"
                    + "       \"codeCategorie\" : \"" + listePassagers[i].codeCategorie + "\"\n"
                    + "     }");
                    if(i < listePassagers.Count -1)
                    {
                        fichierReservation.WriteLine(","); //ajout d'une virgule entre chaque passager sauf pour le dernier
                    }
                    fichierReservation.WriteLine();
                }
                fichierReservation.WriteLine("   ],\n"
                + "     \"vehicules\": [");


                //ecriture de l'onglet vehicules
                for(int i=0; i<listeVehicules.Count;i++)
                {
                    fichierReservation.Write(   "     {\n"
                    + "       \"codeCategorie\" : \"" + listeVehicules[i].codeCategorie + "\",\n"
                    + "       \"quantite\" : \"" + listeVehicules[i].quantité + "\"\n"
                    + "     }");
                    if(i < listeVehicules.Count -1)
                    {
                        fichierReservation.WriteLine(","); //ajout d'une virgule entre chaque véhicule sauf pour le dernier
                    }
                    fichierReservation.WriteLine();
                }
                
                fichierReservation.WriteLine("   ]");


                //écriture de la fermeture de l'objet réservation
                fichierReservation.Write("  }");
                
                //Ajouter une virgule si ce n'est pas la dernière réservation
                if(resIndex < listeReservations.Count - 1)
                {
                    fichierReservation.WriteLine(",");
                }
                else
                {
                    fichierReservation.WriteLine();
                }
            }

            //écriture de la fermeture du fichier JSON
            fichierReservation.WriteLine("]");



            fichierReservation.Close();
            Console.WriteLine("Réservation créée avec succès !");
        }

    }
}