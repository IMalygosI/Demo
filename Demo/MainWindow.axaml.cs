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
            BoxTwo.SelectionChanged += BoxTwo_SelectionChanged;//���������� �� ����

            Vsego.Text = Convert.ToString(Helper.DataBase.Products.Count());// ������� ����� ��-���
            Pokaz.Text = Convert.ToString(Helper.DataBase.Products.Count());//������� ������������ ��-�� ������
            List_Box();
        }


        private void BoxTwo_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            switch (BoxTwo.SelectedIndex)
            {
                case 0:
                    List_Box();
                    break;
                case 1: // ���������� �� ��������
                    ListBox.ItemsSource = Helper.DataBase.Products.OrderByDescending(z => z.Cost).ToList();//����������
                    break;
                case 2: // ���������� �� ������������
                    ListBox.ItemsSource = Helper.DataBase.Products.OrderBy(z => z.Cost).ToList();//����������
                    break;
            }
        }

        public void List_Box()
        {
            ListBox.ItemsSource = Helper.DataBase.Products.ToList();

            ListBox.ItemsSource = Helper.DataBase.Products.Select(x => new
            {
                x.Pictures,
                x.Cost,
                x.Activity,
                x.TovarName,


                Color = x.Activity == "��������" ? "CenterScreen" : "Gray"


            }).ToList();
        }
    }
}