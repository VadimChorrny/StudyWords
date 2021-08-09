using BLL.Service;
using DAL;
using StudyWords.Page;
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

namespace StudyWords
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWordService wordService = new WordService();
        private readonly List<(string en, string ru, int order)> wordsPairs = new List<(string, string, int)>();
        private static readonly Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            ReLoadWords();
        }

        // Перезагрузка списка пар слов.
        // Более правильно - это если в IWordService реализовать
        // метод возвращающий не отдельный слова, а пры слов.
        // Тогда их сразу можно было бы записать в wordsPairs.
        private void ReLoadWords()
        {
            // Получение списков слов
            IEnumerable<string> words = wordService.GetWords();
            IEnumerable<string> trans = wordService.GetTranslate();

            // Получение перечислителей списков
            IEnumerator<string> wordsEnum = words.GetEnumerator();
            IEnumerator<string> transEnum = trans.GetEnumerator();

            // Очистка списка пара
            wordsPairs.Clear();

            // Заполнение списка пар
            while (wordsEnum.MoveNext())
            {
                _ = transEnum.MoveNext();
                wordsPairs.Add((wordsEnum.Current, transEnum.Current, random.Next()));
            }

            // Случайная сортировка списка пар
            wordsPairs.Sort((x, y) => x.order.CompareTo(y.order));

            // Сброс результатов
            progressbar.Value = 0;
            txtScore.Text = $"Score: {progressbar.Value}";
        }

        private void LoadWords()
        { // Вот здесь (на скобке) поставьте точку останова.

            // Получение последней пары
            var pair = wordsPairs[wordsPairs.Count - 1];

            // Удаление полученной пары, чтобы не было повторений
            wordsPairs.RemoveAt(wordsPairs.Count - 1);

            txtWords.Text = pair.en;
            txtTranslateWords.Text = pair.ru;
        }

        // DON'T KNOW
        private void NoknowButtonClick(object sender, RoutedEventArgs e)
        {
            if (progressbar.Value > 0)
            {
                progressbar.Value--;
                txtScore.Text = $"Score: {progressbar.Value}";
            }
            else
            {
                MessageBox.Show("Your level very-very low!");
            }
            LoadWords();
        }

        // KNOW
        private void KnowButtonClick(object sender, RoutedEventArgs e)
        {
            if (progressbar.Value < 100)
            {
                progressbar.Value++;
                txtScore.Text = $"Score: {progressbar.Value}";
            }
            else
            {
                MessageBox.Show("Your level very-very height!");
            }
            LoadWords();
        }

        private void OnReloadClick(object sender, RoutedEventArgs e)
        {
            ReLoadWords();
        }
        private void SettingButtonClick(object sender,RoutedEventArgs e)
        {
            this.Content = new DataGridPage();
        }
    }
}
