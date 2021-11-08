using System.ComponentModel.DataAnnotations;

namespace EssenceRealty.Data.Identity.Models
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
