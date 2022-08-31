namespace OverSheet.Sample.Modals;

public class SecondPage : ContentPage
{
	public SecondPage()
	{
		Content = new VerticalStackLayout
		{
			BackgroundColor = Colors.Orange,
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Second Page"
				}
			}
		};
	}
}