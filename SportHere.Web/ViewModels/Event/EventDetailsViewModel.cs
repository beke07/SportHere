namespace SportHere.Web.ViewModels.Event
{
    public class EventDetailsViewModel : EventGridViewModel
    {
        public string Color { get; set; }

        public string Comment { get; set; }

        public MapViewModel Map { get; set; }

        public bool IsLighting { get; set; }

        public bool HasBall { get; set; }

        public bool HasDressingRoom { get; set; }
    }
}
