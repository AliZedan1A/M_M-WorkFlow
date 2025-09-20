using Domain.Databases;
using Domain.DataTransfareObject;

namespace ServerSide.Services.Interfaces
{
    public interface IShiftService
    {
        Task<shiftModel> GetShift(int id);
        Task<List<shiftModel>> GetShifts();
        Task<List<shiftModel>> GetUserShift(int userId);
        Task<bool> CreateShift(AddShiftDto req);
        Task<bool> DeleteShift(int id);
        Task<bool> UpdateShiftStatus(int id , ShiftStatus newshift);
        Task<bool> SetShiftEndTime(int id ,double x ,double y);
   
    }
}
