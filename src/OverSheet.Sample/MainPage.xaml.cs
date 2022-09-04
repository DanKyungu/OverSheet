
using OverSheet.Sample.Modals;

namespace OverSheet.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void ShowBottomSheet_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.ShowBottomSheet(GetBottomSheetView(), 40, true);
            SemanticScreenReader.Announce(ShowBottomSheet.Text);

        }

        private void HideBottomSheet_Clicked(object sender, EventArgs e)
        {
            //this.HideBottomSheet();
            Application.Current.MainPage.ShowBottomSheet(new FirstPage(), 0, false, false);
            SemanticScreenReader.Announce(HideBottomSheet.Text);
        }

        private View GetBottomSheetView()
        {
            var view = (View)BottomSheetTemplate.CreateContent();
            //view.BindingContext = BindingContext;
            return view;
        }
    }
}