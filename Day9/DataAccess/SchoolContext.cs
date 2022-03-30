using Microsoft.EntityFrameworkCore;
using Day9.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Day9.DataAccess
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentCourse> DepartmentsCourse { get; set;}
        public virtual DbSet<StudentCourse> StudentsCourse { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Default"));
        //    //optionsBuilder.UseSqlServer(connectionString: ConfigurationManager.AppSettings["Default"]);
        //    optionsBuilder.UseSqlServer(connectionString: "Data Source=DESKTOP-P1A0AIP;Initial Catalog=Day9EFCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(nameof(StudentCourse.CourseId), nameof(StudentCourse.StudentId));
            modelBuilder.Entity<DepartmentCourse>()
                .HasKey(nameof(DepartmentCourse.DepartmentId), nameof(DepartmentCourse.CourseId));

        }
    }
}
