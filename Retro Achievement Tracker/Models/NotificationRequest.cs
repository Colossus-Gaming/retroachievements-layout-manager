namespace Retro_Achievement_Tracker.Models
{
    class NotificationRequest
    {
        public Achievement Achievement { get; set; }
        public GameInfo GameInfoAndProgress { get; set; }
    }
}
