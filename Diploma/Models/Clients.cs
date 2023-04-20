using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Model
{
    class Clients
    {
        public int Id { get; set; }
        public string IIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public int ClientCharacterId { get; set; }
        public int LoanId { get; set; }
        public int PrerequisitesId { get; set; }
    }
}
