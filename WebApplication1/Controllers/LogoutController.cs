namespace MvcClient.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class LogoutController : Controller
    {
        private readonly ILogger<LogoutController> logger;

        public LogoutController(ILogger<LogoutController> logger)
        {
            this.logger = logger;
        }

        public async Task Index()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        public async Task FrontChannelLogout()
        {
            this.logger.LogInformation("FrontendChannelLogout endpoint requested");

            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }
    }
}
