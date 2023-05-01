using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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


    }
}
