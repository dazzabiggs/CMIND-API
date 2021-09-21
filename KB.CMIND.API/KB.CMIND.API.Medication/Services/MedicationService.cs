using KB.CMIND.API.Incidents.Services.Interfaces;
using KB.CMIND.API.Medication.DBContexts;
using KB.CMIND.API.Medication.Entities;
using KB.CMIND.API.Medication.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KB.AUTH.Middleware.Helpers;

namespace KB.CMIND.API.Medication.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly AppSettings _appSettings;
        private readonly MedicationItemRepository _medicationItemRepository;
        private readonly MedicationTypeRepository _medicationTypeRepository;
        private readonly MedicationDeliveryRepository _medicationDeliveryRepository;

        public MedicationService(IOptions<AppSettings> appSettings, MedicationContext context)
        {
            _appSettings = appSettings.Value;
            _medicationItemRepository = new MedicationItemRepository(context);
            _medicationTypeRepository = new MedicationTypeRepository(context);
            _medicationDeliveryRepository = new MedicationDeliveryRepository(context);
        }

        // Medication Item
        public IEnumerable<MedicationItem> GetMedicationItems()
        {
            return _medicationItemRepository.GetMedicationItems();
        }

        public MedicationItem GetMedicationItemByID(int Id)
        {
            return _medicationItemRepository.GetMedicationItemByID(Id);
        }

        public void InsertMedicationItem(MedicationItem item)
        {
            _medicationItemRepository.InsertMedicationItem(item);
        }

        public void DeleteMedicationItem(int Id)
        {
            _medicationItemRepository.DeleteMedicationItem(Id);
        }

        public void UpdateMedicationItem(MedicationItem item)
        {
            _medicationItemRepository.UpdateMedicationItem(item);
        }

        // Medication Type

        public IEnumerable<MedicationType> GetMedicationTypes()
        {
            return _medicationTypeRepository.GetMedicationTypes();
        }

        public MedicationType GetMedicationTypeByID(int Id)
        {
            return _medicationTypeRepository.GetMedicationTypeByID(Id);
        }

        public void InsertMedicationType(MedicationType type)
        {
            _medicationTypeRepository.InsertMedicationType(type);
        }

        public void DeleteMedicationType(int Id)
        {
            _medicationTypeRepository.DeleteMedicationType(Id);
        }

        public void UpdateMedicationType(MedicationType type)
        {
            _medicationTypeRepository.UpdateMedicationType(type);
        }

        // Medication Delivery

        public IEnumerable<MedicationDelivery> GetMedicationDeliveries()
        {
            return _medicationDeliveryRepository.GetMedicationDeliveries();
        }

        public MedicationDelivery GetMedicationDeliveryByID(int Id)
        {
            return _medicationDeliveryRepository.GetMedicationDeliveryByID(Id);
        }

        public void InsertMedicationDelivery(MedicationDelivery delivery)
        {
            _medicationDeliveryRepository.InsertMedicationDelivery(delivery);
        }

        public void DeleteMedicationDelivery(int Id)
        {
            _medicationDeliveryRepository.DeleteMedicationDelivery(Id);
        }

        public void UpdateMedicationDelivery(MedicationDelivery delivery)
        {
            _medicationDeliveryRepository.UpdateMedicationDelivery(delivery);
        }

    }
}
