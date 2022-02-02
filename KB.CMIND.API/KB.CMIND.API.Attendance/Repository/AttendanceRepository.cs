using KB.CMIND.API.Attendance.DBContexts;
using KB.CMIND.API.Attendance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Attendance.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AttendanceContext _dbContext;

        public AttendanceRepository(AttendanceContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAttendanceLog(int attendanceID)
        {
            var Attendance = _dbContext.AttendanceLogs.Find(attendanceID);
            _dbContext.AttendanceLogs.Remove(Attendance);
            Save();
        }

        public AttendanceLog GetAttendanceLogByID(int attendanceID)
        {
            return _dbContext.AttendanceLogs.Find(attendanceID);
        }

        public IEnumerable<AttendanceLog> GetAttendanceLogs()
        {
            return _dbContext.AttendanceLogs.ToList();
        }

        public void InsertAttendanceLog(AttendanceLog attendance)
        {
            _dbContext.Add(attendance);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAttendanceLog(AttendanceLog attendance)
        {
            _dbContext.Entry(attendance).State = EntityState.Modified;
            Save();
        }
    }
}
