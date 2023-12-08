using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace MiniExcel
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
       // public dynamic myWindowContent { get; set; } // цей приймає тип контенту, щоб можа було його правильно налаштувати можна замінити на шось інше наприклад var або похуй в цілому
       // public dynamic myWindowAction { get; set; } // це приймає обєкт класу в якому буде виконуватись дія, щоб коли нажав на ок то зразу відправлялось то шо нада туди куди нада      

        public PopUpWindow()
        {
            InitializeComponent();
            Show();
        }

        private void SetWindowName()
        {
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //--- Контент вводу ---

        // 0/0 x/y

        private void CreateInputfields()
        {
            // Create Label and TextBoxes
            Label label = new Label
            {
                Content = "Label",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBox textBox1 = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBox textBox2 = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center
            };

            // Add controls to the existing popupWindowContainer Grid
            Grid.SetColumn(label, 0); // Column 1
            Grid.SetRow(label, 0);    // Row 1

            Grid.SetColumn(textBox1, 1); // Column 2
            Grid.SetRow(textBox1, 0);    // Row 1

            Grid.SetColumn(textBox2, 2); // Column 3
            Grid.SetRow(textBox2, 0);    // Row 1

            popupWindowContainer.Children.Add(label);
            popupWindowContainer.Children.Add(textBox1);
            popupWindowContainer.Children.Add(textBox2);
        }


        private void CreateBoolParam() { }
        private void CreateTextBoxParam() { }

        public void SortContent()
        {
            CreateInputfields();
            // 2 текст бокса + параметр (тру фолс)
        }
        public void FilterContent() 
        {
            // 2 текст бокса + параметр (2 текст бокса)
        }
        public void AvarageContent()
        {
            // 2 текст бокса 
        }
        public void MinContent()
        {
            // 2 текст бокса 
        }
        public void MaxContent()
        {
            // 2 текст бокса 
        }
        //--- Контент виводу ---

        public void SetEvent(RoutedEventHandler temp)
        {
            if (temp != null)
            {
                //confirmButton.Click += temp;
            }
        }
        public void SortAction(object sender, RoutedEventArgs e)
        {

        }
        public void FilterAction(object sender, RoutedEventArgs e)
        {

        }
        public void AvarageAction(object sender, RoutedEventArgs e)
        {

        }
        public void MinAction(object sender, RoutedEventArgs e)
        {

        }
        public void MaxAction(object sender, RoutedEventArgs e)
        {
        
        }


    }
}
