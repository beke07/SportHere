using SportHere.Web.ViewModels.Event;

namespace SportHere.Web.ViewModels.Challenge
{
    public class ChallengeDetailsViewModel : ChallengeGridViewModel
    {
        public string Color { get; set; }

        public string Comment { get; set; }

        public MapViewModel Map { get; set; }

        public bool IsLighting { get; set; }

        public bool HasBall { get; set; }

        public bool HasDressingRoom { get; set; }
    }
}
