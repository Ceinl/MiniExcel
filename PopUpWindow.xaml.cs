using System;
using System.Diagnostics;
using System.Linq;
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


        private void CreateLabel(string LabelContent, int x, int y) 
        {
            Label label = new Label
            {
                Content = LabelContent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(label, y); 
            Grid.SetRow(label, x);  
            popupWindowContainer.Children.Add(label);
        }

        private void CreateTextbox(string TextBoxContent, int x, int y) 
        {
            TextBox textBox = new TextBox
            {
                Text = TextBoxContent,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 150,
                TextAlignment = TextAlignment.Center,
            };
            Grid.SetColumn(textBox, y);
            Grid.SetRow(textBox, x);
            popupWindowContainer.Children.Add(textBox);

        }

        private void CreateRadiobutton(string RadioButtonContent, int x, int y) 
        {
            RadioButton radioButton = new RadioButton
            {
                Content = RadioButtonContent,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(radioButton, y);
            Grid.SetRow(radioButton, x);
            popupWindowContainer.Children.Add(radioButton);


        }

        private string GetFromTextBox(int x, int y)
        {
            string coordinates = null;

            // Перевірка, чи грід існує та чи координати знаходяться в межах гріда
            if (popupWindowContainer != null && x >= 0 && y >= 0 && x < popupWindowContainer.ColumnDefinitions.Count && y < popupWindowContainer.RowDefinitions.Count)
            {
                // Отримання тексту з текстового поля за допомогою індексів стовпця і рядка
                TextBox textBox = popupWindowContainer.Children
                    .OfType<TextBox>()
                    .FirstOrDefault(tb => Grid.GetColumn(tb) == x && Grid.GetRow(tb) == y);

                if (textBox != null)
                {
                    coordinates = textBox.Text;
                }
            }

            return coordinates;
        }

        private double GetDoubleFromTextBox(int x, int y)
        {
            string text = GetFromTextBox(x, y);

            if(double.TryParse(text, out double number))
            {
                return number;
            }

            MessageBox.Show("Enter the number into field", "Warning!", MessageBoxButton.OK, MessageBoxImage.Error);
            return double.NaN;
        }

        public (int, int) GetCoorditates(int x, int y)
        {
                string toTransform = GetFromTextBox(x, y);

            

            int CoordinateX = 0, coordinateY = 0;
            
                string[] coordinates = toTransform.Split('/');

                if (coordinates.Length == 2)
                {
                    if (int.TryParse(coordinates[0], out CoordinateX) && int.TryParse(coordinates[1], out coordinateY))
                    {
                        return (CoordinateX, coordinateY);
                    }
                    else 
                    {
                        MessageBox.Show("Please put only numbers to coordinates");
                        return (12, 12);
                    }
                }
                else 
                {
                    MessageBox.Show("Please use a x/y coordinates pattern");
                    return (12, 12);
                }
        }




        private void InputContent() 
        {
            CreateLabel("Please write input coordinates:", 0, 0);
            CreateTextbox("1/1", 0, 1);
            CreateTextbox("5/5", 0, 2);
        }

        public void SortContent()
        {
            // 2 текст бокса + параметр (тру фолс)
            InputContent();
            CreateLabel("Please choice a sorting parametr:", 1, 0);
            CreateRadiobutton("From lower to higher",1,1);
            CreateRadiobutton("From higher to lower", 1,2);
        }
        public void FilterContent() 
        {
            // 2 текст бокса + параметр (2 текст бокса)
            InputContent();
            CreateLabel("Please write filtering diapason:", 1, 0);
            CreateTextbox("low border", 1, 1);
            CreateTextbox("high border", 1, 2);

        }
        public void AvarageContent()
        {
            // 2 текст бокса 
            InputContent();

        }
        public void MinContent()
        {
            // 2 текст бокса 
            InputContent();

        }
        public void MaxContent()
        {
            // 2 текст бокса 
            InputContent();

        }

        public void OutputContent(string Result)
        {
            CreateLabel($"Your result: {Result}", 1, 1);
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
            var startCoords = GetCoorditates(1, 0);
            var endCoords = GetCoorditates(2, 0);
            DataManager.SortFunc(startCoords.Item1,startCoords.Item2,endCoords.Item1, endCoords.Item2);
            Hide();
        }
        public void FilterAction(object sender, RoutedEventArgs e)
        {
            var startCoords = GetCoorditates(1, 0);
            var endCoords = GetCoorditates(2, 0);
            double minValue = GetDoubleFromTextBox(1,1);
            double maxValue = GetDoubleFromTextBox(2,1);
            DataManager.FilterFunc(startCoords.Item1, startCoords.Item2, endCoords.Item1, endCoords.Item2, minValue, maxValue);
            Hide();
        }
        public void AvarageAction(object sender, RoutedEventArgs e)
        {
            var startCoords = GetCoorditates(1, 0);
            var endCoords = GetCoorditates(2, 0);
            DataManager.AvarageFunc(startCoords.Item1, startCoords.Item2, endCoords.Item1, endCoords.Item2);
        }
        public void MinAction(object sender, RoutedEventArgs e)
        {
            var startCoords = GetCoorditates(1, 0);
            var endCoords = GetCoorditates(2, 0);
            DataManager.MinFunc(startCoords.Item1, startCoords.Item2, endCoords.Item1, endCoords.Item2);
            Hide();
        }
        public void MaxAction(object sender, RoutedEventArgs e)
        {
            var startCoords = GetCoorditates(1, 0);
            var endCoords = GetCoorditates(2, 0);
            DataManager.MaxFunc(startCoords.Item1, startCoords.Item2, endCoords.Item1, endCoords.Item2);
        }



        // TEXT CONTENT

        public void UpperCaseContent()
        {

        }
        public void LowerCaseContent() 
        {
        
        }
        public void sortAbcContent() 
        {
        
        }
        public void sortLenghtContent() 
        {
        
        }
        public void searchContent()
        {

        }
        // TEXT ACTION

        public void UpperCaseAction(object sender, RoutedEventArgs e)
        {

        }
        public void LowerCaseAction(object sender, RoutedEventArgs e)
        {

        }
        public void sortAbcAction(object sender, RoutedEventArgs e)
        {

        }
        public void sortLenghtAction(object sender, RoutedEventArgs e)
        {

        }
        public void searchAction(object sender, RoutedEventArgs e)
        {

        }









        public void OutputAction(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
