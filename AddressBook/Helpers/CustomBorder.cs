using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
namespace AddressBook.Helpers;

public class CustomBorder : Border
{
    public CustomBorder()
    {
        StrokeThickness = 2;
        HorizontalOptions = LayoutOptions.FillAndExpand;
        StrokeShape = new RoundRectangle
        {
            CornerRadius = new CornerRadius(5)

        };
        Margin = new Thickness(45, 5);
    }

}
