using System;
using Microsoft.AspNetCore.Identity;

namespace ReminderNotes.Models
{
    public class ReminderNotesUser : IdentityUser
    {
        /// <summary>
        /// Gets or sets nickname for this user.
        /// </summary>
        [PersonalData]
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets date of birth for this user.
        /// </summary>
        [PersonalData]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets number of notes created by this user.
        /// </summary>
        [PersonalData]
        public int NotesCreated { get; set; }
    }
}
