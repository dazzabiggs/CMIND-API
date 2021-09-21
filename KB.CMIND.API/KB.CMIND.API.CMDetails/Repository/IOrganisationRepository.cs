using KB.CMIND.API.CMDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Repository
{
    public interface IOrganisationRepository
    {
        IEnumerable<Organisation> GetOrganisations();
        Organisation GetOrganisationByID(int Id);
        void InsertOrganisation(Organisation Organisation);
        void DeleteOrganisation(int Id);
        void UpdateOrganisation(Organisation Organisation);
        void Save();
    }
}
