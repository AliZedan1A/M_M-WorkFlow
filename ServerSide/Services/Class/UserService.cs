using Domain.Databases;
using Microsoft.EntityFrameworkCore;
using ServerSide.db;
using ServerSide.Services.Interfaces;

namespace ServerSide.Services.Class
{
    public class UserService : IUserService
    {
        private readonly MMDbContext _dbcontext;
        public UserService(MMDbContext context)
        {
            _dbcontext = context;


        }
        public async Task<bool> AddUser(string username, string phonnumber)
        {
            if(string.IsNullOrEmpty(phonnumber)||string.IsNullOrEmpty(username))
            {
                return false;
            }
            var newmodel = new UserModel()
            {
                IsAdmin = false,
                Name = username,
                PhonNumber = phonnumber,
                
            };
            try
            {
                _dbcontext.Users.Add(newmodel);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
           
        private async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<bool> EditPhonNumberById(int id, string newphonnumber)
        {
            var modeltoedit = await _dbcontext.Users.SingleOrDefaultAsync(x => x.Id == id);
            if (modeltoedit != null)
            {
                try
                {
                    modeltoedit.PhonNumber = newphonnumber;
                    await SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
               
            }
            else
            {
                return false;
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var foundedmodel = await _dbcontext.Users.SingleOrDefaultAsync(x => x.Id == id);
            if(foundedmodel != null)
            {
                return foundedmodel;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _dbcontext.Users.ToListAsync();
            return users;
        }

        public async Task<VerfyStatus?> GetUserStatus(int Id)
        {
           var user = await _dbcontext.Users.SingleOrDefaultAsync(_ => _.Id == Id);
           if(user !=null)
            {
                return user.IsVerfy;
            }
            else
            {
                return null;
            }
        }

        public async Task<VerfyStatus?> GetUserStatusByPhonNumber(string phonnumber)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(_ => _.PhonNumber == phonnumber);
            if (user != null)
            {
                return user.IsVerfy;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> ModfyVerfyStatus(int Id, VerfyStatus newstatus)
        {
            var user = await _dbcontext.Users.SingleOrDefaultAsync(_ => _.Id == Id);
            if (user != null)
            {

                try
                {
                    user.IsVerfy = newstatus;
                    await SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            
            }
            else
            {
                return false;
            }
        }
    }
}
