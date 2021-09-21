using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.AUTH.Middleware.Entities
{
    [Table("ClientDetails")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
