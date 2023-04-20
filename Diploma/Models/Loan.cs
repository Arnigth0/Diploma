using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Model
{
    class Loan
    {
        public int Id { get; set; }
        public float AppraisalValue { get; set; }
        public float CollateralDiscount { get; set; }
        public float LoanAmount { get; set; }
        public float InterestRate { get; set; }
        public float SecurityRatio { get; set; }
        public float OverallScore { get; set; }
    }
}
