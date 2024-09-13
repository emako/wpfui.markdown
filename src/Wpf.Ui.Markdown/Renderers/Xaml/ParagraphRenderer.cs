using Markdig.Syntax;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml;

/// <summary>
/// A XAML renderer for a <see cref="ParagraphBlock"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class ParagraphRenderer : XamlObjectRenderer<ParagraphBlock>
{
    protected override void Write(XamlRenderer renderer, ParagraphBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        if (!renderer.IsFirstInContainer)
        {
            renderer.EnsureLine();
        }
        renderer.WriteLine("<Paragraph>");
        renderer.WriteLeafInline(obj);
        renderer.EnsureLine();
        renderer.WriteLine("</Paragraph>");
    }
}
