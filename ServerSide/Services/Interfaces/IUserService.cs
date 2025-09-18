using Domain.Databases;

namespace ServerSide.Services.Interfaces
{
    public interface IUserService
    {
       Task<bool> AddUser(string username, string phonnumber);
       Task<VerfyStatus?> GetUserStatus(int Id);
       Task<VerfyStatus?> GetUserStatusByPhonNumber(string phonnumber);
       Task<bool> ModfyVerfyStatus(int Id,VerfyStatus newstatus);
       Task<bool> EditPhonNumberById(int id,string newphonnumber);
       Task<List<UserModel>> GetUsers();
       Task<UserModel> GetUserById(int id);
    }
}
