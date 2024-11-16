using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using S_API.Models;
using S_BLL.BL;
using S_BLL.Model;
using S_BLL.Model.DTO;
using S_BLL.Model.StatusCodes;

namespace S_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly AuthenticateUserBl AuthenticateUserBl;

        public LoginController(AuthenticateUserBl authenticateUserBl)
        {
            AuthenticateUserBl = authenticateUserBl;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Index(AuthData authData)
        {
            try
            {
                var (claims, identity) = await AuthenticateUserBl.AuthenticateUser(authData.Login, authData.Password);
                await HttpContext.SignInAsync(claims);

                return Ok(identity.ToString());
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Invalid data: {ex.ParamName}");
            }
        }
    }
}
