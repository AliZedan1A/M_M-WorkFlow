using Domain.DataTransfareObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public async Task<IActionResult>AddShift([FromForm]AddShiftDto req)
        {
            var response = await _shiftService.CreateShift(req.UserId, req.File);
            return response ? Ok():BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> ModfiyShiftStatus(ModfiyShiftStatusDto req)
        {
          var response = await   _shiftService.UpdateShiftStatus(req.ShiftId, req.NewStatus);
            return response ? Ok() : BadRequest();
        }
    }
}
