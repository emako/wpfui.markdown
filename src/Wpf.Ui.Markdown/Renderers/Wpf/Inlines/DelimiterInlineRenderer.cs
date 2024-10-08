using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Inlines;

/// <summary>
/// A WPF renderer for a <see cref="DelimiterInline"/>.
/// </summary>
/// <seealso cref="Markdig.Renderers.Wpf.WpfObjectRenderer{Markdig.Syntax.Inlines.DelimiterInline}" />
public class DelimiterInlineRenderer : WpfObjectRenderer<DelimiterInline>
{
    /// <inheritdoc/>
    protected override void Write(WpfRenderer renderer, DelimiterInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        renderer.WriteText(obj.ToLiteral());
        renderer.WriteChildren(obj);
    }
}
