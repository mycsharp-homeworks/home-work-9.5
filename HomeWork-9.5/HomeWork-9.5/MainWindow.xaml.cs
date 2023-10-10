using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace HomeWork_9._5
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

        private void SplitButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIfTextIsNotEmpty(TextToSplit.Text);
            ListView.ItemsSource = WordsPrinter(TextToSplit.Text);
        }

        private void InversionButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIfTextIsNotEmpty(TextToInvert.Text);
            InversionLabel.Content = InvertWords(TextToInvert.Text);
        }

        /// <summary>
        /// Метод проверяет содержимое TextBox, если он пуст,
        /// то выдает соотвествующее предупреждение
        /// </summary>
        /// <param name="stringToSplit"></param>
        /// <returns></returns>
        private void CheckIfTextIsNotEmpty(string text)
        {
            if(String.IsNullOrEmpty(text))
            {
                MessageBox.Show(
                    "Сначала введите текст", 
                    this.Title,
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                    );
            }
        }

        /// <summary>
        /// Метод разделяет строку на слова, заполняет ими массив и возвращает его
        /// </summary>
        /// <param name="stringToSplit"></param>
        /// <returns></returns>
        private string[] StringIntoArrayOfWords(string stringToSplit)
        {
            char emptySpace = ' ';
            string[] result = stringToSplit.Split(emptySpace, (char)StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        /// <summary>
        /// Метод принемает строку, передает ее в  StringIntoArrayOfWords(), 
        /// полученный массив слов выводит на экран
        /// </summary>
        /// <param name="stringToSplitAndPrint"></param>
        private ObservableCollection<string> WordsPrinter(string stringToSplitAndPrint)
        {
            string[] words = StringIntoArrayOfWords(stringToSplitAndPrint);
            ObservableCollection<string> listOfWords = new ObservableCollection<string>();

            for (int i = 0; i < words.Length; i++)
            {
                listOfWords.Add(words[i]);
            }

            return listOfWords;
        }

        /// <summary>
        /// Метод принимает строку, передает ее в StringIntoArrayOfWords,
        /// распечатывает полученный массив слов задом наперед
        /// и переносит на новую строку каждые 4 слова, что бы поместить
        /// весь текст в Label
        /// </summary>
        /// <param name="textToInvert"></param>
        private string InvertWords(string textToInvert)
        {
            string[] words = StringIntoArrayOfWords(textToInvert);
            string inversionResult = "";

            for (int i = words.Length - 1; i >= 0; i--)
            {
                if(i % 4 == 0 && i != words.Length - 1)
                {
                    inversionResult += words[i] + " \n";
                } else
                {
                    inversionResult += words[i] + " ";
                }                
            }

            return inversionResult;
        }
    }
}
