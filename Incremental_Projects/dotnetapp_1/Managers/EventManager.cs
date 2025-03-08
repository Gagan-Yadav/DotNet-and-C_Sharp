using System;
using dotnetapp.Models;
// using Internal;
namespace dotnetapp.Managers
{
    class EventManager : IEventManager
    {
        // list here
        public List<Event> events {get;set;} = new List<Event>();

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
            Console.WriteLine("List of Events:");
            foreach(Event item in events){
               Console.WriteLine($"Event ID: {item.EventId}, Name: {item.Name}, Location: {item.Location}, Event Date: {item.Date}, Event Budget: {item.Budget}");
            }
        }
        public void AddEventToDB()
        {

        }
        public void ListEventsFromDB()
        {

        }
    }

}
