using Microsoft.Maui.LifecycleEvents;

namespace OverSheet.Hosting;

/// <summary>
/// Represent application host extension, that used to configure OverSheet 
/// </summary>
public static class AppHostBuilderExtensions
{
    /// <summary>
    /// Automatically sets up lifecycle events and Maui Handlers
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static MauiAppBuilder ConfigureOverSheet(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(lifeCycle =>
        {
#if ANDROID
            lifeCycle.AddAndroid(d =>
            {
                d.OnStart((o) =>
                {
                    OverSheet.OverSheetExtensions.InitializePeristentBottomSheet();
                });
            });
#endif
        });

        return builder;
    }
}
