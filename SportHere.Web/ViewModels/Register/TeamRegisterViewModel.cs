using System.ComponentModel.DataAnnotations;

namespace SportHere.Web.ViewModels.Register
{
    public class TeamRegisterViewModel : RegisterViewModel
    {
        [Display(Name = "Létszám")]
        public long HeadCount { get; set; }
    }
}
