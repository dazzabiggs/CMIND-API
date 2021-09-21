using KB.CMIND.API.Incidents.DBContexts;
using KB.CMIND.API.Incidents.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Repository
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IncidentsContext _dbContext;

        public IncidentRepository(IncidentsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteIncident(int incidentID)
        {
            var incident = _dbContext.Incidents.Find(incidentID);
            _dbContext.Incidents.Remove(incident);
            Save();
        }

        public Incident GetIncidentByID(int incidentID)
        {
            return _dbContext.Incidents.Find(incidentID);
        }

        public IEnumerable<Incident> GetIncidents()
        {
            return _dbContext.Incidents.ToList();
        }

        public void InsertIncident(Incident incident)
        {
            _dbContext.Add(incident);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateIncident(Incident incident)
        {
            _dbContext.Entry(incident).State = EntityState.Modified;
            Save();
        }
    }
}
