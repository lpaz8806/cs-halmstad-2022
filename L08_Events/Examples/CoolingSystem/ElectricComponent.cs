namespace Events.Examples.CoolingSystem;

public class ElectricComponent
{
    private int _temperature = 25;
    private bool _working = false;
    
    public int Temperature
    {
        get => _temperature;
        internal set
        {
            if (_temperature == value)
                return;
            
            var old = _temperature;
            _temperature = value;
            TemperatureChanged?.Invoke(this, new TempChangedEventArgs(old, value));
        }
    }
    
    public void StartWork()
    {
        _working = true;
        var random = new Random();

        while (_working)
        {
            Temperature++;
        }
    }

    public void StopWork()
    {
        _working = false;
    }
    
    public event EventHandler<TempChangedEventArgs> TemperatureChanged;
}