using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter student name")]
        [StringLength(30, ErrorMessage = "Please enter maximum 30 characters")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Please enter only letters")]
        public string StudentName { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter department name")]
        [StringLength(3, MinimumLength = 2, ErrorMessage = "Please enter maximum 3 characters")]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Please enter capital letters")]
        public string Department { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter student email address")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter student CGPA")]
        [RegularExpression(@"^[0-4]([.][0-9]{1,2})?$", ErrorMessage = "Please enter valid Number")]
        [Range(0, 4, ErrorMessage = "Please enter only between 0 and 4")]
        public double CGPA { get; set; }
    }
}
