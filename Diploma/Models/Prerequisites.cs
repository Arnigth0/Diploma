using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Model
{
    class Prerequisites
    {
        public int Id { get; set; }
        public float MinimumLivingWage { get; set; }
        public float DependentPersonsCount { get; set; }
        public float MaxMonthlyLoanPayment { get; set; }
        public float AverageSalaryLast3Months { get; set; }
        public float AnnualOtherIncome { get; set; }
        public float TotalMonthlyIncome { get; set; }
        public float FamilyMaintenanceExpenses { get; set; }
        public float MonthlyRentPayment { get; set; }
        public float AnnualTuitionFee { get; set; }
        public float CurrentCreditPayments { get; set; }
        public float OtherExpensesLast3Months { get; set; }
        public float TotalMonthlyExpenses { get; set; }
        public float MonthlyDisposableIncome { get; set; }
        public float LoanPaymentPercentage { get; set; }
        public float OverallCriteriaScore { get; set; }
    }
}
