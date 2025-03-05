using System;
using System.Collections;

public class Toy
{
    public int ToyID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Cost { get; set; }

    public Toy() { }

    public Toy(int id, string name, string type, int cost)
    {
        this.ToyID = id;
        this.Name = name;
        this.Type = type;
        this.Cost = cost;
    }
}

public class ToyManager
{
    public ArrayList toys = new ArrayList(); // Changed from Dictionary to ArrayList

    public void Show()
    {
        if (toys.Count == 0)
        {
            Console.WriteLine("Record not Found");
        }

        foreach (Toy item in toys)
        {
            Console.WriteLine($"ToyID: {item.ToyID}, Name: {item.Name}, Type: {item.Type}, Cost: {item.Cost}");
        }
    }

    public void SearchToy(int id)
    {
        bool found = false;
        foreach (Toy item in toys)
        {
            if (item.ToyID == id)
            {
                Console.WriteLine("Record Found with ID :" + id);
                Console.WriteLine($"ToyID: {item.ToyID}, Name: {item.Name}, Type: {item.Type}, Cost: {item.Cost}");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("No Record Available with Id: " + id);
        }
    }

    public void DeleteToy(int id)
    {
        Toy toyToDelete = null;
        foreach (Toy item in toys)
        {
            if (item.ToyID == id)
            {
                toyToDelete = item;
                break;
            }
        }
        if (toyToDelete != null)
        {
            toys.Remove(toyToDelete);
            Console.WriteLine("Toy deleted successfully.");
        }
        else
        {
            Console.WriteLine("No Record Available with Id: " + id);
        }
    }

    public void AddToy(Toy toy)
    {
        foreach (Toy item in toys)
        {
            if (item.ToyID == toy.ToyID)
            {
                Console.WriteLine($"A toy with ID {toy.ToyID} already exists");
                return;
            }
        }

        toys.Add(toy);
        Console.WriteLine("Toy added successfully.");
    }

    public void EditToy(int id, string name, string newtype, int newcost)
    {
        foreach (Toy item in toys)
        {
            if (item.ToyID == id)
            {
                item.Name = name;
                item.Type = newtype;
                item.Cost = newcost;
                Console.WriteLine("Toy updated successfully.");
                return;
            }
        }

        Console.WriteLine($"No toy with ID {id} found");
    }
}

public class Program
{
    public static ToyManager m = new ToyManager();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Show");
            Console.WriteLine("4. Search by Id");
            Console.WriteLine("5. Delete by Id");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    AddToy();
                    break;
                case 2:
                    EditToy();
                    break;
                case 3:
                    m.Show();
                    break;
                case 4:
                    Console.Write("Enter id to search: ");
                    int id = int.Parse(Console.ReadLine());
                    m.SearchToy(id);
                    break;
                case 5:
                    Console.Write("Enter id to Delete: ");
                    int id1 = int.Parse(Console.ReadLine());
                    m.DeleteToy(id1);
                    break;
                case 6:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    public static void AddToy()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Type: ");
        string type = Console.ReadLine();
        Console.Write("Cost: ");
        int cost = int.Parse(Console.ReadLine());

        Toy tt = new Toy(id, name, type, cost);
        m.AddToy(tt);
    }

    public static void EditToy()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Type: ");
        string type = Console.ReadLine();
        Console.Write("Cost: ");
        int cost = int.Parse(Console.ReadLine());

        m.EditToy(id, name, type, cost);
    }
}
