using Markdig.Renderers;
using Markdig.Syntax;

namespace Wpf.Ui.Markdown.Renderers.Wpf;

/// <summary>
/// A base class for WPF rendering <see cref="Block"/> and <see cref="Markdig.Syntax.Inlines.Inline"/> Markdown objects.
/// </summary>
/// <typeparam name="TObject">The type of the object.</typeparam>
/// <seealso cref="Markdig.Renderers.IMarkdownObjectRenderer" />
public abstract class WpfObjectRenderer<TObject> : MarkdownObjectRenderer<WpfRenderer, TObject>
    where TObject : MarkdownObject
{
}
