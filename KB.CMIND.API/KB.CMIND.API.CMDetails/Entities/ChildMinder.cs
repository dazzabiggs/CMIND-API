using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Entities
{
    [Table("Childminders")]
    public class ChildMinder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string DOB { get; set; }

        public int AddressID { get; set; }
        public Address Adddress { get; set; }
    }
}
