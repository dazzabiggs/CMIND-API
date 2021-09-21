using KB.CMIND.API.CMDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Repository
{
    public interface IChildMinderRepository
    {
        IEnumerable<ChildMinder> GetChildMinders();
        ChildMinder GetChildMinderByID(int Id);
        void InsertChildMinder(ChildMinder ChildMinder);
        void DeleteChildMinder(int Id);
        void UpdateChildMinder(ChildMinder ChildMinder);
        void Save();
    }
}
