

using System.Text.Json.Serialization;

namespace Domain.Databases
{
    public enum ShiftStatus
    {
        Acepted = 0,
        pending = 1,
        referd = 2
    }
    public class ApiResponse<T>
    {
        public bool IsSucceeded { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }
    }
  
    public class shiftModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public UserModel User { get; set; }
        public  DateTime  StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImagePath { get; set; }
        public ShiftStatus ShiftStatus { get; set; } = ShiftStatus.pending;
        public double Latitude { get; set; }   // X
        public double Longitude { get; set; }  // Y

    }
}
