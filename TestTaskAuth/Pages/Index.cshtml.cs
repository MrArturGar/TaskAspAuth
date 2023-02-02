using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestTaskAuth.Models;
using TestTaskAuth.Services;

namespace TestTaskAuth.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApiClient _apiClient;

        [BindProperty]
        public Credential Credential { get; set; }
        public Detail Detail { get; set; }
        public AlertMessage AlertMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }
        public void OnPost()
        {
            if (ModelState.IsValid && Credential.Username != null && Credential.Password != null)
            {
                Detail = _apiClient.Auth(Credential);

                if (Detail == null)
                {
                    AlertMessage = new AlertMessage
                    {
                        Type = Alerts.Warning,
                        Title = "Warning!",
                        Message = _apiClient.ResponseText
                    };
                }
                else
                {
                    AlertMessage = new AlertMessage
                    {
                        Type = Alerts.Info,
                        Title = "Info!",
                        Message = "You are logged in"
                    };
                }
            }
        }

        public void OnGet()
        {

        }
    }

}