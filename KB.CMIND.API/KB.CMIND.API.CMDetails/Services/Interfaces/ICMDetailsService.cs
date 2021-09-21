using KB.CMIND.API.CMDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Services.Interfaces
{
    public interface ICMDetailsService
    {
        // Address
        IEnumerable<Address> GetAddresses();
        Address GetAddressByID(int Id);
        void InsertAddress(Address Address);
        void DeleteAddress(int Id);
        void UpdateAddress(Address Address);

        // Child Minder
        IEnumerable<ChildMinder> GetChildMinders();
        ChildMinder GetChildMinderByID(int Id);
        void InsertChildMinder(ChildMinder ChildMinder);
        void DeleteChildMinder(int Id);
        void UpdateChildMinder(ChildMinder ChildMinder);

        // Organisation
        IEnumerable<Organisation> GetOrganisations();
        Organisation GetOrganisationByID(int Id);
        void InsertOrganisation(Organisation Organisation);
        void DeleteOrganisation(int Id);
        void UpdateOrganisation(Organisation Organisation);

    }
}
