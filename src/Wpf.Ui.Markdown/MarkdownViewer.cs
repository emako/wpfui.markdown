using Markdig;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

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
    /// Defines the <see cref="Pipeline"/> property.
    /// </summary>
    public static readonly DependencyProperty PipelineProperty =
        DependencyProperty.Register(nameof(Pipeline), typeof(MarkdownPipeline), typeof(MarkdownViewer), new FrameworkPropertyMetadata(PipelineChanged));

    /// <summary>
    /// Defines the <see cref="TextBrush"/> property.
    /// </summary>
    public static readonly DependencyProperty TextBrushProperty =
        DependencyProperty.Register(nameof(TextBrush), typeof(Brush), typeof(MarkdownViewer), new FrameworkPropertyMetadata(null, MarkdownChanged));

    /// <summary>
    /// Defines the <see cref="HeaderBrush"/> property.
    /// </summary>
    public static readonly DependencyProperty HeaderBrushProperty =
        DependencyProperty.Register(nameof(HeaderBrush), typeof(Brush), typeof(MarkdownViewer), new FrameworkPropertyMetadata(null, MarkdownChanged));

    /// <summary>
    /// Defines the <see cref="HyperlinkBrush"/> property.
    /// </summary>
    public static readonly DependencyProperty HyperlinkBrushProperty =
        DependencyProperty.Register(nameof(HyperlinkBrush), typeof(Brush), typeof(MarkdownViewer), new FrameworkPropertyMetadata(null, MarkdownChanged));

    /// <summary>
    /// Defines the <see cref="HyperlinkInteractive"/> property.
    /// </summary>
    public static readonly DependencyProperty HyperlinkInteractiveProperty =
        DependencyProperty.Register(nameof(HyperlinkInteractive), typeof(bool), typeof(MarkdownViewer), new FrameworkPropertyMetadata(true, MarkdownChanged));

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

    /// <summary>
    /// Gets or sets the brush for general text.
    /// </summary>
    public Brush? TextBrush
    {
        get => (Brush?)GetValue(TextBrushProperty);
        set => SetValue(TextBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the brush for header text.
    /// </summary>
    public Brush? HeaderBrush
    {
        get => (Brush?)GetValue(HeaderBrushProperty);
        set => SetValue(HeaderBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets the brush for hyperlink text.
    /// </summary>
    public Brush? HyperlinkBrush
    {
        get => (Brush?)GetValue(HyperlinkBrushProperty);
        set => SetValue(HyperlinkBrushProperty, value);
    }

    /// <summary>
    /// Gets or sets whether hyperlinks are interactive (clickable).
    /// </summary>
    public bool HyperlinkInteractive
    {
        get => (bool)GetValue(HyperlinkInteractiveProperty);
        set => SetValue(HyperlinkInteractiveProperty, value);
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
        if (Markdown != null)
        {
            var renderer = new Renderers.WpfRenderer();
            renderer.TextBrush = TextBrush;
            renderer.HeaderBrush = HeaderBrush;
            renderer.HyperlinkBrush = HyperlinkBrush;
            renderer.HyperlinkInteractive = HyperlinkInteractive;
            Document = Ui.Markdown.Markdown.ToFlowDocument(Markdown, Pipeline ?? DefaultPipeline, renderer);
        }
        else
        {
            Document = null;
        }
    }
}
