﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniExcel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PopUpWindow popUpWindow;

        public MainWindow()
        {
            InitializeComponent();
            popUpWindow = new PopUpWindow();
        }

        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPopUpWindow();
        }

        private void intFilterButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPopUpWindow();
        }

        private void intMinValue_Click(object sender, RoutedEventArgs e)
        {
            ShowPopUpWindow();
        }

        private void intAvarageValue_Click(object sender, RoutedEventArgs e)
        {
            ShowPopUpWindow();
        }

        private void intMaxValue_Click(object sender, RoutedEventArgs e)
        {
            ShowPopUpWindow();
        }

        private void ShowPopUpWindow()
        {
            popUpWindow.Show();
        }

        private void AddColumne(object sender, RoutedEventArgs e)
        {
            TextBox newTextBox = new TextBox
            {
                Width = 30,
                Height = 30,

            };


            ColumnDefinition newColumn = new ColumnDefinition();
            ItemContainer.ColumnDefinitions.Add(newColumn);

            Grid.SetColumn(newTextBox, ItemContainer.ColumnDefinitions.Count - 1);

            ItemContainer.Children.Add(newTextBox);
        }

        private void btAddRow_Click(object sender, RoutedEventArgs e)
        {
            TextBox newTextBox = new TextBox
            {
                Width = 30,
                Height = 30,

            };




            RowDefinition newRowDefinition = new RowDefinition();
            ItemContainer.RowDefinitions.Add(newRowDefinition);

            Grid.SetRow(newTextBox, ItemContainer.RowDefinitions.Count - 1);

            ItemContainer.Children.Add(newTextBox);
        }

    }
}


