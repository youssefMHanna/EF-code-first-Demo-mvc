using System.ComponentModel.DataAnnotations;

namespace Day9.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public virtual ICollection<DepartmentCourse> Departments { get; set; }
        public virtual ICollection<StudentCourse> Students { get; set; }
        public Course()
        {
            Departments = new HashSet<DepartmentCourse>();
            Students = new HashSet<StudentCourse>();
        }
    }
}
