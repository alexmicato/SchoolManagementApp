using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

public static class SelectionChangedCommandBehavior
{
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(SelectionChangedCommandBehavior), new PropertyMetadata(null, OnCommandChanged));

    public static ICommand GetCommand(DependencyObject obj)
    {
        return (ICommand)obj.GetValue(CommandProperty);
    }

    public static void SetCommand(DependencyObject obj, ICommand value)
    {
        obj.SetValue(CommandProperty, value);
    }

    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ListView listView)
        {
            if (e.NewValue is ICommand command)
            {
                listView.SelectionChanged += ListView_SelectionChanged;
            }
            else
            {
                listView.SelectionChanged -= ListView_SelectionChanged;
            }
        }
    }

    private static void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ListView listView)
        {
            ICommand command = GetCommand(listView);
            if (command?.CanExecute(listView.SelectedItem) == true)
            {
                command.Execute(listView.SelectedItem);
            }
        }
    }
}