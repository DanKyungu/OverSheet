using UIKit;
using Microsoft.Maui.Platform;
using System.Runtime.Versioning;
using System.Diagnostics.CodeAnalysis;
using ContentView = Microsoft.Maui.Controls.ContentView;

namespace OverSheet;

public static partial class OverSheetExtensions
{
    private static bool IsiOS15OrNewer => UIDevice.CurrentDevice.CheckSystemVersion(15, 0);
    private static UISheetPresentationController? SheetPresentationController;

    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Platform Compatibility is handled internally")]
    public static void ShowBottomSheet(this Page page, IView content, float cornerRadius = 0, bool isPersistent = false)
    {
        if (content is ContentView)
            content = ((ContentView)content).Content;

        if (!IsiOS15OrNewer) throw new Exception("OverSheet is only supported for iOS 15.0 and above");

        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");

        var viewController = page.ToUIViewController(mauiContext);
        var viewControllerToPresent = content.ToUIViewController(mauiContext);

        var sheet = viewControllerToPresent.SheetPresentationController;

        if (sheet is not null)
        {
            SheetPresentationController = sheet;

            sheet.Detents = new[]
            {
                UISheetPresentationControllerDetent.CreateMediumDetent(),
                UISheetPresentationControllerDetent.CreateLargeDetent(),
            };

            sheet.PreferredCornerRadius = cornerRadius;
            sheet.LargestUndimmedDetentIdentifier = isPersistent ? UISheetPresentationControllerDetentIdentifier.Medium : UISheetPresentationControllerDetentIdentifier.Unknown;
            sheet.PrefersScrollingExpandsWhenScrolledToEdge = false;
            sheet.PrefersEdgeAttachedInCompactHeight = true;
            sheet.WidthFollowsPreferredContentSizeWhenEdgeAttached = true;

        }
        viewController.PresentViewController(viewControllerToPresent, animated: true, null);
    }

    [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Platform Compatibility is handled internally")]
    public static void HideBottomSheet(this Page page)
    {
        if (!IsiOS15OrNewer) throw new Exception("OverSheet is only supported for iOS 15.0 and above");

        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");
        var viewController = page.ToUIViewController(mauiContext);

        viewController.DismissModalViewController(true);
    }

    public static void ToggleDetent(this Page page)
    {
        if (!IsiOS15OrNewer) throw new Exception("OverSheet is only supported for iOS 15.0 and above");

        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext can not be null");
        var viewController = page.ToUIViewController(mauiContext);

        SheetPresentationController?.AnimateChanges(() =>
        {
            if (SheetPresentationController.SelectedDetentIdentifier == UISheetPresentationControllerDetentIdentifier.Medium
                || SheetPresentationController.SelectedDetentIdentifier == UISheetPresentationControllerDetentIdentifier.Unknown)
            {
                SheetPresentationController.SelectedDetentIdentifier = UISheetPresentationControllerDetentIdentifier.Large;
            }
            else
            {
                SheetPresentationController.SelectedDetentIdentifier = UISheetPresentationControllerDetentIdentifier.Medium;
            }
        });
    }
}