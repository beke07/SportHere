using SportHere.Web.ViewModels.Event;
using System.ComponentModel.DataAnnotations;

namespace SportHere.Web.ViewModels.Challenge
{
    public class ChallengeViewModel : EventViewModel
    {
        [Required(ErrorMessage = "Nyeremény megadása kötelező!")]
        [Display(Name = "Nyeremény")]
        public int Prize { get; set; }
    }
}
