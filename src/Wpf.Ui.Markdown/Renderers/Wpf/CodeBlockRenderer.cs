using Markdig.Syntax;
using System;
using System.Windows;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Renderers.Wpf;

public class CodeBlockRenderer : WpfObjectRenderer<CodeBlock>
{
    protected override void Write(WpfRenderer renderer, CodeBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));

        var paragraph = new Paragraph();
        paragraph.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.CodeBlockStyleKey);
        renderer.Push(paragraph);
        renderer.WriteLeafRawLines(obj);
        renderer.Pop();
    }
}
