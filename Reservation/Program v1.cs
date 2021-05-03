using System;

namespace Reservation
{
    class Program_V1
    {
        static void Main_V1(string[] args)
        {
            string organisorName = GetUserInput("de naam van de organistator");

            Console.WriteLine("geef het Emailadres van de organisator:");
            string organisorEmail = GetUserInput("Emailadres van de organisator");
            Console.Clear();

            Console.WriteLine("geef de naam van het evenement:");
            string ActivityTitle = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Voeg omschrijving toe?\n)Y\n)N");

            if (Console.ReadLine() == "Y")
            {
                Console.WriteLine("geef een omschrijving van het evenement:");
                string activityDescription = Console.ReadLine();
                Console.Clear();
            };

            Console.WriteLine("geef de datum van het evenement:");
            string activityDate = Console.ReadLine();
            Console.Clear();


            Console.WriteLine($"de activiteit wordt georganiseerd door: {organisorName}\nDe Bevestigingen worden verstuurd naar: {organisorEmail}\n");

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static string GetUserInput(string Description)
        {
            Console.WriteLine($"geef {Description} op:");
            string Input = Console.ReadLine();
            Console.Clear();
            return Input;
        }
    }
}
