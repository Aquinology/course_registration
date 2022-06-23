using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно.")]
        [MaxLength(200, ErrorMessage = "Длина этого поля не должна привышать 200 символов.")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-\,\.\&\(\)\:\;\?]*$", ErrorMessage = "Название курса может иметь латинские буквы от a до z, цифры от 0 до 9 и следующие символы: - . , & ( ) : ; ?, а также должно начинаться с большой буквы.")]
        //[Remote(action: "CourseNameUnique", controller: "Course")]
        public string Name { get; set; }
    }
}
