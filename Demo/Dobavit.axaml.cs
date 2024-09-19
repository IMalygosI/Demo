using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Demo;

public partial class Dobavit : Window
{
    public Dobavit()
    {
        InitializeComponent();
        Otmena_Button.Click += Otmena_Click;
    }

    private void Otmena_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow obtatno = new MainWindow();
        obtatno.Show();
        Close();
    }
}