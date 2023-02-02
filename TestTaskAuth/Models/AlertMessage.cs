namespace TestTaskAuth.Models
{
    public class AlertMessage
    {
        public Alerts Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

    }

    public enum Alerts
    {
        Success,
        Info,
        Warning,
        Danger
    }
}
