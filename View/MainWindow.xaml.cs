using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using lab1.Model;
using lab1.ViewModel;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;
using System.Windows.Media;
using System.Text;

namespace lab1
{

    public partial class MainWindow : Window
    {
        private void GiveBtn_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 3;
        }

        private void BooksBtn_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        private void UsersBtn_Click(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        public MainWindow()
        {
            
            BooksViewModel viewModel = new BooksViewModel();
            UsersViewModel usersViewModel = new UsersViewModel();
            UsersBookViewModel usersBookViewModel = new UsersBookViewModel();
            InitializeComponent();

            GiveUser.DataContext = usersViewModel;
            GiveBook.DataContext = viewModel;
            GiveUserBook.DataContext = usersBookViewModel;
            ItemUser.DataContext = usersViewModel;
            ItemBook.DataContext = viewModel;
            ItemUserBook.DataContext = usersBookViewModel;


        }


    }
}
