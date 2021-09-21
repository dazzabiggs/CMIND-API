using KB.CMIND.API.ParentChild.DBContexts;
using KB.CMIND.API.ParentChild.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.Repository
{
    public class ChildRepository : IChildRepository
    {
        private readonly ParentChildContext _dbContext;

        public ChildRepository(ParentChildContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteChild(int childID)
        {
            var child = _dbContext.Children.Find(childID);
            _dbContext.Children.Remove(child);
            Save();
        }

        public Child GetChildByID(int childID)
        {
            return _dbContext.Children.Find(childID);
        }

        public IEnumerable<Child> GetChildren()
        {
            return _dbContext.Children.ToList();
        }

        public void InsertChild(Child child)
        {
            _dbContext.Add(child);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateChild(Child child)
        {
            _dbContext.Entry(child).State = EntityState.Modified;
            Save();
        }
    }
}
