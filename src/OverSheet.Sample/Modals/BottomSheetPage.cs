namespace OverSheet.Sample.Modals;

public class BottomSheetPage : ContentView
{
	public BottomSheetPage()
	{
		Content = new Grid
		{
			Padding = new Thickness(50),
			VerticalOptions = LayoutOptions.Center,
			BackgroundColor = Colors.White,
			HeightRequest = 400,
			Children = {
				new VerticalStackLayout
				{
                    VerticalOptions = LayoutOptions.Start,
                    Spacing = 20,
                    Children =
					{
                        new Label
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 35,
                            TextColor = Colors.Black,
                            Text = "Bottom Sheet",
                            Margin = new Thickness(0,20,0,0),
                        },
                        new Button
                        {
                            Text = "Dismiss",
                            Command = new Command(() => App.Current.MainPage.HideBottomSheet())
                        },
                        new Button
                        {
                            Text = "Toggle Detent",
                            Command = new Command(() => App.Current.MainPage.ToggleDetent())
                        }
                    }
                }
			}
		};
	}
}