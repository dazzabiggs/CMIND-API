using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.Entities
{
    [Table("Children")]
    public class Child
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Allergies { get; set; }

        public int AddressID { get; set; }
        public Address Adddress { get; set; }
        public ICollection<Parent> Parents { get; set; }
    }
}
