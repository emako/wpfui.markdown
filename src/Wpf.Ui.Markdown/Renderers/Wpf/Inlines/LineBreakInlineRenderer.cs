using System;
using System.Windows.Documents;
using Markdig.Syntax.Inlines;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Inlines;

/// <summary>
/// A WPF renderer for a <see cref="LineBreakInline"/>.
/// </summary>
/// <seealso cref="Markdig.Renderers.Wpf.WpfObjectRenderer{Markdig.Syntax.Inlines.LineBreakInline}" />
public class LineBreakInlineRenderer : WpfObjectRenderer<LineBreakInline>
{
    /// <inheritdoc/>
    protected override void Write(WpfRenderer renderer, LineBreakInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        if (obj.IsHard)
        {
            renderer.WriteInline(new LineBreak());
        }
        else
        {
            // Soft line break.
            renderer.WriteText(" ");
        }
    }
}
