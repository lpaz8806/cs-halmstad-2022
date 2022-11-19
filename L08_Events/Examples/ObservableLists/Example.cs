namespace Events.Examples.ObservableLists;

public static class Example
{
    public static void Run()
    {
        var numbers = new ObservableList("Kalle");
        
        // subscribe to an event
        numbers.ItemAdded += OnItemAdded;
        numbers.ItemAdded += UpdateDatabase;

        // public delegate void EventHandler(object? sender, EventArgs e);
        numbers.Add(-1);
        
        // unsubscribe a handler from an event
        numbers.ItemAdded -= UpdateDatabase;
        
        Run(numbers);
    }

    // read a number. if even, add it to the list
    private static void Run(ObservableList numbers)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                return;

            var number = int.Parse(input);
            var isEven = number % 2 == 0;  // explanatory variable
            if (isEven)
                numbers.Add(number);
        }
    }

    static void OnItemAdded(object? sender, EventArgs e)
    {
        var list = sender as ObservableList;
        Console.WriteLine($"An item was added to {list.Owner}'s list");
    }
    
    static void UpdateDatabase(object? sender, EventArgs e)
    {
        var list = sender as ObservableList;
        Console.WriteLine($"The db was updated with the new item");
    }
}
