﻿using BLL.Service;
using System;
using System.Collections;
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
    /// Interaction logic for ShowCardWindow.xaml
    /// </summary>
    public partial class ShowCardWindow : Window
    {
        IGroupService groupService = new GroupService();
        IWordService wordService = new WordService();
        public ShowCardWindow()
        {
            InitializeComponent();
            LoadAllGroups();
        }

        private void LoadAllGroups()
        {
            cbGroups.ItemsSource = groupService.GetGroupName();
        }
        private void LoadSelectedWordsGroup()
        {
            datagrid.ItemsSource = wordService.GetAll();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadSelectedWordsGroup();
        }
    }
}
