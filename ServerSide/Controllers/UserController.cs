using Domain.DataTransfareObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Services.Interfaces;

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userservice)
        {
            _userService = userservice;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDto req)
        {
            var response = await _userService.AddUser(req.UserName, req.PhonNunber);
            return response ? Ok():BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> ChangeStatus(ChangeStatusDto req)
        {
           var response = await   _userService.ModfyVerfyStatus(req.UserId,req.NewStatus);
            return response ? Ok():BadRequest();
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult>GetUserById(int id)
        {
            var response = await _userService.GetUserById(id);
            return response is not null ? Ok(response) : NotFound();    
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            return response is not null ? Ok(response) : BadRequest();
        }


    }
}
