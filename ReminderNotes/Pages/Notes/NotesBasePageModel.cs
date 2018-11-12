using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReminderNotes.Data;
using ReminderNotes.Models;

namespace ReminderNotes.Pages.Notes
{
    public class NotesBasePageModel : PageModel
    {
        protected ReminderNotesDbContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<ReminderNotesUser> UserManager { get; }

        public NotesBasePageModel(ReminderNotesDbContext context,
            IAuthorizationService authorizationService,
            UserManager<ReminderNotesUser> userManager) : base()
        {
            Context = context;
            AuthorizationService = authorizationService;
            UserManager = userManager;
        }
    }
}
