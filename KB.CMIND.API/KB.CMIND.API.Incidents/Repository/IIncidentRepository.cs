using KB.CMIND.API.Incidents.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Repository
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> GetIncidents();
        Incident GetIncidentByID(int Id);
        void InsertIncident(Incident Incident);
        void DeleteIncident(int Id);
        void UpdateIncident(Incident Incident);
        void Save();
    }
}
