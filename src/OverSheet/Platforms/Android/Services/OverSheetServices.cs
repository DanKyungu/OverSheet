using Android.Content;

namespace OverSheet
{
    public static class OverSheetServices
    {
        public static Context? GetCurrentContext()
         => Platform
           .CurrentActivity?.Window?
           .DecorView.FindViewById(Android.Resource.Id.Content)?.RootView?.Context;
    }
}
