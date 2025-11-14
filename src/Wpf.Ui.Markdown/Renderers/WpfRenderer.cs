using ColorCode.Styling;
using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Syntax;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using Wpf.Ui.Appearance;
using Wpf.Ui.Markdown.Renderers.Wpf;
using Wpf.Ui.Markdown.Renderers.Wpf.ColorCode;
using Wpf.Ui.Markdown.Renderers.Wpf.Extensions;
using Wpf.Ui.Markdown.Renderers.Wpf.Inlines;
using Block = System.Windows.Documents.Block;

namespace Wpf.Ui.Markdown.Renderers;

/// <summary>
/// WPF renderer for a Markdown <see cref="MarkdownDocument"/> object.
/// </summary>
/// <seealso cref="RendererBase" />
public class WpfRenderer : RendererBase
{
    private readonly Stack<IAddChild> stack = new();
    private char[] buffer;

    public WpfRenderer()
    {
        buffer = new char[1024];
    }

    public WpfRenderer(FlowDocument document)
    {
        buffer = new char[1024];
        LoadDocument(document);
    }

    /// <summary>
    /// Gets or sets the custom brush for general text.
    /// </summary>
    public Brush? TextBrush { get; set; }

    /// <summary>
    /// Gets or sets the custom brush for headers.
    /// </summary>
    public Brush? HeaderBrush { get; set; }

    /// <summary>
    /// Gets or sets the custom brush for hyperlinks.
    /// </summary>
    public Brush? HyperlinkBrush { get; set; }

    /// <summary>
    /// Gets or sets whether hyperlinks are interactive.
    /// </summary>
    public bool HyperlinkInteractive { get; set; } = true;

    public virtual void LoadDocument(FlowDocument document)
    {
        Document = document ?? throw new ArgumentNullException(nameof(document));
        document.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.DocumentStyleKey);
        
        // Apply custom text brush if provided
        if (TextBrush != null)
        {
            document.Foreground = TextBrush;
        }
        
        stack.Push(document);
        LoadRenderers();
    }

    public FlowDocument? Document { get; protected set; }

    /// <inheritdoc/>
    public override object? Render(MarkdownObject markdownObject)
    {
        Write(markdownObject);
        return Document;
    }

    /// <summary>
    /// Writes the inlines of a leaf inline.
    /// </summary>
    /// <param name="leafBlock">The leaf block.</param>
    /// <returns>This instance</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteLeafInline(LeafBlock leafBlock)
    {
        if (leafBlock == null) throw new ArgumentNullException(nameof(leafBlock));
        var inline = (Markdig.Syntax.Inlines.Inline)leafBlock.Inline;
        while (inline != null)
        {
            Write(inline);
            inline = inline.NextSibling;
        }
    }

    /// <summary>
    /// Writes the lines of a <see cref="LeafBlock"/>
    /// </summary>
    /// <param name="leafBlock">The leaf block.</param>
    public void WriteLeafRawLines(LeafBlock leafBlock)
    {
        if (leafBlock == null) throw new ArgumentNullException(nameof(leafBlock));
        if (leafBlock.Lines.Lines != null)
        {
            var lines = leafBlock.Lines;
            var slices = lines.Lines;
            for (var i = 0; i < lines.Count; i++)
            {
                if (i != 0)
                    WriteInline(new LineBreak());

                WriteText(ref slices[i].Slice);
            }
        }
    }

    public void Push(IAddChild o)
    {
        stack.Push(o);
    }

    public void Pop()
    {
        var popped = stack.Pop();
        stack.Peek().AddChild(popped);
    }

    public void WriteBlock(Block block)
    {
        stack.Peek().AddChild(block);
    }

    public void WriteInline(Inline inline)
    {
        AddInline(stack.Peek(), inline);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteText(ref StringSlice slice)
    {
        if (slice.Start > slice.End)
            return;

        WriteText(slice.Text, slice.Start, slice.Length);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteText(string? text)
    {
        WriteInline(new Run(text));
    }

    public void WriteText(string? text, int offset, int length)
    {
        if (text == null)
            return;

        if (offset == 0 && text.Length == length)
        {
            WriteText(text);
        }
        else
        {
            if (length > buffer.Length)
            {
                buffer = text.ToCharArray();
                WriteText(new string(buffer, offset, length));
            }
            else
            {
                text.CopyTo(offset, buffer, 0, length);
                WriteText(new string(buffer, 0, length));
            }
        }
    }

    /// <summary>
    /// Loads the renderer used for render WPF
    /// </summary>
    protected virtual void LoadRenderers()
    {
        ApplicationThemeManager.Changed += ApplicationThemeManager_Changed;

        // Default block renderers
        ObjectRenderers.Add(new ColorCodeBlockRenderer(styleDictionary:
            ApplicationThemeManager.GetAppTheme() == ApplicationTheme.Dark
            ? StyleDictionary.DefaultDark
            : StyleDictionary.DefaultLight));
        ObjectRenderers.Add(new ListRenderer());
        ObjectRenderers.Add(new HeadingRenderer(this));
        ObjectRenderers.Add(new ParagraphRenderer());
        ObjectRenderers.Add(new QuoteBlockRenderer());
        ObjectRenderers.Add(new ThematicBreakRenderer());

        // Default inline renderers
        ObjectRenderers.Add(new AutolinkInlineRenderer());
        ObjectRenderers.Add(new CodeInlineRenderer());
        ObjectRenderers.Add(new DelimiterInlineRenderer());
        ObjectRenderers.Add(new EmphasisInlineRenderer());
        ObjectRenderers.Add(new HtmlEntityInlineRenderer());
        ObjectRenderers.Add(new LineBreakInlineRenderer());
        ObjectRenderers.Add(new LinkInlineRenderer(this));
        ObjectRenderers.Add(new LiteralInlineRenderer());

        // Extension renderers
        ObjectRenderers.Add(new TableRenderer());
        ObjectRenderers.Add(new TaskListRenderer());
    }

    private static void AddInline(IAddChild parent, Inline inline)
    {
        parent.AddChild(inline);
    }

    private void ApplicationThemeManager_Changed(ApplicationTheme currentApplicationTheme, Color systemAccent)
    {
        ObjectRenderers.RemoveAt(0);
        ObjectRenderers.Insert(0, new ColorCodeBlockRenderer(styleDictionary:
            ApplicationThemeManager.GetAppTheme() == ApplicationTheme.Dark
            ? StyleDictionary.DefaultDark
            : StyleDictionary.DefaultLight));
    }
}
