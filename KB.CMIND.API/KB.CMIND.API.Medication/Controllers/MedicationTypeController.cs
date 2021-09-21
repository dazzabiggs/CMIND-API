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
    [Route("api/v1/medication/type")]
    [ApiController]
    public class MedicationTypeController : ControllerBase
    {
        private readonly IMedicationService _medicationService;

        public MedicationTypeController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var medicationTypes = _medicationService.GetMedicationTypes();
            return new OkObjectResult(medicationTypes);
        }

        [HttpGet("{id}", Name = "GetMedicationType")]
        public IActionResult Get(int id)
        {
            var medicationType = _medicationService.GetMedicationTypeByID(id);
            return new OkObjectResult(medicationType);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MedicationType medicationType)
        {
            using (var scope = new TransactionScope())
            {
                _medicationService.InsertMedicationType(medicationType);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = medicationType.ID }, medicationType);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] MedicationType medicationType)
        {
            if (medicationType != null)
            {
                using (var scope = new TransactionScope())
                {
                    _medicationService.UpdateMedicationType(medicationType);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _medicationService.DeleteMedicationType(id);
            return new OkResult();
        }
    }
}
