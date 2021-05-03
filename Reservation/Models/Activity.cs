using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Models
{
    class Activity
    {
        public Organizer Organizer { get; set; }
        public List<Invitee> Invitees { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Activity(string name, DateTime date, string description, Organizer organizer)
        {
            Name = name;
            Date = date;
            Description = description;
            Organizer = organizer;
            Invitees = new List<Invitee>();
        }
        public Activity(string name, DateTime date, Organizer organizer) : this(name, date, string.Empty, organizer)
        {
        }
    }
}
