using System;
namespace dotnetapp.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public string Email { get; set; }

        public int EventId { get; set; }

        public Attendee() { }

        static int id = 1;
        public Attendee(string nm, int ag, string em, int eid)
        {
            AttendeeId = id;
            Name = nm;
            Age = ag;
            Email = em;
            EventId = eid;
            id++;
        }
    }
}
