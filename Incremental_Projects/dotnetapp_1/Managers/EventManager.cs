using System;
using dotnetapp.Models;
using System.Data.SqlClient;
using System.Data;
// using Internal;
// using Internal;
// using Internal;
// using Internal;
// using Internal;
namespace dotnetapp.Managers
{
    class EventManager : IEventManager
    {
        // list here
        public static string connectionString = "User ID=sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        public static List<Event> events { get; set; } = new List<Event>();
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
            if (events.Count > 0)
            {
                Console.WriteLine("List of Events:");
                foreach (Event item in events)
                {
                    Console.WriteLine($"Event ID: {item.EventId}, Name: {item.Name}, Location: {item.Location}, Event Date: {item.Date}, Event Budget: \u20B9{item.Budget}");
                    am.ListAttendeeByID(item.EventId);
                }


            }
            else
            {
                Console.WriteLine("No Recoord Found.");
            }
        }
        public string ListEventByID(int id)
        {
            if (events.Count > 0)
            {
                foreach (Event item in events)
                {
                    if (item.EventId == id)
                    {
                        return item.Name;
                    }
                }
            }

            return null;

        }
        public void AddEventToDB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                Console.Write("Enter Event Name: ");
                string em = Console.ReadLine();
                Console.Write("Enter Location: ");
                string lc = Console.ReadLine();

                Console.Write("Enter Event Date: ");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Budget: ");
                int bg = int.Parse(Console.ReadLine());


                SqlCommand cmd = new SqlCommand("Select * from Events", connection);
                // cmd.Parameters.AddWithValue("@aid", );
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();
                //   DataSet set = new DataSet();
                adapter.Fill(set, "Events");
                // if (set.Tables[0].Rows.Count <= 0)
                //{
                DataRow row = set.Tables[0].NewRow();
                row[1] = em;
                row[2] = lc;
                row[3] = dt;
                row[4] = bg;

                set.Tables[0].Rows.Add(row);
                adapter.Update(set, "Events");
                Console.WriteLine("Event added to the database successfully!");
                //}
                //else
                //{
                /// Console.WriteLine("ID Already Exists");
                // }
            }
        }
        public void ListEventsFromDB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {



                SqlCommand cmd = new SqlCommand("Select * from Events", connection);
                // cmd.Parameters.AddWithValue("@aid",eid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();

                adapter.Fill(set, "Events");
                if (set.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in set.Tables[0].Rows)
                    {

                        Console.WriteLine($"Event ID: {row[0]}\nName: {row[1]}\nLocation: {row[2]}\nEvent Date:  {row[3]}\nBudget: \u20B9{row[4]}");
                        Console.WriteLine("Attendees:");
                        am.ListAttendeesFromDBById((int)row[0]);
                    }
                }
                else
                {
                    Console.WriteLine("No Event Found.");
                }
            }

        }
    }

}
