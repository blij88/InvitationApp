using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    class Organizer : Person
    {

        public string FullName => string.IsNullOrWhiteSpace(SurPrefix) ? $"{FirstName} {SurName}" : $"{FirstName} {SurName} {SurPrefix}";


        public Organizer(string firstName, string surName, string surPrefix)
        {
            FirstName = firstName;
            SurName = surName;
            SurPrefix = surPrefix;
        }

    }
}
