using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost("login")] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Login(UserModel userModel)
        {
            try
            {
                var model = UserList.Users().FirstOrDefault(f=> f.UserName== userModel.UserName);
                if (model == null)
                {
                    return NotFound("User not found in database!!!");
                }
                var auth = UserList.Users().FirstOrDefault(u => u.UserName == userModel.UserName && u.Password == userModel.Password);

                if (auth == null)
                {
                    return BadRequest("You are not authorize to access app!!!");
                }
                return Ok(auth);
            }
            catch (Exception ex)
            {
                var error = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
                return BadRequest(error);
            }
        }
    }
}
