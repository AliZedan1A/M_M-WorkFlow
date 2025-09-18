using Domain.Databases;

namespace Domain.DataTransfareObject
{
    public class ModfiyShiftStatusDto
    {
        public int ShiftId { get; set; }
        public  ShiftStatus NewStatus { get; set; }
    }
}
