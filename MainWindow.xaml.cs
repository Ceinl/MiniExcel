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
        public MainWindow()
        {
            InitializeComponent();
        }
        int TextRow = 0;
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



