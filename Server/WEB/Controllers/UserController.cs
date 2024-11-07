using BLL.DTO;
using BLL.Inretfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBll I;
        public UserController(IUserBll i) 
        {
            this.I = i;
        }
        [HttpGet("GetAllUsers")]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            return Ok(I.get_all());
        }
        [HttpGet("GetUser")]
        public ActionResult<UserDTO> GetUser(string email, string login_password)
        {
            return Ok(I.get(email, login_password));
        }
        [HttpGet("GetAllTripToUser")]
        public ActionResult<List<TripDTO>> GetAllTripToUser(int code)
        {
            return Ok(I.get_all_trips(code));
        }
        [HttpPost("AddUser")]
        public ActionResult<bool> AddUser(UserDTO user)
        {
            return Ok(I.add(user));
        }
        [HttpPut("UpdateUser")]
        public ActionResult<bool> UpdateUser(UserDTO user)
        {
            return Ok(I.update(user));
        }
        [HttpDelete("DeleteUser")]
        public ActionResult<bool> DeleteUser(UserDTO user) 
        {
            return Ok(I.delete(user));
        }
    }
}
