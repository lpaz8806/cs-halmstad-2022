using L04_ClassLibraries;

class Program
{
    static void Main(string[] args)
    {
        IProduct[] products = InitProductsList();
        
        while (true)
        {
            ShowMenu(products);
            var choice = ReadChoice("Your choice: ");
            if(choice == -1)
                break;
            
            var chosenProduct = products[choice];
        
            chosenProduct.Buy();
            chosenProduct.Use();
            
            Console.ReadKey(true);
        }
    }
    
    static void ShowMenu(IProduct[] products)
    {
        Console.Clear();
        
        for (int i = 0; i < products.Length; i++)
            Console.WriteLine($"{i + 1}- {products[i].Name}");

        Console.WriteLine($"{products.Length + 1}- Quit");
        
        Console.WriteLine();
    }

    static IProduct ChooseProduct(IProduct[] products)
    {
        var choice = ReadChoice("Your choice: ");
        return products[choice - 1];
    }

    static int ReadChoice(string message)
    {
        Console.Write(message);
        var choice = int.Parse(Console.ReadLine() ?? string.Empty);
        return choice - 1;
    }
    
    static IProduct[] InitProductsList()
    {
        return new IProduct[]
        {
            new Food("Chips", "Nasty"),
            new Food("Burger", "Makes you fat, yet happy"),
        
            new Drink("Zingo", "best orange soda"),
            new Drink("CocaCola", "capitalism sign"),
            
            new Cloth("T-shirt", "Never in winter"),
            new Cloth("Tröja", "Nice and warm"),
            
            new Alcohol("Prips blå", "Ses under bordet")
        };
    }
}
