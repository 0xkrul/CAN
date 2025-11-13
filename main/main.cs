using System;
using System.IO;

class SAE11
{
    struct traversee
    {
        
    }
    static void Main()
    {
        int choix; string liaison;

        Console.WriteLine("=== Choisissez un itinéraire ===");
        Console.WriteLine("1 - Lorient → Groix");
        Console.WriteLine("2 - Groix → Lorient");
        Console.WriteLine("3 - Quiberon → Le Palais");
        Console.WriteLine("4 - Le Palais → Quiberon");
        Console.WriteLine();

        Console.WriteLine("Choisissez le numéro de votre itinéraire");
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