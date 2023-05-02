using Diploma.Enums;
using System;
using System.Collections.Generic;

namespace Diploma.Model
{
    public class Client
    {

        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Индивидуальный Идентификационный Номер (ИИН) клиента
        /// </summary>
        public string IIN { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество клиента
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Пол клиента.
        /// </summary>
        public GenderType Gender { get; set; }

        /// <summary>
        /// Дата рождения клиента.
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Возраст клиента.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Адрес клиента
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Уникальный идентификатор характеристик клиента
        /// </summary>
        public int? ClientCharacterId { get; set; }

        /// <summary>
        /// Уникальный идентификатор займа
        /// </summary>
        public int? LoanId { get; set; }

        /// <summary>
        /// Уникальный идентификатор предварительных требований
        /// </summary>
        public int? PrerequisitesId { get; set; }

        /// <summary>
        /// Список предварительных требований для клиента
        /// </summary>
        public List<Prerequisite>? Prerequisites { get; set; }

        /// <summary>
        /// Список характеристик клиента
        /// </summary>
        public List<ClientCharacteristics>? ClientCharacteristics { get; set; }

        /// <summary>
        /// Список займов клиента
        /// </summary>
        public List<Loan>? Loan { get; set; }
    }
}
