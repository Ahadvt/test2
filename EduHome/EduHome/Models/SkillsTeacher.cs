using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SkillsTeacher
    {
        public int Id { get; set; }
        public int SkillsId { get; set; }
        public int TeacherId { get; set; }
        public Skill Skill { get; set; }
        public Teacher Teacher { get; set; }
    }
}
