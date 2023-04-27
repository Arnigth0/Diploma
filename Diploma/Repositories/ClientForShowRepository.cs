using Diploma.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Repositories
{
    public class ClientForShowRepository
    {
        private readonly DataBaseContext _dbContext;

        public ClientForShowRepository(DataBaseContext dataBaseContext)
        {
            _dbContext = dataBaseContext;
        }

        public IList<ClientForShow> GetData()
        {
            return _dbContext.ClientsForShow.FromSqlRaw(
                @"  SELECT TOP 25 IIN, 
	                (CONCAT(FirstName, ' ', LastName, ' ', MiddleName)) AS Fullname, 
	                BirthDay, 
	                OverallCriteriaScore, 
	                OverallScore 
	                FROM Clients AS cl
		                LEFT JOIN ClientCharacteristics c ON cl.ClientCharacterId = c.Id
		                LEFT JOIN Loans ln ON ln.Id = cl.LoanId
		                LEFT JOIN Prerequisites pr ON pr.Id = cl.PrerequisitesId
		                ORDER BY IIN DESC;
                ").ToList();
        }


    }
}
