using KB.CMIND.API.Attendance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Attendance.Repository
{
    public interface IAttendanceTypeRepository
    {
        IEnumerable<AttendanceType> GetAttendanceTypes();
        AttendanceType GetAttendanceTypeByID(int Id);
        void InsertAttendanceType(AttendanceType AttendanceType);
        void DeleteAttendanceType(int Id);
        void UpdateAttendanceType(AttendanceType AttendanceType);
        void Save();
    }
}
