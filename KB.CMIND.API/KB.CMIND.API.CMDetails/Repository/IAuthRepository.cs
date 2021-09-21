using KB.AUTH.Middleware.Entities;
using System.Collections.Generic;

namespace KB.CMIND.API.CMDetails.Repository
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
