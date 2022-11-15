// See https://aka.ms/new-console-template for more information

// Packages
// Koppla till Databas

using System.Threading.Channels;
using L05_Packages;
using MySqlConnector;

var server = "localhost";
var username = "pepe";
var password = "pepe";
var db = "carsales_db";

var connectionString =
    $"SERVER={server};DATABASE={db};UID={username};PASSWORD={password}";

using var connection = new MySqlConnection(connectionString);

var repo = new MySqlRepository(connection);

// Console.WriteLine(string.Join('\n', repo.GetAllCustomers()));

var customer = repo.GetCustomerById(4);

Console.WriteLine(customer);
customer.FirstName = "'; DROP TABLE secret; -- ";
repo.Save(customer);

// Console.WriteLine(repo.GetCustomerById(4));