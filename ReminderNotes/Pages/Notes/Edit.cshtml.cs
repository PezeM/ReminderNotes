using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReminderNotes.Authorization;
using ReminderNotes.Models;
using ReminderNotes.Services;

namespace ReminderNotes.Pages.Notes
{
    public class EditModel : NotesBasePageModel
    {
        [BindProperty]
        public Note Note { get; set; }

        public EditModel(INotesData context,
            IAuthorizationService authorizationService,
            UserManager<ReminderNotesUser> userManager) : base(context, authorizationService, userManager)
        {

        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Note = await Context.GetAsync(id);

            // Note to edit is not found
            if (Note == null)
                return NotFound();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, Note, NoteOperations.Update);

            if (!isAuthorized.Succeeded)
                return new ChallengeResult();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var note = await Context.GetAsNoTrackingAsync(id);

            if (note == null)
                return NotFound();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, note, NoteOperations.Update);

            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            // Keep the old create time
            Note.CreateTime = note.CreateTime;
            Note.OwnerId = note.OwnerId;
            Context.Update(Note);

            return RedirectToPage("./Notes");
        }
    }
}