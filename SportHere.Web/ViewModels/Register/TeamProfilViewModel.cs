using System.ComponentModel.DataAnnotations;

namespace SportHere.Web.ViewModels.Register
{
    public class TeamProfilViewModel
    {
        [Display(Name = "Létszám")]
        public long HeadCount { get; set; }

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
