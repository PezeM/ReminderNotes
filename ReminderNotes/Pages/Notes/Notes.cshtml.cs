using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReminderNotes.Authorization;
using ReminderNotes.Models;
using ReminderNotes.Pages.Notes;
using ReminderNotes.Services;

namespace ReminderNotes.Pages
{
    public class NotesModel : NotesBasePageModel
    {
        public IEnumerable<Note> Notes { get; set; }

        public NotesModel(INotesData context,
            IAuthorizationService authorizationService,
            UserManager<ReminderNotesUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public async Task OnGetAsync()
        {
            var notes = Context.GetAll();

            var currentUserId = UserManager.GetUserId(User);

            // Get all notes created by this user and order them. Expiring newest
            Notes = notes.Where(n => n.OwnerId == currentUserId).OrderBy(n => n.ExpireTime);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            //var note = await Context.FindAsync(id);

            var note = await Context.GetAsNoTrackingAsync(id);

            if (note == null)
                return NotFound();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, note, NoteOperations.Delete);

            if (!isAuthorized.Succeeded)
                return new ChallengeResult();

            await Context.RemoveAsync(note);

            return RedirectToPage();
        }
    }
}