using System.Collections.Generic;
using ReminderNotes.Models;

namespace ReminderNotes.Services
{
    public interface INotesData
    {
        IEnumerable<Note> GetAll();
        Note Get(int id);
        void Add(Note note);
        Note Remove(Note note);
        Note Update(Note note);
    }
}
