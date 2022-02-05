using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Image is Required")]
        [StringLength(90)]
        public string Img { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(400)]
        public string Description { get; set; }
        [Required(ErrorMessage = "AboutCourse is Required")]
        [StringLength(400)]
        public string AboutCourse { get; set; }
        [Required(ErrorMessage = "How To Apply is Required")]
        [StringLength(400)]
        public string HowToApply { get; set; }
        [Required(ErrorMessage = "Serftication is Required")]
        [StringLength(400)]
        public string Serftication { get; set; }
        [Required(ErrorMessage = "Start is Required")]
     
        public DateTime Starts { get; set; }
        [Required(ErrorMessage = "duration is Required")]
        [StringLength(30)]
        public string Duration { get; set; }
        [Required(ErrorMessage = "class duration is Required")]
        [StringLength(30)]
        public string ClassDuration { get; set; }
        [Required(ErrorMessage = "Skill Level is Required")]
        [StringLength(30)]
        public string SkillLevel { get; set; }
        [Required(ErrorMessage = "Language is Required")]
        [StringLength(30)]
        public string Language { get; set; }
        [Required(ErrorMessage = "StudentCount is Required")]
      
        public int Student { get; set; }
        [Required(ErrorMessage = "Assesments is Required")]
        [StringLength(30)]

        public string Assesment { get; set; }
        [Required(ErrorMessage = "duration is Required")]
       
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CourseTag> CourseTags { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
