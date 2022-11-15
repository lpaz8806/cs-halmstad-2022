using MySqlConnector;

namespace L05_Packages;

public class MySqlRepository : IRepository
{
    private MySqlConnection _conn;

    public MySqlRepository(MySqlConnection conn)
    {
        _conn = conn;
    }
    
    public List<Customer> GetAllCustomers()
    {
        _conn.Open();
        var query = "SELECT * FROM customer";
        var command = new MySqlCommand(query, _conn);

        var reader = command.ExecuteReader();

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
        _conn.Close();
        return customers;
    }
    public Customer? GetCustomerById(int id)
    {
        _conn.Open();
        var query = $"SELECT * FROM customer WHERE customer_id = {id}";
        var command = new MySqlCommand(query, _conn);

        var reader = command.ExecuteReader();
        var customer = !reader.Read()
            ? null
            : new Customer()
            {
                Id = reader.GetInt32("customer_id"),
                FirstName = reader.GetString("customer_firstname"),
                LastName = reader.GetString("customer_lastname"),
                Phone = reader.GetInt32("customer_telephone").ToString(),
            };
        
        _conn.Close();
        return customer;
    }

    public void Save(Customer c)
    {
        if(c.Id == 0)
            Insert(c);
        else
            Update(c);
    }

    private void Insert(Customer c)
    {
        _conn.Open();
        var query =
            "INSERT INTO customer(customer_firstname, customer_lastname,customer_telephone)" +
            $"VALUES('{c.FirstName}', '{c.LastName}', '{c.Phone}')";
        
        var command = new MySqlCommand(query, _conn);
        command.ExecuteNonQuery();
        _conn.Close();
    }
    private void Update(Customer c)
    {
        _conn.Open();
        var query =
            "UPDATE customer SET " +
            $"customer_firstname = '{c.FirstName}'," +
            $"customer_lastname = '{c.LastName}'," +
            $"customer_telephone = '{c.Phone}' " +
            $"WHERE customer_id = {c.Id}";
        
        var command = new MySqlCommand(query, _conn);
        
        command.ExecuteNonQuery();
        
    }
}