namespace SportHere.Web.ViewModels.Challenge
{
    public class ChallengeGridViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string DateTime { get; set; }

        public bool? WasItWin { get; set; }

        public int MaxNumberOfParticipants { get; set; }

        public int NumberofParcitipans { get; set; }
    }
}
