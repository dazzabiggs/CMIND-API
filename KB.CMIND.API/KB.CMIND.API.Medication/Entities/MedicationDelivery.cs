using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Entities
{
    [Table("MedicationDelivery")]
    public class MedicationDelivery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Dosage { get; set; }
        public string Times { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int ChildID { get; set; }

        public int MedicationItemID { get; set; }
        public MedicationItem MedicationItems { get; set; }
    }
}
