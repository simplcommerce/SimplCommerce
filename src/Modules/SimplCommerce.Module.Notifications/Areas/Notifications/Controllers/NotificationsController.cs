using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Extensions;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Notifications.Models;
using SimplCommerce.Module.Notifications.Notifiers;

namespace SimplCommerce.Module.Notifications.Areas.Notifications.Controllers
{
    [Area("Notifications")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class NotificationsController : Controller
    {
        private readonly ITestNotifier _testNotifier;
        private readonly IWorkContext _workContext;

        public NotificationsController(
            ITestNotifier testNotifier,
            IWorkContext workContext)
        {
            _testNotifier = testNotifier;
            _workContext = workContext;
        }

        [HttpGet("notifications")]
        public IActionResult Index()
        {
            return View();
        }

        #region Etc
        [HttpGet("test-notification")]
        public async Task<ActionResult> TestNotification(string message = "", string severity = "info")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + DateTime.Now;
            }

            await _testNotifier.SendMessageAsync(
                _workContext.GetCurrentUser().Result.Id,
                message,
                severity.ToPascalCase().ToEnum<NotificationSeverity>()
                );

            return Content("Sent notification: " + message);
        }

        #endregion
    }
}
