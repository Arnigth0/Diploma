namespace Diploma.Model
{
    /// <summary>
    /// Финансовая состоятельность клиента
    /// </summary>
    public class Prerequisite
    {
        /// <summary>
        /// Уникальный идентификатор заявки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Минимальный уровень прожиточного минимума для региона заемщика
        /// </summary>
        public float MinimumLivingWage { get; set; }

        /// <summary>
        /// Количество иждивенцев
        /// </summary>
        public float DependentPersonsCount { get; set; }

        /// <summary>
        /// Максимальный ежемесячный платеж по займу, который может позволить заемщик
        /// </summary>
        public float MaxMonthlyLoanPayment { get; set; }

        /// <summary>
        /// Средняя заработная плата заемщика за последние 3 месяца
        /// </summary>
        public float AverageSalaryLast3Months { get; set; }

        /// <summary>
        /// Годовой доход, полученный заемщиком помимо зарплаты
        /// </summary>
        public float AnnualOtherIncome { get; set; }

        /// <summary>
        /// Общий ежемесячный доход заемщика
        /// </summary>
        public float TotalMonthlyIncome { get; set; }

        /// <summary>
        /// Расходы заемщика на содержание семьи
        /// </summary>
        public float FamilyMaintenanceExpenses { get; set; }

        /// <summary>
        /// Ежемесячный платеж заемщика за аренду жилья
        /// </summary>
        public float MonthlyRentPayment { get; set; }

        /// <summary>
        /// Годовые расходы заемщика на обучение
        /// </summary>
        public float AnnualTuitionFee { get; set; }

        /// <summary>
        /// Текущие ежемесячные платежи заемщика по кредитам
        /// </summary>
        public float CurrentCreditPayments { get; set; }

        /// <summary>
        /// Прочие расходы заемщика за последние 3 месяца
        /// </summary>
        public float OtherExpensesLast3Months { get; set; }

        /// <summary>
        /// Общие ежемесячные расходы заемщика
        /// </summary>
        public float TotalMonthlyExpenses { get; set; }

        /// <summary>
        /// Ежемесячный остаток денежных средств после вычета расходов из доходов
        /// </summary>
        public float MonthlyDisposableIncome { get; set; }

        /// <summary>
        /// Доля ежемесячного платежа по займу от общих ежемесячных расходов заемщика
        /// </summary>
        public float LoanPaymentPercentage { get; set; }

        /// <summary>
        /// Общий балл критериев заемщика
        /// </summary>
        public float OverallCriteriaScore { get; set; }

        /// <summary>
        /// Уникальный идентификатор заемщика
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Заемщик, которому принадлежит заявка
        /// </summary>
        public Client Client { get; set; }
    }
}
