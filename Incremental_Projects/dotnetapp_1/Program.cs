using System;
using System.Collections.Generic;
using Internal;
// using Internal;

namespace dotnetapp
{
    class Program
    {
        public static EventManager em = new EventManager();
        public static AttendeeManager am = new AttendeeManager();
        static void Main(string[] args)
        {
            while(true){
                Console.WriteLine("Event Management Console App Menu:");
                Console.WriteLine("1. Add Event to list");
                Console.WriteLine("2. List Events from list");
                Console.WriteLine("3. Add Attendee to list");
                Console.WriteLine("4. List Attendee from list");
                Console.WriteLine("5. Find Attendee from list");
                Console.WriteLine("6. Edit Attendee in list");
                Console.WriteLine("7. Delete Attendee from list");
                Console.WriteLine("8. Exit");
                int ch = int.Parse(Console.ReadLine());
                switch(ch){
                    case 1:
                    em.AddEvent();
                    break;

                    case 2:
                    em.ListEvents();
                    break;

                    case 3:
                    am.AddAttendee();
                    break;

                    case 4:
                    am.ListAttendees();
                    break;

                    case 5:
                    am.FindAttendee();
                    break;
                    case 6:
                    am.EditAttendee();
                    break;
                    case 7:
                    am.DeleteAttendee();
                    break;

                    case 8:
                       Console.WriteLine("Exiting Event Management App...");
                       return;

                       default:
                       Console.WriteLine("Invalid Option");
                       break; 

                }
            }
        }
    }
}
