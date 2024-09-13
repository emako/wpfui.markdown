![WPF UI Banner Dark](https://user-images.githubusercontent.com/13592821/174165081-9c62d188-ecb6-4200-abd8-419afbaf32c2.png#gh-dark-mode-only)

![WPF UI Banner Light](https://user-images.githubusercontent.com/13592821/174165388-921c4745-90ed-4396-9a4b-9c86478f7447.png#gh-light-mode-only)

# WPF-UI.Markdown

[![GitHub license](https://img.shields.io/github/license/emako/wpfui.markdown)](https://github.com/emako/wpfui.markdown/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/v/WPF-UI.Markdown.svg)](https://nuget.org/packages/WPF-UI.Markdown) [![VS 2022 Downloads](https://img.shields.io/visual-studio-marketplace/i/lepo.WPF-UI?label=vs-2022)](https://marketplace.visualstudio.com/items?itemName=lepo.WPF-UI) [![Actions](https://github.com/emako/wpfui.markdown/actions/workflows/library.nuget.yml/badge.svg)](https://github.com/emako/wpfui.markdown/actions/workflows/library.nuget.yml) [![Platform](https://img.shields.io/badge/platform-Windows-blue?logo=windowsxp&color=1E9BFA)](https://dotnet.microsoft.com/zh-cn/download/dotnet/latest/runtime)

WPF UI Markdown is based on WPF UI, and provides the simple markdown viewer.

Pure C# Markdown Viewer without any Webview Engine.

Some Markdown feature are not supported in WPF.

See the [example](src/Wpf.Ui.Markdown/) for how to use.

## Usage

```xaml
<Application
    xmlns:md="http://schemas.lepo.co/wpfui/2022/xaml/markdown"
    xmlns:ui="http://schemas.lepo.co/wpfui/2022/xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ui:ThemesDictionary Theme="Dark" />
                <ui:ControlsDictionary />
                <md:ThemesDictionary Theme="Dark" />
                <md:ControlsDictionary />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

```c#
<md:MarkdownViewer Markdown="{Binding Markdown}" />
```

## Screen-shot

![image-20240913172834279](assets/image-20240913172834279.png)