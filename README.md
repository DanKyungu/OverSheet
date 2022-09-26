![OverSheet](https://github.com/DanKyungu/OverSheet/raw/main/img/OverSheet.png)

# OverSheet for MAUI
**OverSheet** - is a cross platform plugin for [MAUI](https://dotnet.microsoft.com/en-us/apps/maui) which allow you to show a native BottomSheet coming with a fluent and native performance for each device.

**Warning:** OverSheet is only avaible for Android and iOS (15.0 and above).

## Availabity
|Platform|Availabilty  |
|--|--|
|  Android |✔️  |
| iOS|✔️|


## Setup
-   Available on NuGet:  [https://www.nuget.org/packages/OverSheet](https://www.nuget.org/packages/OverSheet)  
- Add it to your MAUI project

## Getting Started
1.  Add OverSheet nuget package to your project

2. Add ConfigureOverSheet() to your MAUI program builder :

   `var builder = MauiApp.CreateBuilder();
               builder
                   .UseMauiApp<App>()
                   .ConfigureOverSheet();`

   

3. OverSheet main methods :

**ShowBottomSheet :**

```c#
Application.Current.MainPage.ShowBottomSheet(new Page());
```

ShowBottomSheet Parameters :

| Parameter     | Description                                                  |
| ------------- | ------------------------------------------------------------ |
| Content       | View or Page to set as BottomSheet content.                  |
| CornerRadius  | BottomSheet CornerRadius.                                    |
| IsDismissable | Indicate if the BottomSheet should be dismissable by the user or not. |
| IsPersistent  | Indicate if the BottomSheet should be without overlay and let user interact with the user interface in the back. |
| PeekHeight    | Specify BottomSheet peek height (only for android)           |

**HideBottomSheet :**

```c#
Application.Current.MainPage.HideBottomSheet();
```
**ToggleDetent:**

Toggle the BottomSheet state between Collapsed state and Expanded

```c#
Application.Current.MainPage.ToggleDetent();
```

## Created By: Dan Kyungu

-   LinkedIn:  [Dan Kyungu](https://www.linkedin.com/in/dan-kyungu)
-   Twitter:  [@dankyungu](https://twitter.com/dankyungu)

## License

The MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
