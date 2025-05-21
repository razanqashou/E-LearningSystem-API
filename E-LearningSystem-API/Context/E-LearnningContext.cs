using E_LearningSystem_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_LearningSystem_API.Context
{

    public class E_LearnningContext : DbContext
    {

       

        public DbSet<Users> Users { get; set; }

        public E_LearnningContext(DbContextOptions options) : base(options)
        {
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        }

    }
}
