using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Diploma.Repositories
{
    public class ClientForShowRepository
    {
        private readonly DataBaseContext _dbContext;
        private readonly DbSet<ClientForShow> _dbSet;

        public ClientForShowRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
            _dbSet = dataBaseContext.Set<ClientForShow>();
        }

        public void Add(ClientForShow clientForShow)
        {
            _dbSet.Add(clientForShow);
            _dbContext.SaveChanges();
        }

        public List<ClientForShow> FindAll()
        {
            if (!_dbSet.Any()) return new();
            return _dbSet.ToList();           
        }

        public void UpdateOverallCharacteristicsScore(string iin, decimal overallCharacteristicsScore)
        {        
            var client = _dbContext.ClientsForShow.FirstOrDefault(c => c.IIN == iin);

            if (client != null)
                client.OverallCharacteristicsScore = overallCharacteristicsScore;

            _dbContext.SaveChanges();
        }

        public void UpdateOverallCriteriaScore(string iin, decimal overallCriteriaScore)
        {
            var client = _dbContext.ClientsForShow.FirstOrDefault(c => c.IIN == iin);

            if (client != null)
                client.OverallCriteriaScore = overallCriteriaScore;

            _dbContext.SaveChanges();
        }

        public void UpdateOverallScore(string iin, decimal overallScore)
        {
            var client = _dbContext.ClientsForShow.FirstOrDefault(c => c.IIN == iin);

            if (client != null)
                client.OverallScore = overallScore;

            _dbContext.SaveChanges();
        }

        public void UpdateFinalGrade(string iin, decimal finalGrade)
        {
            var client = _dbContext.ClientsForShow.FirstOrDefault(c => c.IIN == iin);

            if (client != null)
                client.FinalGrade = finalGrade;

            _dbContext.SaveChanges();
        }
    }
}
