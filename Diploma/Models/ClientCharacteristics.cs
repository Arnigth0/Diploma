using System;

namespace Diploma.Model
{
    /// <summary>
    /// Характер клиента
    /// </summary>
    class ClientCharacteristics
    {
        /// <summary>
        /// Уникальный идентификатор клиента.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Пол клиента.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Возраст клиента.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Семейное положение клиента (если есть).
        /// </summary>
        public string? MaritalStatus { get; set; }

        /// <summary>
        /// Количество детей у клиента (если есть).
        /// </summary>
        public int? NumberOfChildren { get; set; }

        /// <summary>
        /// Место проживания клиента (если есть).
        /// </summary>
        public string? PlaceOfResidence { get; set; }

        /// <summary>
        /// Длительность проживания клиента по текущему месту жительства (если есть).
        /// </summary>
        public int? LengthOfResidence { get; set; }

        /// <summary>
        /// Образование клиента (если есть).
        /// </summary>
        public string? Education { get; set; }

        /// <summary>
        /// Тип занятости клиента (если есть).
        /// </summary>
        public string? Employment { get; set; }

        /// <summary>
        /// Отрасль работодателя клиента (если есть).
        /// </summary>
        public string? EmployerIndustry { get; set; }

        /// <summary>
        /// Статус занятости клиента (если есть).
        /// </summary>
        public string? EmploymentStatus { get; set; }

        /// <summary>
        /// Длительность работы на текущем месте (если есть).
        /// </summary>
        public int? EmploymentLength { get; set; }

        /// <summary>
        /// Работает ли клиент в банке (если есть).
        /// </summary>
        public bool? IsBankEmployee { get; set; }

        /// <summary>
        /// Имеет ли клиент кредитную историю (если есть).
        /// </summary>
        public bool? HasPreviousCreditHistory { get; set; }

        /// <summary>
        /// Имеет ли клиент непогашенные кредиты (если есть).
        /// </summary>
        public bool? HasOutstandingLoans { get; set; }

        /// <summary>
        /// Имеет ли клиент судимость (если есть).
        /// </summary>
        public bool? HasCriminalRecord { get; set; }

        /// <summary>
        /// Уникальный идентификатор клиента, которому принадлежат данные.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Клиент, которому принадлежат данные.
        /// </summary>
        public Client Client { get; set; }
    }
}
