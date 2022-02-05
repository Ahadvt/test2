using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Skill
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "SkillName is Required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "SkillPoint is Required")]
        [StringLength(30)]
        public int Point { get; set; }
        public List<SkillsTeacher> SkillsTeachers { get; set; }
    }
}
