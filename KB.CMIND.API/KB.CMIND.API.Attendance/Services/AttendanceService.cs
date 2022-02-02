using KB.CMIND.API.Attendance.Services.Interfaces;
using KB.CMIND.API.Attendance.DBContexts;
using KB.CMIND.API.Attendance.Entities;
using KB.CMIND.API.Attendance.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KB.AUTH.Middleware.Helpers;

namespace KB.CMIND.API.Attendance.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly AppSettings _appSettings;
        private readonly AttendanceRepository _attendanceRepository;
        private readonly AttendanceTypeRepository _attendanceTypeRepository;

        public AttendanceService(IOptions<AppSettings> appSettings, AttendanceContext context)
        {
            _appSettings = appSettings.Value;
            _attendanceRepository = new AttendanceRepository(context);
            _attendanceTypeRepository = new AttendanceTypeRepository(context);
        }

        // Attendance
        public IEnumerable<AttendanceLog> GetAttendanceLogs()
        {
            return _attendanceRepository.GetAttendanceLogs();
        }

        public AttendanceLog GetAttendanceLogByID(int Id)
        {
            return _attendanceRepository.GetAttendanceLogByID(Id);
        }

        public void InsertAttendanceLog(AttendanceLog attendance)
        {
            _attendanceRepository.InsertAttendanceLog(attendance);
        }

        public void DeleteAttendanceLog(int Id)
        {
            _attendanceRepository.DeleteAttendanceLog(Id);
        }

        public void UpdateAttendanceLog(AttendanceLog attendance)
        {
            _attendanceRepository.UpdateAttendanceLog(attendance);
        }

        // Attendance Type

        public IEnumerable<AttendanceType> GetAttendanceTypes()
        {
            return _attendanceTypeRepository.GetAttendanceTypes();
        }

        public AttendanceType GetAttendanceTypeByID(int Id)
        {
            return _attendanceTypeRepository.GetAttendanceTypeByID(Id);
        }

        public void InsertAttendanceType(AttendanceType type)
        {
            _attendanceTypeRepository.InsertAttendanceType(type);
        }

        public void DeleteAttendanceType(int Id)
        {
            _attendanceTypeRepository.DeleteAttendanceType(Id);
        }

        public void UpdateAttendanceType(AttendanceType type)
        {
            _attendanceTypeRepository.UpdateAttendanceType(type);
        }

    }
}
