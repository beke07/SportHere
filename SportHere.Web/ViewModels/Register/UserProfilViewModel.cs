using System.ComponentModel.DataAnnotations;

namespace SportHere.Web.ViewModels.Register
{
    public class UserProfilViewModel
    {
        [StringLength(100, ErrorMessage = "A {0} legalább {2} és maximum {1} karakter hosszú lehet!", MinimumLength = 1)]
        [Display(Name = "Vezetéknév")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "A {0} legalább {2} és maximum {1} karakter hosszú lehet!", MinimumLength = 1)]
        [Display(Name = "Keresztnév")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Cím megadása kötelező!")]
        [Display(Name = "Cím")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon megadása kötelező!")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mobil megadása kötelező!")]
        [Display(Name = "Mobil")]
        public string MobilNumber { get; set; }

        [Required(ErrorMessage = "E-mail cím megadása kötelező!")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
