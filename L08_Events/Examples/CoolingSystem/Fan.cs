namespace Events.Examples.CoolingSystem;

public class Fan
{
    private ElectricComponent _component;
    public bool IsOn { get; private set; }
    
    public Fan(ElectricComponent c)
    {
        _component = c;
    }

    public void TurnOn()
    {
        IsOn = true;
        Console.WriteLine("Fan is on");
        Blow();
    }

    public void TurnOff()
    {
        IsOn = false;
        Console.WriteLine("Fan is off");
    }
    
    private void Blow()
    {
        while (IsOn)
        {
            if(_component.Temperature > 0)
                _component.Temperature--;
        }
    }
}