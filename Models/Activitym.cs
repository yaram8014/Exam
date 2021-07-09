using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Activitym
    {
        [Key]
        [Required]
        public int ActivitymId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title must be 3 characters or longer!")]
        [Display(Name ="Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Time")]
        public DateTime Time { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date")]

       // [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]  
        public DateTime Date { get; set; }

        [Required]
        [Display(Name ="Duration")]
        public int Duration { get; set; }

        [Required]
        public string Hm {get;set;}
        [Required]
        [MinLength(5, ErrorMessage = "Description must be 5 characters or longer!")]
        [Display(Name ="Description")]
        public string Dis { get; set; }

        // Foreign Key for UserId has to match the property name in User class
        public int UserId { get; set; }
        public User Plane { get; set; }
        public List<Join> par { get; set; }
    }
}