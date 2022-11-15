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
connection.Open();

var query = "SELECT * FROM customer";
var command = new MySqlCommand(query, connection);

var reader = command.ExecuteReader();
string[] columns =
{
    "customer_id",
    "customer_firstname",
    "customer_lastname",
    "customer_telephone"
};

List<Customer> customers = new();
while (reader.Read())
{
    customers.Add(new Customer()
    {
        Id = reader.GetInt32("customer_id"),
        FirstName = reader.GetString("customer_firstname"),
        LastName = reader.GetString("customer_lastname"),
        Phone = reader.GetInt32("customer_telephone").ToString(),
    });
}

foreach(var customer in customers)
    Console.WriteLine(customer);