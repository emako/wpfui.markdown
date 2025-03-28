﻿using System;
using System.Windows;
using System.Windows.Markup;
using Wpf.Ui.Appearance;
using Wpf.Ui.Markdown.Appearance;

namespace Wpf.Ui.Markdown.Markup;

[Localizability(LocalizationCategory.Ignore)]
[Ambient]
[UsableDuringInitialization(true)]
public class ThemesDictionary : ResourceDictionary
{
    public ApplicationTheme Theme
    {
        set => SetSourceBasedOnSelectedTheme(value);
    }

    static ThemesDictionary()
    {
        ThemeManager.RegisterApplicationThemeChanged();
    }

    public ThemesDictionary()
    {
        SetSourceBasedOnSelectedTheme(ApplicationTheme.Light);
    }

    private void SetSourceBasedOnSelectedTheme(ApplicationTheme? selectedApplicationTheme)
    {
        var themeName = selectedApplicationTheme switch
        {
            ApplicationTheme.Dark => "Dark",
            //ApplicationTheme.HighContrast => "HighContrast",
            _ => "Light"
        };

        Source = new Uri($"pack://application:,,,/Wpf.Ui.Markdown;component/Resources/Theme/{themeName}.xaml", UriKind.Absolute);
    }
}
