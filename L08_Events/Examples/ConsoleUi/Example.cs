namespace Events.Examples.ConsoleUi;

public static class Example
{
    public static void Run()
    {
        var btnOk = new Button("Ok", 0, 0);
        btnOk.Clicked += Accept;
        
        var btnCancel = new Button("Cancel", 0, 15);
        btnCancel.Clicked += Cancel;
        
        var btnExit = new Button("Exit", 15, 0);
        btnExit.Clicked += Exit;
        
        var w = new Window();
        w.Elements.Add(btnOk);
        w.Elements.Add(btnCancel);
        w.Elements.Add(btnExit);

        while (true)
        {
            Console.Write("Type Position (top, left): ");
            var input = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(input))
                return;

            var pos = input
                .Split(",", StringSplitOptions.TrimEntries)
                .Select(x => int.Parse(x))
                .ToArray();

            var top = pos[0];
            var left = pos[1];
            w.Click(top, left);
        }
    }

    static void Accept(object? sender, EventArgs e)
    {
        Console.WriteLine("User has accepted");
    }
    static void Cancel(object? sender, EventArgs e)
    {
        Console.WriteLine("User has canceled");
    }
    static void Exit(object? sender, EventArgs e)
    {
        Environment.Exit(0);
    }
}