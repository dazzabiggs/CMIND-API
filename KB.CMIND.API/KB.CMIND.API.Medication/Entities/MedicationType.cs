using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Medication.Entities
{
    [Table("MedicationTypes")]
    public class MedicationType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Description { get; set; }

        public ICollection<MedicationItem> MedicationItems { get; set; }
    }
}
