using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Wpf.Ui.Markdown;

/// <summary>
/// List of supported commands.
/// </summary>
public static class Commands
{
    /// <summary>
    /// Routed command for Hyperlink.
    /// </summary>
    //public static RoutedCommand Hyperlink { get; } = new RoutedCommand(nameof(Hyperlink), typeof(Commands));
    public static RoutedUICommand Hyperlink { get; } = NavigationCommands.GoToPage;

    public static void OpenUrlCommandExecutedHandler(object sender, ExecutedRoutedEventArgs e)
    {
        if (e.Parameter is string url && !string.IsNullOrEmpty(url))
        {
            _ = Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = url,
                WorkingDirectory = Environment.CurrentDirectory,
            });
        }
    }

    /// <summary>
    /// Routed command for Images.
    /// </summary>
    public static RoutedCommand Image { get; } = new RoutedCommand(nameof(Image), typeof(Commands));
}
