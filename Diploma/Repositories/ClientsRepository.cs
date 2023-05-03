using Diploma.Model;
using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Diploma.Repositories
{
    public class ClientsRepository
    {
        private readonly DataBaseContext _dbContext;
        private readonly DbSet<Client> _clientsSet;

        public ClientsRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
            _clientsSet = dataBaseContext.Set<Client>(); 
        }

        public void Add(Client client)
        {
            _clientsSet.Add(client);
            _dbContext.SaveChanges();
        }

        public int GetCount()
        {
            try
            {
                return _clientsSet.Count();
            }
            catch
            {
                return 1;
            }
        }

        public List<Client> FindAll()
        {
            return _clientsSet.ToList();
        }

        public Client FindByIIN(string iin)
        {
            return _clientsSet.FirstOrDefault(c => c.IIN == iin);
        }

        public void Update(Client client)
        {
            _clientsSet.Update(client);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = _clientsSet.Find(id);

            if (client != null)
            {
                _clientsSet.Remove(client);
                _dbContext.SaveChanges();
            }
        }

    }
}
