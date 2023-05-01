using Diploma.Model;
using Diploma.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
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

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for BorrowerDataWindow.xaml
    /// </summary>
    public partial class BorrowerDataWindow : Window
    {
        private readonly ClientsRepository _clientRepository;
        private readonly Client _client;

        public BorrowerDataWindow(ClientsRepository clientRepository, string IIN)
        {
            InitializeComponent();
            _clientRepository = clientRepository;
            _client = _clientRepository.FindByIIN(IIN);

            FullName.Text = _client.FirstName + " " + _client.LastName + (string.IsNullOrEmpty(_client.MiddleName) ? "" : " " + _client.MiddleName);
            this.IIN.Text = IIN;
            this.Address.Text = _client.Address;
            BirthDay.Text = _client.BirthDay.ToString("dd MMM yyyy") + " г.р.";
        }

        public void ReturnBack(object sender, RoutedEventArgs e)
        {
            MainWindow main = new(
                _clientRepository,
                null,
                null,
                null,
                null
            );

            main.Show();
            Close();
        }

        public void Continue(object sender, RoutedEventArgs e)
        {
            //AddClientCharacteristicsWindow addClientCharacteristicsWindow = new(_client);
            //addClientCharacteristicsWindow.Show();

            //Close();
        }
    }
}
