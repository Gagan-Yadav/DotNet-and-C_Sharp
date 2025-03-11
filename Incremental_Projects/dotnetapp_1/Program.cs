using System;
using System.Collections.Generic;
// using Internal;
// using Internal;
// using Internal;
// using Internal;
// using Internal;
namespace dotnetapp.Managers
{
    namespace dotnetapp
    {
        class Program
        {
            public static EventManager em = new EventManager();
            public static AttendeeManager am = new AttendeeManager();
            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("Event Management Console App Menu:");
                    Console.WriteLine("1. Add Event to list");
                    Console.WriteLine("2. List Events from list");
                    Console.WriteLine("3. Add Attendee to list");
                    Console.WriteLine("4. List Attendee from list");
                    Console.WriteLine("5. Find Attendee from list");
                    Console.WriteLine("6. Edit Attendee in list");
                    Console.WriteLine("7. Delete Attendee from list");
                    Console.WriteLine("8. Add Event to DB");
                    Console.WriteLine("9. List Events from DB");
                    Console.WriteLine("10. Add Attendee to DB");
                    Console.WriteLine("11. List Attendees from DB");
                    Console.WriteLine("12. Edit Attendee in DB");
                    Console.WriteLine("13. Delete Attendee from DB");

                    Console.WriteLine("14. Exit");
                    Console.Write("Enter your choice: ");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            em.AddEvent();
                            break;

                        case 2:
                            em.ListEvents();
                            break;

                        case 3:
                            Console.Write("Enter Event ID for the Attendee: ");
                            int id = int.Parse(Console.ReadLine());
                            am.AddAttendee(id);
                            break;

                        case 4:
                            am.ListAttendees();
                            break;

                        case 5:
                            Console.Write("Enter Attendee Name to find: ");
                            string nm = Console.ReadLine();
                            am.FindAttendee(nm);
                            break;

                        case 6:
                            am.EditAttendee();
                            break;

                        case 7:
                            am.DeleteAttendee();
                            break;

                        case 8:
                            em.AddEventToDB();
                            break;

                        case 9:
                            em.ListEventsFromDB();
                            break;

                        case 10:
                            Console.Write("Enter Event ID for the Attendee: ");
                            int id1 = int.Parse(Console.ReadLine());
                            am.AddAttendeeToDB(id1);
                            break;

                        case 11:
                            am.ListAttendeesFromDB();
                            break;

                        case 12:
                            am.EditAttendeeInDB();
                            break;

                        case 13:
                            am.DeleteAttendeeFromDB();
                            break;

                        case 14:
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
}
