using Markdig.Syntax;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml;

/// <summary>
/// A XAML renderer for a <see cref="ThematicBreakBlock"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class ThematicBreakRenderer : XamlObjectRenderer<ThematicBreakBlock>
{
    protected override void Write(XamlRenderer renderer, ThematicBreakBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        renderer.EnsureLine();

        renderer.WriteLine("<Paragraph>");
        renderer.Write("<Line X2=\"1\"");
        // Apply styling
        renderer.Write(" Style=\"{StaticResource {x:Static markdig:Styles.ThematicBreakStyleKey}}\"");
        renderer.WriteLine(" />");
        renderer.WriteLine("</Paragraph>");
    }
}
