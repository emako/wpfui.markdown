using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.IO;
using System.IO.Packaging;
using System.Threading;
using System.Windows;
using System.Windows.Resources;
using Wpf.Ui.Appearance;
using Wpf.Ui.Violeta.Controls;

namespace Wpf.Ui.Test;

[ObservableObject]
public partial class MainWindow : ShellWindow
{
    public MainWindow()
    {
        DataContext = this;
        InitializeComponent();

        Thread.Sleep(600);
        Splash.CloseOnLoaded(this, minimumMilliseconds: 1800);

        ScrollViewer.ScrollToEnd();
    }

    [ObservableProperty]
    public partial int ThemeIndex { get; set; } = (int)ApplicationTheme.Dark;

    partial void OnThemeIndexChanged(int value)
    {
        if ((ApplicationTheme)value == ApplicationTheme.Unknown)
        {
            ApplicationThemeManager.ApplySystemTheme();
            return;
        }

        ApplicationThemeManager.Apply((ApplicationTheme)value);
    }

    [ObservableProperty]
    public partial string Markdown { get; set; } = new StreamReader(ResourceHelper.GetStream("pack://application:,,,/Wpf.Ui.Test;component/Resources/Strings/Template.md")!).ReadToEnd();
}

file static class ResourceHelper
{
    static ResourceHelper()
    {
        if (!UriParser.IsKnownScheme("pack"))
        {
            _ = PackUriHelper.UriSchemePack;
        }
    }

    public static Stream? GetStream(string uriString)
    {
        Uri uri = new(uriString);
        StreamResourceInfo info = Application.GetResourceStream(uri);
        return info?.Stream;
    }
}
