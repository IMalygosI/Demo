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

            BoxOne.SelectionChanged += BoxOne_SelectionChanged;
            BoxTwo.SelectionChanged += BoxTwo_SelectionChanged;//���������� �� ����
            ListBox.SelectionChanged += ListBox_SelectionChanged;// ����� ���� �������������� ��������

            Dobavit.Click += Dobavit_Click;

            Vsego.Text = Convert.ToString(Helper.DataBase.Products.Count());// ������� ����� ��-���
            Pokaz.Text = Convert.ToString(Helper.DataBase.Products.Count());//������� ������������ ��-�� ������


            List_Box();
        }

        List<Product> product = Helper.DataBase.Products.ToList();
     

            
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ListBox.SelectedItem;
            if (selectedItem != null)
            {
                var productId = ((dynamic)selectedItem).Id;
                if (productId != null)
                {
                    Helper.massiv[0] = productId;
                    Redact taskWindow = new Redact();
                    taskWindow.Show();
                    this.Close();
                }
            }
        }// ����� ���� �������������� ��������

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
                case 1: // ���������� �� ��������
                    ListBox.ItemsSource = Helper.DataBase.Products.OrderByDescending(z => z.Cost).ToList();// ���������� �� ��������
                    break;
                case 2: // ���������� �� ������������
                    ListBox.ItemsSource = Helper.DataBase.Products.OrderBy(z => z.Cost).ToList(); ;// ���������� �� ������������
                    break;
            }
        }// ���������� �� ����
        public void List_Box()
        {
            string SearchText = SearchTextBox.Text ?? "";
            if (!string.IsNullOrEmpty(SearchText))
                product = product.Where(y => y.TovarName.Contains(SearchText) ).ToList();
          //  product = product.Where(y => y.TovarName.Contains(SearchText) || y.Description.Contains(SearchText)).ToList();

            ListBox.ItemsSource = Helper.DataBase.Products.ToList();
        }// �������� ������ � ��������
        private void Dobavit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Dobavit okko = new Dobavit();
            okko.Show();
            this.Close();
        }// ���� ����������
    }
}