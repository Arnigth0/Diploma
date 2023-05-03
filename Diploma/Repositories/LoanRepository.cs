using Diploma.Model;
using Diploma.Models;
using System.Linq;

namespace Diploma.Repositories
{
    public class LoanRepository
    {
        private readonly DataBaseContext _dbContext;

        public LoanRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public int Add(Loan loan)
        {
            var Loans = _dbContext.Loans.FirstOrDefault(c => c.ClientId == loan.ClientId);

            if (Loans != null)
            {
                Loans = loan;
            }
            else
            {
                _dbContext.Add(loan);
            }

            _dbContext.SaveChanges();
            return loan.Id;
        }

        public int GetCount()
        {
            try
            {
                return _dbContext.Loans.Count();
            }
            catch 
            { 
                return 1; 
            }
        }
    }
}
