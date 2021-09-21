using KB.CMIND.API.ParentChild.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.Services.Interfaces
{
    public interface IParentChildService
    {
        // Address
        IEnumerable<Address> GetAddresses();
        Address GetAddressByID(int Id);
        void InsertAddress(Address Address);
        void DeleteAddress(int Id);
        void UpdateAddress(Address Address);

        // Child
        IEnumerable<Child> GetChildren();
        Child GetChildByID(int Id);
        void InsertChild(Child Child);
        void DeleteChild(int Id);
        void UpdateChild(Child Child);

        // Parent
        IEnumerable<Parent> GetParents();
        Parent GetParentByID(int Id);
        void InsertParent(Parent Parent);
        void DeleteParent(int Id);
        void UpdateParent(Parent Parent);
    }
}
