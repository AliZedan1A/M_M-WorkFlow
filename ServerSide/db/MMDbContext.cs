using Domain.Databases;
using Microsoft.EntityFrameworkCore;

namespace ServerSide.db
{
    public class MMDbContext:DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<shiftModel> Shifts { get; set; }
        public DbSet<OtpCode> OtpCodes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
               "server=localhost;database=mmworkflowdb;user=root;password=ali12300;",
               new MySqlServerVersion(new Version(8, 0, 36)));
        }
    }
}
