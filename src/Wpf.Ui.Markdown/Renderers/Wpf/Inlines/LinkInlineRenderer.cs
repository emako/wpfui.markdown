using Markdig.Syntax.Inlines;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Inlines;

/// <summary>
/// A WPF renderer for a <see cref="LinkInline"/>.
/// </summary>
/// <seealso cref="Markdig.Renderers.Wpf.WpfObjectRenderer{Markdig.Syntax.Inlines.LinkInline}" />
public class LinkInlineRenderer : WpfObjectRenderer<LinkInline>
{
    private readonly WpfRenderer? _wpfRenderer;

    public LinkInlineRenderer(WpfRenderer? wpfRenderer = null)
    {
        _wpfRenderer = wpfRenderer;
    }

    /// <inheritdoc/>
    protected override void Write(WpfRenderer renderer, LinkInline link)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (link == null) throw new ArgumentNullException(nameof(link));

        var url = link.GetDynamicUrl != null ? link.GetDynamicUrl() ?? link.Url : link.Url;

        if (!Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
        {
            url = "#";
        }

        if (link.IsImage)
        {
            var template = new ControlTemplate();
            var image = new FrameworkElementFactory(typeof(Image));
            image.SetValue(Image.SourceProperty, new BitmapImage(new Uri(url, UriKind.RelativeOrAbsolute)));
            image.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.ImageStyleKey);
            template.VisualTree = image;

            var btn = new Button()
            {
                Template = template,
                Command = Commands.Image,
                CommandParameter = url
            };

            renderer.WriteInline(new InlineUIContainer(btn));
        }
        else
        {
            var hyperlink = new Hyperlink
            {
                NavigateUri = new Uri(url, UriKind.RelativeOrAbsolute),
                ToolTip = !string.IsNullOrEmpty(link.Title) ? link.Title : null,
            };

            // Apply custom brush if provided, otherwise use style
            if (_wpfRenderer?.HyperlinkBrush != null)
            {
                hyperlink.Foreground = _wpfRenderer.HyperlinkBrush;
                // Still set the style for other properties like font size
                hyperlink.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.HyperlinkStyleKey);
            }
            else
            {
                hyperlink.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.HyperlinkStyleKey);
            }

            // Only make hyperlink interactive if HyperlinkInteractive is true
            if (_wpfRenderer?.HyperlinkInteractive ?? true)
            {
                hyperlink.Command = Commands.Hyperlink;
                hyperlink.CommandParameter = url;
                hyperlink.CommandBindings.Add(new CommandBinding(Commands.Hyperlink, Commands.OpenUrlCommandExecutedHandler));
            }

            renderer.Push(hyperlink);
            renderer.WriteChildren(link);
            renderer.Pop();
        }
    }
}
