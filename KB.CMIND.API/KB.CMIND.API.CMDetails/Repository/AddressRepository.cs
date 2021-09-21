using KB.CMIND.API.CMDetails.DBContexts;
using KB.CMIND.API.CMDetails.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CMDetailsContext _dbContext;

        public AddressRepository(CMDetailsContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAddress(int addressID)
        {
            var address = _dbContext.Addresses.Find(addressID);
            _dbContext.Addresses.Remove(address);
            Save();
        }

        public Address GetAddressByID(int addressID)
        {
            return _dbContext.Addresses.Find(addressID);
        }

        public IEnumerable<Address> GetAddresses()
        {
            return _dbContext.Addresses.ToList();
        }

        public void InsertAddress(Address address)
        {
            _dbContext.Add(address);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAddress(Address address)
        {
            _dbContext.Entry(address).State = EntityState.Modified;
            Save();
        }
    }
}
