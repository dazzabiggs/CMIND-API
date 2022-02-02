using KB.CMIND.API.Attendance.DBContexts;
using KB.CMIND.API.Attendance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Attendance.Repository
{
    public class AttendanceTypeRepository : IAttendanceTypeRepository
    {
        private readonly AttendanceContext _dbContext;

        public AttendanceTypeRepository(AttendanceContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteAttendanceType(int attendanceTypeID)
        {
            var AttendanceType = _dbContext.AttendanceTypes.Find(attendanceTypeID);
            _dbContext.AttendanceTypes.Remove(AttendanceType);
            Save();
        }

        public AttendanceType GetAttendanceTypeByID(int attendanceTypeID)
        {
            return _dbContext.AttendanceTypes.Find(attendanceTypeID);
        }

        public IEnumerable<AttendanceType> GetAttendanceTypes()
        {
            return _dbContext.AttendanceTypes.ToList();
        }

        public void InsertAttendanceType(AttendanceType attendanceType)
        {
            _dbContext.Add(attendanceType);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateAttendanceType(AttendanceType attendanceType)
        {
            _dbContext.Entry(attendanceType).State = EntityState.Modified;
            Save();
        }
    }
}
