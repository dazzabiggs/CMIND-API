using KB.CMIND.API.Medication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Repository
{
    public interface IMedicationItemRepository
    {
        IEnumerable<MedicationItem> GetMedicationItems();
        MedicationItem GetMedicationItemByID(int Id);
        void InsertMedicationItem(MedicationItem MedicationItem);
        void DeleteMedicationItem(int Id);
        void UpdateMedicationItem(MedicationItem MedicationItem);
        void Save();
    }
}
