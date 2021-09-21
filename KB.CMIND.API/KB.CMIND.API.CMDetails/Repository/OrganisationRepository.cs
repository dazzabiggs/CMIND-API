using KB.CMIND.API.CMDetails.DBContexts;
using KB.CMIND.API.CMDetails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly CMDetailsContext _dbContext;

        public OrganisationRepository(CMDetailsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteOrganisation(int orgID)
        {
            var address = _dbContext.Organisations.Find(orgID);
            _dbContext.Organisations.Remove(address);
            Save();
        }

        public Organisation GetOrganisationByID(int orgID)
        {
            return _dbContext.Organisations.Find(orgID);
        }

        public IEnumerable<Organisation> GetOrganisations()
        {
            return _dbContext.Organisations.ToList();
        }

        public void InsertOrganisation(Organisation organisation)
        {
            _dbContext.Add(organisation);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateOrganisation(Organisation organisation)
        {
            _dbContext.Entry(organisation).State = EntityState.Modified;
            Save();
        }
    }
}
