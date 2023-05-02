using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Enums
{
    /// <summary>
    /// Сфера   деятельности работодателя
    /// </summary>
    public enum EmployerIndustry
    {
        /// <summary>
        /// Производство
        /// </summary>
        Manufacturing,

        /// <summary>
        /// Транспорт
        /// </summary>
        Transport,

        /// <summary>
        /// Добыча полезных ископаемых
        /// </summary>
        Mining,

        /// <summary>
        /// Связь, торговля, услуги
        /// </summary>
        Services,

        /// <summary>
        /// Финансы
        /// </summary>
        Finance,

        /// <summary>
        /// Иное
        /// </summary>
        Other
    }
}
