using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplCommerce.Infrastructure.Helpers;
using SimplCommerce.Module.Notifications.Models;

namespace SimplCommerce.Module.Notifications.Areas.Notifications.ViewModels
{
    public class TestNotificationVm
    {
        public string Severity { get; set; }

        public string Message { get; set; }

        public long UserId { get; set; }

        public List<SelectListItem> OnlineUsers { get; set; }

        public List<SelectListItem> Severities { get; set; }

        public TestNotificationVm()
        {
            Severities = EnumHelper.ToDictionary(typeof(NotificationSeverity)).Select(s => new SelectListItem(s.Key.ToString(), s.Value)).ToList();
        }
    }
}
