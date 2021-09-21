using KB.AUTH.Middleware.Helpers;
using KB.CMIND.API.CMDetails.DBContexts;
using KB.CMIND.API.CMDetails.Entities;
using KB.CMIND.API.CMDetails.Repository;
using KB.CMIND.API.CMDetails.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Services
{
    public class CMDetailsService : ICMDetailsService
    {
        private readonly AppSettings _appSettings;
        private readonly AddressRepository _addressRepository;
        private readonly ChildMinderRepository _childMinderRepository;
        private readonly OrganisationRepository _organisationRepository;

        public CMDetailsService(IOptions<AppSettings> appSettings, CMDetailsContext context)
        {
            _appSettings = appSettings.Value;
            _addressRepository = new AddressRepository(context);
            _childMinderRepository = new ChildMinderRepository(context);
            _organisationRepository = new OrganisationRepository(context);
        }

        // Address
        public IEnumerable<Address> GetAddresses()
        {
            return _addressRepository.GetAddresses();
        }

        public Address GetAddressByID(int Id)
        {
            return _addressRepository.GetAddressByID(Id);
        }

        public void InsertAddress(Address address)
        {
            _addressRepository.InsertAddress(address);
        }

        public void DeleteAddress(int Id)
        {
            _addressRepository.DeleteAddress(Id);
        }

        public void UpdateAddress(Address address)
        {
            _addressRepository.UpdateAddress(address);
        }

        // Child Minder

        public IEnumerable<ChildMinder> GetChildMinders()
        {
            return _childMinderRepository.GetChildMinders();
        }

        public ChildMinder GetChildMinderByID(int Id)
        {
            return _childMinderRepository.GetChildMinderByID(Id);
        }

        public void InsertChildMinder(ChildMinder childMinder)
        {
            _childMinderRepository.InsertChildMinder(childMinder);
        }

        public void DeleteChildMinder(int Id)
        {
            _childMinderRepository.DeleteChildMinder(Id);
        }

        public void UpdateChildMinder(ChildMinder childMinder)
        {
            _childMinderRepository.UpdateChildMinder(childMinder);
        }

        // Organisation

        public IEnumerable<Organisation> GetOrganisations()
        {
            return _organisationRepository.GetOrganisations();
        }

        public Organisation GetOrganisationByID(int Id)
        {
            return _organisationRepository.GetOrganisationByID(Id);
        }

        public void InsertOrganisation(Organisation org)
        {
            _organisationRepository.InsertOrganisation(org);
        }

        public void DeleteOrganisation(int Id)
        {
            _organisationRepository.DeleteOrganisation(Id);
        }

        public void UpdateOrganisation(Organisation org)
        {
            _organisationRepository.UpdateOrganisation(org);
        }
    }
}
