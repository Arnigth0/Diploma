using Diploma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Repositories
{
    public class PrerequisiteRepository
    {
        private readonly DataBaseContext _dbContext;

        public PrerequisiteRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public void Add(Prerequisite prerequisite)
        {
            _dbContext.Add(prerequisite);
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
