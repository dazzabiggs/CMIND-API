using KB.CMIND.API.Attendance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Attendance.Services.Interfaces
{
    public interface IAttendanceService
    {
        // Attendance
        IEnumerable<AttendanceLog> GetAttendanceLogs();
        AttendanceLog GetAttendanceLogByID(int Id);
        void InsertAttendanceLog(AttendanceLog AttendanceLog);
        void DeleteAttendanceLog(int Id);
        void UpdateAttendanceLog(AttendanceLog AttendanceLog);

        // Attendance Type
        IEnumerable<AttendanceType> GetAttendanceTypes();
        AttendanceType GetAttendanceTypeByID(int Id);
        void InsertAttendanceType(AttendanceType AttendanceType);
        void DeleteAttendanceType(int Id);
        void UpdateAttendanceType(AttendanceType AttendanceType);


    }
}
