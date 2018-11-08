using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReminderNotes.Models;

namespace ReminderNotes.Data
{
    public class ReminderNotesDbContext : IdentityDbContext<ReminderNotesUser>
    {
        public ReminderNotesDbContext(DbContextOptions<ReminderNotesDbContext> options) : base(options)
        {

        }
    }
}
