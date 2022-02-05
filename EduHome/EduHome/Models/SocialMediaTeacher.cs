using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class SocialMediaTeacher
    {
        public int Id { get; set; }
        public int SociaslMediaId { get; set; }
        public int  TeacherId { get; set; }
        public SociaslMedia SociaslMedia { get; set; }
        public Teacher Teacher { get; set; }

    }
}
