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

    public static Inline ToRounded(this Inline inline, double cornerRadius)
    {
        var border = new Border
        {
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(cornerRadius),
            Padding = new Thickness(3d, 1d, 3d, 1d),
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
            Margin = new Thickness(0d, 0d, 0d, -4d),
            Height = 20d,
            Child = new TextBlock(inline)
            {
                Margin = new Thickness(0d, 0d, 0d, -10d),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            }
        };

        inline.SetResourceReference(TextBlock.ForegroundProperty, "CardForeground");
        border.SetResourceReference(Border.BackgroundProperty, "CardBackground");
        border.SetResourceReference(Border.BorderBrushProperty, "CardBorderBrush");

        return new InlineUIContainer(border);
    }
}
