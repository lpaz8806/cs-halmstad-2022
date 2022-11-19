namespace Events.Examples.ConsoleUi;

public interface IUiElement
{
    string Name { get; }
    int Top { get; }
    int Left { get; }
    int Width { get; }
    int Height { get; }

    event EventHandler Clicked;
    void Click();

    void Display();
}