using Buglogger.Api.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Buglogger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public string[] Get()
        {
            return new[] { "value1", "value2" };
        }
    }
}