using System;
using System.Collections;
namespace dotnetapp.Models
{
    class Event{
        public int EventId {get;set;}
        public string Name {get; set;}
        public string Location {get;set;}
        public DateTime Date {get; set;}

        public Decimal Budget {get; set;}

        public ICollection<Attendee> Attendees {get;set;}

        public Event(){}
        public static int id =1;
        public Event(string nm, string lc, DateTime dt, Decimal bg){

                EventId = id;
                Name = nm;
                Location = lc;
                Date = dt;
                Budget = bg;
                id++;
        }
    }
    
}
