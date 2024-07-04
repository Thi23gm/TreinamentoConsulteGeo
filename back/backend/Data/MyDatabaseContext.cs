using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class MyDatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UserDB");
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
