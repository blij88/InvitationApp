using Reservation.Models;
using System.Collections.Generic;

namespace Reservation
{
    internal class Person
    {

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string SurPrefix { get; set; }

        public Gender Gender { get; set; }

        public ContactMethod MyContactMethods { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Adress { get; set; }
    }
}