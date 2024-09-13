using Markdig.Syntax;
using System;
using System.Windows;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Renderers.Wpf;

public class ThematicBreakRenderer : WpfObjectRenderer<ThematicBreakBlock>
{
    protected override void Write(WpfRenderer renderer, ThematicBreakBlock obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var line = new System.Windows.Shapes.Line { X2 = 1 };
        line.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.ThematicBreakStyleKey);

        var paragraph = new Paragraph
        {
            Inlines = { new InlineUIContainer(line) }
        };

        renderer.WriteBlock(paragraph);
    }
}
