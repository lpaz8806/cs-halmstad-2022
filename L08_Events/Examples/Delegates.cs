namespace Events.Examples;

public static class Delegates
{
    /// <summary>
    /// Find the first word starting with capital letter
    /// </summary>
    public static void RunExample1()
    {
        string[] words = {"Foo", "Bar", "hello", "foo", "goo", "Lisa"};
        
        var i = FindFirst(words, StartsWithUpperCase);
        Console.WriteLine(i);
    }
    /// <summary>
    /// Find the first word which second letter is 'e'
    /// </summary>
    public static void RunExample2()
    {
        string[] words = {"Foo", "Bar", "hello", "foo", "goo", "Lisa"};
        
        var i = FindFirst(words, word => word.Length > 1 && word[1] == 'e');
        Console.WriteLine(i);
    }
    
    
    static int FindFirst(string[] words, Predicate<string> condition)
    {
        for (var i = 0; i < words.Length; i++)
            if (condition(words[i]))
                return i;
        
        return -1;
    }
    
    static bool StartsWithLowerCase(string s)
    {
        return s.Length > 0 && char.IsLower(s[0]);
    }
    static bool StartsWithUpperCase(string s)
    {
        return s.Length > 0 && char.IsUpper(s[0]);
    }
    static bool HasLength3(string s)
    {
        return s.Length == 3;
    }
    static bool HasLength4(string s)
    {
        return s.Length == 4;
    }
}


// Method signature
// StartsWithLowerCase => bool (string)
// StartsWithUpperCase => bool (string)
// HasLength3 => bool (string)

// References to functions / methods

// Delegates (syntax)

// bool (string)
public delegate bool StringCondition(string str);  // type
public delegate bool Foo(string www);   // same as StringCondition, they represent the same family of methods

/*
Since delegates with same signature represents the same family of methods, we don't need to define our
own delegates in most of the cases. dotnet is shipped with the most common delegates you need:

Action<T1, T2 ...> for methods that return "void"
Func<T1,T2, ..., TResult> for methods that return TResult
Predicate<T1, T2 ...> for methods that return "bool"

Notice that, for example,
Predicate<int> and Func<int,bool> represents the same family of methods.

The reason for having a special delegate "Predicate" is because in the industry,
functions returning bool are known as predicates
*/