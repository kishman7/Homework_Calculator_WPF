using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calculator_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in GroupButton.Children) //перебираємо всі елементи, які входять до Grid (Name="GroupButton")
            {
                if (el is Button) //якщо елемент є Button
                {
                    ((Button)el).Click += Button_Click; //то підписуємось на подію Button_Click, яка буде реалізовувати процес натиснення кнопки
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) //функція натиснення на кнопку
        {
            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString(); // в змінну присвоюємо значення Content кнопки

                if (textButton == "C")
                {
                    text.Clear(); //очищаємо поле textbox
                }
                else if (textButton == "x")
                {
                    text.Text = text.Text.Substring(text.Text.Length - (text.Text.Length - 1)); // реалізація кнопки Backspace
                }
                else if (textButton == "=")
                {
                    text.Text = new DataTable().Compute(text.Text, null).ToString(); // реалізація кнпки "="
                }
                else
                {
                    text.Text += textButton; //реалізація всіх інших кнопок
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //якщо не вірно введений синтаксис для калькулятора
            }
            
        }
    }
}
