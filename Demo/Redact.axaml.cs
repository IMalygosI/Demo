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
    public Redact()
    {
        InitializeComponent();
        // Айди ++ / Наименование ++ / Цена ++ / Описание + +/ Главное изображение ++ / Производитель + 
        // Id // TovarName  // Cost / Description // Pictures// (ManufacturerName)Немного изменить



        string pictures;
        Id.Text = Convert.ToString(Helper.massiv[0]);
        TovarName.Text = Convert.ToString(Helper.massiv[0]);
        Cost.Text = Convert.ToString(Helper.massiv[0]);
        Description.Text = Convert.ToString(Helper.massiv[0]);
        pictures = Convert.ToString(Helper.massiv[0]);
        Pictures.Source = new Bitmap($@"Assets\\Товары школы\\{pictures}");



        Otmena_Button.Click += Otmena_Button_Click;
    }
    private void Otmena_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow obratno = new MainWindow();
        obratno.Show();
        Close();
    }
}