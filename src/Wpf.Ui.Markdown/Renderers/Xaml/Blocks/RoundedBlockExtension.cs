using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Wpf.Ui.Markdown.Renderers.Xaml.Blocks;

public static class RoundedBlockExtension
{
    public static Block ToRounded(this Block block, double cornerRadius)
    {
        var border = new Border
        {
            BorderThickness = new Thickness(1d),
            CornerRadius = new CornerRadius(cornerRadius),
            Padding = new Thickness(6d, 8d, 6d, 8d),
        };

        var richTextBox = new RichTextBox
        {
            BorderThickness = new Thickness(0d),
            Padding = new Thickness(0d),
            Style = null!,
            BorderBrush = Brushes.Transparent,
            Background = Brushes.Transparent,
            IsReadOnly = true,
            ContextMenu = null!,
            CaretBrush = Brushes.White,
        };

        richTextBox.Document.Blocks.Clear();
        richTextBox.Document.Blocks.Add(block);
        border.Child = richTextBox;

        block.SetResourceReference(TextBlock.ForegroundProperty, "CardForeground");
        border.SetResourceReference(Border.BackgroundProperty, "CardBackground");
        border.SetResourceReference(Border.BorderBrushProperty, "CardBorderBrush");

        return new BlockUIContainer(border);
    }
}
