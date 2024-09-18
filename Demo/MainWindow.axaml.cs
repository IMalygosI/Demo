using Avalonia.Controls;
using Demo.ListPg;
using Demo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List_Box();

            BoxOne.SelectionChanged += BoxOne_SelectionChanged;
            BoxTwo.SelectionChanged += BoxTwo_SelectionChanged;//сортировка по цене

            Dobavit.Click += Dobavit_Click;

            Vsego.Text = Convert.ToString(Helper.DataBase.Products.Count());// Сколько всего эл-тов
            Pokaz.Text = Convert.ToString(Helper.DataBase.Products.Count());//Сколько отображается эл-ов сейчас
        }

        private void Dobavit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Dobavit okko = new Dobavit();
            okko.Show();
            this.Close();
        }

        private void BoxOne_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            BoxOne.ItemsSource = Helper.DataBase.Manufacturers;
        }

        private void BoxTwo_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            switch (BoxTwo.SelectedIndex)
            {
                case 0:
                    List_Box();
                    break;
                case 1: // Сортировка по Убыванию
                    ListBox.ItemsSource = Helper.DataBase.Products.OrderByDescending(z => z.Cost).ToList();//Уменьшение
                    break;
                case 2: // Сортировка по Воззрастанию
                    ListBox.ItemsSource = Helper.DataBase.Products.OrderBy(z => z.Cost).ToList();//Увеличение
                    break;
            }
        }

        public void List_Box()
        {
            ListBox.ItemsSource = Helper.DataBase.Products.ToList();
            /*
            ListBox.ItemsSource = Helper.DataBase.Products.Select(x => new
            {
                x.Pictures,
                x.Cost,
                x.Activity,
                x.TovarName,


                Color = x.Activity == "Активный" ? "CenterScreen" : "Gray"


            }).ToList();
            */
        }
    }
}