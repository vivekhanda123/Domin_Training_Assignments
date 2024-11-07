using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [Authorize(Roles = "User")]
        //[AllowAnonymous]
        [HttpGet]
        public async Task<string> GetSampleData()
        {
            return "Sample data from Sample Controller";
        }
    }
}
