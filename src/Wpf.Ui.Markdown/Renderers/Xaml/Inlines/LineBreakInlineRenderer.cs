using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Inlines;

/// <summary>
/// A XAML renderer for a <see cref="LineBreakInline"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class LineBreakInlineRenderer : XamlObjectRenderer<LineBreakInline>
{
    protected override void Write(XamlRenderer renderer, LineBreakInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        if (obj.IsHard)
        {
            renderer.WriteLine("<LineBreak />");
        }
        else
        {
            renderer.WriteLine();
        }
    }
}
