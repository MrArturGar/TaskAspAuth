using System.ComponentModel.DataAnnotations;

namespace TestTaskAuth.Models
{
    public class Credential
    {
        [Required, MinLength(5)]
        [Display(Name ="Username:")]
        public string Username { get; set; }

        [Required, MinLength(5)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

    }
}
