using Android.Content;
using Microsoft.Maui.Platform;
using Android.Graphics.Drawables;
using Google.Android.Material.BottomSheet;

namespace OverSheet;

public static partial class OverSheetExtensions
{
    private static BottomSheetDialog? BottomSheetDialog;

    public static void ShowBottomSheet(this Page page, IView content, float cornerRadius = 0, bool dismiss = true)
    {
        if(content is ContentView)
            content = ((ContentView)content).Content;

        var context = OverSheetServices.GetCurrentContext() ?? throw new Exception("AndroidContext can not be null");
        var bottomSheetStyle = Resource.Style.BottomSheetStyle;

        BottomSheetDialog = new BottomSheetDialog(context, bottomSheetStyle);
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");

        var viewToShow = content.ToPlatform(mauiContext);


        SetCornerRadius(context, cornerRadius);
        UpdateBackgroundColor(context,viewToShow);

        BottomSheetBehavior.From(viewToShow);

        BottomSheetDialog.SetContentView(viewToShow);
        //BottomSheetDialog.Show();
        
    }

    public static void HideBottomSheet(this Page page)
    {
        if(BottomSheetDialog is not null)
            BottomSheetDialog.DismissWithAnimation = true;

        BottomSheetDialog?.Dismiss();
    }

    private static void SetCornerRadius(Context? context, float cornerRadius)
    {
        float[] raddi = { cornerRadius, cornerRadius, cornerRadius, cornerRadius, 0, 0, 0, 0 };

        var rounded_shape_drawable = context != null
            ? (GradientDrawable?)context.GetDrawable(Resource.Drawable.sheet_background)
            : null;
        
        if(rounded_shape_drawable != null)
            rounded_shape_drawable.SetCornerRadii(raddi);
    }

    private static void UpdateBackgroundColor(Context? context, Android.Views.View? viewToShow)
    {
        if (viewToShow == null)
            return;

        var rounded_shape_drawable = context != null
            ? (GradientDrawable?)context.GetDrawable(Resource.Drawable.sheet_background)
            : null;

        if (viewToShow.Background != null)
        {
            var drawable = (ColorDrawable)viewToShow.Background;
            rounded_shape_drawable?.SetColor(drawable.Color);
        }
        else
        {
            rounded_shape_drawable?.SetColor(Colors.White.ToInt());
        }

        viewToShow.Background = rounded_shape_drawable;
    }
}