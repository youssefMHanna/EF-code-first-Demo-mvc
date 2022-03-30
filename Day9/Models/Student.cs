using System.ComponentModel.DataAnnotations;

namespace Day9.Models
{
    public class Student
    {

        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]

        public string Name { get; set;}
        public virtual ICollection<StudentCourse> Courses { get; set; }
        
        public Student()
        {
            Courses = new HashSet<StudentCourse>();
        }

    }
}
