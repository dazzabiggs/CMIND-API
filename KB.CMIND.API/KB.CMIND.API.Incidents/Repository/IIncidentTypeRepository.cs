using KB.CMIND.API.Incidents.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Repository
{
    public interface IIncidentTypeRepository
    {
        IEnumerable<IncidentType> GetIncidentTypes();
        IncidentType GetIncidentTypeByID(int Id);
        void InsertIncidentType(IncidentType IncidentType);
        void DeleteIncidentType(int Id);
        void UpdateIncidentType(IncidentType IncidentType);
        void Save();
    }
}
