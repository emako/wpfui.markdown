using Markdig.Syntax;
using System;
using System.Windows;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Renderers.Wpf;

public class ParagraphRenderer : WpfObjectRenderer<ParagraphBlock>
{
    /// <inheritdoc/>
    protected override void Write(WpfRenderer renderer, ParagraphBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var paragraph = new Paragraph();
        paragraph.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.ParagraphStyleKey);

        renderer.Push(paragraph);
        renderer.WriteLeafInline(obj);
        renderer.Pop();
    }
}
