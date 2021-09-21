using KB.CMIND.API.ParentChild.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.Repository
{
    public interface IParentRepository
    {
        IEnumerable<Parent> GetParents();
        Parent GetParentByID(int Id);
        void InsertParent(Parent Parent);
        void DeleteParent(int Id);
        void UpdateParent(Parent Parent);
        void Save();
    }
}
