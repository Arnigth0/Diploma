using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Repositories
{
    public class LoanRepository
    {
        private readonly DataBaseContext _dbContext;

        public LoanRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
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
