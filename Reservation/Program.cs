using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Reservation
{
    class Program
    {
        static void Main(string[] args)
        {

            // verkrijg de organisator informatie
            Organizer organizer  = new Organizer(GetUserInput("de naam van de organisator"), GetUserInput("eventuele tussenvoegsels", false), GetUserInput("de achternaam van de organisator"));
            organizer.Email = GetUserInput("Emailadres van de organisator");
            organizer.phoneNumber = GetUserInput("telefoon nummer van de organisator");
            organizer.Gender = GetUserGender("het geslacht van de organisator");

            // verkijg event informatie
            Activity activity = new Activity(GetUserInput("de naam van het evenement"), GetActivityDate("de datum (dd-mm-yyyy) van het evenement", true), GetUserInput("een omschrijving van het evenement", false));

            // collectie van genodigden
            List<Invitee> Invitees = new List<Invitee>();
            do
            {
                Invitee newInvitee = new Invitee(GetUserInput("de voornaam van de genodigde"), GetUserInput("eventuele tussenvoegsels", false), GetUserInput("de achternaam van de genodigde"));
                newInvitee.Gender = GetUserGender("het geslacht van de deelnemer");
                newInvitee.MyContactMethods = GetUserContactMethod(newInvitee);
                Invitees.Add(newInvitee);
                Console.Clear();
            } while (GetUserInput("Wilt u meer gasten toevoegen?\n)Y\n)N")=="Y");
            
            Console.WriteLine($"de activiteit {activity.Name} wordt georganiseerd door: {organizer.FullName} op {activity.Date}\nDe Bevestigingen worden verstuurd naar: {organizer.Email}\n{activity.Description}");
            foreach (var item in Invitees)
            {

                if (item.MyContactMethods.HasFlag(ContactMethod.Email))
                {
               
                Console.WriteLine($"\nTHIS IS AN EMAIL\nDear{(item.Gender == Gender.Female? " Madame " : item.Gender == Gender.Male? " sir ": string.Empty) }{item.FullName},\n\n you are invited to {activity.Name} organised by {organizer.FullName}.\n the event will be held on {activity.Date.ToShortDateString()} please reply to {organizer.Email} to let them know wether you are willing to attend.\nThis message will be send to your {item.MyContactMethods}"); item.Email = GetUserInput("een emailadres");
                }
                if (item.MyContactMethods.HasFlag(ContactMethod.Mail))
                {
                Console.WriteLine($"\nTHIS IS A LETTER \nDear{(item.Gender == Gender.Female? " Madame " : item.Gender == Gender.Male? " sir ": string.Empty) }{item.FullName},\n\n you are invited to {activity.Name} organised by {organizer.FullName}.\n the event will be held on {activity.Date.ToShortDateString()} please reply to {organizer.Email} to let them know wether you are willing to attend.\nThis message will be send to your {item.MyContactMethods}");
                }
                if (item.MyContactMethods.HasFlag(ContactMethod.WhatsApp))
                {
                Console.WriteLine($"\nTHIS IS A WHATSAPP \nDear{(item.Gender == Gender.Female? " Madame " : item.Gender == Gender.Male? " sir ": string.Empty) }{item.FullName},\n\n you are invited to {activity.Name} organised by {organizer.FullName}.\n the event will be held on {activity.Date.ToShortDateString()} please reply to {organizer.Email} to let them know wether you are willing to attend.\nThis message will be send to your {item.MyContactMethods}");

                }
                if (item.MyContactMethods.HasFlag(ContactMethod.Phone))
                {
                    Console.WriteLine("ringgggg ringggggg");
                }
            } 

            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        }

        private static ContactMethod GetUserContactMethod(Invitee invitee)
        {
            List < ContactMethod > newContactMethods = new List<ContactMethod> {ContactMethod.Email, ContactMethod.Mail, ContactMethod.Phone, ContactMethod.WhatsApp };
            ContactMethod methods = new ContactMethod();
            do
            {
                int i = 1;
                Console.WriteLine("kies een contact methode");
                foreach (var item in newContactMethods)
                {
                    Console.WriteLine($"{i}) {item}");
                    i++;
                }
                int result;
                if(int.TryParse(Console.ReadLine(), out result) && result>0 && result <= newContactMethods.Count)
                {
                    methods |= newContactMethods[result - 1];
                    newContactMethods.RemoveAt(result - 1);
                }
                else
                {
                    Console.WriteLine($"geef een numer tussen 1 en {newContactMethods.Count} op");
                }
            } while (GetUserInput("wilt u meer toevoegen? druk \"y\" en ENTER",false) == "y" || newContactMethods.Count == 4);
            GetRelevantContactMethods(invitee, methods);
            return methods;
        }

        private static void GetRelevantContactMethods(Invitee invitee, ContactMethod contactMethod)
        {
            if (contactMethod.HasFlag(ContactMethod.Email))
            {
                invitee.Email = GetUserInput("een emailadres");
            }
            if (contactMethod.HasFlag(ContactMethod.Mail))
            {
                invitee.Adress = GetUserInput("een postadress");
            }
            if (contactMethod.HasFlag(ContactMethod.Phone) || contactMethod.HasFlag(ContactMethod.WhatsApp))
            {
                invitee.phoneNumber = GetUserInput("je Telefoonnummer");
            }
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

        private static DateTime GetActivityDate(string Description, bool required)
        {
            DateTime input;
            do
            {   
                Console.WriteLine($"geef {Description} op {(required? "(verplicht)" :string.Empty)}:");
                DateTime.TryParse(Console.ReadLine(), out input);
                Console.Clear();

            } while (required && input.Date < DateTime.Now) ;
            return input;

        }
        
        private static Gender GetUserGender(string Description)
        {
                Console.WriteLine($"kies {Description} op \n1) vrouw" +
                    $"\n2) man\n3) neutraal:");
                string caseswitch = Console.ReadLine();
                switch (caseswitch)
                {
                    case "1":
                    Console.Clear();
                        return Gender.Female;
                    case "2":
                    Console.Clear();
                        return Gender.Male;
                    case "3":
                    Console.Clear();
                        return Gender.Neutral;
                    default:
                    Console.Clear();
                        return Gender.Unknown;
                }

        }


    }
}
