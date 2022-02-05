using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FullName  is Required")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required(ErrorMessage = " Img is Required")]
        [StringLength(70)]
        public string Img { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
