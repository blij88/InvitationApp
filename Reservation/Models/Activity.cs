using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    class Activity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Activity(string name, DateTime date, string description)
        {
            Name = name;
            Date = date;
            Description = description;
        }
        public Activity(string name, DateTime date) : this(name, date, string.Empty)
        {
        }
    }
}
