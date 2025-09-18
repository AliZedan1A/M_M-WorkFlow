
using Domain.Databases;

namespace Domain.DataTransfareObject
{
    public class ChangeStatusDto
    {
        public int UserId { get; set; }
        public VerfyStatus NewStatus { get; set; }
    }
}
