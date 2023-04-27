using Diploma.Model;
using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Repositories
{
    public class ClientsRepository
    {
        private readonly DataBaseContext _dbContext;

        public ClientsRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public void Add(Client client)
        {
            _dbContext.Clients.FromSqlRaw("INSERT INTO Clients");
        }

        public Client FindById(int id)
        {
            return _dbContext.Clients.FromSqlRaw(@$"SELECT * FROM Clients WHERE id = @id;").FirstOrDefault();
        }

        public List<Client> FindAll()
        {
            return _dbContext.Set<Client>().ToList();
        }

        public void Update(Client client)
        {
            _dbContext.Update(client);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = FindById(id);
            if (client != null)
            {
                _dbContext.Remove(client);
                _dbContext.SaveChanges();
            }
        }

    }
}
