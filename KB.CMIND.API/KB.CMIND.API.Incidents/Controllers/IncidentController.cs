using KB.CMIND.API.Incidents.Entities;
using KB.CMIND.API.Incidents.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace KB.CMIND.API.Incidents.Controllers
{
    [Authorize(Roles = "Incidents")]
    [Route("api/v1/incident")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentsService _incidentService;

        public IncidentController(IIncidentsService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var incidents = _incidentService.GetIncidents();
            return new OkObjectResult(incidents);
        }

        [HttpGet("{id}", Name = "GetIncident")]
        public IActionResult Get(int id)
        {
            var incident = _incidentService.GetIncidentByID(id);
            return new OkObjectResult(incident);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Incident incident)
        {
            using (var scope = new TransactionScope())
            {
                _incidentService.InsertIncident(incident);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = incident.ID }, incident);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Incident incident)
        {
            if (incident != null)
            {
                using (var scope = new TransactionScope())
                {
                    _incidentService.UpdateIncident(incident);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _incidentService.DeleteIncident(id);
            return new OkResult();
        }
    }
}
