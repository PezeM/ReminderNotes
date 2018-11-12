using System;
using System.ComponentModel.DataAnnotations;

namespace ReminderNotes.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        // User ID from AspNetUsers table
        public string OwnerId { get; set; }

        public DateTime CreateTime { get; set; }

        [Required]
        [Display(Name = "Note expire time")]
        public DateTime ExpireTime { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}
