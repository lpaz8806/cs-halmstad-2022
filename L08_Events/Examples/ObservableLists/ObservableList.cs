namespace Events.Examples.ObservableLists;

public class ObservableList
{
    private List<int> _numbers = new();

    public string Owner { get; }

    public ObservableList(string owner)
    {
        Owner = owner;
    }
    
    public void Add(int n)
    {
        _numbers.Add(n);
        ItemAdded?.Invoke(this, EventArgs.Empty);
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _numbers)}]";
    }
    
    // publish an event
    public event EventHandler ItemAdded;
}