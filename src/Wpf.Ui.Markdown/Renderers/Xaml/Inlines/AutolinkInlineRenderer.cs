using Markdig.Syntax.Inlines;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Inlines;

/// <summary>
/// A XAML renderer for a <see cref="AutolinkInline"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class AutolinkInlineRenderer : XamlObjectRenderer<AutolinkInline>
{
    protected override void Write(XamlRenderer renderer, AutolinkInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var url = obj.Url;
        if (obj.IsEmail)
        {
            url = "mailto:" + url;
        }

        renderer.Write("<Hyperlink");
        renderer.Write(" Style=\"{StaticResource {x:Static markdig:Styles.HyperlinkStyleKey}}\"");
        renderer.Write(" Command=\"{x:Static markdig:Commands.Hyperlink}\"");
        renderer.Write(" CommandParameter=\"").WriteEscapeUrl(url).Write("\"");
        renderer.Write(">");
        renderer.WriteEscapeUrl(obj.Url);
        renderer.WriteLine("</Hyperlink>");
    }
}
