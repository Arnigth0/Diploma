using Diploma.Model;
using Diploma.Enums;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System;
using Diploma.Services;
using Diploma.Repositories;

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientCharacteristicsWindow : Window
    {
        private bool constantWork;
        private readonly Client _client;
        private readonly StringToEnumService _stringToEnumService;
        private readonly ClientCharacteristicsRepository _clientCharacteristicsRepository;

        public AddClientCharacteristicsWindow(Client client)
        {
            InitializeComponent();
            _clientCharacteristicsRepository = new(new());
            _stringToEnumService = new StringToEnumService();
            _client = client;
        }

        private void GoToPrerequisiteWindow(object sender, RoutedEventArgs e)
        {
            if ( IsStackPanelChecked(MaritalStatus) &&
                NumberOfChildren != null &&
                PlaceOfResidence.SelectedItem != null &&
                LengthOfResidence != null &&
                Education.SelectedItem != null &&
                IsStackPanelChecked(Employment) &&
                IsStackPanelChecked(IsBankEmployee) &&
                IsStackPanelChecked(HasCriminalRecord) &&
                IsStackPanelChecked(HasPreviousCreditHistory) &&
                IsStackPanelChecked(HasOutstandingLoans) &&
                (constantWork == false ||
                    (constantWork == true &&
                    EmployerIndustry.SelectedItem != null &&
                    IsStackPanelChecked(EmploymentStatus) &&
                    EmploymentLength != null))
                )
            {
                ClientCharacteristics clientCharacteristics = new()
                {
                    MaritalStatus = _stringToEnumService.GetMaritalStatus(GetContentFromStackPanel(MaritalStatus)),
                    NumberOfChildren = int.Parse(NumberOfChildren.Text.ToString()),
                    PlaceOfResidence = _stringToEnumService.GetPlaceOfResidence(((ComboBoxItem)PlaceOfResidence.SelectedItem).Content.ToString()),
                    LengthOfResidence = int.Parse(LengthOfResidence.Text.ToString()),
                    Education = _stringToEnumService.GetEducation(((ComboBoxItem)Education.SelectedItem).Content.ToString()),
                    Employment = _stringToEnumService.GetEmployment(GetContentFromStackPanel(Employment)),
                    EmployerIndustry = _stringToEnumService.GetEmployerIndustry(((ComboBoxItem)EmployerIndustry.SelectedItem).Content.ToString()),
                    EmploymentStatus = _stringToEnumService.GetEmploymentStatus(GetContentFromStackPanel(EmploymentStatus)),
                    EmploymentLength = int.Parse(EmploymentLength.Text.ToString()),
                    IsBankEmployee = GetContentFromStackPanel(IsBankEmployee) == "Да" ? true : false,
                    HasPreviousCreditHistory = GetContentFromStackPanel(HasPreviousCreditHistory) == "Да" ? true : false,
                    HasOutstandingLoans = GetContentFromStackPanel(HasOutstandingLoans) == "Да" ? true : false,
                    HasCriminalRecord = GetContentFromStackPanel(HasCriminalRecord) == "Да" ? true : false,
                    ClientId = _client.Id,
                    Client = _client
                };

                clientCharacteristics.OverallCharacteristicsScore = (float)CalculateOveralScore(clientCharacteristics);
                clientCharacteristics.Client = _client;
                _client.ClientCharacteristics = new() { clientCharacteristics };

                _clientCharacteristicsRepository.Add(clientCharacteristics);

                PrerequisiteWindow prerequisiteWindow = new(_client);
                prerequisiteWindow.Show();

                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private bool IsStackPanelChecked(StackPanel stackPanel)
        {
            bool isSelected = false;

            foreach (RadioButton radioButton in stackPanel.Children)
                if (radioButton.IsChecked == true)
                    isSelected = true;

            return isSelected;
        }

        private string GetContentFromStackPanel(StackPanel stack)
        {
            string result = string.Empty;

            if (stack != null)
                foreach (var radioButton in stack.Children.OfType<RadioButton>())
                    if ((bool)radioButton.IsChecked)
                        result += radioButton.Content.ToString();

            return result;
        }

        private void EmploymentClick(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton selectedRadioButton && selectedRadioButton.IsChecked == true && selectedRadioButton.Content.ToString() == "Постоянная")
            {
                EmployerIndustryLabel.Visibility = Visibility.Visible;
                EmployerIndustry.Visibility = Visibility.Visible;
                EmploymentStatusLabel.Visibility = Visibility.Visible;
                EmploymentStatus.Visibility = Visibility.Visible;
                EmploymentLengthLabel.Visibility = Visibility.Visible;
                EmploymentLength.Visibility = Visibility.Visible;
                constantWork = true;
            }
            else
            {
                EmployerIndustryLabel.Visibility = Visibility.Hidden;
                EmployerIndustry.Visibility = Visibility.Hidden;
                EmploymentStatusLabel.Visibility = Visibility.Hidden;
                EmploymentStatus.Visibility = Visibility.Hidden;
                EmploymentLengthLabel.Visibility = Visibility.Hidden;
                EmploymentLength.Visibility = Visibility.Hidden;
                constantWork = false;
            }
        }
    
        private static double CalculateOveralScore(ClientCharacteristics clientCharacteristics)
        {
            double OveralScore = 0;

            OveralScore += clientCharacteristics.Client.Gender == GenderType.Female ? 2 : 0;

            OveralScore += clientCharacteristics.MaritalStatus switch
            {
                Enums.MaritalStatus.Married => 0.5,
                Enums.MaritalStatus.Divorced => 1,
                _ => 0 
            };

            OveralScore += clientCharacteristics.NumberOfChildren >= 2 ? 1 : 1.5;

            OveralScore += clientCharacteristics.PlaceOfResidence switch
            {
                Enums.PlaceOfResidence.Renting => 1,
                Enums.PlaceOfResidence.Owning => 1.5,
                _ => 0
            };

            OveralScore += clientCharacteristics.LengthOfResidence <= 4 ? 0.8 : 3.5;

            OveralScore += clientCharacteristics.Education switch
            {
                Enums.Education.Higher => 1,
                Enums.Education.Vocational => 0.5,
                _ => 0
            };

            switch (clientCharacteristics.Employment)
            {
                case Enums.Employment.Permanent:
                    OveralScore += 1;

                    OveralScore += clientCharacteristics.EmployerIndustry switch
                    {
                        Enums.EmployerIndustry.Manufacturing => 0.5,
                        Enums.EmployerIndustry.Transport => 1.5,
                        Enums.EmployerIndustry.Mining => 2.0,
                        Enums.EmployerIndustry.Services => 2.0,
                        Enums.EmployerIndustry.Finance => 3.0,
                        _ => 0.0
                    };

                    OveralScore += clientCharacteristics.EmploymentStatus == Enums.EmploymentStatus.PartTime ? 0 : 1;
                    OveralScore += clientCharacteristics.EmploymentLength >= 4 ? 3 : 0.7;
                    break;

                case Enums.Employment.Periodic:
                    OveralScore += 0.5;
                    break;

                case Enums.Employment.Temporary:
                    OveralScore += 0.5;
                    break;

                default:
                    break;
            }

            OveralScore += clientCharacteristics.IsBankEmployee == true ? 5.0 : 0.0;
            OveralScore += clientCharacteristics.HasPreviousCreditHistory == true ? -1.0 : 0.0;
            OveralScore += clientCharacteristics.HasOutstandingLoans == true ? -5.0 : 1.0;
            OveralScore += clientCharacteristics.HasCriminalRecord == true ? -20.0 : 0.0;

            return OveralScore;
        }
    }
}
