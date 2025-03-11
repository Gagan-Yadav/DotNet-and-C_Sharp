using System;
using System.Data.SqlClient;
using System.Data;
using dotnetapp.Models;
// using Internal;

// using Internal;
// using Internal;
// using Internal;
// using Internal;
// using Internal;
// using Internal;
namespace dotnetapp.Managers
{

    class AttendeeManager : IAttendeeManager
    {
        public static string connectionString = "User ID=sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
        public static List<Attendee> attendees { get; set; } = new List<Attendee>();
        public EventManager ev = new EventManager();
        public void AddAttendee(int EventId)
        {
            Console.Write("Enter Attendee Name: ");
            string nm = Console.ReadLine();
            Console.Write("Enter Age: ");
            int ag = int.Parse(Console.ReadLine());
            Console.Write("Enter Email: ");
            string em = Console.ReadLine();
            Attendee ad = new Attendee(nm, ag, em, EventId);

            attendees.Add(ad);
            Console.WriteLine("Attendee added successfully!");
        }

        public void EditAttendee()
        {
            Console.Write("Enter Attendee ID to edit: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter new Attendee Name (leave empty to keep current): ");
            string nm = Console.ReadLine();
            if (!string.IsNullOrEmpty(nm))
            {
                foreach (Attendee item in attendees)
                {
                    if (item.AttendeeId == id)
                    {
                        item.Name = nm;
                    }
                }
            }

            Console.Write("Enter new Attendee Age (leave empty to keep current): ");

            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                foreach (Attendee item in attendees)
                {
                    if (item.AttendeeId == id)
                    {
                        item.Age = age;
                    }
                }
            }


            Console.Write("Enter new Attendee Email (leave empty to keep current): ");
            string em = Console.ReadLine();
            if (!string.IsNullOrEmpty(em))
            {
                foreach (Attendee item in attendees)
                {
                    if (item.AttendeeId == id)
                    {
                        item.Email = em;

                    }
                }
            }

            // Attendee et = new Attendee(id, nm, age, em);
            // attendees[id] = et;
            Console.WriteLine("Attendee information updated successfully!");

        }

        public void DeleteAttendee()
        {
            Console.WriteLine("Enter Attendee ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            if (attendees.Count > 0)
            {
                foreach (Attendee item in attendees)
                {
                    if (item.AttendeeId == id)
                    {
                        Console.WriteLine("Attendee deleted successfully!");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Attendees");
            }
        }

        public void ListAttendees()
        {
            if (attendees.Count > 0)
            {

                foreach (Attendee item in attendees)
                {
                    string evn = ev.ListEventByID(item.EventId);
                    Console.WriteLine($"Attende ID: {item.AttendeeId}, Name: {item.Name}, Age: {item.Age}, Email: {item.Email}, Event Name: {evn}");
                }
                return;
            }
            else
            {
                Console.WriteLine("No attendee found!");
            }
        }


        public void ListAttendeeByID(int id)
        {

            Console.WriteLine("   Attendee:");
            foreach (Attendee item in attendees)
            {

                if (item.EventId == id)
                {
                    Console.WriteLine($"Attende ID: {item.AttendeeId}, Name: {item.Name}, Age: {item.Age}, Email: {item.Email}");
                }
            }

        }
        public void FindAttendee(string attendeeName)
        {

            if (attendees.Count > 0)
            {

                foreach (Attendee item in attendees)
                {
                    string evn = ev.ListEventByID(item.EventId);
                    if (item.Name == attendeeName)
                    {
                        Console.WriteLine($"Attende ID: {item.AttendeeId}, Name: {item.Name}, Age: {item.Age}, Email: {item.Email}, Event Name: {evn}");
                    }
                    else
                    {
                        Console.WriteLine("No attendee found!");
                    }
                }
                return;
            }
            else
            {
                Console.WriteLine("No attendee found!");
            }
        }

        public void AddAttendeeToDB(int eventid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Console.Write("Connection successful!");\
                // Console.Write("Enter Event ID for the Attendee: ");
                // int eid = int.Parse(Console.ReadLine());
                Console.Write("Enter Attendee Name: ");
                string nm = Console.ReadLine();
                Console.Write("Enter Age: ");
                int ag = int.Parse(Console.ReadLine());
                Console.Write("Enter Email: ");
                string em = Console.ReadLine();

                SqlCommand cmd = new SqlCommand("Select * from Attendees", connection);
                // cmd.Parameters.AddWithValue("@aid", );
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();
                //   DataSet set = new DataSet();
                adapter.Fill(set, "Attendees");
                // if (set.Tables[0].Rows.Count <= 0)
                //{
                DataRow row = set.Tables[0].NewRow();
                row[1] = nm;
                row[2] = ag;
                row[3] = em;
                row[4] = eventid;

                set.Tables[0].Rows.Add(row);
                adapter.Update(set, "Attendees");
                Console.WriteLine("Attendee added to the database successfully!");
                //}
                //else
                //{
                /// Console.WriteLine("ID Already Exists");
                // }
            }

        }

        public void EditAttendeeInDB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                Console.Write("Enter Attendee ID to edit: ");
                int id = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand("Select * from Attendees where AttendeeId = @id", connection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();
                adapter.Fill(set, "Attendees");

                if (set.Tables[0].Rows.Count > 0)
                {
                    Console.WriteLine($"Editing Attendee with ID: {id}");

                    Console.Write("Enter new Attendees Name (leave empty to keep current): ");
                    string nm = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nm))
                    {
                        foreach (Attendee item in attendees)
                        {
                            if (item.AttendeeId == id)
                            {
                                item.Name = nm;
                            }
                        }
                    }

                    Console.Write("Enter new Attendees Age (leave empty to keep current): ");

                    if (!int.TryParse(Console.ReadLine(), out int age))
                    {
                        foreach (Attendee item in attendees)
                        {
                            if (item.AttendeeId == id)
                            {
                                item.Age = age;
                            }
                        }
                    }

                    Console.Write("Enter new Attendees Email (leave empty to keep current): ");
                    string em = Console.ReadLine();
                    if (!string.IsNullOrEmpty(em))
                    {
                        foreach (Attendee item in attendees)
                        {
                            if (item.AttendeeId == id)
                            {
                                item.Email = em;

                            }
                        }
                    }

                    DataRow row = set.Tables[0].Rows[0];
                    row[1] = nm;
                    row[2] = age;
                    row[3] = em;

                    adapter.Update(set, "Attendees");
                    Console.WriteLine("Attendee information updated successfully!");
                }
                else
                {
                    Console.WriteLine($"Record Not Found with ID {id}");
                }

            }
        }

        public void DeleteAttendeeFromDB()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.Write("Enter Attendee ID to delete: ");
                int eid = int.Parse(Console.ReadLine());


                SqlCommand cmd = new SqlCommand("Select * from Attendees where AttendeeId = @aid", connection);
                cmd.Parameters.AddWithValue("@aid", eid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();

                adapter.Fill(set, "Attendees");
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    row.Delete();
                    adapter.Update(set, "Attendees");
                    Console.WriteLine("Attendee Deleted successfully!");
                }
                else
                {
                    Console.WriteLine("No Attendee Found.");
                }
            }
        }
        public void ListAttendeesFromDB()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {



                SqlCommand cmd = new SqlCommand("Select a.AttendeeId, a.Name, a.Age, a.Email, e.Name from Attendees a INNER JOIN Events e on a.EventId=e.EventId", connection);
                // cmd.Parameters.AddWithValue("@aid",eid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();

                adapter.Fill(set, "Attendees");
                if (set.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in set.Tables[0].Rows)
                    {

                        Console.WriteLine($"Attendee ID: {row[0]}\nName: {row[1]}\nAge: {row[2]}\nEmail:  {row[3]}\nEvent Name:{row[4]}");
                    }
                }
                else
                {
                    Console.WriteLine("No Attendee Found.");
                }
            }
        }

        public void ListAttendeesFromDBById(int id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {



                SqlCommand cmd = new SqlCommand("Select a.AttendeeId, a.Name, a.Age, a.Email, e.Name from Attendees a INNER JOIN Events e on a.EventId=e.EventId where e.EventId = @id", connection);
                cmd.Parameters.AddWithValue("@id",id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                DataSet set = new DataSet();

                adapter.Fill(set, "Attendees");
                if (set.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in set.Tables[0].Rows)
                    {

                        Console.WriteLine($"Attendee ID: {row[0]} Name: {row[1]} Age: {row[2]} Email:  {row[3]} Event Name:{row[4]}");
                    }
                }
                else
                {
                    Console.WriteLine("No Attendee Found.");
                }
            }
        }
    }
}
