using Markdig.Syntax.Inlines;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Inlines;

/// <summary>
/// A XAML renderer for a <see cref="HtmlInline"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class HtmlInlineRenderer : XamlObjectRenderer<HtmlInline>
{
    protected override void Write(XamlRenderer renderer, HtmlInline obj)
    {
        // HTML inlines are not supported
    }
}
