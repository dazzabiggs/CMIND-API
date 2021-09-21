using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.CMDetails.Entities
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public ICollection<ChildMinder> ChildMinders { get; set; }
        public ICollection<Organisation> Organisations { get; set; }
    }
}
