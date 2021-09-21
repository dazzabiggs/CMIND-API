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
    [Route("api/v1/parent")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentChildService _pcService;
        public ParentController(IParentChildService pcService)
        {
            _pcService = pcService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var parents = _pcService.GetParents();
            return new OkObjectResult(parents);
        }

        [HttpGet("{id}", Name = "GetParent")]
        public IActionResult Get(int id)
        {
            var parent = _pcService.GetParentByID(id);
            return new OkObjectResult(parent);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Parent parent)
        {
            using (var scope = new TransactionScope())
            {
                _pcService.InsertParent(parent);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = parent.ID }, parent);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Parent parent)
        {
            if (parent != null)
            {
                using (var scope = new TransactionScope())
                {
                    _pcService.UpdateParent(parent);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pcService.DeleteParent(id);
            return new OkResult();
        }
    }
}
