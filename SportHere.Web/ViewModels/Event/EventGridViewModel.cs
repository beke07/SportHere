namespace SportHere.Web.ViewModels.Event
{
    public class EventGridViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string DateTime { get; set; }

        public int MaxNumberOfParticipants { get; set; }

        public int NumberofParcitipans { get; set; }

        public bool IsChallenge { get; set; }

        public bool IsExpired { get; set; }
    }
}
