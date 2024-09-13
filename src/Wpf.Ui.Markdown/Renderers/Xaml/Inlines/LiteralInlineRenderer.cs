using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Inlines;

/// <summary>
/// A XAML renderer for a <see cref="LiteralInline"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class LiteralInlineRenderer : XamlObjectRenderer<LiteralInline>
{
    protected override void Write(XamlRenderer renderer, LiteralInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        if (obj.Content.IsEmpty)
            return;

        renderer.Write("<Run");
        renderer.Write(" Text=\"").WriteEscape(ref obj.Content).Write("\"");
        renderer.Write(" />");
    }
}
