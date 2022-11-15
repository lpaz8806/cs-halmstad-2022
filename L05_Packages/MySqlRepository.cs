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
        return new List<Customer>();
    }
    public Customer? GetCustomerById(int id)
    {
        return null;
    }

    public void Save(Customer c)
    {
        throw new NotImplementedException();
    }
}