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

        // your app goes here
        
    }
}
