using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam.Models
{
    public class Join
    {
        [Key]
        [Required]
        public int JoinId { get; set; }

        // bring foriegn keys for all users and weddings
        public int UserId { get; set; }
        public User parti { get; set; }
        public int ActivitymId { get; set; }
        public Activitym JoinOf { get; set; }


    }
}