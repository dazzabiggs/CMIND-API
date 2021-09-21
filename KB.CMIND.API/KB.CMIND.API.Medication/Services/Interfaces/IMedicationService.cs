using KB.CMIND.API.Medication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Services.Interfaces
{
    public interface IMedicationService
    {
        // Medication Item
        IEnumerable<MedicationItem> GetMedicationItems();
        MedicationItem GetMedicationItemByID(int Id);
        void InsertMedicationItem(MedicationItem MedicationItem);
        void DeleteMedicationItem(int Id);
        void UpdateMedicationItem(MedicationItem MedicationItem);

        // Medication Type
        IEnumerable<MedicationType> GetMedicationTypes();
        MedicationType GetMedicationTypeByID(int Id);
        void InsertMedicationType(MedicationType MedicationType);
        void DeleteMedicationType(int Id);
        void UpdateMedicationType(MedicationType MedicationType);

        // Medication Delivery
        IEnumerable<MedicationDelivery> GetMedicationDeliveries();
        MedicationDelivery GetMedicationDeliveryByID(int Id);
        void InsertMedicationDelivery(MedicationDelivery MedicationDelivery);
        void DeleteMedicationDelivery(int Id);
        void UpdateMedicationDelivery(MedicationDelivery MedicationDelivery);
    }
}
