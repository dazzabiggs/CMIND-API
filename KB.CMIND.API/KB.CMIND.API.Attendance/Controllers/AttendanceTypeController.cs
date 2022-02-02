using KB.CMIND.API.Attendance.Entities;
using KB.CMIND.API.Attendance.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace KB.CMIND.API.Attendance.Controllers
{
    [Authorize(Roles = "Attendance")]
    [Route("api/v1/attendance/type")]
    [ApiController]
    public class AttendanceTypeController : ControllerBase
    {

        private readonly IAttendanceService _attendanceService;

        public AttendanceTypeController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var attendanceTypes = _attendanceService.GetAttendanceTypes();
            return new OkObjectResult(attendanceTypes);
        }

        [HttpGet("{id}", Name = "GetAttendanceType")]
        public IActionResult Get(int id)
        {
            var attendanceType = _attendanceService.GetAttendanceTypeByID(id);
            return new OkObjectResult(attendanceType);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AttendanceType attendanceType)
        {
            using (var scope = new TransactionScope())
            {
                _attendanceService.InsertAttendanceType(attendanceType);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = attendanceType.ID }, attendanceType);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AttendanceType attendanceType)
        {
            if (attendanceType != null)
            {
                using (var scope = new TransactionScope())
                {
                    _attendanceService.UpdateAttendanceType(attendanceType);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _attendanceService.DeleteAttendanceType(id);
            return new OkResult();
        }
    }
}
