using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Inlines;

/// <summary>
/// A XAML renderer for a <see cref="DelimiterInline"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class DelimiterInlineRenderer : XamlObjectRenderer<DelimiterInline>
{
    protected override void Write(XamlRenderer renderer, DelimiterInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        renderer.WriteEscape(obj.ToLiteral());
        renderer.WriteChildren(obj);
    }
}
