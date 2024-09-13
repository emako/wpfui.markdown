using Markdig.Syntax;
using System;
using System.Windows;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Renderers.Wpf;

public class HeadingRenderer : WpfObjectRenderer<HeadingBlock>
{
    protected override void Write(WpfRenderer renderer, HeadingBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var paragraph = new Paragraph();
        ComponentResourceKey? styleKey = null;

        switch (obj.Level)
        {
            case 1: styleKey = Styles.Heading1StyleKey; break;
            case 2: styleKey = Styles.Heading2StyleKey; break;
            case 3: styleKey = Styles.Heading3StyleKey; break;
            case 4: styleKey = Styles.Heading4StyleKey; break;
            case 5: styleKey = Styles.Heading5StyleKey; break;
            case 6: styleKey = Styles.Heading6StyleKey; break;
        }

        if (styleKey != null)
        {
            paragraph.SetResourceReference(FrameworkContentElement.StyleProperty, styleKey);
        }

        renderer.Push(paragraph);
        renderer.WriteLeafInline(obj);
        renderer.Pop();
    }
}
