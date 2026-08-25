using Markdig.Syntax.Inlines;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Wpf.Ui.Markdown.Renderers;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Inlines;

/// <summary>
/// A WPF renderer for a <see cref="AutolinkInline"/>.
/// </summary>
/// <seealso cref="Markdig.Renderers.Wpf.WpfObjectRenderer{Markdig.Syntax.Inlines.AutolinkInline}" />
public class AutolinkInlineRenderer : WpfObjectRenderer<AutolinkInline>
{
    private readonly WpfRenderer? _wpfRenderer;

    public AutolinkInlineRenderer(WpfRenderer? wpfRenderer = null)
    {
        _wpfRenderer = wpfRenderer;
    }

    /// <inheritdoc/>
    protected override void Write(WpfRenderer renderer, AutolinkInline link)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (link == null) throw new ArgumentNullException(nameof(link));

        var url = link.Url;
        if (link.IsEmail)
        {
            url = "mailto:" + url;
        }

        if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
        {
            url = "#";
        }

        var hyperlink = new Hyperlink
        {
            NavigateUri = new Uri(url, UriKind.RelativeOrAbsolute),
            ToolTip = link.Url,
        };

        if (_wpfRenderer?.HyperlinkBrush != null)
        {
            hyperlink.Foreground = _wpfRenderer.HyperlinkBrush;
        }

        hyperlink.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.HyperlinkStyleKey);

        if (_wpfRenderer?.HyperlinkInteractive ?? true)
        {
            hyperlink.Command = Commands.Hyperlink;
            hyperlink.CommandParameter = url;
            hyperlink.CommandBindings.Add(new CommandBinding(Commands.Hyperlink, Commands.OpenUrlCommandExecutedHandler));
        }

        renderer.Push(hyperlink);
        renderer.WriteText(link.Url);
        renderer.Pop();
    }
}
