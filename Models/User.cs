using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid email format")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
       [RegularExpression (@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$" , ErrorMessage = "The passowrd must be one char and numbers")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Confirm must be 8 characters or longer!")]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string Confirm { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // Navigation property for related models 
        public List<Activitym> ActivityPlanned { get; set; }
        public List<Join> joined { get; set; }
        public int ActivitymId { get; internal set; }
    }
}