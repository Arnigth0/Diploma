namespace Diploma.Model
{
    /// <summary>
    /// Обеспечение кредита
    /// </summary>
    public class Loan
    {
        /// <summary>
        /// Уникальный идентификатор займа
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Оценочная стоимость залога
        /// </summary>
        public float AppraisalValue { get; set; }

        /// <summary>
        /// Скидка на стоимость залога
        /// </summary>
        public float CollateralDiscount { get; set; }

        /// <summary>
        /// Сумма займа
        /// </summary>
        public float LoanAmount { get; set; }

        /// <summary>
        /// Процентная ставка по займу
        /// </summary>
        public float InterestRate { get; set; }

        /// <summary>
        /// Коэффициент безопасности займа
        /// </summary>
        public float SecurityRatio { get; set; }

        /// <summary>
        /// Общая оценка займа
        /// </summary>
        public float OverallScore { get; set; }

        /// <summary>
        /// Уникальный идентификатор клиента, которому принадлежит данный займ
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент, которому принадлежит данный займ
        /// </summary>
        public Client Client { get; set; }
    }
}
