
namespace Domain.Databases
{
    public enum VerfyStatus
    {
        Active=0,
        pending = 1,
        rejected = 2,
    }
    
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhonNumber { get; set; }
        public bool IsAdmin { get; set; } = false;
        public VerfyStatus IsVerfy { get; set; } = VerfyStatus.pending;
        public ICollection<shiftModel> Shifts { get; set; }
    }
}
