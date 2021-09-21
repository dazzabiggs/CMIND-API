using KB.CMIND.API.ParentChild.Repository;
using KB.CMIND.API.ParentChild.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using KB.CMIND.API.ParentChild.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace KB.CMIND.API.ParentChild.Controllers
{
    [Authorize(Roles = "ParentChild")]
    [Route("api/v1/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IParentChildService _pcService;
        public AddressController(IParentChildService pcService)
        {
            _pcService = pcService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var addresses = _pcService.GetAddresses();
            return new OkObjectResult(addresses);
        }

        [HttpGet("{id}", Name = "GetAddress")]
        public IActionResult Get(int id)
        {
            var address = _pcService.GetAddressByID(id);
            return new OkObjectResult(address);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            using (var scope = new TransactionScope())
            {
                _pcService.InsertAddress(address);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = address.ID }, address);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Address address)
        {
            if (address != null)
            {
                using (var scope = new TransactionScope())
                {
                    _pcService.UpdateAddress(address);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pcService.DeleteAddress(id);
            return new OkResult();
        }
    }
}
