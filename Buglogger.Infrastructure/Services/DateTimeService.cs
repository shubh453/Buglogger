using Buglogger.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buglogger.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
