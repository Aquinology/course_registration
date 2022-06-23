using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CourseRegistration.Models
{
    public class RegistrationSheet
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно.")]
        //[Remote(action: "StudentsInCourseUnique", controller: "StudentCourses",
        //    AdditionalFields = nameof(CourseId), ErrorMessage = "Product name already exists under the chosen category. Please enter a different product name.")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        [ValidateNever]
        public Student Student { get; set; }
        [Required(ErrorMessage = "Это поле обязательно.")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        [ValidateNever]
        //[Remote(action: "StudentIdUnique", controller: "Students")]
        public Course Course { get; set; }
    }
}
