using ArishProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArishProject.Context
{
    public class ArishContext : DbContext
    {
        public ArishContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
