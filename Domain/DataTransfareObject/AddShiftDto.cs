

using Microsoft.AspNetCore.Http;

namespace Domain.DataTransfareObject
{
    public class AddShiftDto
    {
        public int UserId { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Extention { get; set; }
    }
}
