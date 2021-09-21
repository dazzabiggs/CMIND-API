using KB.CMIND.API.ParentChild.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.Repository
{
    public interface IChildRepository
    {
        IEnumerable<Child> GetChildren();
        Child GetChildByID(int Id);
        void InsertChild(Child Child);
        void DeleteChild(int Id);
        void UpdateChild(Child Child);
        void Save();
    }
}
