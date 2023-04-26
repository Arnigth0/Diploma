using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Diploma.Models;

namespace Diploma.Views
{
    /// <summary>
    /// Interaction logic for CreditCalculatorWindow.xaml
    /// </summary>
    public partial class CreditCalculatorWindow : Window
    {
        public CreditCalculatorWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get input values
            double loanAmount = double.Parse(LoanAmount.Text);
            int loanTerm = int.Parse(LoanTerm.Text);
            string paymentType = ((ComboBoxItem)PaymentType.SelectedItem).Content.ToString();
            string paymentFrequency = ((ComboBoxItem)PaymentFrequency.SelectedItem).Content.ToString();
            double interestRate = GetInterestRateOfPayment(paymentType);

            // Calculate payment amount and total payments
            double paymentAmount = CalculatePaymentAmount(loanAmount, interestRate, loanTerm, paymentFrequency);
            double totalPayments = paymentAmount * GetNumberOfPayments(paymentFrequency, loanTerm);

            // Display payment amount and total payments
            this.PaymentAmount.Text = Math.Round(paymentAmount, 2).ToString();
            this.TotalPayments.Text = Math.Round(totalPayments, 2).ToString();
            // MessageBox.Show($"Payment amount: {paymentAmount:C}\nTotal payments: {totalPayments:C}");

            // Calculate payment schedule
            ObservableCollection<Payment> paymentSchedule = CalculatePaymentSchedule(loanAmount, interestRate, loanTerm, paymentAmount, paymentFrequency);

            // Bind payment schedule to the data grid
            PaymentSchedule.ItemsSource = paymentSchedule;
        }

        private double CalculatePaymentAmount(double loanAmount, double interestRate, int loanTerm, string paymentType)
        {
            double annualInterestRate = interestRate / 100;
            int numberOfPayments = GetNumberOfPayments(paymentType, loanTerm);
            double discountFactor = (Math.Pow(1 + annualInterestRate / numberOfPayments, numberOfPayments) - 1) / (annualInterestRate / numberOfPayments * Math.Pow(1 + annualInterestRate / numberOfPayments, numberOfPayments));
            double paymentAmount = loanAmount / discountFactor;
            return paymentAmount;
        }

        private double GetInterestRateOfPayment(string paymentType)
        {
            return paymentType switch
            {
                "Аннуитет" => 12.2,
                "Дискрет" => 8.9,
                _ => throw new ArgumentException("Invalid payment type"),
            };
        }

        private int GetNumberOfPayments(string paymentFrequency, int loanTerm)
        {
            return paymentFrequency switch
            {
                "Ежемесячно" => loanTerm * 12,
                "Ежеквартально" => loanTerm * 4,
                "Ежегодно" => loanTerm,
                _ => throw new ArgumentException("Invalid payment type"),
            };
        }

        private ObservableCollection<Payment> CalculatePaymentSchedule(double loanAmount, double interestRate, int loanTerm, double paymentAmount, string paymentType)
        {
            double annualInterestRate = interestRate / 100;
            int numberOfPayments = GetNumberOfPayments(paymentType, loanTerm);
            double monthlyInterestRate = annualInterestRate / numberOfPayments;
            double balance = loanAmount;
            ObservableCollection<Payment> paymentSchedule = new ObservableCollection<Payment>();
            for (int i = 1; i <= numberOfPayments; i++)
            {
                double interest = balance * monthlyInterestRate;
                double principal = paymentAmount - interest;
                balance -= principal;
                paymentSchedule.Add(new Payment
                {
                    Period = i,
                    Amount = Math.Round(paymentAmount, 2),
                    Interest = Math.Round(interest, 2),
                    Principal = Math.Round(principal, 2),
                    Balance = Math.Round(balance, 2)
                });
            }
            return paymentSchedule;
        }

        private void PaymentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InterestRate.Text = GetInterestRateOfPayment(((ComboBoxItem)PaymentType.SelectedItem).Content.ToString()).ToString();
        }
    }
}
