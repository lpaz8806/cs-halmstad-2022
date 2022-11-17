/*
Agenda:
    [X] Delegates
    [X] Action, Func and Predicate
    [X] Anonymous delegates / Lambda expressions
    [] Events
*/
class Program
{
    static void Main(string[] args)
    {
        string[] words = {"Foo", "Bar", "hello", "foo", "goo", "Lisa"};
        
        // 2nd letter is 'e'   pos = 1

        var i = FindFirst(words, word => word.Length > 1 && word[1] == 'i');
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

// Delegates

// bool (string)
public delegate bool StringCondition(string str);  // type

public delegate bool Foo(string www);
