using KB.CMIND.API.Medication.DBContexts;
using KB.CMIND.API.Medication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Repository
{
    public class MedicationDeliveryRepository : IMedicationDeliveryRepository
    {
        private readonly MedicationContext _dbContext;

        public MedicationDeliveryRepository(MedicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteMedicationDelivery(int medDeliveryID)
        {
            var medDelivery = _dbContext.MedicationDeliveries.Find(medDeliveryID);
            _dbContext.MedicationDeliveries.Remove(medDelivery);
            Save();
        }

        public MedicationDelivery GetMedicationDeliveryByID(int medDeliveryID)
        {
            return _dbContext.MedicationDeliveries.Find(medDeliveryID);
        }

        public IEnumerable<MedicationDelivery> GetMedicationDeliveries()
        {
            return _dbContext.MedicationDeliveries.ToList();
        }

        public void InsertMedicationDelivery(MedicationDelivery medDelivery)
        {
            _dbContext.Add(medDelivery);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateMedicationDelivery(MedicationDelivery medDelivery)
        {
            _dbContext.Entry(medDelivery).State = EntityState.Modified;
            Save();
        }
    }
}
