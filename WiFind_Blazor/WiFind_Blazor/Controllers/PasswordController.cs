using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WiFind_Blazor.Data;

namespace WiFind_Blazor.Controllers
{
    [AllowAnonymous]
    [ApiController()]
    [Route("api/controller")]
    public class PasswordController : ControllerBase
    {
        private readonly WiFindDbContext _wiFindDbContext;
        public PasswordController(WiFindDbContext wiFindDbContext)
        {
            _wiFindDbContext = wiFindDbContext;
        }

        [HttpPost, Route("")] // url: https://localhost:67657/api/password
        public async Task<IActionResult> PostPassword([FromBody] PostPasswordCommand request)
        {
            _wiFindDbContext.Locations.Add(new Models.Location
            {
                LocationName = request.Location,
                WiFiName = request.WiFiName,
                Password = request.Password,
                City = request.Where
            });

            _wiFindDbContext.SaveChanges();
            return Ok(); //200
        }
    }
}