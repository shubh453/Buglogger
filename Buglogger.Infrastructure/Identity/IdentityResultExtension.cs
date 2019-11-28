﻿using Buglogger.Domain.DTO;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Buglogger.Infrastructure.Identity
{
    public static class IdentityResultExtension
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}