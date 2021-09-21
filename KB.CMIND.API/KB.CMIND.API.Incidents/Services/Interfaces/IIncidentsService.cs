using KB.CMIND.API.Incidents.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Services.Interfaces
{
    public interface IIncidentsService
    {
        // Incident
        IEnumerable<Incident> GetIncidents();
        Incident GetIncidentByID(int Id);
        void InsertIncident(Incident Incident);
        void DeleteIncident(int Id);
        void UpdateIncident(Incident Incident);

        // Incident Type
        IEnumerable<IncidentType> GetIncidentTypes();
        IncidentType GetIncidentTypeByID(int Id);
        void InsertIncidentType(IncidentType IncidentType);
        void DeleteIncidentType(int Id);
        void UpdateIncidentType(IncidentType IncidentType);


    }
}
