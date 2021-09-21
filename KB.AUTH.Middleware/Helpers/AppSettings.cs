using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.AUTH.Middleware.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
    }
}
