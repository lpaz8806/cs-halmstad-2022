namespace Events.Examples.ConsoleUi;

public abstract class UiElementBase : IUiElement
{
    public string Name { get; }
    public int Top { get; set; }
    public int Left { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public event EventHandler? Clicked;

    protected UiElementBase(string name, int top, int left, int width = 10, int height = 10)
    {
        Name = name;
        Top = top;
        Left = left;
        Width = width;
        Height = height;
    }
    
    public virtual void Click()
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }

    public virtual void Display()
    {
        
    }
}