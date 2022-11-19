namespace Events.Examples.ConsoleUi;

public class Window
{
    public List<IUiElement> Elements { get; } = new();

    public void Click(int top, int left)
    {
        foreach (var el in Elements)
        {
            if(IsInside(top, left, el))
                el.Click();
        }
    }

    private bool IsInside(int top, int left, IUiElement el)
    {
        return
            top >= el.Top &&
            top <= el.Top + el.Height &&
            left >= el.Left &&
            left <= el.Left + el.Width;
    }
}