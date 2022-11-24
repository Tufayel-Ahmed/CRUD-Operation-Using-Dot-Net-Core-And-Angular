using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class StudentDbContext: DbContext
    {
        public StudentDbContext(DbContextOptions options): base(options){}

        public DbSet<Student> Students { get; set; }
    }
}
