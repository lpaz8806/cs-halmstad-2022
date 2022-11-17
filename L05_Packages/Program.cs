// See https://aka.ms/new-console-template for more information

// Packages
// Koppla till Databas

using L05_Packages;
using MySqlConnector;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = File.ReadAllLines("config.txt")[0];
        using var connection = new MySqlConnection(connectionString);
        var repo = new MySqlRepository(connection);
        var customers = repo.GetAllCustomers();


        while (true)
        {
            PrintCustomersMenu(customers);
            var customer = ChooseCustomerOrQuit("Choose customer (leave blank to quit): ", customers);
            if (customer == null)
            {
                ShowMessageAndWaitForAKey("Invalid choice");
                continue;
            }
            
            DoUpdateCustomer(customer);
            repo.Save(customer);
            ShowMessageAndWaitForAKey("Customer updated");
        }
    }

    static void PrintCustomersMenu(List<Customer> customers)
    {
        for (var i = 0; i < customers.Count; i++)
            Console.WriteLine($"{i + 1}. {customers[i]}");

        Console.WriteLine();
    }

    static Customer? ChooseCustomerOrQuit(string message, List<Customer> customers)
    {
        var input = ReadStringOrDefault(message);

        if (string.IsNullOrEmpty(input))
            Environment.Exit(0);    // very nasty hack, but for now we can live with it
        
        // this line will attempt to convert the input to int and save the result in choice.
        // if failure, choice will be set to the default value (0)
        int.TryParse(input, out var choice);
        
        if (choice > 1 && choice < customers.Count) // if choice in range
            return customers[choice - 1];       // -1 to match the list index
        
        return null; // very bad idea to return null, but for now we can live with it
    }
    static void DoUpdateCustomer(Customer c)
    {
        c.FirstName = ReadStringOrDefault($"New first name [{c.FirstName}]: ", c.FirstName);
        c.LastName = ReadStringOrDefault($"New last name [{c.LastName}]: ", c.LastName);
        c.Phone = ReadStringOrDefault($"New phone [{c.Phone}]: ", c.Phone);
    }
    
    static string ReadStringOrDefault(string message, string defaultValue = "")
    {
        Console.Write(message);
        var input = Console.ReadLine();
        return string.IsNullOrEmpty(input) ? defaultValue : input;
    }

    static void ShowMessageAndWaitForAKey(string message)
    {
        Console.WriteLine($"{message}. Press any key to continue...");
        Console.ReadKey(true);
    }
}
