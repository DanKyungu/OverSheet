using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public static MauiAppBuilder ConfigureOverSheet(this MauiAppBuilder builder, Page page)
    {
#if ANDROID
                page.InitializePeristentBottomSheet();
#endif

        return builder;
    }
}
