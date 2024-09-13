using Markdig.Syntax.Inlines;
using System;
using System.Windows;
using System.Windows.Documents;
using Wpf.Ui.Markdown.Renderers.Xaml.Blocks;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Inlines;

public class CodeInlineRenderer : WpfObjectRenderer<CodeInline>
{
    protected override void Write(WpfRenderer renderer, CodeInline obj)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        var run = new Run(obj.Content);
        run.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.CodeStyleKey);
        //renderer.WriteInline(run);
        renderer.WriteInline(run.ToRounded(4));
    }
}
