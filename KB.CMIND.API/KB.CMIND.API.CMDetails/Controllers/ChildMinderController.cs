using KB.CMIND.API.CMDetails.Entities;
using KB.CMIND.API.CMDetails.Repository;
using KB.CMIND.API.CMDetails.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace KB.CMIND.API.CMDetails.Controllers
{
    [Authorize(Roles = "CMDetails")]
    [Route("api/v1/childminder")]
    [ApiController]
    public class ChildMinderController : ControllerBase
    {
        private readonly ICMDetailsService _detailsService;

        public ChildMinderController(ICMDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        [HttpGet]
        public IActionResult GetCM()
        {
            var childMinders = _detailsService.GetChildMinders();
            return new OkObjectResult(childMinders);
        }

        [HttpGet("{id}", Name = "GetCM")]
        public IActionResult GetCM(int id)
        {
            var childMinder = _detailsService.GetChildMinderByID(id);
            return new OkObjectResult(childMinder);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ChildMinder childMinder)
        {
            using (var scope = new TransactionScope())
            {
                _detailsService.InsertChildMinder(childMinder);
                scope.Complete();
                return CreatedAtAction(nameof(GetCM), new { id = childMinder.ID }, childMinder);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ChildMinder childMinder)
        {
            if (childMinder != null)
            {
                using (var scope = new TransactionScope())
                {
                    _detailsService.UpdateChildMinder(childMinder);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _detailsService.DeleteChildMinder(id);
            return new OkResult();
        }
    }
}
