using Domain.Databases;
using Microsoft.EntityFrameworkCore;
using ServerSide.db;
using ServerSide.Services.Interfaces;

namespace ServerSide.Services.Class
{
    public class ShiftService : IShiftService
    {
        private readonly MMDbContext _dbcontext;
        private readonly DateTimeService _timeservice;
        private readonly AttachmentService _attachmentservice;
        private readonly IUserService _userservice;
        public ShiftService( IUserService userservice, MMDbContext context , DateTimeService dateTimeService ,AttachmentService attachmentService)
        {
            _timeservice = dateTimeService; 
            _dbcontext = context;
            _userservice = userservice;
             _attachmentservice = attachmentService;
        }
        public async Task<bool> CreateShift(int id, IFormFile file)
        {
            var user = await _userservice.GetUserById(id);
            if (user is null) return false;
            var image = await _attachmentservice.ConvertFileToPath(file);
            if (string.IsNullOrEmpty(image)) return false;
            var newmodel = new shiftModel()
            {
                StartTime = _timeservice.IsraelNow(),
                ImagePath = image,
                UserId = id
                
            };
            try
            {
                _dbcontext.Shifts.Add(newmodel);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { 
            return false;
            }
           
        }
        private async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<bool> DeleteShift(int id)
        {
            var shift =await  GetShift(id);
            if (shift is null) return false;

            try
            {
                _dbcontext.Shifts.Remove(shift);
                await SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<shiftModel> GetShift(int id)
        {
            var model = await _dbcontext.Shifts.SingleOrDefaultAsync(x => x.Id == id);
            if (model is null) return null;
            return model;
        }

        public async Task<List<shiftModel>> GetShifts()
        {
            return await _dbcontext.Shifts.ToListAsync();
        }

        public async Task<List<shiftModel>> GetUserShift(int userId)
        {
            
            var userincluded = await _dbcontext.Users.Include(x => x.Shifts).SingleOrDefaultAsync(x => x.Id == userId);
            if (userincluded is null) return null;
            return userincluded.Shifts.ToList();
        }

        public async Task<bool> UpdateShiftStatus(int id, ShiftStatus newshift)
        {
            var shift = await GetShift(id);
            if (shift is null) return false;
            try
            {
                shift.ShiftStatus = newshift;
                await SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
          
            
        }

        public async Task<bool> SetShiftEndTime(int id)
        {
            var model = await GetShift(id);
            if (model is null) return false;
            try
            {
                model.EndTime = _timeservice.IsraelNow();
                await SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
             }


        }
    }
}
