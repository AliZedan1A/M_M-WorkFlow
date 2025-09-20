
using Domain.Databases;

namespace Domain.Databases
{
    public enum VerfyStatus
    {
        Active=0,
        pending = 1,
        rejected = 2,
    }
    public class OtpCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime ExpireTime { get; set; } = DateTime.UtcNow.AddMinutes(10);
    }
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhonNumber { get; set; }
        public bool IsAdmin { get; set; } = false;
        public VerfyStatus IsVerfy { get; set; } = VerfyStatus.pending;
        public ICollection<shiftModel> Shifts { get; set; } = new List<shiftModel>();
        public ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
    }
}
