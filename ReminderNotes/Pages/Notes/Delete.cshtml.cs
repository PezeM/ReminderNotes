using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReminderNotes.Authorization;
using ReminderNotes.Models;
using ReminderNotes.Services;

namespace ReminderNotes.Pages.Notes
{
    public class DeleteModel : NotesBasePageModel
    {
        [BindProperty]
        public Note Note { get; set; }

        public DeleteModel(INotesData context,
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

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, Note, NoteOperations.Delete);

            if (!isAuthorized.Succeeded)
                return new ChallengeResult();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Note = await Context.FindAsync(id);

            var note = await Context.GetAsNoTrackingAsync(id);

            if (note == null)
                return NotFound();

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, note, NoteOperations.Delete);

            if (!isAuthorized.Succeeded)
                return new ChallengeResult();

            await Context.RemoveAsync(Note);

            return RedirectToPage("./Notes");
        }
    }
}