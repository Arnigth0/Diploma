using Diploma.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientCharacteristicsWindow : Window
    {
        private bool constantWork;
        private readonly Client _client;

        public AddClientCharacteristicsWindow()
        {
            InitializeComponent();
            //_client = client;
        }

        private void GoToPrerequisiteWindow(object sender, RoutedEventArgs e)
        {
            if (MaritalStatus != null &&
                NumberOfChildren != null &&
                PlaceOfResidence != null &&
                LengthOfResidence != null &&
                Education != null &&
                Employment != null &&
                IsBankEmployee != null &&
                HasCriminalRecord != null &&
                HasPreviousCreditHistory != null &&
                HasOutstandingLoans != null &&
                (constantWork == false ||
                    (constantWork == true &&
                    EmployerIndustry != null &&
                    EmploymentStatus != null &&
                    EmploymentLength != null))
                )
            {

                ClientCharacteristics clientCharacteristics = new ClientCharacteristics()
                {
                    MaritalStatus = GetContentFromStackPanel(MaritalStatus),
                    NumberOfChildren = int.Parse(NumberOfChildren.Text.ToString()),
                    PlaceOfResidence = PlaceOfResidence.ToString(),
                    LengthOfResidence = int.Parse(LengthOfResidence.Text.ToString()),
                    Education = Education.ToString(),
                    Employment = GetContentFromStackPanel(Employment),
                    EmployerIndustry = EmployerIndustry.ToString(),
                    EmploymentStatus = GetContentFromStackPanel(EmploymentStatus),
                    EmploymentLength = int.Parse(EmploymentLength.Text.ToString()),
                    IsBankEmployee = GetContentFromStackPanel(IsBankEmployee) == "Да" ? true : false,
                    HasPreviousCreditHistory = GetContentFromStackPanel(HasPreviousCreditHistory) == "Да" ? true : false,
                    HasOutstandingLoans = GetContentFromStackPanel(HasOutstandingLoans) == "Да" ? true : false,
                    HasCriminalRecord = GetContentFromStackPanel(HasCriminalRecord) == "Да" ? true : false,
                    ClientId = _client.Id,
                    Client = _client
                };

                clientCharacteristics.OverallCharacteristicsScore = CalculateOveralScore(clientCharacteristics);
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private string GetContentFromStackPanel(StackPanel stack)
        {
            string result = string.Empty;

            if (stack != null) 
                foreach (var radioButton in stack.Children.OfType<RadioButton>()) 
                    result = radioButton.Content.ToString(); 

            return result;
        }

        private void EmploymentClick(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton.IsChecked == true && selectedRadioButton.Content.ToString() == "Постоянная")
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
    
        private float CalculateOveralScore(ClientCharacteristics clientCharacteristics)
        {
            //float gender = clientCharacteristics.Client.Gender == "Мужчина" 

            //return 0;
        }
    }
}
