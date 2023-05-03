using Diploma.Repositories;
using System.Windows;
using Diploma.Models;
using System.Collections.Generic;
using Diploma.Views;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;

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

        private void IINChanged(object sender, TextChangedEventArgs e)
        {
            string searchIIN = IIN.Text.ToString();
            ICollectionView view = CollectionViewSource.GetDefaultView(ClientsForShowSchedule.ItemsSource);

            if (view != null)
            {
                view.Filter = item => ((ClientForShow)item).IIN.Contains(searchIIN);
                ClientsForShowSchedule.SelectedItems.Clear();

                foreach (var item in view)
                {
                    ClientsForShowSchedule.SelectedItems.Add(item);
                }
            }
        }
    }
}
