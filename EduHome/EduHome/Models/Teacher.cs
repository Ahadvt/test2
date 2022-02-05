using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "SurName is Required")]
        [StringLength(30)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Img is Required")]
        [StringLength(70)]
        public string Img { get; set; }
        [Required(ErrorMessage = "About is Required")]
        [StringLength(400)]
        public string AboutMe { get; set; }
        [Required(ErrorMessage = "Experience is Required")]
        [StringLength(100)]
        public string Experience { get; set; }
        [Required(ErrorMessage = "Degree is Required")]
        [StringLength(50)]
        public string Degree { get; set; }
        [Required(ErrorMessage = "PhoneNumber is Required")]
        [StringLength(50)]
        public string PhoneNUmber { get; set; }
        [Required]
        [StringLength(50)]
        public string Mail { get; set; }
        public List<SkillsTeacher> SkillsTeachers { get; set; }
        public List<SocialMediaTeacher> SocialMediaTeachers { get; set; }
        public List<PositionTeacher> PositionTeachers { get; set; }
        public List<FacultyTeacher> FacultyTeachers { get; set; }
        public List<HobbieTeacher> HobbieTeachers { get; set; }


    }
}
