using Domain.DataTransfareObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Services.Class;
using ServerSide.Services.Interfaces;

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllShifts()
        {
            var response = await _shiftService.GetShifts();
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult>GetShift(int id)
        {
            var response = await _shiftService.GetShift(id);
            return response !=null ? Ok(response) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult>AddShift([FromBody]AddShiftDto req)
        {
            var response = await _shiftService.CreateShift(req);
            return response ? Ok():BadRequest();
        }
        [HttpPut("EndShift")]
        public async Task<IActionResult>  EndShift(EndShiftDto req)
        {
            var response = await _shiftService.SetShiftEndTime(req.ShiftId,req.X,req.Y);
            return response?Ok():BadRequest();
        }
        [HttpPut("ModfyStatus")]
        public async Task<IActionResult> ModfiyShiftStatus(ModfiyShiftStatusDto req)
        {
          var response = await   _shiftService.UpdateShiftStatus(req.ShiftId, req.NewStatus);
            return response ? Ok() : BadRequest();
        }
        [HttpGet("GetUserShift/{userid:int}")]
        public async Task<IActionResult> GetUserShifts(int userid)
        {
            var response = await _shiftService.GetUserShift(userid);
            return response is not null ? Ok(response) : NotFound();

        }
        [HttpGet("ShiftImage/{id}")]
        public async Task<IActionResult> ShiftImage(int id)
        {
            var model = await _shiftService.GetShift(id);
            var contentType = "image/jpeg";
            var stream = System.IO.File.OpenRead(model.ImagePath);
            return File(stream, contentType);
        }
    }
}
