using KB.CMIND.API.Medication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Repository
{
    public interface IMedicationTypeRepository
    {
        IEnumerable<MedicationType> GetMedicationTypes();
        MedicationType GetMedicationTypeByID(int Id);
        void InsertMedicationType(MedicationType MedicationType);
        void DeleteMedicationType(int Id);
        void UpdateMedicationType(MedicationType MedicationType);
        void Save();
    }
}
