namespace Events.Exercises;

/*
1. Read the operation (string, either "sum" or "mul")
2. Reduce the array depending on the operation
3. print the result

2.1 Implement the Reduce method.
*/

public static class ReduceArray
{
    public static void Run()
    {
        int[] numbers = {1, 2, 3, 4, 5};
        
        // read the operation "sum", "mul"
        var operation = Console.ReadLine() ?? string.Empty;
        
        // don't get scared about this. use if-else / switch if you prefer
        Func<int, int, int> op = operation switch
        {
            "sum" => Sum,
            "mul" => Mul,
            _ => throw new InvalidOperationException("Invalid option")
        };
        
        var result = Reduce(numbers, op);
        Console.WriteLine($"{operation}(1,2,3,4,5) = {result}");
    }

    public static void Run2()
    {
        int[] numbers = {1, 2, 3, 4, 5};

        string[] names = {"0. Sum", "1. Mul", "2. 2x+y"};
        
        Func<int, int, int>[] functions =
        {
            Sum,
            Mul,
            (x, y) => 2 * x + y
        };

        Console.WriteLine(string.Join("\n", names));
        Console.Write("Your choice: ");
        int i = int.Parse(Console.ReadLine() ?? string.Empty);

        var result = Reduce(numbers, functions[i]);
        Console.WriteLine(result);
    }
    
    // figure it out what type (delegate) is func
    static int Reduce(int[] numbers, Func<int, int, int> func)
    {
        var result = numbers[0];        // keep the first as result

        for (var i = 1; i < numbers.Length; i++)
            result = func(result, numbers[i]);
        
        return result;
    }
    
    static int Sum(int x, int y) => x + y;
    static int Mul(int x, int y) => x * y;
}
