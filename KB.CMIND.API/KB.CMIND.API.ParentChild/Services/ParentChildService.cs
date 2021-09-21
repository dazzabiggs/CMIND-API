using KB.CMIND.API.ParentChild.Services.Interfaces;
using KB.CMIND.API.ParentChild.DBContexts;
using KB.CMIND.API.ParentChild.Entities;
using KB.CMIND.API.ParentChild.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KB.AUTH.Middleware.Helpers;

namespace KB.CMIND.API.ParentChild.Services
{
    public class ParentChildService : IParentChildService
    {
        private readonly AppSettings _appSettings;
        private readonly AddressRepository _addressRepository;
        private readonly ChildRepository _childRepository;
        private readonly ParentRepository _parentRepository;

        public ParentChildService(IOptions<AppSettings> appSettings, ParentChildContext context)
        {
            _appSettings = appSettings.Value;
            _addressRepository = new AddressRepository(context);
            _childRepository = new ChildRepository(context);
            _parentRepository = new ParentRepository(context);
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

        // Child

        public IEnumerable<Child> GetChildren()
        {
            return _childRepository.GetChildren();
        }

        public Child GetChildByID(int Id)
        {
            return _childRepository.GetChildByID(Id);
        }

        public void InsertChild(Child child)
        {
            _childRepository.InsertChild(child);
        }

        public void DeleteChild(int Id)
        {
            _childRepository.DeleteChild(Id);
        }

        public void UpdateChild(Child child)
        {
            _childRepository.UpdateChild(child);
        }

        // Parent

        public IEnumerable<Parent> GetParents()
        {
            return _parentRepository.GetParents();
        }

        public Parent GetParentByID(int Id)
        {
            return _parentRepository.GetParentByID(Id);
        }

        public void InsertParent(Parent parent)
        {
            _parentRepository.InsertParent(parent);
        }

        public void DeleteParent(int Id)
        {
            _parentRepository.DeleteParent(Id);
        }

        public void UpdateParent(Parent parent)
        {
            _parentRepository.UpdateParent(parent);
        }

    }
}
