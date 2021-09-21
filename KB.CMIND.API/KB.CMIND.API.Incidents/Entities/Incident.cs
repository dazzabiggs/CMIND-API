using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.Incidents.Entities
{
    [Table("Incidents")]
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ChildID { get; set; }

        public int IncidentTypeID { get; set; }
        public IncidentType IncidentTypes { get; set; }
    }
}
