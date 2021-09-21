using KB.CMIND.API.Medication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Repository
{
    public interface IMedicationDeliveryRepository
    {
        IEnumerable<MedicationDelivery> GetMedicationDeliveries();
        MedicationDelivery GetMedicationDeliveryByID(int Id);
        void InsertMedicationDelivery(MedicationDelivery MedicationDelivery);
        void DeleteMedicationDelivery(int Id);
        void UpdateMedicationDelivery(MedicationDelivery MedicationDelivery);
        void Save();
    }
}
