using Android.Content;
using Microsoft.Maui.Platform;
using Android.Graphics.Drawables;
using Google.Android.Material.BottomSheet;
using Android.Views;
using AndroidX.CoordinatorLayout.Widget;
using Android.App;
using View = Android.Views.View;
using Android.Widget;

namespace OverSheet;

public static partial class OverSheetExtensions
{
    private static BottomSheetDialog? BottomSheetDialog;
    private static BottomSheetBehavior CurrentBehavior;

    public static void ShowBottomSheet(this Page page, IView content, float cornerRadius = 0,bool isDismissable = true, bool isPersistent = false)
    {
        if(content is ContentView)
            content = ((ContentView)content).Content;

        var context = OverSheetServices
            .GetCurrentContext() ?? throw new Exception("AndroidContext can not be null");

        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");

        var viewToShow = content.ToPlatform(mauiContext);

        if (isPersistent)
        {
            ShowPeristentBottomSheet(viewToShow);
            return;
        }

        var bottomSheetStyle = Resource.Style.BottomSheetStyle;

        BottomSheetDialog = new BottomSheetDialog(context, bottomSheetStyle);

        BottomSheetDialog.Behavior.Draggable = isDismissable;

        SetCornerRadius(context, cornerRadius);
        UpdateBackgroundColor(context,viewToShow);

        BottomSheetDialog.SetContentView(viewToShow);
        BottomSheetDialog.Show();
        
    }

    public static void HideBottomSheet(this Page page)
    {
        if(BottomSheetDialog is not null)
            BottomSheetDialog.DismissWithAnimation = true;

        BottomSheetDialog?.Dismiss();
    }

    public static void ToggleDetent(this Page page)
    {
        CurrentBehavior.State = BottomSheetBehavior.StateCollapsed;

        if (BottomSheetDialog is not null)
        {
            BottomSheetDialog.DismissWithAnimation = true;

            if (BottomSheetDialog.Behavior.State != BottomSheetBehavior.StateExpanded)
            {
                BottomSheetDialog.Behavior.State = BottomSheetBehavior.StateExpanded;
            }
            else
            {
                BottomSheetDialog.Behavior.State = BottomSheetBehavior.StateCollapsed;
            }
        }
    }

    private static void ShowPeristentBottomSheet(View view)
    {
        if (Platform.CurrentActivity is not Activity activity)
            return;

        CoordinatorLayout? frameLayout = (CoordinatorLayout?)activity?.FindViewById(Resource.Id.persistent_bottomSheet_container);
        
        if(frameLayout?.ChildCount > 0)
        {
            frameLayout.RemoveAllViews();
            frameLayout?.AddView(view);
        }
        else
        {
            frameLayout?.AddView(view);
        }

        if (CurrentBehavior?.State == BottomSheetBehavior.StateHidden)
        {
            CurrentBehavior.State = BottomSheetBehavior.StateExpanded;
            return;
        }
    }

    public static void InitializePeristentBottomSheet(this Page page)
    {
        if (Platform.CurrentActivity is not Activity activity)
            return;

        CoordinatorLayout? frameLayout = (CoordinatorLayout?)activity?.FindViewById(80000000);

        if (frameLayout != null)
            return;
        
        var context = OverSheetServices
            .GetCurrentContext() ?? throw new Exception("AndroidContext can not be null");

        ViewGroup? nativeLayer;

        ViewGroup? viewGroup = (ViewGroup?) activity?.FindViewById(Android.Resource.Id.Content);
        nativeLayer = viewGroup?.GetFirstChildOfType<CoordinatorLayout>() ?? null;

        if (nativeLayer is null) return;

        frameLayout = new CoordinatorLayout(activity?.ApplicationContext);
        frameLayout.Id = Resource.Id.persistent_bottomSheet_container;

        var layoutParams = new CoordinatorLayout.LayoutParams(CoordinatorLayout.LayoutParams.MatchParent, CoordinatorLayout.MarginLayoutParams.WrapContent);
        layoutParams.Behavior = new BottomSheetBehavior(context, null);

        //frameLayout.AddView(view);
        nativeLayer?.AddView(frameLayout, layoutParams);

        var behavior = BottomSheetBehavior.From(frameLayout);
        CurrentBehavior = behavior;

        behavior.SetPeekHeight(200, true);
        behavior.Hideable = true;
        behavior.State = BottomSheetBehavior.StateHidden;
    }

    private static void SetCornerRadius(Context? context, float cornerRadius)
    {
        float[] raddi = { cornerRadius, cornerRadius, cornerRadius, cornerRadius, 0, 0, 0, 0 };

        var drawab = context.GetDrawable(Resource.Drawable.sheet_background);

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