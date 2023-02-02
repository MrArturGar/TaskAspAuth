using TestTaskAuth.Models;

namespace TestTaskAuth.Helpers
{
    public class Alert
    {
        public static string ShowAlert(AlertMessage obj)
        {
            if (obj == null)
                return string.Empty;

            string alertDiv = null;
            switch (obj.Type)
            {
                case Alerts.Success:
                    alertDiv = "<div class='alert alert-success alert-dismissable' id='alert'><strong> " + obj.Title + "</ strong > " + obj.Message + ".</div>";
                    break;
                case Alerts.Danger:
                    alertDiv = "<div class='alert alert-danger alert-dismissible' id='alert'><strong>" + obj.Title + "</ strong > " + obj.Message + ".<</div>";
                    break;
                case Alerts.Info:
                    alertDiv = "<div class='alert alert-info alert-dismissable' id='alert'><strong> " + obj.Title + "</ strong > " + obj.Message + ".</div>";
                    break;
                case Alerts.Warning:
                    alertDiv = "<div class='alert alert-warning alert-dismissable' id='alert'><strong> " + obj.Title + "</strong> " + obj.Message + ".</div>";
                    break;
            }
            return alertDiv;
        }

    }
}
