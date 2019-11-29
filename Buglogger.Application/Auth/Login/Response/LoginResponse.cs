using Buglogger.Domain.Common;
using Buglogger.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buglogger.Application.Auth.Login.Response
{
    public class LoginResponse : BaseResponse
    {
        public AccessToken AccessToken { get; }

        public string RefreshToken { get; }

        public IEnumerable<Error> Errors { get; }

        public LoginResponse(AccessToken accessToken,
                              string refreshToken,
                              bool success = true,
                              string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public LoginResponse(IEnumerable<Error> errors,
                              bool success = false,
                              string message = null) : base(success, message) => Errors = errors;
    }
}
