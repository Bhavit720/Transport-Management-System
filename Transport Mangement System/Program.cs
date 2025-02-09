using System;
using System.Collections.Generic;

class BusSystem
{
    // Passenger Information
    public List<string> Names = new List<string>();
    public List<int> Ids = new List<int>();
    public List<string> Genders = new List<string>();
    public List<int> Ages = new List<int>();

    // Bus Data
    private int[] busCapacities = { 40, 40, 40, 40, 40, 40, 40, 40, 40, 40 };
    private int[] passengersInBus = new int[10];

    // Finance Data
    public double Debit { get; set; }
    public double Losses { get; set; }
    public double Income { get; set; }

    // Staff Information
    public List<string> DriverNames = new List<string>();
    public List<int> DriverIds = new List<int>();
    public List<double> DriverSalaries = new List<double>();

    public List<int> ManagerAges = new List<int>();
    public List<int> ManagerIds = new List<int>();
    public List<double> ManagerSalaries = new List<double>();

    // Resume Feature
    public Dictionary<int, string> Resumes = new Dictionary<int, string>();

    // Constructor
    public BusSystem()
    {
        for (int i = 0; i < 10; i++)
            passengersInBus[i] = 0;
    }

    // Add Passenger
    public void AddPassenger(string name, int id, string gender, int age, int busNumber)
    {
        if (busNumber < 1 || busNumber > 10)
        {
            Console.WriteLine("Invalid Bus Number!");
            return;
        }

        int busIndex = busNumber - 1;

        if (passengersInBus[busIndex] < busCapacities[busIndex])
        {
            Names.Add(name);
            Ids.Add(id);
            Genders.Add(gender);
            Ages.Add(age);
            passengersInBus[busIndex]++;
            Console.WriteLine($"Passenger {name} added to Bus A{busNumber}");
        }
        else
        {
            Console.WriteLine($"Bus A{busNumber} is full!");
        }
    }

    // Display Passengers of a Bus
    public void ShowPassengers(int busNumber)
    {
        if (busNumber < 1 || busNumber > 10)
        {
            Console.WriteLine("Invalid Bus Number!");
            return;
        }

        int busIndex = busNumber - 1;

        if (passengersInBus[busIndex] == 0)
        {
            Console.WriteLine($"There are no passengers in Bus A{busNumber}");
        }
        else
        {
            Console.WriteLine($"Passengers in Bus A{busNumber}:");
            for (int i = 0; i < Names.Count; i++)
            {
                Console.WriteLine($"Name: {Names[i]}, ID: {Ids[i]}, Gender: {Genders[i]}, Age: {Ages[i]}");
            }
        }
    }

    // Finance Menu
    public void FinanceMenu()
    {
        Console.WriteLine("\n--- Finance Menu ---");
        Console.WriteLine("1. Check Total Debit");
        Console.WriteLine("2. Record Extra Losses");
        Console.WriteLine("3. Check Total Income");
        Console.Write("Enter choice: ");
        byte choice = Convert.ToByte(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine($"Total Debit: {Debit}");
                break;
            case 2:
                Console.Write("Enter extra losses: ");
                Losses = Convert.ToDouble(Console.ReadLine());
                Income -= Losses;
                Console.WriteLine("Loss recorded.");
                break;
            case 3:
                Console.WriteLine($"Total Income: {Income}");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    // Display Staff Information
    public void ShowStaffInfo()
    {
        Console.WriteLine("\n--- Staff Information ---");

        Console.WriteLine("\nDrivers:");
        for (int i = 0; i < DriverNames.Count; i++)
            Console.WriteLine($"Name: {DriverNames[i]}, ID: {DriverIds[i]}, Salary: {DriverSalaries[i]}");

        Console.WriteLine("\nManagers:");
        for (int i = 0; i < ManagerAges.Count; i++)
            Console.WriteLine($"ID: {ManagerIds[i]}, Age: {ManagerAges[i]}, Salary: {ManagerSalaries[i]}");
    }

    // Resume Feature
    public void ManageResumes()
    {
        Console.WriteLine("\n--- Resume Manager ---");
        Console.WriteLine("1. Save Resume");
        Console.WriteLine("2. View Resume");
        Console.Write("Enter choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Enter your ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter your resume details: ");
                string resume = Console.ReadLine();
                Resumes[id] = resume;
                Console.WriteLine("Resume saved successfully.");
                break;
            case 2:
                Console.Write("Enter your ID: ");
                id = Convert.ToInt32(Console.ReadLine());
                if (Resumes.ContainsKey(id))
                    Console.WriteLine($"Your Resume:\n{Resumes[id]}");
                else
                    Console.WriteLine("Resume not found.");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    // Main Menu
    public void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Add Passenger");
            Console.WriteLine("2. Show Passengers");
            Console.WriteLine("3. Finance Menu");
            Console.WriteLine("4. Show Staff Info");
            Console.WriteLine("5. Resume Manager");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Gender: ");
                    string gender = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Bus Number (1-10): ");
                    int busNum = Convert.ToInt32(Console.ReadLine());
                    AddPassenger(name, id, gender, age, busNum);
                    break;
                case 2:
                    Console.Write("Enter Bus Number (1-10): ");
                    busNum = Convert.ToInt32(Console.ReadLine());
                    ShowPassengers(busNum);
                    break;
                case 3:
                    FinanceMenu();
                    break;
                case 4:
                    ShowStaffInfo();
                    break;
                case 5:
                    ManageResumes();
                    break;
                case 6:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

// Main Execution
class Program
{
    static void Main()
    {
        BusSystem busSystem = new BusSystem();
        busSystem.MainMenu();
    }
}
