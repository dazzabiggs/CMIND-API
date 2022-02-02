using KB.CMIND.API.Attendance.Entities;
using KB.CMIND.API.Attendance.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace KB.CMIND.API.Attendance.Controllers
{
    [Authorize(Roles = "Attendance")]
    [Route("api/v1/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var logs = _attendanceService.GetAttendanceLogs();
            return new OkObjectResult(logs);
        }

        [HttpGet("{id}", Name = "GetAttendanceLog")]
        public IActionResult Get(int id)
        {
            var log = _attendanceService.GetAttendanceLogByID(id);
            return new OkObjectResult(log);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AttendanceLog log)
        {
            using (var scope = new TransactionScope())
            {
                _attendanceService.InsertAttendanceLog(log);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = log.ID }, log);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] AttendanceLog log)
        {
            if (log != null)
            {
                using (var scope = new TransactionScope())
                {
                    _attendanceService.UpdateAttendanceLog(log);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _attendanceService.DeleteAttendanceLog(id);
            return new OkResult();
        }
    }
}
