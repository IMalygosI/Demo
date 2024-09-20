using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Demo.ListPg;
using Demo.Models;
using System;

namespace Demo;

public partial class Redact : Window
{
    public Product product;
    public Redact()
    {
        InitializeComponent();

      //  Product.Datacontext;

        Otmena_Button.Click += Otmena_Button_Click;
    }
    private void Otmena_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow obratno = new MainWindow();
        obratno.Show();
        Close();
    }
}