using KB.CMIND.API.Attendance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Attendance.Repository
{
    public interface IAttendanceRepository
    {
        IEnumerable<AttendanceLog> GetAttendanceLogs();
        AttendanceLog GetAttendanceLogByID(int Id);
        void InsertAttendanceLog(AttendanceLog attendance);
        void DeleteAttendanceLog(int Id);
        void UpdateAttendanceLog(AttendanceLog attendance);
        void Save();
    }
}
