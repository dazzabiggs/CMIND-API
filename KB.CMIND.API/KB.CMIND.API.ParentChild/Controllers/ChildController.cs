using KB.CMIND.API.ParentChild.Entities;
using KB.CMIND.API.ParentChild.Repository;
using KB.CMIND.API.ParentChild.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace KB.CMIND.API.ParentChild.Controllers
{
    [Authorize(Roles = "ParentChild")]
    [Route("api/v1/child")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IParentChildService _pcService;
        public ChildController(IParentChildService pcService)
        {
            _pcService = pcService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var children = _pcService.GetChildren();
            return new OkObjectResult(children);
        }

        [HttpGet("{id}", Name = "GetChild")]
        public IActionResult Get(int id)
        {
            var child = _pcService.GetChildByID(id);
            return new OkObjectResult(child);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Child child)
        {
            using (var scope = new TransactionScope())
            {
                _pcService.InsertChild(child);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = child.ID }, child);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Child child)
        {
            if (child != null)
            {
                using (var scope = new TransactionScope())
                {
                    _pcService.UpdateChild(child);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pcService.DeleteChild(id);
            return new OkResult();
        }
    }
}
