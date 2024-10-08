﻿using System;
using System.Windows.Media;

namespace Wpf.Ui.Markdown.Renderers.Wpf.ColorCode.Common;

internal static class ExtensionMethods
{
    public static SolidColorBrush GetSolidColorBrush(this string hex)
    {
        hex = hex.Replace("#", string.Empty);

        byte a = 255;
        int index = 0;

        if (hex.Length == 8)
        {
            a = (byte)(Convert.ToUInt32(hex.Substring(index, 2), 16));
            index += 2;
        }

        byte r = (byte)(Convert.ToUInt32(hex.Substring(index, 2), 16));
        index += 2;
        byte g = (byte)(Convert.ToUInt32(hex.Substring(index, 2), 16));
        index += 2;
        byte b = (byte)(Convert.ToUInt32(hex.Substring(index, 2), 16));
        SolidColorBrush myBrush = new(Color.FromArgb(a, r, g, b));
        return myBrush;
    }
}
