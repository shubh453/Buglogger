using System;
using System.Collections.Generic;
using System.Text;

namespace Buglogger.Application.Interfaces
{
    public interface ICurrentUser
    {
        public Guid UserId { get; }
    }
}
