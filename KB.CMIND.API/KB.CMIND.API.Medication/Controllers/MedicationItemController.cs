using KB.CMIND.API.Incidents.Services.Interfaces;
using KB.CMIND.API.Medication.Entities;
using KB.CMIND.API.Medication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace KB.CMIND.API.Medication.Controllers
{
    [Authorize(Roles = "Medication")]
    [Route("api/v1/medication/item")]
    [ApiController]
    public class MedicationItemController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationItemController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var medicationItems = _medicationService.GetMedicationItems();
            return new OkObjectResult(medicationItems);
        }

        [HttpGet("{id}", Name = "GetMedicatioItem")]
        public IActionResult Get(int id)
        {
            var medicationItem = _medicationService.GetMedicationItemByID(id);
            return new OkObjectResult(medicationItem);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MedicationItem medicationItem)
        {
            using (var scope = new TransactionScope())
            {
                _medicationService.InsertMedicationItem(medicationItem);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = medicationItem.ID }, medicationItem);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] MedicationItem medicationItem)
        {
            if (medicationItem != null)
            {
                using (var scope = new TransactionScope())
                {
                    _medicationService.UpdateMedicationItem(medicationItem);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _medicationService.DeleteMedicationItem(id);
            return new OkResult();
        }
    }
}
