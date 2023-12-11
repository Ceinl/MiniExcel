using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Runtime.CompilerServices;
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


        private static TextBox[,] textBoxArray;

        public MainWindow()
        {
            InitializeComponent();
            textBoxArray = new TextBox[11, 11];
            AddRowAction(); 
            AddRowAction();
            AddColumnAction();
            AddColumnAction();
        }


        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.SortContent();
            popUpWindow.SetEvent(popUpWindow.SortAction);
            popUpWindow.Show();
        }

        private void intFilterButton_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.FilterContent();
            popUpWindow.SetEvent(popUpWindow.FilterAction);
            popUpWindow.Show();
        }

        private void intMinValue_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.MinContent();
            popUpWindow.SetEvent(popUpWindow.MinAction);
            popUpWindow.Show();
        }

        private void intAvarageValue_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.AvarageContent();
            popUpWindow.SetEvent(popUpWindow.AvarageAction);
            popUpWindow.Show();
        }

        private void intMaxValue_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.MaxContent();
            popUpWindow.SetEvent(popUpWindow.MaxAction);
            popUpWindow.Show();

        }

        private void ShowPopUpWindow()
        {

        }

        private void AddColumn(object sender, RoutedEventArgs e)
        {
            AddColumnAction();
        }

        private void AddRow(object sender, RoutedEventArgs e)
        {
            AddRowAction();
        }

        private void AddRowAction()
        {
            if (ItemContainer.RowDefinitions.Count >= 11)
            {
                MessageBox.Show("Maximum number of rows (10) reached.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Додаємо новий рядок
            RowDefinition newRowDefinition = new RowDefinition();
            ItemContainer.RowDefinitions.Add(newRowDefinition);

            if (textBoxArray == null)
            {
                textBoxArray = new TextBox[ItemContainer.RowDefinitions.Count, ItemContainer.ColumnDefinitions.Count];
            }

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
                    Width = 60,
                    Height = 60,
                };

                Grid.SetRow(newTextBox, ItemContainer.RowDefinitions.Count - 1);
                Grid.SetColumn(newTextBox, i);

                ItemContainer.Children.Add(newTextBox);

                //Додаємо текстбокс в масив по відповідних координатах
                textBoxArray[i, ItemContainer.RowDefinitions.Count - 1] = newTextBox;
            }
        }

        private void AddColumnAction()
        {
            if (ItemContainer.ColumnDefinitions.Count >= 11)
            {
                MessageBox.Show("Maximum number of columns (10) reached.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            // Додаємо новий стовбець
            ColumnDefinition newColumn = new ColumnDefinition();
            ItemContainer.ColumnDefinitions.Add(newColumn);

            if (textBoxArray == null)
            {
                textBoxArray = new TextBox[ItemContainer.RowDefinitions.Count, ItemContainer.ColumnDefinitions.Count];
            }

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
                    Width = 60,
                    Height = 60,
                };

                Grid.SetColumn(newTextBox, ItemContainer.ColumnDefinitions.Count - 1);
                Grid.SetRow(newTextBox, i);

                ItemContainer.Children.Add(newTextBox);

                //Додаємо текстбокс в масив по відповідних координатах
                textBoxArray[ItemContainer.ColumnDefinitions.Count - 1, i] = newTextBox;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        public static TextBox[,] GetTextBoxes()
        {
            return textBoxArray;
        }

        public static void SetTextBoxes(TextBox[,] newTextBoxArray, int startRow, int startColumn, int endRow, int endColumn)
        {
            int rows = newTextBoxArray.GetLength(0);
            int columns = newTextBoxArray.GetLength(1);

            // Ensure that the dimensions match
            if (rows == textBoxArray.GetLength(0) && columns == textBoxArray.GetLength(1))
            {
                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startColumn; j <= endColumn; j++)
                    {
                        if (newTextBoxArray[i, j] != null)
                        {
                            textBoxArray[i, j].Text = newTextBoxArray[i, j].Text;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Dimensions do not match.");
                // Handle a case where the dimensions do not match (optional)
                // You may choose to throw an exception or handle it differently based on your requirements
            }
        }

    }
}



