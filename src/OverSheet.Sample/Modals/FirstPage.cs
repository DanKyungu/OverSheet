namespace OverSheet.Sample.Modals;

public class FirstPage : ContentView
{
    public FirstPage()
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
                    VerticalOptions = LayoutOptions.Center,
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
                            Text = "First Page",

                        },
                        new Button
                        {
                            Text = "Dismiss",
                            Command = new Command(() => App.Current.MainPage.HideBottomSheet(new NewContent1(),200))
                        }
                    }
                }
            }
        };
    }
}