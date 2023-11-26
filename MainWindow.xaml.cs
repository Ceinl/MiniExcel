using System;
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

        private void AddColumn(object sender, RoutedEventArgs e)
        {
            // Додаємо новий стовбець
            ColumnDefinition newColumn = new ColumnDefinition();
            ItemContainer.ColumnDefinitions.Add(newColumn);

            // Додаємо Label для нумерації стовбців
            Label headerLabel = new Label
            {
                Content = (ItemContainer.ColumnDefinitions.Count - 1).ToString(), // Нумерація з 1
                Width = 30,
                Height = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(headerLabel, ItemContainer.ColumnDefinitions.Count - 1);
            Grid.SetRow(headerLabel, 0);
            ItemContainer.Children.Add(headerLabel);

            // Додаємо текстбокси в кожну комірку нового стовбця
            for (int i = 1; i < ItemContainer.RowDefinitions.Count; i++)
            {
                TextBox newTextBox = new TextBox
                {
                    Width = 30,
                    Height = 30,
                };

                Grid.SetColumn(newTextBox, ItemContainer.ColumnDefinitions.Count - 1);
                Grid.SetRow(newTextBox, i);

                ItemContainer.Children.Add(newTextBox);
            }
        }

        private void AddRow(object sender, RoutedEventArgs e)
        {
            // Додаємо новий рядок
            RowDefinition newRowDefinition = new RowDefinition();
            ItemContainer.RowDefinitions.Add(newRowDefinition);

            // Додаємо Label для нумерації рядків
            Label headerLabel = new Label
            {
                Content = (ItemContainer.RowDefinitions.Count - 1).ToString(), // Нумерація з 1
                Width = 30,
                Height = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(headerLabel, 0);
            Grid.SetRow(headerLabel, ItemContainer.RowDefinitions.Count - 1);
            ItemContainer.Children.Add(headerLabel);

            // Додаємо текстбокси в кожну комірку нового рядка
            for (int i = 1; i < ItemContainer.ColumnDefinitions.Count; i++)
            {
                TextBox newTextBox = new TextBox
                {
                    Width = 30,
                    Height = 30,
                };

                Grid.SetRow(newTextBox, ItemContainer.RowDefinitions.Count - 1);
                Grid.SetColumn(newTextBox, i);

                ItemContainer.Children.Add(newTextBox);
            }
        }




    }
}



