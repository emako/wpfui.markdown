using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Inlines;

/// <summary>
/// A XAML renderer for a <see cref="HtmlEntityInline"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class HtmlEntityInlineRenderer : XamlObjectRenderer<HtmlEntityInline>
{
    protected override void Write(XamlRenderer renderer, HtmlEntityInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        renderer.WriteEscape(obj.Transcoded);
    }
}
