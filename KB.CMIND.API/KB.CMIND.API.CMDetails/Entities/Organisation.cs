using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Entities
{
    [Table("Organisations")]
    public class Organisation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public int AddressID { get; set; }
        public Address Adddress { get; set; }

    }
}
