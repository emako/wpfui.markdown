using Markdig.Syntax;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml;

/// <summary>
/// A XAML renderer for a <see cref="QuoteBlock"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class QuoteBlockRenderer : XamlObjectRenderer<QuoteBlock>
{
    protected override void Write(XamlRenderer renderer, QuoteBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        renderer.EnsureLine();

        renderer.Write("<Section");
        // Apply quote block styling
        renderer.Write(" Style=\"{StaticResource {x:Static markdig:Styles.QuoteBlockStyleKey}}\"");
        renderer.WriteLine(">");
        renderer.WriteChildren(obj);
        renderer.WriteLine("</Section>");
    }
}
