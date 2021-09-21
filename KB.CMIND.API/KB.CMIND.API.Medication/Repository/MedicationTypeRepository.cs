using KB.CMIND.API.Medication.DBContexts;
using KB.CMIND.API.Medication.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Repository
{
    public class MedicationTypeRepository : IMedicationTypeRepository
    {
        private readonly MedicationContext _dbContext;

        public MedicationTypeRepository(MedicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteMedicationType(int medTypeID)
        {
            var medType = _dbContext.MedicationTypes.Find(medTypeID);
            _dbContext.MedicationTypes.Remove(medType);
            Save();
        }

        public MedicationType GetMedicationTypeByID(int medTypeID)
        {
            return _dbContext.MedicationTypes.Find(medTypeID);
        }

        public IEnumerable<MedicationType> GetMedicationTypes()
        {
            return _dbContext.MedicationTypes.ToList();
        }

        public void InsertMedicationType(MedicationType medType)
        {
            _dbContext.Add(medType);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateMedicationType(MedicationType medType)
        {
            _dbContext.Entry(medType).State = EntityState.Modified;
            Save();
        }
    }
}
