using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Attendance.Entities
{
    [Table("AttendanceLogs")]
    public class AttendanceLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ChildID { get; set; }

        public int AttendanceTypeID { get; set; }
        public AttendanceType AttendanceTypes { get; set; }
    }
}
