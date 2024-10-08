using Markdig.Syntax;
using System;

namespace Wpf.Ui.Markdown.Renderers.Xaml;

/// <summary>
/// A XAML renderer for a <see cref="ListBlock"/>.
/// </summary>
/// <seealso cref="Xaml.XamlObjectRenderer{T}" />
public class ListRenderer : XamlObjectRenderer<ListBlock>
{
    protected override void Write(XamlRenderer renderer, ListBlock listBlock)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (listBlock == null) throw new ArgumentNullException(nameof(listBlock));

        renderer.EnsureLine();

        renderer.Write("<List");
        if (listBlock.IsOrdered)
        {
            renderer.Write(" MarkerStyle=\"Decimal\"");

            if (listBlock.OrderedStart != null && (listBlock.DefaultOrderedStart != listBlock.OrderedStart))
            {
                renderer.Write(" StartIndex=\"").Write(listBlock.OrderedStart).Write("\"");
            }
        }
        else
        {
            renderer.Write(" MarkerStyle=\"Disc\"");
        }
        renderer.WriteLine(">");

        foreach (var item in listBlock)
        {
            var listItem = (ListItemBlock)item;

            renderer.EnsureLine();
            renderer.WriteLine("<ListItem>");
            renderer.WriteChildren(listItem);
            renderer.WriteLine("</ListItem>");
        }
        renderer.WriteLine("</List>");
    }
}
