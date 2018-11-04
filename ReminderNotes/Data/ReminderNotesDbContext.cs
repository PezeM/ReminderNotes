using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReminderNotes.Data
{
    public class ReminderNotesDbContext : IdentityDbContext
    {
        public ReminderNotesDbContext(DbContextOptions<ReminderNotesDbContext> options) : base(options)
        {

        }
    }
}
