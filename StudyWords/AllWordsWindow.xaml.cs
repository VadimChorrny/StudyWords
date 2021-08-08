using BLL.Service;
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

namespace StudyWords
{
    /// <summary>
    /// Interaction logic for AllWordsWindow.xaml
    /// </summary>
    public partial class AllWordsWindow : Window
    {
        IWordService wordService = new WordService();
        int index = 0;
        public AllWordsWindow()
        {
            InitializeComponent();
            LoadAllWords();
        }
        void LoadAllWords()
        {
            foreach (var item in wordService.GetWord().Where(a => a.Id == index))
            {
                txtShow.Text += item;
            }
        }

        private void btnKnow_Click(object sender, RoutedEventArgs e)
        {
            index++;
        }

        private void btnDontKnow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
