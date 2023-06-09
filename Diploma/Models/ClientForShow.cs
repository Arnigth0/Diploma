﻿namespace Diploma.Models
{
    public class ClientForShow
    {
        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Индивидуальный Идентификационный Номер (ИИН) клиента
        /// </summary>
        public string IIN { get; set; }

        /// <summary>
        /// Полное имя клиента
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        public string BirthDay { get; set; }

        /// <summary>
        /// Общий балл критериев заемщика
        /// </summary>
        public decimal? OverallCriteriaScore { get; set; }

        /// <summary>
        /// Общий балл характеристики заемщика
        /// </summary>
        public decimal? OverallCharacteristicsScore { get; set; }

        /// <summary>
        /// Общая оценка займа
        /// </summary>
        public decimal? OverallScore { get; set; }

        /// <summary>
        /// Итоговая оценка
        /// </summary>
        public decimal? FinalGrade { get; set; }
    }
}
