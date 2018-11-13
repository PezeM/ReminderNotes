using System;
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
    public class CreateModel : NotesBasePageModel
    {
        [BindProperty]
        public Note Note { get; set; }

        public CreateModel(INotesData context,
            IAuthorizationService authorizationService,
            UserManager<ReminderNotesUser> userManager) : base(context, authorizationService, userManager)
        {
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Get note owner id
            Note.OwnerId = UserManager.GetUserId(User);
            Note.CreateTime = DateTime.Now;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, Note, NoteOperations.Create);

            if (!isAuthorized.Succeeded)
                return new ChallengeResult();

            Context.Add(Note);

            return RedirectToPage("./Notes");
        }
    }
}