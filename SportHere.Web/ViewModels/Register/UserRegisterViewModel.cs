using System.ComponentModel.DataAnnotations;

namespace SportHere.Web.ViewModels.Register
{
    public class UserRegisterViewModel : RegisterViewModel
    {
        [StringLength(100, ErrorMessage = "A {0} legalább {2} és maximum {1} karakter hosszú lehet!", MinimumLength = 1)]
        [Display(Name = "Vezetéknév")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "A {0} legalább {2} és maximum {1} karakter hosszú lehet!", MinimumLength = 1)]
        [Display(Name = "Keresztnév")]
        public string LastName { get; set; }
    }
}
