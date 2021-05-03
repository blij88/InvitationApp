using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Reservation
{
    partial class Invitee : Person
    {
        public string FullName => string.IsNullOrWhiteSpace(SurPrefix) ? $"{SurName}, {FirstName}" : $"{SurName}, {FirstName} {SurPrefix}";

        public Invitee(string firstName, string surName, string surPrefix)
        {
            FirstName = firstName;
            SurName = surName;
            SurPrefix = surPrefix;
        }




    }
}
