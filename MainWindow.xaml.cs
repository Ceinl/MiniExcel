using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            initStartScreen();
        }

        private void initStartScreen() 
        {
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

        /////////////////////////////// ТЕКСТОВІ ІВЕНТИ 
        private void upperCaseBtn_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.UpperCaseContent();
            popUpWindow.SetEvent(popUpWindow.UpperCaseAction);
            popUpWindow.Show();
        }

        private void lowerCaseBtn_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.LowerCaseContent();
            popUpWindow.SetEvent(popUpWindow.LowerCaseAction);
            popUpWindow.Show();
        }

        private void sortAbcBtn_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.sortAbcContent();
            popUpWindow.SetEvent(popUpWindow.sortAbcAction);
            popUpWindow.Show();
        }

        private void sortLenghtBtn_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.sortLenghtContent();
            popUpWindow.SetEvent(popUpWindow.sortLenghtAction);
            popUpWindow.Show();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            PopUpWindow popUpWindow = new PopUpWindow();
            popUpWindow.searchContent();
            popUpWindow.SetEvent(popUpWindow.searchAction);
            popUpWindow.Show();
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

            RowDefinition newRowDefinition = new RowDefinition();
            ItemContainer.RowDefinitions.Add(newRowDefinition);

            if (textBoxArray == null)
            {
                textBoxArray = new TextBox[ItemContainer.RowDefinitions.Count, ItemContainer.ColumnDefinitions.Count];
            }

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
            ColumnDefinition newColumn = new ColumnDefinition();
            ItemContainer.ColumnDefinitions.Add(newColumn);

            if (textBoxArray == null)
            {
                textBoxArray = new TextBox[ItemContainer.RowDefinitions.Count, ItemContainer.ColumnDefinitions.Count];
            }
            Label headerLabel = new Label
            {
                Content = (ItemContainer.ColumnDefinitions.Count - 1).ToString(), 
                Width = 30,
                Height = 30,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(headerLabel, ItemContainer.ColumnDefinitions.Count - 1);
            Grid.SetRow(headerLabel, 0);
            ItemContainer.Children.Add(headerLabel);

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

        public static void SetTextBox(TextBox[,] UpdatedTextBox)
        {
            int rows = UpdatedTextBox.GetLength(0);
            int columns = UpdatedTextBox.GetLength(1);



            if (rows == textBoxArray.GetLength(0) && columns == textBoxArray.GetLength(1))
            {
                for (int i = 1; i <= FieldManipulator.UpdateFieldCoordinates[3]; i++)
                {
                    for (int j = 1; j <= FieldManipulator.UpdateFieldCoordinates[2]; j++)
                    {
                        if (UpdatedTextBox[i, j] != null)
                        {
                            textBoxArray[i, j].Text = UpdatedTextBox[i, j].Text;
                            Debug.Print(textBoxArray[i, j].Text);
                        }
                        else 
                        {
                            MessageBox.Show("pf");

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Dimensions do not match.");
   
            }
        }

        private void removeColumnBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ItemContainer.ColumnDefinitions.Count > 0)
            {
                int columnIndexToRemove = ItemContainer.ColumnDefinitions.Count - 1;
                ItemContainer.ColumnDefinitions.RemoveAt(columnIndexToRemove);

                foreach (UIElement child in ItemContainer.Children)
                {
                    if (Grid.GetColumn(child) == columnIndexToRemove)
                    {
                        ItemContainer.Children.Remove(child);
                        break; 
                    }
                }
            }
        }

        private void removeRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ItemContainer.RowDefinitions.Count > 0)
            {
                int rowIndexToRemove = ItemContainer.RowDefinitions.Count - 1;
                ItemContainer.RowDefinitions.RemoveAt(rowIndexToRemove);

                foreach (UIElement child in ItemContainer.Children)
                {
                    if (Grid.GetRow(child) == rowIndexToRemove)
                    {
                        ItemContainer.Children.Remove(child);
                        break; 
                    }
                }
            }
        }

    }
}
