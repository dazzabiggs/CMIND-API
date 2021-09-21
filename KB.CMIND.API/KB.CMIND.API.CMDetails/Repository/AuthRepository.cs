using KB.AUTH.Middleware.Entities;
using KB.CMIND.API.CMDetails.DBContexts;
using KB.CMIND.API.CMDetails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CMDetailsContext _dbContext;

        public AuthRepository(CMDetailsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAuth(int authID)
        {
            var auth = _dbContext.ClientDetails.Find(authID);
            _dbContext.ClientDetails.Remove(auth);
            Save();
        }

        public Client GetAuthByID(int authID)
        {
            return _dbContext.ClientDetails.Find(authID);
        }

        public Client GetAuthBySecrets(string clientID, string clientSecret)
        {
            return _dbContext.ClientDetails.Where(s => s.ClientID == clientID).Where(s => s.ClientSecret == clientSecret).FirstOrDefault();
        }

        public IEnumerable<Client> GetAuth()
        {
            return _dbContext.ClientDetails.ToList();
        }

        public void InsertAuth(Client client)
        {
            _dbContext.Add(client);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAuth(Client client)
        {
            _dbContext.Entry(client).State = EntityState.Modified;
            Save();
        }
    }
}
