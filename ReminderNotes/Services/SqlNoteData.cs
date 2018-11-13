using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReminderNotes.Data;
using ReminderNotes.Models;

namespace ReminderNotes.Services
{
    public class SqlNoteData : INotesData
    {
        private ReminderNotesDbContext _context;

        public SqlNoteData(ReminderNotesDbContext context)
        {
            _context = context;
        }

        public void Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public Task<Note> FindAsync(int id)
        {
            return _context.Notes.FindAsync(id);
        }

        public Note Get(int id)
        {
            return _context.Notes.FirstOrDefault(n => n.NoteId == id);
        }

        public async Task<Note> GetAsync(int id)
        {
            return await _context.Notes.FirstOrDefaultAsync(n => n.NoteId == id);
        }

        public async Task<Note> GetAsNoTrackingAsync(int id)
        {
            return await _context.Notes.AsNoTracking().FirstOrDefaultAsync(n => n.NoteId == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes.OrderBy(n => n.CreateTime);
        }

        public void Remove(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public async Task RemoveAsync(Note note)
        {
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public Note Update(Note note)
        {
            _context.Attach(note).State = EntityState.Modified;
            _context.SaveChanges();
            return note;
        }
    }
}
