namespace Events.Examples.CoolingSystem;

public static class Example
{
    public static void Run()
    {
        var component = new ElectricComponent();
        component.TemperatureChanged += OnTempChanged;
        
        var fan = new Fan(component);
        component.TemperatureChanged += (sender, e) =>
        {
            if(e.NewTemp > 85)
                fan.TurnOn();
            
            if(e.NewTemp < 45)
                fan.TurnOff();
        }; 
        
        component.StartWork();
    }

    static void OnTempChanged(object? sender, TempChangedEventArgs e)
    {
        Console.WriteLine($"Temp = {e.NewTemp}");
    }
}