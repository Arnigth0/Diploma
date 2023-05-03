using Diploma.Repositories;
using System.Windows;
using Diploma.Models;
using System;
using System.Collections.Generic;
using Diploma.ViewModels;
using Diploma.Views;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Diploma.Model;

namespace Diploma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataBaseContext _dbContext;
        private readonly ClientsRepository _clientsRepository;
        private readonly ClientForShowRepository _clientForShowRepository;

        public MainWindow()
        {
            InitializeComponent();

            _dbContext = new();
            _clientForShowRepository = new(_dbContext);
            _clientsRepository = new(_dbContext);

            FillTheTable();
        }

        public MainWindow(ClientsRepository clientsRepository, ClientForShowRepository clientForShowRepository)
        {
            InitializeComponent();

            if (clientForShowRepository == null && clientsRepository == null)
            {
                _dbContext = new();
                _clientForShowRepository = new(_dbContext);
                _clientsRepository = new(_dbContext);
            } 
            else
            {
                _clientsRepository = clientsRepository;
                _clientForShowRepository = clientForShowRepository;
            }

            FillTheTable();
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new (
                _clientsRepository,
                _clientForShowRepository
            );

            addClientWindow.Show();
            Close();
        }

        private void GoToCreditCalculator(object sender, RoutedEventArgs e)
        {
            CreditCalculatorWindow creditCalculatorWindow = new();
            creditCalculatorWindow.Show();
            Close();
        }

        private void GoToBorrowerData(object sender, RoutedEventArgs e)
        {
            if (ClientsForShowSchedule.SelectedItem is ClientForShow selectedClient)
            {
                BorrowerDataWindow borrowerDataWindow = new (
                    _clientsRepository, 
                    selectedClient.IIN
                );

                borrowerDataWindow.Show();
                Close();
            }
        }

        private void FillTheTable()
        {
            ObservableCollection<ClientForShow> cfsSchedeule = new();
            List<ClientForShow> clientForShowList = _clientForShowRepository.FindAll();

            clientForShowList.ForEach(client =>
            {
                cfsSchedeule.Add(client);
            });

            ClientsForShowSchedule.ItemsSource = cfsSchedeule;
        }
             
    }
}
