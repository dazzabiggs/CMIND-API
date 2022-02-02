using KB.CMIND.API.Incidents.Entities;
using KB.CMIND.API.Incidents.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace KB.CMIND.API.Incidents.Controllers
{
    [Authorize(Roles = "Incidents")]
    [Route("api/v1/incident/type")]
    [ApiController]
    public class IncidentTypeController : ControllerBase
    {

        private readonly IIncidentsService _incidentService;

        public IncidentTypeController(IIncidentsService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var incidentTypes = _incidentService.GetIncidentTypes();
            return new OkObjectResult(incidentTypes);
        }

        [HttpGet("{id}", Name = "GetIncidentType")]
        public IActionResult Get(int id)
        {
            var incidentType = _incidentService.GetIncidentTypeByID(id);
            return new OkObjectResult(incidentType);
        }

        [HttpPost]
        public IActionResult Post([FromBody] IncidentType incidentType)
        {
            using (var scope = new TransactionScope())
            {
                _incidentService.InsertIncidentType(incidentType);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = incidentType.ID }, incidentType);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] IncidentType incidentType)
        {
            if (incidentType != null)
            {
                using (var scope = new TransactionScope())
                {
                    _incidentService.UpdateIncidentType(incidentType);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _incidentService.DeleteIncidentType(id);
            return new OkResult();
        }
    }
}
