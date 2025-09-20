using Domain.Databases;
using Domain.DataTransfareObject;

namespace WorkFlowClient.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<bool>> AddUserAsync(AddUserDto dto);
        Task<ApiResponse<VerfyStatus>> GetUserStatusByPhonNumberAsync(string phonNumber);
        Task<ApiResponse<bool>> ChangeStatusAsync(ChangeStatusDto dto);
        Task<ApiResponse<UserModel>> GetUserByIdAsync(int id);
        Task<ApiResponse<List<UserModel>>> GetUsersAsync();
        Task<ApiResponse<UserModel>> GetUserByPhonNumber(string phonNumber);
        Task<ApiResponse<bool>> CheckCode(CheckVerfyCode dto);
        Task<ApiResponse<bool>> SendVerfyCode(SendVerfyCodeDto dto);

    }
}
