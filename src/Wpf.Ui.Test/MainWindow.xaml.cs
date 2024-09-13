using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.IO;
using System.IO.Packaging;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Resources;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using Wpf.Ui.Violeta.Appearance;
using Wpf.Ui.Violeta.Controls;

namespace Wpf.Ui.Test;

[ObservableObject]
public partial class MainWindow : FluentWindow
{
    public MainWindow()
    {
        DataContext = this;
        InitializeComponent();

        Thread.Sleep(600);
        Splash.CloseOnLoaded(this, minimumMilliseconds: 1800);

        ScrollViewer.ScrollToEnd();
    }

    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);

        if (WindowBackdrop.IsSupported(WindowBackdropType.Mica))
        {
            Background = new SolidColorBrush(Colors.Transparent);
            WindowBackdrop.ApplyBackdrop(this, WindowBackdropType.Mica);
        }
    }

    [ObservableProperty]
    private int themeIndex = (int)ApplicationTheme.Dark;

    partial void OnThemeIndexChanged(int value)
    {
        ThemeManager.Apply((ApplicationTheme)value);
    }

    [ObservableProperty]
    private string markdown = new StreamReader(ResourceHelper.GetStream("pack://application:,,,/Wpf.Ui.Test;component/Resources/Strings/Template.md")).ReadToEnd();
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
