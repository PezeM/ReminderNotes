using System;

namespace ReminderNotes.Models
{
    public class Note
    {
        public int NoteId { get; set; }

        // User ID from AspNetUsers table
        public string OwnerId { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime ExpireTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
