using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KB.CMIND.API.ParentChild.Entities
{
    [Table("Parents")]
    public class Parent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }

        public int AddressID { get; set; }
        public Address Adddress { get; set; }
        public ICollection<Child> Children { get; set; }
    }
}
