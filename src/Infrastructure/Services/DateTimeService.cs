using ZooApp.Application.Common.Interfaces;
using System;

namespace ZooApp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
