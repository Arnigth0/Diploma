using Diploma.Repositories;
using System.Windows;
using Diploma.Models;
using System;
using System.Collections.Generic;
using Diploma.ViewModels;
using Diploma.Views;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Diploma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataBaseContext _dbContext;
        private readonly ClientsRepository _clientsRepository;
        private readonly PrepequisiteRepository _prepequisiteRepository;
        private readonly LoanRepository _loanRepository;
        private readonly ClientCharacteristicsRepository _clientCharacteristicsRepository;
        private readonly ClientForShowRepository _clientForShowRepository;

        public MainWindow ()
        {
            InitializeComponent();
            _dbContext = new();
            _clientForShowRepository = new(_dbContext);
            _clientsRepository = new(_dbContext);
            _loanRepository = new(_dbContext);
            _clientCharacteristicsRepository = new(_dbContext);
            _prepequisiteRepository = new(_dbContext);

            FillTheTable();
        }

        public MainWindow(
            ClientsRepository? clientsRepository,
            ClientForShowRepository? clientForShowRepository,
            ClientCharacteristicsRepository? clientCharacteristicsRepository,
            LoanRepository? loanRepository,
            PrepequisiteRepository? prepequisiteRepository
            )
        {
            InitializeComponent();

            _dbContext = new();
            _clientForShowRepository = clientForShowRepository ?? new(_dbContext);
            _clientsRepository = clientsRepository ?? new(_dbContext);
            _loanRepository = loanRepository ?? new(_dbContext);
            _clientCharacteristicsRepository = clientCharacteristicsRepository ?? new(_dbContext);
            _prepequisiteRepository = prepequisiteRepository ?? new(_dbContext);

            FillTheTable();
        }

        private void AddClient(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new (
                _clientsRepository,
                _clientForShowRepository,
                _clientCharacteristicsRepository,
                _loanRepository,
                _prepequisiteRepository
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
