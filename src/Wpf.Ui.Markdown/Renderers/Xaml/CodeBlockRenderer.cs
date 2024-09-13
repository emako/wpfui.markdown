using Markdig.Syntax;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml;

/// <summary>
/// A XAML renderer for a <see cref="CodeBlock"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class CodeBlockRenderer : XamlObjectRenderer<CodeBlock>
{
    protected override void Write(XamlRenderer renderer, CodeBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        renderer.EnsureLine();

        renderer.Write("<Paragraph xml:space=\"preserve\"");
        // Apply code block styling
        renderer.Write(" Style=\"{StaticResource {x:Static markdig:Styles.CodeBlockStyleKey}}\"");
        renderer.WriteLine(">");
        renderer.WriteLeafRawLines(obj, true, true);
        renderer.WriteLine("</Paragraph>");
    }
}
