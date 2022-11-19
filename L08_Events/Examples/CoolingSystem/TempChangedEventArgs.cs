namespace Events.Examples.CoolingSystem;

public class TempChangedEventArgs : EventArgs
{
    public int OldTemp { get; }
    public int NewTemp { get; }

    public TempChangedEventArgs(int old, int @new)
    {
        OldTemp = old;
        NewTemp = @new;
    }
}