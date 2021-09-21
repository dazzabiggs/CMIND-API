using KB.CMIND.API.Incidents.DBContexts;
using KB.CMIND.API.Incidents.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Repository
{
    public class IncidentTypeRepository : IIncidentTypeRepository
    {
        private readonly IncidentsContext _dbContext;

        public IncidentTypeRepository(IncidentsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteIncidentType(int incidentTypeID)
        {
            var incidentType = _dbContext.IncidentTypes.Find(incidentTypeID);
            _dbContext.IncidentTypes.Remove(incidentType);
            Save();
        }

        public IncidentType GetIncidentTypeByID(int incidentTypeID)
        {
            return _dbContext.IncidentTypes.Find(incidentTypeID);
        }

        public IEnumerable<IncidentType> GetIncidentTypes()
        {
            return _dbContext.IncidentTypes.ToList();
        }

        public void InsertIncidentType(IncidentType incidentType)
        {
            _dbContext.Add(incidentType);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateIncidentType(IncidentType incidentType)
        {
            _dbContext.Entry(incidentType).State = EntityState.Modified;
            Save();
        }
    }
}
