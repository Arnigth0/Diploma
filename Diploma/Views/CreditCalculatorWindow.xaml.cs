﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Diploma.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using OfficeOpenXml;
using System.IO;

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

        private void ReturnToMainMenu(object sender, RoutedEventArgs e) => this.Close();       

        private void CalculationButton(object sender, RoutedEventArgs e)
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

            ShowAllFields();
        }

        private void ShowAllFields()
        {
            this.Height = 650;
            this.PaymentAmount.Visibility = Visibility.Visible;
            this.PaymentAmountLabel.Visibility = Visibility.Visible;
            this.TotalPayments.Visibility = Visibility.Visible;
            this.TotalPaymentsLabel.Visibility = Visibility.Visible;
            this.PaymentSchedule.Visibility = Visibility.Visible;
            this.ExportLabel.Visibility = Visibility.Visible;
            this.ExportToDocx.Visibility = Visibility.Visible;
            this.ExportToExcel.Visibility = Visibility.Visible;
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

        private void ExportToDocxButton(object sender, RoutedEventArgs e)
        {
            
        }

        private void ExportToExcelButton(object sender, RoutedEventArgs e)
        {
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //using(var excelPackage = new ExcelPackage())
            //{
            //    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("График платежa");

            //    worksheet.Cells[1, 1].Value = "Период";
            //    worksheet.Cells[1, 2].Value = "Сумма платежа";
            //    worksheet.Cells[1, 3].Value = "Проценты";
            //    worksheet.Cells[1, 4].Value = "Главный долг";
            //    worksheet.Cells[1, 5].Value = "Остаток задолжности";

            //    ObservableCollection<Payment>? payments = this.PaymentSchedule.ItemsSource as ObservableCollection<Payment>;

            //    // заполняем ячейки данными из класса
            //    if (payments != null)
            //    {
            //        for (int i = 0; i < payments.Count; i++)
            //        {
            //            worksheet.Cells[i + 2, 1].Value = payments[i].Period;
            //            worksheet.Cells[i + 2, 2].Value = payments[i].Amount;
            //            worksheet.Cells[i + 2, 3].Value = payments[i].Interest;
            //            worksheet.Cells[i + 2, 4].Value = payments[i].Principal;
            //            worksheet.Cells[i + 2, 5].Value = payments[i].Balance;
            //        }

            //        using (FileStream outputStream = new(@$"График платежa {DateTime.Now:dd.MM.yyyy hh:mm}.xlsx", FileMode.Create, FileAccess.Write))
            //        {
            //            excelPackage.SaveAs("C:\\Users\\arman\\OneDrive\\Рабочий стол\\" + outputStream);
            //        }
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}           
        }
    }
}
