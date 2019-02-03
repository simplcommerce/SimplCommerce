namespace SimplCommerce.Module.HangfireJobs.Models
{
    /// <summary>
    /// Contains constant CRON expressions
    /// </summary>
    public static class CommonCrons
    {
        /// <summary>
        /// Every minute.
        /// </summary>
        public const string Minutely = "* * * * *";

        /// <summary>
        /// Every hour.
        /// </summary>
        public const string Hourly = "0 * * * *";

        /// <summary>
        /// Every day at 00:00.
        /// </summary>
        public const string Daily = "0 0 * * *";

        /// <summary>
        /// Every Monday at 00:00.
        /// </summary>
        public const string Weekly = "0 0 * * 1";

        /// <summary>
        /// Every first day of the month at 00:00.
        /// </summary>
        public const string Monthly = "0 0 1 * *";

        /// <summary>
        /// Every year on January 1st at 00:00.
        /// </summary>
        public const string Yearly = "0 0 1 1 *";
    }
}
