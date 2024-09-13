using Markdig;
using System;

namespace Wpf.Ui.Markdown;

/// <summary>
/// Provides extension methods for <see cref="MarkdownPipeline"/> to enable several Markdown extensions.
/// </summary>
public static class MarkdownExtensions
{
    /// <summary>
    /// Uses all extensions supported by <c>Markdig.Wpf</c>.
    /// </summary>
    /// <param name="pipeline">The pipeline.</param>
    /// <returns>The modified pipeline</returns>
    public static MarkdownPipelineBuilder UseSupportedExtensions(this MarkdownPipelineBuilder pipeline)
    {
        if (pipeline == null) throw new ArgumentNullException(nameof(pipeline));
        return pipeline
            .UseEmphasisExtras()
            .UseGridTables()
            .UsePipeTables()
            .UseTaskLists()
            .UseAutoLinks();
    }
}
