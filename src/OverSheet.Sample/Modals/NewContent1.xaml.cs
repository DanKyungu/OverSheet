namespace OverSheet.Sample.Modals;

public partial class NewContent1 : ContentView
{
    public NewContent1()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void opentBtn_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage.ShowBottomSheet(new FirstPage(), 0, false, false);

    }
}