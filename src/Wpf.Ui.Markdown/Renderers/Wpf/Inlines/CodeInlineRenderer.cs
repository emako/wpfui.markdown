using Markdig.Syntax.Inlines;
using System;
using System.Windows;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Inlines;

public class CodeInlineRenderer : WpfObjectRenderer<CodeInline>
{
    protected override void Write(WpfRenderer renderer, CodeInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var run = new Run(obj.Content);
        run.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.CodeStyleKey);
        renderer.WriteInline(run);
    }
}
