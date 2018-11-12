using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ReminderNotes.Models;
using ReminderNotes.Pages.Notes;
using ReminderNotes.Services;

namespace ReminderNotes.Pages
{
    public class NotesModel : NotesBasePageModel
    {
        public IList<Note> Notes { get; set; }

        public NotesModel(INotesData context,
            IAuthorizationService authorizationService,
            UserManager<ReminderNotesUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public async Task OnGetAsync()
        {
            var notes = Context.GetAll();

            var currentUserId = UserManager.GetUserId(User);

            // Get all notes created by this user
            notes = notes.Where(n => n.OwnerId == currentUserId);

            Notes = notes.ToList();
        }
    }
}