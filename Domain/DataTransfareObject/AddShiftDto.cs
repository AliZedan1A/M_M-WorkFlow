

using Microsoft.AspNetCore.Http;

namespace Domain.DataTransfareObject
{
    public class AddShiftDto
    {
        public int UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
