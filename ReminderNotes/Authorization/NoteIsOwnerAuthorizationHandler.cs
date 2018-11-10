using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using ReminderNotes.Models;

namespace ReminderNotes.Authorization
{
    public class NoteIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, Note>
    {
        private UserManager<ReminderNotesUser> _userManager;

        public NoteIsOwnerAuthorizationHandler(UserManager<ReminderNotesUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Note resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if (resource.OwnerId == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
