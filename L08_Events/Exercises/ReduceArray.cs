namespace Events.Exercises;

public static class ReduceArray
{
    public static void Run()
    {
        int[] numbers = {1, 2, 3, 4, 5};
        
        // read one number
        int x;
        // read another
        int y;

        // read the operation "sum", "mul"
        string operation = default;
        
        var result = Reduce(numbers, Mul); // 120


        Console.WriteLine($"{operation}(1,2,3,4,5) = {result}");
    }

    // 
    static int Reduce(int[] numbers, object func)
    {
        return default;
    }
    
    static int Sum(int x, int y) => x + y;
    static int Mul(int x, int y) => x * y;
}