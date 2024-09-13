using Markdig;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Controls;

/// <summary>
/// A markdown viewer control.
/// </summary>
public class MarkdownViewer : Control
{
    protected static readonly MarkdownPipeline DefaultPipeline = new MarkdownPipelineBuilder().UseSupportedExtensions().Build();

    private static readonly DependencyPropertyKey DocumentPropertyKey =
        DependencyProperty.RegisterReadOnly(nameof(Document), typeof(FlowDocument), typeof(MarkdownViewer), new FrameworkPropertyMetadata());

    /// <summary>
    /// Defines the <see cref="Document"/> property.
    /// </summary>
    public static readonly DependencyProperty DocumentProperty = DocumentPropertyKey.DependencyProperty;

    /// <summary>
    /// Defines the <see cref="Markdown"/> property.
    /// </summary>
    public static readonly DependencyProperty MarkdownProperty =
        DependencyProperty.Register(nameof(Markdown), typeof(string), typeof(MarkdownViewer), new FrameworkPropertyMetadata(MarkdownChanged));

    /// <summary>
    /// Defines the <see cref="Markdown"/> property.
    /// </summary>
    public static readonly DependencyProperty PipelineProperty =
        DependencyProperty.Register(nameof(Pipeline), typeof(MarkdownPipeline), typeof(MarkdownViewer), new FrameworkPropertyMetadata(PipelineChanged));

    static MarkdownViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MarkdownViewer), new FrameworkPropertyMetadata(typeof(MarkdownViewer)));
    }

    /// <summary>
    /// Gets the flow document to display.
    /// </summary>
    public FlowDocument? Document
    {
        get => (FlowDocument)GetValue(DocumentProperty);
        protected set => SetValue(DocumentPropertyKey, value);
    }

    /// <summary>
    /// Gets or sets the markdown to display.
    /// </summary>
    public string? Markdown
    {
        get => (string)GetValue(MarkdownProperty);
        set => SetValue(MarkdownProperty, value);
    }

    /// <summary>
    /// Gets or sets the markdown pipeline to use.
    /// </summary>
    public MarkdownPipeline Pipeline
    {
        get => (MarkdownPipeline)GetValue(PipelineProperty);
        set => SetValue(PipelineProperty, value);
    }

    private static void MarkdownChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var control = (MarkdownViewer)sender;
        control.RefreshDocument();
    }

    private static void PipelineChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var control = (MarkdownViewer)sender;
        control.RefreshDocument();
    }

    protected virtual void RefreshDocument()
    {
        Document = Markdown != null ? Ui.Markdown.Markdown.ToFlowDocument(Markdown, Pipeline ?? DefaultPipeline) : null;
    }
}
