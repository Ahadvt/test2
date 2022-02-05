using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name  is Required")]
        [StringLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is Required")]
        [StringLength(25)]
        public string SurnameName { get; set; }
        [Required(ErrorMessage = " Img is Required")]
        [StringLength(150)]
        public string Img { get; set; }
        public List<SpeakerPosition> SpeakerPositions { get; set; }
        public List<EventSpeaker> EventSpeakers { get; set; }
    }
}
