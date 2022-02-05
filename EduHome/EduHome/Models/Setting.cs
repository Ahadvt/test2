using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Logo is Required")]
        [StringLength(100)]
        public string Logo { get; set; }
       
        [StringLength(100)]
        public string SearchIcon { get; set; }
        [Required(ErrorMessage = "InfoTitle is Required")]
        [StringLength(100)]
        public string InfoTitle { get; set; }
       
        [StringLength(300)]
        public string InfoDescriptionTop { get; set; }
       
        [StringLength(300)]
        public string InfoDescriptionBottom { get; set; }
     
        [StringLength(100)]
        public string InfoImg { get; set; }
        [StringLength(200)]
        public string InfoLink { get; set; }

        
        [StringLength(100)]
        public string FooterLogo { get; set; }
        [Required(ErrorMessage = "FooterDesciription is Required")]
        [StringLength(250)]
        public string FooterDedcription { get; set; }
     
        [StringLength(50)]
        public string PhoneNumber1 { get; set; }
 
        [StringLength(50)]
        public string PhoneNumber2 { get; set; }
        
        [StringLength(100)]
        public string Mail { get; set; }
        
        [StringLength(50)]
        public string WebAddress { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        public List<SociamMediaSetting> SociamMediaSettings { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        [NotMapped]

        public IFormFile FootorlogoFile { get; set; }
        [NotMapped]

        public IFormFile InfoImgFile { get; set; }



    }
}
