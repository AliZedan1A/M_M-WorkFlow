using Domain.Databases;
using Microsoft.EntityFrameworkCore;
using ServerSide.db;
using ServerSide.Services.Interfaces;
using System.Text.RegularExpressions;

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
            var IsPhonNumberAvailble = !await _dbcontext.Users.AnyAsync(x=>x.PhonNumber == phonnumber);
            if (IsPhonNumberAvailble) { 
            
            
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
            else
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

        public async Task<UserModel> GetUserByPhonNumber(string phonnumber)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.PhonNumber == phonnumber);
            if (user != null)
            {
                return user;
            }
            return null;

        }

        public async Task<bool> SendOtpCode(string phonnumber , string contrycode, string username)
        {
            var userreq = await GetUserByPhonNumber(phonnumber);
            if (userreq is null)
            {
                try
                {
                    _dbcontext.Users.Add(new UserModel()
                    {
                        Name = username,
                        PhonNumber = phonnumber,

                    });
                    await SaveChangesAsync();
                }
                catch
                {
                    return false;
                }
            
            }
            string pattern = @"^(?:0)?(\d{2})(\d{3})(\d{4})$";
            string replacement = "$1-$2-$3";

            string result = Regex.Replace(phonnumber, pattern, replacement);

            if (!Regex.IsMatch(phonnumber, @"^\d{10}$"))
            {
                return false;
            }
            try
            {
                Random random = new Random();
                var code = random.Next(1000, 9999);
                var user = await GetUserByPhonNumber(phonnumber);

                //sendcode
                if (user != null)
                {
                    _dbcontext.OtpCodes.Add(new()
                    {
                        Code = code.ToString(),
                        UserId = user.Id

                    });
                    await SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> VerfyOtpCode(string code, string phonnumber)
        {
            var user =  await GetUserByPhonNumber(phonnumber);
            if (user != null) {
                bool IsCorrect = await _dbcontext.OtpCodes.Where(x => x.UserId == user.Id)
                    .AnyAsync(x=>x.Code == code && x.ExpireTime> DateTime.UtcNow );
                return IsCorrect;
            }
            else
            {
                return false;
            }
        }
    }
}
