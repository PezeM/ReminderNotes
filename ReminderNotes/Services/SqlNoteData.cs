using System.Collections.Generic;
using System.Linq;
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

        public Note Get(int id)
        {
            return _context.Notes.FirstOrDefault(r => r.NoteId == id);
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes.OrderBy(n => n.CreateTime);
        }

        public Note Remove(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return note;
        }

        public Note Update(Note note)
        {
            _context.Attach(note).State = EntityState.Modified;
            _context.SaveChanges();
            return note;
        }
    }
}
