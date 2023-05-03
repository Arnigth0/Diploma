using System;

namespace Diploma.Services
{
    public class StringToEnumService
    {
        public StringToEnumService() { }

        public Enums.MaritalStatus GetMaritalStatus(string MaritalStatusText)
        {
            return MaritalStatusText switch
            {
                "В браке" => Enums.MaritalStatus.Married,
                "Не состоял(а) в браке" => Enums.MaritalStatus.Divorced,
                "Разведен(а), живет отдельно" => Enums.MaritalStatus.Single,
                _ => throw new ArgumentException("Empty"),
            };
        }

        public Enums.PlaceOfResidence GetPlaceOfResidence(string PlaceOfResidence)
        {
            return PlaceOfResidence switch
            {
                "С родственниками" => Enums.PlaceOfResidence.LivingWithRelatives,
                "В арендуемой квартире" => Enums.PlaceOfResidence.Renting,
                "В собственном жилье" => Enums.PlaceOfResidence.Owning,
                _ => throw new ArgumentException("Empty"),
            };
        }

        public Enums.Education GetEducation(string Education)
        {
            return Education switch
            {
                "Среднее" => Enums.Education.Secondary,
                "Среднее специальное" => Enums.Education.Vocational,
                "Высшее" => Enums.Education.Higher,
                _ => throw new ArgumentException("Empty"),
            };
        }


        public Enums.Employment GetEmployment(string Employment)
        {
            return Employment switch
            {
                "Постоянная" => Enums.Employment.Permanent,
                "Периодическая" => Enums.Employment.Periodic,
                "Временная" => Enums.Employment.Temporary,
                _ => throw new ArgumentException("Empty"),
            };
        }

        public Enums.EmployerIndustry GetEmployerIndustry(string EmployerIndustry)
        {
            return EmployerIndustry switch
            {
                "Производство" => Enums.EmployerIndustry.Manufacturing,
                "Транспорт" => Enums.EmployerIndustry.Transport,
                "Добыча полезных ископаемых" => Enums.EmployerIndustry.Mining,
                "Связь, торговля, услуги" => Enums.EmployerIndustry.Services,
                "Финансы" => Enums.EmployerIndustry.Finance,
                "Иное" => Enums.EmployerIndustry.Other,
                _ => throw new ArgumentException("Empty"),
            };
        }

        public Enums.EmploymentStatus GetEmploymentStatus(string EmploymentStatus)
        {
            return EmploymentStatus switch
            {
                "Неполная ставка" => Enums.EmploymentStatus.PartTime,
                "Полная ставка" => Enums.EmploymentStatus.FullTime,
                _ => throw new ArgumentException("Empty"),
            };
        }
    }
}
