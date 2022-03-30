using System.ComponentModel.DataAnnotations;

namespace Day9.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
        public virtual ICollection<DepartmentCourse> Departments { get; set; }
    
        public Department()
        {
            Departments = new HashSet<DepartmentCourse>();
        }
    }
}
