using BLL.Service;
using DAL.Entities;
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

namespace StudyWords.Page
{
    /// <summary>
    /// Interaction logic for DataGridPage.xaml
    /// </summary>
    public partial class DataGridPage
    {

        IWordService wordService = new WordService();
        public DataGridPage()
        {
            InitializeComponent();
            LoadDate();
        }

        void LoadDate()
        {
            datagrid.ItemsSource = wordService.GetAll();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in datagrid.SelectedItems)
            {
                Word word = item as Word;
                if(word != null)
                {
                    wordService.Update((Word)item);
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in datagrid.SelectedItems)
            {
                Word word = item as Word;
                if (word != null)
                {
                    wordService.RemoveWord((Word)item);
                }
            }
        }
    }
}
