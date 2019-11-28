using Buglogger.Application.Interfaces;
using System;

namespace Buglogger.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}