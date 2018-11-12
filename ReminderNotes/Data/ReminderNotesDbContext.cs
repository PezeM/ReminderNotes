using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReminderNotes.Models;

namespace ReminderNotes.Data
{
    public class ReminderNotesDbContext : IdentityDbContext<ReminderNotesUser>
    {
        public DbSet<Note> Notes { get; set; }

        public ReminderNotesDbContext(DbContextOptions<ReminderNotesDbContext> options) : base(options)
        {

        }
    }
}
