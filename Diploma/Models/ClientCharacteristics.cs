using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Model
{
    class ClientCharacteristics
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string MaritalStatus { get; set; }
        public int? NumberOfChildren { get; set; }
        public string PlaceOfResidence { get; set; }
        public int? LengthOfResidence { get; set; }
        public string Education { get; set; }
        public string Employment { get; set; }
        public string EmployerIndustry { get; set; }
        public string EmploymentStatus { get; set; }
        public int? EmploymentLength { get; set; }
        public bool IsBankEmployee { get; set; }
        public bool HasPreviousCreditHistory { get; set; }
        public bool HasOutstandingLoans { get; set; }
        public bool HasCriminalRecord { get; set; }
    }
}
