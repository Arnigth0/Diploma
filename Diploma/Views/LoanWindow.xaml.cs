using System.Windows;
using Diploma.Model;
using Diploma.Repositories;
using Diploma.Services;

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for LoanWindow.xaml
    /// </summary>
    public partial class LoanWindow : Window
    {
        private readonly Checks _checks;
        private readonly Client _client;
        private readonly Loan _loan;
        private readonly LoanRepository _loanRepository;

        public LoanWindow(Client client)
        {
            InitializeComponent();
            _loan = new Loan();
            _loanRepository = new LoanRepository(new());
            _checks = new Checks();
            _client = client;
            _loan.Client = _client;
        }

        private void CalculateLoan(object sender, RoutedEventArgs e)
        {
            if (_checks.IsTextBoxEmpty(AppraisalValue) &&
                _checks.IsTextBoxEmpty(CollateralDiscount) &&
                _checks.IsTextBoxEmpty(LoanAmount) &&
                _checks.IsTextBoxEmpty(InterestRate))
            {
                _loan.AppraisalValue = float.Parse(AppraisalValue.Text.ToString());
                _loan.CollateralDiscount = float.Parse(CollateralDiscount.Text.ToString());
                _loan.LoanAmount = float.Parse(LoanAmount.Text.ToString());
                _loan.InterestRate = float.Parse(InterestRate.Text.ToString());

                _loan.SecurityRatio = (_loan.AppraisalValue * (1 - _loan.CollateralDiscount)) 
                    / (_loan.LoanAmount * (1 + (2 * _loan.InterestRate / 12)));
                _loan.OverallScore = 100 * (1 - _loan.SecurityRatio);

                _client.Loan = new() { _loan };
                _loanRepository.Add(_loan);

                SecurityRatio.Text = _loan.SecurityRatio.ToString();
                SecurityRatio.Visibility = Visibility.Visible;
                SecurityRatioLabel.Visibility = Visibility.Visible;

                OverallScore.Text = _loan.OverallScore.ToString();
                OverallScore.Visibility = Visibility.Visible;
                OverallScoreLabel.Visibility = Visibility.Visible;

                FinalDecisionButton.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void FinalDecision(object sender, RoutedEventArgs e)
        {
            ConclusionWindow conclusionWindow = new(_client);
            conclusionWindow.Show();

            Close();
        }
    }
}
