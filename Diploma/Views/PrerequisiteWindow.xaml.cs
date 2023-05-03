using Diploma.Model;
using Diploma.Repositories;
using Diploma.Services;
using System.Windows;

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for PrerequisiteWindow.xaml
    /// </summary>
    public partial class PrerequisiteWindow : Window
    {
        private readonly Prerequisite _prerequisite;
        private readonly Client _client;
        private readonly Checks _checks;
        private readonly PrerequisiteRepository _prerequisiteRepository;
        private readonly ClientForShowRepository _clientForShowRepository;


        public PrerequisiteWindow(Client client, ClientForShowRepository clientForShowRepository)
        {
            InitializeComponent();
            _clientForShowRepository = clientForShowRepository;
            _prerequisite = new Prerequisite();
            _prerequisiteRepository = new PrerequisiteRepository(new());
            _checks = new Checks();
            _client = client;
        }

        private void CalulateTotalMonthlyIncome(object sender, RoutedEventArgs e)
        {
            if (_checks.IsTextBoxEmpty(MinimumLivingWage) &&
                _checks.IsTextBoxEmpty(DependentPersonsCount) &&
                _checks.IsTextBoxEmpty(MaxMonthlyLoanPayment) && 
                _checks.IsTextBoxEmpty(AverageSalaryLast3Months) && 
                _checks.IsTextBoxEmpty(AnnualOtherIncome))
            {
                _prerequisite.MinimumLivingWage = float.Parse(MinimumLivingWage.Text.ToString().Replace('.', ','));
                _prerequisite.DependentPersonsCount = int.Parse(DependentPersonsCount.Text.ToString().Replace('.', ','));
                _prerequisite.MaxMonthlyLoanPayment = float.Parse(MaxMonthlyLoanPayment.Text.ToString().Replace('.', ','));
                _prerequisite.AverageSalaryLast3Months = float.Parse(AverageSalaryLast3Months.Text.ToString().Replace('.', ','));
                _prerequisite.AnnualOtherIncome = float.Parse(AnnualOtherIncome.Text.ToString().Replace('.', ','));

                _prerequisite.TotalMonthlyIncome = _prerequisite.AverageSalaryLast3Months + (_prerequisite.AnnualOtherIncome / 12);         
                _prerequisite.FamilyMaintenanceExpenses = (_prerequisite.DependentPersonsCount + 1) * _prerequisite.MinimumLivingWage;
                FamilyMaintenanceExpenses.Text = _prerequisite.FamilyMaintenanceExpenses.ToString();
                TotalMonthlyIncome.Text = _prerequisite.TotalMonthlyIncome.ToString();

                TotalMonthlyIncome.Visibility = Visibility.Visible;
                TotalMonthlyIncomeText.Visibility = Visibility.Visible;
                ExpensesGrid.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void CalculateTotalMonthlyExpensesTextBox(object sender, RoutedEventArgs e)
        {
            if (_checks.IsTextBoxEmpty(MonthlyRentPayment) &&
                _checks.IsTextBoxEmpty(AnnualTuitionFee) &&
                _checks.IsTextBoxEmpty(CurrentCreditPayments) &&
                _checks.IsTextBoxEmpty(OtherExpensesLast3Months))
            {
                _prerequisite.MonthlyRentPayment = float.Parse(MonthlyRentPayment.Text.ToString().Replace('.', ','));
                _prerequisite.AnnualTuitionFee = int.Parse(AnnualTuitionFee.Text.ToString().Replace('.', ','));
                _prerequisite.CurrentCreditPayments = float.Parse(CurrentCreditPayments.Text.ToString().Replace('.', ','));
                _prerequisite.OtherExpensesLast3Months = float.Parse(OtherExpensesLast3Months.Text.ToString().Replace('.', ','));

                _prerequisite.TotalMonthlyExpenses = _prerequisite.FamilyMaintenanceExpenses
                    + _prerequisite.MonthlyRentPayment
                    + (_prerequisite.AnnualTuitionFee / 12)
                    + _prerequisite.CurrentCreditPayments
                    + _prerequisite.OtherExpensesLast3Months;

                _prerequisite.MonthlyDisposableIncome = (_prerequisite.TotalMonthlyIncome - _prerequisite.TotalMonthlyExpenses);
                _prerequisite.LoanPaymentPercentage = _prerequisite.MinimumLivingWage / _prerequisite.MonthlyDisposableIncome;
                _prerequisite.OverallCriteriaScore = 100 * (1 - _prerequisite.LoanPaymentPercentage);

                TotalMonthlyExpenses.Text = _prerequisite.TotalMonthlyExpenses.ToString();
                MonthlyDisposableIncome.Text = _prerequisite.MonthlyDisposableIncome.ToString();
                LoanPaymentPercentage.Text = _prerequisite.LoanPaymentPercentage.ToString();
                OverallCriteriaScore.Text = _prerequisite.OverallCriteriaScore.ToString();

                TotalMonthlyExpensesText.Visibility = Visibility.Visible;
                TotalMonthlyExpenses.Visibility = Visibility.Visible;
                ConclusionGrid.Visibility = Visibility.Visible;
                ContinueButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            _client.PrerequisitesId = _prerequisiteRepository.Add(_prerequisite);
            _client.Prerequisites = new() { _prerequisite };
            _clientForShowRepository.UpdateOverallCriteriaScore(_client.IIN, (decimal)_prerequisite.OverallCriteriaScore);

            LoanWindow loanWindow = new LoanWindow(_client, _clientForShowRepository);
            loanWindow.Show();

            Close();
        }
    }
}
