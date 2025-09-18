

namespace Domain.Databases
{
    public enum ShiftStatus
    {
        Acepted = 0,
        pending = 1,
        referd = 2
    }
    public class shiftModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public  DateTime  StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImagePath { get; set; }
        public ShiftStatus ShiftStatus { get; set; } = ShiftStatus.pending;

    }
}
