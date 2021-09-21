using KB.AUTH.Middleware.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Repository
{
    public interface IAuthRepository
    {
        IEnumerable<Client> GetAuth();
        Client GetAuthByID(int Id);
        Client GetAuthBySecrets(string ClientID, string ClientSecret);
        void InsertAuth(Client Client);
        void DeleteAuth(int Id);
        void UpdateAuth(Client Client);
        void Save();
    }
}
