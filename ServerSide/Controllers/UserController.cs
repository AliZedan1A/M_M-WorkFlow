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
        [HttpGet("GetUserStatusbyphonnumber/{phonnumber}")]
        public async Task<IActionResult> GetUserStatusByPhonNumber(string phonnumber)
        {
            var response = await _userService.GetUserStatusByPhonNumber(phonnumber);
            return response !=null ? Ok(response) : BadRequest();
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
        [HttpGet("GetUserByPhonNumber/{phonnumber}")]
        public async Task<IActionResult> GetUserByPhonNumber(string phonnumber)
        {
            var response = await _userService.GetUserByPhonNumber(phonnumber);
            return response is not null ? Ok(response) : BadRequest();
        }
        [HttpPost("SendVerfyCode")]
        public async Task<IActionResult> SendVerfyCode(SendVerfyCodeDto req)
        {
            var response = await _userService.SendOtpCode(req.PhonNumber,req.ContryCode,req.UserName);
            return response  ? Ok() : BadRequest();
        }
        [HttpPost("CheckVerfyCode")]
        public async Task<IActionResult> CheckVerfyCode(CheckVerfyCode req)
        {
            var response = await _userService.VerfyOtpCode(req.Code, req.PhonNumber);
            return response ? Ok() : BadRequest();
        }


    }
}
