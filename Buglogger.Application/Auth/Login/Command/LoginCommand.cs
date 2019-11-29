using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buglogger.Application.Auth.Login.Command
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
