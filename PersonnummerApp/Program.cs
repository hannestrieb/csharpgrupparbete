// See https://aka.ms/new-console-template for more information
using System.Linq;
class Program
{
    //Gör allt i program.cs pga göra det så enkelt som möjligt
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Välj ett alternativ\n");
            Console.WriteLine("1. Starta programmet");
            Console.WriteLine("2. Avsluta programmet");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    RunProgram();
                    break;

                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Programmet avslutas...");
                    running = false;
                    break;
            }
        }
    }

    static void RunProgram()
    {
        Console.WriteLine("Skriv in ditt personnummer (ÅÅMMDD-XXXX eller ÅÅMMDDXXXX):");
        string personnummer = Console.ReadLine();

        if (!PersonnummerValidation(personnummer))
        {
            Console.WriteLine("Du har angett ett felaktigt personnummer!");
        }
        else
        {
            Console.WriteLine("Personnumret är korrekt!");
        }

        Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
        Console.ReadKey(true);
    }

    //Bool metod för att kolla så personnummret uppfyller vissa krav
    static bool PersonnummerValidation(string personnummer)
    {
        //Tar bort eventuella bindestreck
        personnummer = personnummer.Replace("-", "");

        //Check för längd på personnummer
        if (personnummer.Length != 10)
        {
            Console.WriteLine("Personnumret måste vara 10 siffror!");
            return false;
        }

        //Check så personnummret bara innehåller siffror
        if (!personnummer.All(char.IsDigit))
        {
            Console.WriteLine("Personnumret får endast innehålla siffror!");
            return false;
        }

        return true;
    }
}