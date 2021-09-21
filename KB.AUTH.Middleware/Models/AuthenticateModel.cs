using System.ComponentModel.DataAnnotations;

namespace KB.AUTH.Middleware.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string ClientID { get; set; }

        [Required]
        public string ClientSecret { get; set; }
    }
}
