using Microsoft.EntityFrameworkCore;
using UniversitySystem.Entities;
using UniversitySystem.Entities.Enums;

namespace UniversitySystem.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          /*  modelBuilder.Entity<Course>()
                .HasOne(course => course.Exams)
                .WithOne(exam => exam.Course)
                .HasForeignKey<Exam>(exam => exam.CourseId);
          */
            modelBuilder.Entity<Role>().HasData(
                    new Role()
                    {
                        RoleId = 1,
                        RoleName = "Admin",
                        Key = ERole.admin.ToString(),
                    },
                      new Role()
                      {
                          RoleId = 2,
                          RoleName = "User",
                          Key = ERole.user.ToString(),
                      },
                        new Role()
                        {
                            RoleId = 3,
                            RoleName = "SuperAdmin",
                            Key = ERole.superadmin.ToString(),
                        }
                    );
            modelBuilder.Entity<User>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Teacher>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Student>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Question>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Group>().HasQueryFilter(m => !m.IsDeleted);
            modelBuilder.Entity<Course>().HasQueryFilter(m => !m.IsDeleted);
        }
    }
}