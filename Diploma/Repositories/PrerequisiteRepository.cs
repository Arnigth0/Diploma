using Diploma.Model;
using System.Linq;
using Diploma.Models;

namespace Diploma.Repositories
{
    public class PrerequisiteRepository
    {
        private readonly DataBaseContext _dbContext;

        public PrerequisiteRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public int Add(Prerequisite prerequisite)
        {
            var Prerequisite = _dbContext.Prerequisites.FirstOrDefault(x => x.ClientId == prerequisite.ClientId);

            if(Prerequisite == null)
            {
                Prerequisite = prerequisite;
            }
            else
            {
                _dbContext.Add(prerequisite);
            }
            
            _dbContext.SaveChanges();
            return prerequisite.Id;
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
