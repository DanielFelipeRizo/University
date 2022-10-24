using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.models.dataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options): base(options)
        {

        }
        //TO DO: agregar tablas bd
        public DbSet<User>? Users { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<index> index { get; set; }
    }
}
