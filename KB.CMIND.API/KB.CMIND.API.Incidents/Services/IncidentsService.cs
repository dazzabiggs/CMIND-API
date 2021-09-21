using KB.CMIND.API.Incidents.Services.Interfaces;
using KB.CMIND.API.Incidents.DBContexts;
using KB.CMIND.API.Incidents.Entities;
using KB.CMIND.API.Incidents.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KB.AUTH.Middleware.Helpers;

namespace KB.CMIND.API.Incidents.Services
{
    public class IncidentsService : IIncidentsService
    {
        private readonly AppSettings _appSettings;
        private readonly IncidentRepository _incidentRepository;
        private readonly IncidentTypeRepository _incidentTypeRepository;

        public IncidentsService(IOptions<AppSettings> appSettings, IncidentsContext context)
        {
            _appSettings = appSettings.Value;
            _incidentRepository = new IncidentRepository(context);
            _incidentTypeRepository = new IncidentTypeRepository(context);
        }

        // Incident
        public IEnumerable<Incident> GetIncidents()
        {
            return _incidentRepository.GetIncidents();
        }

        public Incident GetIncidentByID(int Id)
        {
            return _incidentRepository.GetIncidentByID(Id);
        }

        public void InsertIncident(Incident incident)
        {
            _incidentRepository.InsertIncident(incident);
        }

        public void DeleteIncident(int Id)
        {
            _incidentRepository.DeleteIncident(Id);
        }

        public void UpdateIncident(Incident incident)
        {
            _incidentRepository.UpdateIncident(incident);
        }

        // Incident Type

        public IEnumerable<IncidentType> GetIncidentTypes()
        {
            return _incidentTypeRepository.GetIncidentTypes();
        }

        public IncidentType GetIncidentTypeByID(int Id)
        {
            return _incidentTypeRepository.GetIncidentTypeByID(Id);
        }

        public void InsertIncidentType(IncidentType type)
        {
            _incidentTypeRepository.InsertIncidentType(type);
        }

        public void DeleteIncidentType(int Id)
        {
            _incidentTypeRepository.DeleteIncidentType(Id);
        }

        public void UpdateIncidentType(IncidentType type)
        {
            _incidentTypeRepository.UpdateIncidentType(type);
        }

    }
}
