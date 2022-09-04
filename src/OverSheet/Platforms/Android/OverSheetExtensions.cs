using Android.Content;
using Microsoft.Maui.Platform;
using Android.Graphics.Drawables;
using Google.Android.Material.BottomSheet;
using Android.OS;

namespace OverSheet;

public static partial class OverSheetExtensions
{
    private static BottomSheetDialog? BottomSheetDialog;

    public static void ShowBottomSheet(this Page page, IView content, float cornerRadius = 0, bool dismiss = true)
    {
        if (content is ContentView)
            content = ((ContentView)content).Content;

        var context = OverSheetServices.GetCurrentContext() ?? throw new Exception("AndroidContext can not be null");
        var bottomSheetStyle = Resource.Style.BottomSheetStyle;

        BottomSheetDialog = new BottomSheetDialog(context, bottomSheetStyle);
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");

        var viewToShow = content.ToPlatform(mauiContext);

        SetCornerRadius(context, cornerRadius);
        UpdateBackgroundColor(context, viewToShow);

        BottomSheetDialog.SetContentView(viewToShow);
        BottomSheetDialog.Show();

    }

    public static void ShowBottomSheet(this Page page, IView content, float cornerRadius = 0, bool dismiss = true, bool cancelable = true)
    {
        if (content is ContentView)
            content = ((ContentView)content).Content;

        var context = OverSheetServices.GetCurrentContext() ?? throw new Exception("AndroidContext can not be null");
        var bottomSheetStyle = Resource.Style.BottomSheetStyle;

        BottomSheetDialog = new BottomSheetDialog(context, bottomSheetStyle);
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");

        var viewToShow = content.ToPlatform(mauiContext);

        SetCornerRadius(context, cornerRadius);
        UpdateBackgroundColor(context, viewToShow);

        BottomSheetDialog.SetContentView(viewToShow);
        BottomSheetDialog.SetCancelable(cancelable);
        BottomSheetDialog.Behavior.FitToContents = false;
        BottomSheetDialog.Behavior.Draggable = false;
        BottomSheetDialog.Show();

    }

    public static void ShowBottomSheet(this Page page, IView content, IView whenClosed, float cornerRadius = 0, bool dismiss = true, int peekHeight = 0)
    {
        if (content is ContentView)
            content = ((ContentView)content).Content;

        if (whenClosed is ContentView)
            whenClosed = ((ContentView)whenClosed).Content;

        var context = OverSheetServices.GetCurrentContext() ?? throw new Exception("AndroidContext can not be null");
        var bottomSheetStyle = Resource.Style.BottomSheetStyle;

        BottomSheetDialog = new BottomSheetDialog(context, bottomSheetStyle);
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");

        var viewToShow = content.ToPlatform(mauiContext);
        var viewToShowWhenClosed = whenClosed.ToPlatform(mauiContext);

        SetCornerRadius(context, cornerRadius);
        UpdateBackgroundColor(context, viewToShow);


        BottomSheetDialog.Behavior.PeekHeight = peekHeight;

        if (BottomSheetDialog.Behavior.State == BottomSheetBehavior.StateExpanded)
        {
            BottomSheetDialog.SetContentView(viewToShow);
        }
        else if (BottomSheetDialog.Behavior.State == BottomSheetBehavior.StateCollapsed
            || BottomSheetDialog.Behavior.State == BottomSheetBehavior.StateHalfExpanded)
        {
            BottomSheetDialog.SetContentView(viewToShowWhenClosed);
        }

        BottomSheetDialog.Show();
    }


    public static void HideBottomSheet(this Page page)
    {
        if (BottomSheetDialog is not null)
            BottomSheetDialog.DismissWithAnimation = true;

        BottomSheetDialog?.Dismiss();
    }

    public static void HideBottomSheet(this Page page, IView view, int peekHeight = 0)
    {
        int a = 0;
        if (BottomSheetDialog is not null)
        {
            if (view is ContentView)
                view = ((ContentView)view).Content;

            var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");

            var viewToShow = view.ToPlatform(mauiContext);


            BottomSheetDialog.Behavior.SetPeekHeight(peekHeight, true);
            BottomSheetDialog.DismissWithAnimation = true;
            if (BottomSheetDialog.Behavior.State == BottomSheetBehavior.StateDragging)
            {
                System.Diagnostics.Debug.WriteLine(a++, "state");
            }
            BottomSheetDialog.Behavior.Draggable = true;
            BottomSheetDialog.SetContentView(viewToShow);
        }
    }

    public static void SetPeek(this Page page, int peekHeight = 0, bool canSet = true)
    {
        if (BottomSheetDialog is not null)
        {
            BottomSheetDialog.Behavior.SetPeekHeight(peekHeight, true);
        }
    }

    private static void SetCornerRadius(Context? context, float cornerRadius)
    {
        float[] raddi = { cornerRadius, cornerRadius, cornerRadius, cornerRadius, 0, 0, 0, 0 };

        var rounded_shape_drawable = context != null
            ? (GradientDrawable?)context.GetDrawable(Resource.Drawable.sheet_background)
            : null;

        if (rounded_shape_drawable != null)
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