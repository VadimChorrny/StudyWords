using BLL.Service;
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
        public ShowCardWindow()
        {
            InitializeComponent();
            LoadAllGroups();
        }

        private void LoadAllGroups()
        {
            foreach (var item in groupService.GetId())
            {
                TextBlock txtBlock = new TextBlock();
                txtBlock.FontSize = 30;
                txtBlock.Text = groupService.GetGroupName().First();
                groupPanel.Children.Add(txtBlock);
            }
        }
    }
}
