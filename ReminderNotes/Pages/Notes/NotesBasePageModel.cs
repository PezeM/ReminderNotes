using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReminderNotes.Models;
using ReminderNotes.Services;

namespace ReminderNotes.Pages.Notes
{
    public class NotesBasePageModel : PageModel
    {
        protected INotesData Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<ReminderNotesUser> UserManager { get; }

        public NotesBasePageModel(INotesData context,
            IAuthorizationService authorizationService,
            UserManager<ReminderNotesUser> userManager) : base()
        {
            Context = context;
            AuthorizationService = authorizationService;
            UserManager = userManager;
        }
    }
}
