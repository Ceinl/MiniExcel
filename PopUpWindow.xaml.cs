using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace MiniExcel
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
        public dynamic myWindowContent { get; set; } // цей приймає тип контенту, щоб можа було його правильно налаштувати можна замінити на шось інше наприклад var або похуй в цілому
        public dynamic myWindowAction { get; set; } // це приймає обєкт класу в якому буде виконуватись дія, щоб коли нажав на ок то зразу відправлялось то шо нада туди куди нада      

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

        private void CreateInputTextBox() { }
        private void CreateBoolParam() { }
        private void CreateTextBoxParam() { }

        public void SortContent()
        {
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
                confirmButton.Click += temp;
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
