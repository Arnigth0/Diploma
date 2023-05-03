using Diploma.Model;
using Diploma.Models;
using System.Linq;

namespace Diploma.Repositories
{
    public class ClientCharacteristicsRepository
    {
        private readonly DataBaseContext _dbContext;

        public ClientCharacteristicsRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public int Add(ClientCharacteristics clientCharacteristics)
        {
            var ClientCharacteristics = _dbContext.ClientCharacteristics.FirstOrDefault(c => c.ClientId == clientCharacteristics.ClientId);

           
            if (ClientCharacteristics != null)
            {
                ClientCharacteristics = clientCharacteristics;
            }
            else
            {
                _dbContext.Add(clientCharacteristics);
            }     

            _dbContext.SaveChanges();
            return clientCharacteristics.Id;
        }

        public int GetCount()
        {
            try
            {
                return _dbContext.ClientCharacteristics.Count();
            }
            catch
            {
                return 1;
            }
        }

    }
}
