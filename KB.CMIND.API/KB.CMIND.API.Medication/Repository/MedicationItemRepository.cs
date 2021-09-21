using KB.CMIND.API.Medication.DBContexts;
using KB.CMIND.API.Medication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Repository
{
    public class MedicationItemRepository : IMedicationItemRepository
    {
        private readonly MedicationContext _dbContext;

        public MedicationItemRepository(MedicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteMedicationItem(int medItemID)
        {
            var medItem = _dbContext.MedicationItems.Find(medItemID);
            _dbContext.MedicationItems.Remove(medItem);
            Save();
        }

        public MedicationItem GetMedicationItemByID(int medItemID)
        {
            return _dbContext.MedicationItems.Find(medItemID);
        }

        public IEnumerable<MedicationItem> GetMedicationItems()
        {
            return _dbContext.MedicationItems.ToList();
        }

        public void InsertMedicationItem(MedicationItem medItem)
        {
            _dbContext.Add(medItem);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateMedicationItem(MedicationItem medItem)
        {
            _dbContext.Entry(medItem).State = EntityState.Modified;
            Save();
        }
    }
}
