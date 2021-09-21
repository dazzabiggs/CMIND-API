using KB.CMIND.API.ParentChild.DBContexts;
using KB.CMIND.API.ParentChild.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.Repository
{
    public class ParentRepository : IParentRepository
    {
        private readonly ParentChildContext _dbContext;

        public ParentRepository(ParentChildContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteParent(int parentID)
        {
            var parent = _dbContext.Parents.Find(parentID);
            _dbContext.Parents.Remove(parent);
            Save();
        }

        public Parent GetParentByID(int parentID)
        {
            return _dbContext.Parents.Find(parentID);
        }

        public IEnumerable<Parent> GetParents()
        {
            return _dbContext.Parents.ToList();
        }

        public void InsertParent(Parent parent)
        {
            _dbContext.Add(parent);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateParent(Parent parent)
        {
            _dbContext.Entry(parent).State = EntityState.Modified;
            Save();
        }
    }
}
