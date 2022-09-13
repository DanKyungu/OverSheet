using Microsoft.Maui;
using Microsoft.Maui.Controls.Shapes;
using OverSheet.Sample.Modals;
using System.Linq.Expressions;

namespace OverSheet.Sample;

public class MainPage : ContentPage
{
	public MainPage()
	{
		Content = new VerticalStackLayout
		{
			VerticalOptions = LayoutOptions.Center,
			Children = {
                new Image()
                {
                    Source = "over_sheet.png",
                    Margin = new Thickness(40),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    WidthRequest = 120,
                    HeightRequest = 120
                },
                new Button()
				{
					Text = "Show Dialog BottomSheet",
					VerticalOptions = LayoutOptions.Center,
					Margin = new Thickness(60,40,60,0),
					BackgroundColor = Color.FromHex("#10A86C"),
                    Command = new Command(() => App.Current.MainPage.ShowBottomSheet(new BottomSheetPage(),35,true))
				},
                new Button()
                {
                    Text = "Show Presistent BottomSheet",
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(60,20,60,0),
                    BackgroundColor = Color.FromHex("#10A86C")
                }
            }
		};
	}
}