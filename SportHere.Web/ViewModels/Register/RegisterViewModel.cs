using System.ComponentModel.DataAnnotations;

namespace SportHere.Web.ViewModels.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Felhasználónév megadása kötelező!")]
        [Display(Name = "Felhasználónév")]
        public string UserName { get; set; }

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

        [Required(ErrorMessage = "Jelszó cím megadása kötelező!")]
        [StringLength(100, ErrorMessage = "A {0} legalább {2} és maximum {1} karakter hosszú lehet!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Jelszó")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Jelszó mégegyszer")]
        [Compare("Password", ErrorMessage = "Nem egyezik meg a jelszóval!")]
        public string ConfirmPassword { get; set; }
    }
}
