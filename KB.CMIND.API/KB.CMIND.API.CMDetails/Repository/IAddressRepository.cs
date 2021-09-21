using KB.CMIND.API.CMDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Repository
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddressByID(int Id);
        void InsertAddress(Address Address);
        void DeleteAddress(int Id);
        void UpdateAddress(Address Address);
        void Save();
    }
}
