using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Entities
{
    [Table("MedicationItems")]
    public class MedicationItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<MedicationDelivery> MedicationDeliveries { get; set; }
        public int MedicationTypeID { get; set; }
        public MedicationType MedicationTypes { get; set; }
    }
}
