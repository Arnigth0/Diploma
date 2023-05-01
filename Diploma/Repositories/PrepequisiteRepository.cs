using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Repositories
{
    public class PrepequisiteRepository
    {
        private readonly DataBaseContext _dbContext;

        public PrepequisiteRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public int GetCount()
        {
            try
            {
                return _dbContext.Prerequisites.Count();
            }
            catch
            {
                return 1;
            }
        }
    }
}
