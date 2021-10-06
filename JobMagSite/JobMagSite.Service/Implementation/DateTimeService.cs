using JobMagSite.Service.Contract;
using System;

namespace JobMagSite.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}