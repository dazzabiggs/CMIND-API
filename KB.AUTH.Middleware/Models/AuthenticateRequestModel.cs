using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.AUTH.Middleware.Models
{
    public class AuthenticateRequestModel
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string Role { get; set; }
    }
}
