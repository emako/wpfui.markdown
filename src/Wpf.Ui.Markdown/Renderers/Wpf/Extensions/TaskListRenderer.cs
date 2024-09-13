using Markdig.Extensions.TaskLists;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Wpf.Ui.Markdown.Renderers.Wpf.Extensions;

public class TaskListRenderer : WpfObjectRenderer<TaskList>
{
    protected override void Write(WpfRenderer renderer, TaskList taskList)
    {
        if (renderer == null) throw new ArgumentNullException(nameof(renderer));
        if (taskList == null) throw new ArgumentNullException(nameof(taskList));

        var checkBox = new CheckBox
        {
            IsEnabled = false,
            IsChecked = taskList.Checked,
        };

        checkBox.SetResourceReference(FrameworkContentElement.StyleProperty, Styles.TaskListStyleKey);
        renderer.WriteInline(new InlineUIContainer(checkBox));
    }
}
