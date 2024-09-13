using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Inlines;

/// <summary>
/// A XAML renderer for a <see cref="CodeInline"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class CodeInlineRenderer : XamlObjectRenderer<CodeInline>
{
    protected override void Write(XamlRenderer renderer, CodeInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        renderer.Write("<Run");
        // Apply code styling (see also CodeBlockRenderer)
        renderer.Write(" Style=\"{StaticResource {x:Static markdig:Styles.CodeStyleKey}}\"");
        renderer.Write(" Text=\"").WriteEscape(obj.Content).Write("\"");
        renderer.Write(" />");
    }
}
