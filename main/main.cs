using System;
using System.IO;

class SAE11
{
    struct traversee
    {
        public string liaison;
        public string nom;
        public string date;
        public string heure;
        
        public traversee(iti, nm, d, hr)
        {
            liaison = iti ;
            nom = nm;
            date = d;
            heure = hr;
        }

    }
    
    struct reservation
    {
        public 
    }
    static void Main()
    {
        int choix; string liaison;
        Dictonary<int, List<string>> horaireLorientGroix, horaireGroixLorient;

        horaireLorentGroix = new Dictionary<int, List<string>>
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
 

        Console.WriteLine("=== Choisissez un itinéraire ===");
        Console.WriteLine("1 - Lorient → Groix");
        Console.WriteLine("2 - Groix → Lorient");
        Console.WriteLine("3 - Quiberon → Le Palais");
        Console.WriteLine("4 - Le Palais → Quiberon");
        Console.WriteLine();

        Console.Write("Choisissez le numéro de votre itinéraire : ");
        choix = int.Parse(Console.ReadLine());

        switch(choix)
        {
            case 1:
                Console.WriteLine("Vous avez choisi : Lorient → Groix");
                liaison = "Lorient-Groix";

                break;
            case 2:
                Console.WriteLine("Vous avez choisi : Groix → Lorient");
                liaison = "Groix-Lorient";
                break;
            case 3:
                Console.WriteLine("Vous avez choisi : Quiberon → Le Palais");
                liaison = "Quiberon-Le Palais";
                break;
            case 4:
                Console.WriteLine("Vous avez choisi : Le Palais → Quiberon");
                liaison = "Le Palais-Quiberon";
                break;
            default:
                Console.WriteLine("Choix invalide !");
                break;
        }
    }
}