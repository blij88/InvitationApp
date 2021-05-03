using Reservation.Models;
using System;
using System.Collections.Generic;

namespace Reservation
{
    class ProgramV3
    {
        static void MainV3(string[] args)
        {

            // verkrijg de organisator informatie
            Organizer organizer  = new Organizer();
            organizer.FirstName = GetUserInput("de naam van de organisator");
            organizer.SurName = GetUserInput("de achternaam van de organisator");
            organizer.Email = GetUserInput("Emailadres van de organisator");

            // verkijg event informatie
            string ActivityTitle = GetUserInput("de naam van het evenement");

            DateTime activityDate;
            DateTime.TryParse(GetUserInput("de datum (dd-mm-yyyy) van het evenement"), out activityDate);
            
            string activityDescription = GetUserInput("een omschrijving van het evenement", false);

            // collectie van genodigden
            List<Invitee> Invitees = new List<Invitee>();

            do
            {
                Invitee newInvitee = new Invitee( GetUserInput($"de voornaam van de genodigde"), GetUserInput($"de achternaam van de genodigde") );
                newInvitee.Email = GetUserInput($"Emailadres van de genodigde");
                newInvitee.phoneNumber = int.Parse(GetUserInput($"Telefoonnummer van de genodigde"));
                //newInvitee.Preferences = GetUserInput($"Emailadres van de genodigde ({i+1}/{amountOfInvitees})");
                Invitees.Add(newInvitee);
                Console.Clear();
            } while (GetUserInput("Wilt u meer gasten toevoegen?\n)Y\n)N")=="Y");
            
            foreach (var item in Invitees)
            {
                Console.WriteLine($"de activiteit {ActivityTitle} wordt georganiseerd door: {organizer.FullName} op {activityDate}\nDe Bevestigingen worden verstuurd naar: {organizer.Email}\n{activityDescription}");

                Console.WriteLine($"Deelnmer: {item.FullName}   Email: {item.Email}");
            } 

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        } 
        
        private static string GetUserInput(string Description)
        {
            return GetUserInput(Description, true);
        }

        private static string GetUserInput(string Description, bool required)
        {   
            string input;
            do
            {   
                Console.WriteLine($"geef {Description} op {(required? "(verplicht)" :string.Empty)}:");
                input = Console.ReadLine();
                Console.Clear();

            } while (required && string.IsNullOrWhiteSpace(input)) ;
            return input;
        }
    }
}
