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
using System.Windows.Shapes;

namespace MiniExcel
{
    /// <summary>
    /// Interaction logic for PopUpWindow.xaml
    /// </summary>
    public partial class PopUpWindow : Window
    {
        public string MyWindowName { get; set; } // цей приймає ім'я вінка (шоб понятно було шо ти відкрив)
        public dynamic myWindowContent { get; set; } // цей приймає тип контенту, щоб можа було його правильно налаштувати можна замінити на шось інше наприклад var або похуй в цілому
        public dynamic myWindowAction { get; set; } // це приймає обєкт класу в якому буде виконуватись дія, щоб коли нажав на ок то зразу відправлялось то шо нада туди куди нада




        public PopUpWindow()
        {
            InitializeComponent();
            SetWindowName();
            WindowContent(myWindowContent);
            WindowActon(myWindowAction);
            Show();
        }

        private void SetWindowName()
        {
            WindowName.Content = MyWindowName;
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void WindowContent()  // Прийом масива
        {

        }
        void WindowContent(string result) //виведення результатів дій
        {

        }
        void WindowContent(int graph) // Виведення графіка
        {

        }

        void WindowActon()
        {
            
        }
        void WindowActon(int a)
        {
            
        }
    }
    }
