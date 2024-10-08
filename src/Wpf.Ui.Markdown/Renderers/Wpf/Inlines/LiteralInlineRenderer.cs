using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Inlines;

/// <summary>
/// A WPF renderer for a <see cref="LiteralInline"/>.
/// </summary>
/// <seealso cref="Markdig.Renderers.Wpf.WpfObjectRenderer{Markdig.Syntax.Inlines.LiteralInline}" />
public class LiteralInlineRenderer : WpfObjectRenderer<LiteralInline>
{
    /// <inheritdoc/>
    protected override void Write(WpfRenderer renderer, LiteralInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        if (obj.Content.IsEmpty)
            return;

        renderer.WriteText(ref obj.Content);
    }
}
