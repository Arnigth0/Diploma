using Diploma.Repositories;
using System.Windows;
using Diploma.Models;
using System;

namespace Diploma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly DataBaseContext _dbContext;

        MainWindow main;

        public MainWindow()
        {
            InitializeComponent();
            main = this;


            main.ListView.Items.Add(new ClientForShow() { Id = 1, IIN="020503500655", BirthDay = new System.DateOnly(), Fullname = "Арман Темиргали", OverallCriteriaScore = Convert.ToDecimal(85.6), OverallScore = Convert.ToDecimal(59.1)});
            main.ListView.Items.Add(new ClientForShow() { Id = 2, IIN ="950106911544", BirthDay = new System.DateOnly(), Fullname = "Наташа Албай", OverallCriteriaScore = Convert.ToDecimal(8.6), OverallScore = Convert.ToDecimal(59.21)});

        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string iin = main.IIN.ToString().Trim();

            if (string.IsNullOrEmpty(iin))
                return;          

            //if(ListView != null) 
            //{
            //    foreach(var item in main.ListView.Items)
            //    {
            //        ClientForShow? client = item as ClientForShow;

            //        bool isClientNull = client == null;
            //        bool isIINEqual = client.IIN == iin;

            //        if (isClientNull && isIINEqual) 
            //        {
            //            ListView.SelectedIndex = client.Id - 1;
            //        }
            //    }
            //}
        }

        private void Add(object sender, RoutedEventArgs e)
        {

        }

        private void CreditRating(object sender, RoutedEventArgs e)
        {

        }

        private void CreditCalculator(object sender, RoutedEventArgs e)
        {

        }
    }
}
