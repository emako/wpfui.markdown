using Markdig.Renderers;
using Markdig.Syntax;

namespace Wpf.Ui.Markdown.Renderers.Xaml;

/// <summary>
/// A base class for XAML rendering <see cref="Block"/> and <see cref="Syntax.Inlines.Inline"/> Markdown objects.
/// </summary>
/// <typeparam name="TObject">The type of the object.</typeparam>
/// <seealso cref="IMarkdownObjectRenderer" />
public abstract class XamlObjectRenderer<TObject> : MarkdownObjectRenderer<XamlRenderer, TObject>
    where TObject : MarkdownObject
{
}
