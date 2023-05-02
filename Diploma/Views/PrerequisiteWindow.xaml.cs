using Diploma.Model;
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
    /// Interaction logic for PrerequisiteWindow.xaml
    /// </summary>
    public partial class PrerequisiteWindow : Window
    {
        private readonly Prerequisite _prerequisite;
        private readonly Client _client;


        public PrerequisiteWindow(Client client)
        {
            InitializeComponent();
            _prerequisite = new Prerequisite();
            _client = client;
            _prerequisite.Client = client;
            client.Prerequisites = new() { _prerequisite };
        }

        private void CalulateTotalMonthlyIncome(object sender, RoutedEventArgs e)
        {
            if (IsTextBoxEmpty(MinimumLivingWage) && 
                IsTextBoxEmpty(DependentPersonsCount) && 
                IsTextBoxEmpty(MaxMonthlyLoanPayment) && 
                IsTextBoxEmpty(AverageSalaryLast3Months) && 
                IsTextBoxEmpty(AnnualOtherIncome))
            {
                _prerequisite.MinimumLivingWage = float.Parse(MinimumLivingWage.Text.ToString());
                _prerequisite.DependentPersonsCount = int.Parse(DependentPersonsCount.Text.ToString());
                _prerequisite.MaxMonthlyLoanPayment = float.Parse(MaxMonthlyLoanPayment.Text.ToString());
                _prerequisite.AverageSalaryLast3Months = float.Parse(AverageSalaryLast3Months.Text.ToString());
                _prerequisite.AnnualOtherIncome = float.Parse(AnnualOtherIncome.Text.ToString());

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
            if (IsTextBoxEmpty(MonthlyRentPayment) &&
                IsTextBoxEmpty(AnnualTuitionFee) &&
                IsTextBoxEmpty(CurrentCreditPayments) &&
                IsTextBoxEmpty(OtherExpensesLast3Months))
            {
                _prerequisite.MonthlyRentPayment = float.Parse(MonthlyRentPayment.Text.ToString());
                _prerequisite.AnnualTuitionFee = int.Parse(AnnualTuitionFee.Text.ToString());
                _prerequisite.CurrentCreditPayments = float.Parse(CurrentCreditPayments.Text.ToString());
                _prerequisite.OtherExpensesLast3Months = float.Parse(OtherExpensesLast3Months.Text.ToString());

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
            Close();
        }

        private static bool IsTextBoxEmpty(TextBox textBox)
        {
            return !string.IsNullOrEmpty(textBox.Text.ToString());
        }
    }
}
