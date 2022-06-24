using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CourseRegistration.Models
{
    public class RegistrationSheet
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно.")]
        [Remote(action: "StudentsInCourseUnique", controller: "RegistrationSheet", 
            AdditionalFields = nameof(CourseId), 
            ErrorMessage = "Этот студент уже проходит данный курс.")]
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
        public Course Course { get; set; }
    }
}
