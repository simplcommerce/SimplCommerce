using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.EmailSenderSmtp.Data
{
    public class EmailSenderSmptCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>().HasData(
                new AppSetting("SmtpServer") { Module = "EmailSenderSmpt", IsVisibleInCommonSettingPage = false, Value = "smtp.gmail.com" },
                new AppSetting("SmtpPort") { Module = "EmailSenderSmpt", IsVisibleInCommonSettingPage = false, Value = "587" },
                new AppSetting("SmtpUsername") { Module = "EmailSenderSmpt", IsVisibleInCommonSettingPage = false, Value = "" },
                new AppSetting("SmtpPassword") { Module = "EmailSenderSmpt", IsVisibleInCommonSettingPage = false, Value = "" }
            );
        }
    }
}
