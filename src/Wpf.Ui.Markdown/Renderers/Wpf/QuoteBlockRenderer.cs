using Markdig.Syntax;
using System;
using System.Windows;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Renderers.Wpf;

public class QuoteBlockRenderer : WpfObjectRenderer<QuoteBlock>
{
    /// <inheritdoc/>
    protected override void Write(WpfRenderer renderer, QuoteBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var section = new Section();

        renderer.Push(section);
        renderer.WriteChildren(obj);
        section.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.QuoteBlockStyleKey);
        renderer.Pop();
    }
}
