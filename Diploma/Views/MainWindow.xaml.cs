using Diploma.Repositories;
using System.Windows;
using Diploma.Models;
using System;
using System.Collections.Generic;
using Diploma.ViewModels;
using Diploma.Views;

namespace Diploma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataBaseContext context = new DataBaseContext();    

            DataContext = new MainViewModel(new ClientForShowRepository(new DataBaseContext()));
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            AddClientWindow addClientWindow = new();
            addClientWindow.Show();
        }
    }
}
