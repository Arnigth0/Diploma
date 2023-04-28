using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Repositories
{
    public class ClientCharacteristicsRepository
    {
        private readonly DataBaseContext _dbContext;

        public ClientCharacteristicsRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public int GetCount()
        {
            try
            {
                return _dbContext.ClientCharacteristics.Count();
            }
            catch
            {
                return 0;
            }
        }

    }
}
