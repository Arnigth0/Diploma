using Diploma.Model;
using Diploma.Repositories;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Diploma.Models;
using Diploma.Enums;

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private readonly ClientsRepository _clientsRepository;
        private readonly PrepequisiteRepository _prepequisiteRepository;
        private readonly LoanRepository _loanRepository;
        private readonly ClientCharacteristicsRepository _clientCharacteristicsRepository;
        private readonly ClientForShowRepository _clientForShowRepository;

        public AddClientWindow(
            ClientsRepository clientsRepository, 
            ClientForShowRepository clientForShowRepository, 
            ClientCharacteristicsRepository clientCharacteristicsRepository, 
            LoanRepository loanRepository, 
            PrepequisiteRepository prepequisiteRepository
            )
        {
            InitializeComponent();
            _clientsRepository = clientsRepository;
            _clientCharacteristicsRepository = clientCharacteristicsRepository;
            _loanRepository = loanRepository;
            _prepequisiteRepository = prepequisiteRepository;
            _clientForShowRepository = clientForShowRepository;       
        }

        private void ReturnToMainMenu(object sender, RoutedEventArgs e)
        {
            MainWindow main = new (
                _clientsRepository,
                _clientForShowRepository,
                _clientCharacteristicsRepository,
                _loanRepository,
                _prepequisiteRepository
            );

            main.Show();
            Close();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new()
                {
                    IIN = IIN.Text.ToString(),
                    FirstName = FirstName.Text.ToString(),
                    LastName = LastName.Text.ToString(),
                    Gender = GetGenderByIIN(IIN.Text.ToString()),
                    BirthDay = GetDateFromIIN(IIN.Text.ToString()),
                    Age = (int)(DateTime.Today.Subtract(GetDateFromIIN(IIN.Text.ToString())).Days / 365),
                    Address = Address.Text.ToString(),
                    ClientCharacterId = _clientCharacteristicsRepository.GetCount(),
                    LoanId = _loanRepository.GetCount(),
                    PrerequisitesId = _prepequisiteRepository.GetCount(),
                };

                //MessageBox.Show(@$"
                //    IIN : {client.IIN}
                //    FirstName : {client.FirstName}
                //    LastName: {client.LastName}
                //    Gender : {client.Gender}
                //    BirthDay: {client.BirthDay}
                //    Age : {client.Age}
                //        {client.LoanId}{client.ClientCharacterId}{client.PrerequisitesId}
                //");

                _clientsRepository.Add(client);

                _clientForShowRepository.Add(new ClientForShow()
                {
                    IIN = client.IIN,
                    Fullname = client.FirstName + " " + client.LastName + (string.IsNullOrEmpty(client.MiddleName) ? "" : " " + client.MiddleName),
                    BirthDay = client.BirthDay.ToString()
                });

                MessageBox.Show("Успешно завершено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
                    
            ReturnToMainMenu(sender, e);
        }

        private static DateTime GetDateFromIIN(string IIN)
        {
            int year = Convert.ToInt32(IIN.Substring(0, 2));
            int month = Convert.ToInt32(IIN.Substring(2, 2));
            int day = Convert.ToInt32(IIN.Substring(4, 2));
            int century = Convert.ToInt32(IIN.Substring(6, 1)) switch
            {
                1 => 1800,
                2 => 1800,
                3 => 1900,
                4 => 1900,
                5 => 2000,
                6 => 2000,
                _ => throw new ArgumentException("Invalid IIN Century"),
            };

            return new DateTime(year + century, month, day);
        }

        private static GenderType GetGenderByIIN(string IIN)
        {
            return Convert.ToInt32(IIN.Substring(6, 1)) % 2 == 0 ? GenderType.Female : GenderType.Male;
        }
    }
}
