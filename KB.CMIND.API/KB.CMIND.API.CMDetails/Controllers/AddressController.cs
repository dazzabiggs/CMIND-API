using KB.CMIND.API.CMDetails.Entities;
using KB.CMIND.API.CMDetails.Repository;
using KB.CMIND.API.CMDetails.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace KB.CMIND.API.CMDetails.Controllers
{
    [Authorize(Roles = "CMDetails")]
    [Route("api/v1/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ICMDetailsService _detailsService;

        public AddressController(ICMDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        [HttpGet]
        public IActionResult GetAddress()
        {
            var addresses = _detailsService.GetAddresses();
            return new OkObjectResult(addresses);
        }

        [HttpGet("{id}", Name = "GetAddress")]
        public IActionResult GetAddress(int id)
        {
            var address = _detailsService.GetAddressByID(id);
            return new OkObjectResult(address);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            using (var scope = new TransactionScope())
            {
                _detailsService.InsertAddress(address);
                scope.Complete();
                return CreatedAtAction(nameof(GetAddress), new { id = address.ID }, address);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Address address)
        {
            if (address != null)
            {
                using (var scope = new TransactionScope())
                {
                    _detailsService.UpdateAddress(address);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _detailsService.DeleteAddress(id);
            return new OkResult();
        }
    }
}
