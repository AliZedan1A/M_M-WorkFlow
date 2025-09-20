using Domain.Databases;
using Domain.DataTransfareObject;


namespace WorkFlowClient.Services.Interfaces
{
    public interface IShiftService
    {
        Task<ApiResponse<List<shiftModel>>> GetAllShiftsAsync();
        Task<ApiResponse<shiftModel>> GetShiftAsync(int id);
        Task<ApiResponse<bool>> AddShiftAsync(int userid, FileResult file);
        Task<ApiResponse<bool>> EndShiftAsync(EndShiftDto dto);
        Task<ApiResponse<bool>> ModfiyStatusAsync(ModfiyShiftStatusDto dto);
        Task<ApiResponse<List<shiftModel>>> GetUserShiftsAsync(int userId);
    }
}
