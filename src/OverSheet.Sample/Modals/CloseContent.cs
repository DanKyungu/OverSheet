namespace OverSheet.Sample.Modals;

public class CloseContent : ContentView
{
	public CloseContent()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.StartAndExpand, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}