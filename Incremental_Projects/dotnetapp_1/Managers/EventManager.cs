using System;
using dotnetapp.Models;
// using Internal;
// using Internal;
// using Internal;
namespace dotnetapp.Managers
{
    class EventManager : IEventManager
    {
        // list here
        public static List<Event> events {get;set;} = new List<Event>();
        public static AttendeeManager am = new AttendeeManager();
        public void AddEvent()
        {
         
            Console.Write("Enter Event Name: ");
            string nm = Console.ReadLine();
            Console.Write("Enter Location: ");
            string lc = Console.ReadLine();
            Console.Write("Enter Event Date: ");
            DateTime dt = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Budget: ");
            Decimal bg = Decimal.Parse(Console.ReadLine());
            Event ev = new Event(nm, lc, dt, bg);
            events.Add(ev);
            Console.WriteLine("Event added successfully!");
            
        }
        public void ListEvents()
        {
            if(events.Count > 0){
            Console.WriteLine("List of Events:");
            foreach(Event item in events){
               Console.WriteLine($"Event ID: {item.EventId}, Name: {item.Name}, Location: {item.Location}, Event Date: {item.Date}, Event Budget: {item.Budget}");
               am.ListAttendeeByID(item.EventId);
            }
           

            }else{
                Console.WriteLine("No Recoord Found.");
            }
        }
        public string ListEventByID(int id){
            if(events.Count>0){
                foreach(Event item in events){
                    if(item.EventId==id){
                        return item.Name;
                    }
                }
            }

                return null;
        
        }
        public void AddEventToDB()
        {

        }
        public void ListEventsFromDB()
        {

        }
    }

}
