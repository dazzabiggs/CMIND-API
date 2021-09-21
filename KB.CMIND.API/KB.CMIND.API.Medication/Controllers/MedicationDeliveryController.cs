using KB.CMIND.API.Incidents.Services.Interfaces;
using KB.CMIND.API.Medication.Entities;
using KB.CMIND.API.Medication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace KB.CMIND.API.Medication.Controllers
{
    [Authorize(Roles = "Medication")]
    [Route("api/v1/medication/delivery")]
    [ApiController]
    public class MedicationDeliveryController : ControllerBase
    {

        private readonly IMedicationService _medicationService;

        public MedicationDeliveryController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var medicationDeliveries = _medicationService.GetMedicationDeliveries();
            return new OkObjectResult(medicationDeliveries);
        }

        [HttpGet("{id}", Name = "GetMedicationDelivery")]
        public IActionResult Get(int id)
        {
            var medicationDelivery = _medicationService.GetMedicationDeliveryByID(id);
            return new OkObjectResult(medicationDelivery);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MedicationDelivery medicationDelivery)
        {
            using (var scope = new TransactionScope())
            {
                _medicationService.InsertMedicationDelivery(medicationDelivery);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = medicationDelivery.ID }, medicationDelivery);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] MedicationDelivery medicationDelivery)
        {
            if (medicationDelivery != null)
            {
                using (var scope = new TransactionScope())
                {
                    _medicationService.UpdateMedicationDelivery(medicationDelivery);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _medicationService.DeleteMedicationDelivery(id);
            return new OkResult();
        }
    }
}
