using System.Globalization;
using System.Linq;
public class Program
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

                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig input!");
                    Console.WriteLine("\n\nTryck på valrfri knapp för att återgå till menyn.");
                    Console.ReadKey(true);
                    break;
            }
        }
    }

    static void RunProgram()
    {
        Console.WriteLine("Skriv in ditt personnummer (ÅÅMMDD-XXXX eller ÅÅMMDDXXXX):");
        string personnummer = Console.ReadLine() ?? ""; //null check

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

        //Check så att datumet är i rätt format, dvs yyMMdd
        string dateOfBirth = personnummer.Substring(0, 6);
        if (!DateTime.TryParseExact(
            dateOfBirth, "yyMMdd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None, out _
            ))
        {
            Console.WriteLine("Personnumrets datum är ogiltigt!");
        }

        if (!LuhnValidation(personnummer))
        {
            Console.WriteLine("Personnumret har en ogiltig kontrollsiffra.");
            return false;
        }

        return true;
    }

    //bool metod för Luhn algoritm
    static bool LuhnValidation(string personnummer)
    {
        int sum = 0; //Kommer innehålla totala Luhn-summan

        //Går igenom dom första 9 (index 0-8) sifforna eftersom kontrollsiffran är den sista (index 9)
        for (int i = 0; i < 9; i++)
        {
            int digit = int.Parse(personnummer[i].ToString()); //Konverterar char till int

            if (i % 2 == 0) //Varannan siffra ska multipliceras med 2
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit; //Lägger till siffran i summan
        }

        int moduloResult = sum % 10;
        int calcControlDigit = (10 - moduloResult) % 10; //Räknar ut kontrollsiffran
        int realControlDigit = int.Parse(personnummer[9].ToString()); //Konverterar kontroll siffra från char till int

        return calcControlDigit == realControlDigit;
    }
}
