using System;
using System.Data;
using System.Data.SqlClient;
using DisconnectedArchitecture.Models;
 
 
 
 
 
namespace DisconnectArchitecture
{
    public static class ConnectionStringProvider
    {
        public static string ConnectionString { get; } = "User ID=sa;password=examlyMssql@123;server=localhost;Database=appdb;trusted_connection=false;Persist Security Info=False;Encrypt=False";
    }
 
    public class Program
    {
        public static string connectionString = ConnectionStringProvider.ConnectionString;
 
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add car");
                Console.WriteLine("2. List car");
                Console.WriteLine("3. Update car");
                Console.WriteLine("4. Delete car");
                Console.WriteLine("5. Search car");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6):");
                int choice = int.Parse(Console.ReadLine());
 
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Car Make: ");
                        string carmake = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(carmake))
                            throw new ArgumentException("Car Make cannot be empty.");
 
                        Console.Write("Enter Car Model: ");
                        string carmodel = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(carmodel))
                            throw new ArgumentException("Car model cannot be empty.");
 
                        Console.Write("Enter Car Year: ");
                        int caryear = int.Parse(Console.ReadLine());
 
                        Console.Write("Enter the Service date dd-mm-yyyy:");
                        string servicedate = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(servicedate))
                            throw new ArgumentException("Enter a valid service date");
 
                        Car car = new Car(carmake, carmodel, caryear, servicedate);
                        AddCar(car);
                        break;
 
                    case 2:
                        ListCar();
                        break;
 
                    case 3:
                        Console.Write("Enter Car id to update: ");
                        int updateId = int.Parse(Console.ReadLine());
 
                        Console.Write("Enter new Car Make: ");
                        string newCarmake = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newCarmake))
                            throw new ArgumentException("Car Make cannot be empty.");
 
                        Console.Write("Enter new Car Model: ");
                        string newCarmodel = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newCarmodel))
                            throw new ArgumentException("Car model cannot be empty.");
 
                        Console.Write("Enter new Car Year: ");
                        int newCaryear = int.Parse(Console.ReadLine());
 
                        Console.Write("Enter the new Service date dd-mm-yyyy:");
                        string newServicedate = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newServicedate))
                            throw new ArgumentException("Enter a valid service date");
 
                        UpdateCar(updateId, newCarmake, newCarmodel, newCaryear, newServicedate);
                        break;
 
                    case 4:
                        Console.Write("Enter Car id to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        DeleteCar(deleteId);
                        break;
 
                    case 5:
                        Console.Write("Enter search id");
                        int searchid = int.Parse(Console.ReadLine());
                        SearchCar(searchid);
                        break;
 
                    case 6:
                        Console.WriteLine("Exiting the application.");
                        return;
 
                    default:
                        Console.WriteLine("Invalid choice, please enter a valid option.");
                        break;
                }
            }
        }
 
 
 
 
 
        public static void AddCar(Car v)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Cars WHERE CarID =@CarID", connection);
                    command.Parameters.AddWithValue("@CarId", v.CarId);
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Cars");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        Console.WriteLine("A car with id exist");
 
                    }
                    DataRow newRow = dataSet.Tables[0].NewRow();
                    newRow[1] = v.CarMake;
                    newRow[2] = v.CarModel;
                    newRow[3] = v.CarYear;
                    newRow[4] = v.ServiceDate;
 
                    dataSet.Tables[0].Rows.Add(newRow);
                    SqlCommandBuilder br = new SqlCommandBuilder(adapter);
                    adapter.Update(dataSet, "Cars");
                    Console.WriteLine("Added information");
                }
            }
        }
 
        public static void ListCar()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Cars", connection);
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Cars");
                    if (dataSet.Tables[0].Rows.Count == 0)
                    {
                        Console.WriteLine("No information ");
 
                    }
 
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine($"CarID: {row[0]}\tCarMake: {row[1]}\tCarModel: {row[2]}\tYear: {row[3]}\tServiceDate: {row[4]}");
                    }
                }
            }
        }
 
 
 
        public static void UpdateCar(int updateId, string newCarmake, string newCarmodel, int newCaryear, string newServicedate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Cars WHERE CarId = @CarId", connection);
                    command.Parameters.AddWithValue("@CarId", updateId);
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Cars");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = dataSet.Tables[0].Rows[0];
                        row[1] = newCarmake;
                        row[2] = newCarmodel;
                        row[3] = newCaryear;
                        row[4] = newServicedate;
 
                        SqlCommandBuilder br = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet, "Cars");
                        Console.WriteLine("Car information updated");
                    }
                    else
                    {
                        Console.WriteLine("No update");
                    }
                }
            }
        }
 
 
 
 
        public static void DeleteCar(int deleteId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Cars WHERE CarID =@CarID", connection);
                    command.Parameters.AddWithValue("@CarId", deleteId);
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Cars");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
 
                        DataRow row = dataSet.Tables[0].Rows[0];
                        row.Delete();
                        SqlCommandBuilder br = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet, "Cars");
                        Console.WriteLine("Deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("id not deleted.");
                    }
 
 
 
 
                }
            }
        }
 
 
 
        public static void SearchCar(int searchid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
 
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Cars where CarId = @CarId", connection);
                    command.Parameters.AddWithValue("@CarId", searchid);
                    adapter.SelectCommand = command;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Cars");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = dataSet.Tables[0].Rows[0];
                        Console.WriteLine($"CarID: {row[0]}\tCarMake: {row[1]}\tCarModel: {row[2]}\tYear: {row[3]}\tServiceDate: {row[4]}");
 
                    }
                    else
                    {
                        Console.WriteLine("no search id ");
                    }
                }
 
            }
        }
 
    }
}
 
