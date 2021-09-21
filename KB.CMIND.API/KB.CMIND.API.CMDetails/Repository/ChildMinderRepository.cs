using KB.CMIND.API.CMDetails.DBContexts;
using KB.CMIND.API.CMDetails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Repository
{
    public class ChildMinderRepository : IChildMinderRepository
    {
        private readonly CMDetailsContext _dbContext;

        public ChildMinderRepository(CMDetailsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteChildMinder(int cmID)
        {
            var childMinder = _dbContext.ChildMinders.Find(cmID);
            _dbContext.ChildMinders.Remove(childMinder);
            Save();
        }

        public ChildMinder GetChildMinderByID(int cmID)
        {
            return _dbContext.ChildMinders.Find(cmID);
        }

        public IEnumerable<ChildMinder> GetChildMinders()
        {
            return _dbContext.ChildMinders.ToList();
        }

        public void InsertChildMinder(ChildMinder childMinder)
        {
            _dbContext.Add(childMinder);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateChildMinder(ChildMinder childMinder)
        {
            _dbContext.Entry(childMinder).State = EntityState.Modified;
            Save();
        }
    }
}
