using Google.Android.Material.BottomSheet;

namespace OverSheet.Platforms.Android.Services;

public class BottomSheetCallbackExtension : BottomSheetBehavior.BottomSheetCallback
{
    public override void OnSlide(global::Android.Views.View bottomSheet, float newState)
    {
        System.Diagnostics.Debug.Write(newState);
    }

    public override void OnStateChanged(global::Android.Views.View p0, int p1)
    {
        var state = p1;
        switch (state)
        {
            case BottomSheetBehavior.StateCollapsed:
                System.Diagnostics.Debug.WriteLine("state has changed to Collapsed");
                break;
            
            case BottomSheetBehavior.StateExpanded:
                System.Diagnostics.Debug.WriteLine("state has changed to Expanded");
                break;

            case BottomSheetBehavior.StateHalfExpanded:
                System.Diagnostics.Debug.WriteLine("state has changed to StateHalfExpanded");
                break;

        }
        
    }
}
