using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CourseRegistration.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно.")]
        [MaxLength(100, ErrorMessage = "Длина этого поля не должна привышать 100 символов.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Имя студента может иметь только латинские символы от a до z и должно начинаться с большой буквы.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле обязательно.")]
        [Range(1, 10000, ErrorMessage = "Значение этого поля не должно выходить из следующего диапазона: 1 - 10000.")]
        [Remote(action: "StudentIdUnique", controller: "Student", ErrorMessage = "Студент с таким Id уже существует.")]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Это поле обязательно.")]
        [MaxLength(10, ErrorMessage = "Длина этого поля не должна привышать 10 символов.")]
        [RegularExpression(@"^([A-Z]{2,3})\-([0-9]{3,4})$", ErrorMessage = "Название группы должно содржать 2-3 символа латинского алфавита, затем тире и 3-4 цифры от 0 до 9.")]
        public string Group { get; set; }
    }
}
