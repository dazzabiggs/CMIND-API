using KB.CMIND.API.CMDetails.Entities;
using KB.CMIND.API.CMDetails.Repository;
using KB.CMIND.API.CMDetails.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace KB.CMIND.API.CMDetails.Controllers
{
    [Authorize(Roles = "CMDetails")]
    [Route("api/v1/organisation")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private readonly ICMDetailsService _detailsService;
        public OrganisationController(ICMDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        [HttpGet]
        public IActionResult GetOrg()
        {
            var organisations = _detailsService.GetOrganisations();
            return new OkObjectResult(organisations);
        }

        [HttpGet("{id}", Name = "GetOrg")]
        public IActionResult GetOrg(int id)
        {
            var organisation = _detailsService.GetOrganisationByID(id);
            return new OkObjectResult(organisation);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Organisation organisation)
        {
            using (var scope = new TransactionScope())
            {
                _detailsService.InsertOrganisation(organisation);
                scope.Complete();
                return CreatedAtAction(nameof(GetOrg), new { id = organisation.ID }, organisation);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Organisation organisation)
        {
            if (organisation != null)
            {
                using (var scope = new TransactionScope())
                {
                    _detailsService.UpdateOrganisation(organisation);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _detailsService.DeleteOrganisation(id);
            return new OkResult();
        }
    }
}
