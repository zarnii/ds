using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S_API.Models;
using S_BLL.BL;
using S_BLL.Model.DTO;
using S_BLL.Model.StatusCodes;

namespace S_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JoinController : Controller
    {
        private readonly JoinToServerBl JoinToServerBl;

        public JoinController(JoinToServerBl joinToServerBll) 
        { 
            JoinToServerBl = joinToServerBll;
        }

        
        [HttpGet("[action]")]
        public async Task<ActionResult<ServerPolitics>> GetPolitics()
        {
            var serverIsOpen = JoinToServerBl.CheckServerIsOpen();

            if (serverIsOpen)
            {
                return Ok(await JoinToServerBl.GetServerPolitics());
            }

            return StatusCode(StatusCodes.Status503ServiceUnavailable);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> CreateRequestToConnect(RequestToJoinData requestData)
        {
            if (!JoinToServerBl.CheckServerIsOpen())
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            var responseToJoin = await JoinToServerBl.AcceptJoinRequest(new RequestToJoinDto() 
            { 
                AcceptPolitics = requestData.AcceptPolitics,
                Login = requestData.Login,
                Username = requestData.Username,
                UserPassword = requestData.UserPassword,
                ServerPassword = requestData.ServerPassword
            });

            if (responseToJoin.ValidateDataStatusCode == ValidateUserDataStatusCode.Success)
            {
                return Ok();
            }

            return BadRequest(responseToJoin.Message);
        }
    }
}
