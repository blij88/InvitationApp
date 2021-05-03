using System;

namespace InvitationConsoleApp
{
    class Program_V2
    {
        static void Main_V2(string[] args)
        {
            //Gegevens opvragen van de organisator:
            string organizerName = GetUserInput("naam van de organisator");
            string organizerEmail = GetUserInput("email van de organisator");
            //Gegevens opvragen van de activiteit:
            string activityTitle = GetUserInput("titel van de activiteit");
            //Zorg ervoor dat er om een datum invoer gevraagd wordt en deze als zodaning verwerkt wordt
            DateTime activityDate = DateTime.Parse(GetUserInput("datum van de activiteit"));
            string activityDescription = GetUserInput("omschrijving van de activiteit", false);

            //Aantal personen uitnodigen (2 manieren, hoeveel in totaal of aan de hand van 'vraag wilt u meer uitnodigen..')

            //Zorg ervoor dat er om een int invoer gevraagd wordt en deze als zodaning verwerkt wordt
            int amountOfInvitees = int.Parse(GetUserInput("aantal genodigden"));
            string[] inviteeNames = new string[amountOfInvitees];
            string[] inviteeEmails = new string[amountOfInvitees];

            for (int i = 0; i < amountOfInvitees; i++)
            {
                inviteeNames[i] = GetUserInput($"naam van de ({i + 1}/{amountOfInvitees}) genodigde");
                inviteeEmails[i] = GetUserInput($"email van de ({i + 1}/{amountOfInvitees}) genodigde");
            }


            Console.WriteLine($"De activiteit {activityTitle} wordt georganiseerd op {activityDate} door {organizerName}\nOrganisator Email:{organizerEmail}\n\nOmschrijving van de activiteit:\n{activityDescription}");

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        }
        private static string GetUserInput(string description)
        {
            return GetUserInput(description, true);
        }
        private static string GetUserInput(string description, bool required)
        {
            //Vragen om gebruiker invoer/ tekst
            //Een gebruiker dient te weten welke invoer gevraagd wordt: omschrijving tonen
            //Wanneer er geen input is gegeven dan dient de gebruiker opnieuw invoer te geven wanneer deze verplicht is (zolang er geen input is gegeven dient om input gevraagd te worden)
            //Tonen wanneer invoer verplicht is

            string input;
            do
            {
                Console.WriteLine($"Geef de {description} op{(required ? " (verplicht)" : string.Empty)}:");
                input = Console.ReadLine();
                Console.Clear();

            } while (required && string.IsNullOrWhiteSpace(input));

            return input;
        }


    }

}
